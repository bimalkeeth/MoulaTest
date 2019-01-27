using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BIRuleManager.interfaces;
using CommonContracts;
using CommonContracts.Resources;
using Grpc.Core;
using Grpc.Core.Utils;
using Moula.CustomerService;

namespace MoulaCustomers.CustomerServiceImpl
{
    public class CustomerServiceProcess:CustomerService.CustomerServiceBase
    {
        private readonly IAddressRuleManager _addressRuleManager;
        private readonly IContactRuleManager _contactRuleManager;
        private readonly ICustomerRuleManager _customerRuleManager;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CustomerServiceProcess(IAddressRuleManager addressRuleManager,
            IContactRuleManager contactRuleManager,ICustomerRuleManager customerRuleManager)
        {
            _addressRuleManager = addressRuleManager;
            _contactRuleManager = contactRuleManager;
            _customerRuleManager = customerRuleManager;
        }
        /// <summary>-----------------------------------------
        /// Create Customer based on data passed by client
        /// </summary>----------------------------------------
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="RpcException"></exception>
        public  override async Task<CreateCustomerResponse>CreateCustomer(CustomerRequest request, ServerCallContext context)
        {
            try
            {
                DateTime date;
                var dateOfBirth= DateTime.TryParse(request.DateOfBirth, out date);
                if (!dateOfBirth)
                {
                    throw new ValidationException(BusinessRuleResource.Error_InDateOfBirth);
                }

                var customerAddress = new List<CustomerAddressBo>();
                foreach (var customerAdd in request.CustomerAddress)
                {
                    if(customerAdd.Address==null) continue;
                    customerAddress.Add(new CustomerAddressBo
                    {
                        IsPrimary = customerAdd.IsPrimary,
                        Address =new AddressBo
                        {
                            Street = customerAdd.Address.Street,
                            StateId = customerAdd.Address.StateId,
                            Suburb = customerAdd.Address.Suburb,
                            Country = customerAdd.Address.Country,
                            Street2 = customerAdd.Address.Street2,
                            AddressTypeId = customerAdd.Address.AddressTypeId
                        }
                    });
                }

                var customerContacts = new List<CustomerContactsBo>();
                foreach (var customerCon in request.CustomerContacts)
                {
                    if(customerCon.Contact==null) continue;
                    customerContacts.Add(new CustomerContactsBo
                    {
                        IsPrimary = customerCon.IsPrimary,
                        Contact = new ContactsBo
                        {
                            Contact = customerCon.Contact.Contact,
                            ContactTypeId = customerCon.Contact.ContactTypeId
                        }
                    });
                }
                
                var customer = new CustomerBo
                {
                  LastName = request.LastName,
                  FirstName = request.FirstName,
                  DateOfBirth =Convert.ToDateTime(request.DateOfBirth),
                  CustomerAddress = customerAddress,
                  CustomerContacts = customerContacts
                };
               var result= _customerRuleManager.CreateCustomer(customer);
               await Task.Delay(1000);
               return new CreateCustomerResponse{Successful = result};
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new RpcException(new Status(StatusCode.Aborted,e.Message));
            }
        }
        /// <summary>
        /// Get Top Customers
        /// </summary>
        /// <param name="request"></param>
        /// <param name="responseStream"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="RpcException"></exception>
        public  override async Task GetTopCustomers(CustomerDetailRequest request, IServerStreamWriter<CustomerDetailResponse> responseStream, ServerCallContext context)
        {
            try
            {
               if (request.TopCustomers == 0)
               {
                    throw new ValidationException(BusinessRuleResource.Error_InTopCount);
               }
               var customerList= _customerRuleManager.GetTopCustomers(request.TopCustomers).ToArray();
               
               if (customerList.Any())
               {
                   foreach (var customer in customerList)
                   {
                       await responseStream.WriteAsync(new CustomerDetailResponse
                       {
                           Id = customer.Id,
                           Street = customer.Street,
                           Suburb = customer.Suburb,
                           Contact = customer.Contact,
                           Country = customer.Country,
                           Street2 = customer.Street2,
                           StateId = customer.StateId,
                           FullName = customer.FullName,
                           LastName = customer.LastName,
                           AddressId = customer.AddressId,
                           ContactId = customer.ContactId,
                           FirstName = customer.FirstName,
                           StateName = customer.StateName,
                           CustomerCode = customer.CustomerCode,
                           DateOfBirth = customer.DateOfBirth.ToShortDateString(),
                           AddressTypeId = customer.AddressTypeId,
                           ContactTypeId = customer.ContactTypeId,
                           CustomerAddressId = customer.CustomerAddressId,
                           CustomerContactId = customer.CustomerContactId
                       });
                   }
               }
               else
               {
                   await responseStream.WriteAllAsync(new CustomerDetailResponse[] { });
               }
            }
            catch (Exception e)
            {
               log.Error(e.Message);
               throw new RpcException(new Status(StatusCode.Aborted,e.Message));
            }
        }
        
        /// <summary>
        /// Get all States
        /// </summary>
        /// <param name="request"></param>
        /// <param name="responseStream"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="RpcException"></exception>
        public override async Task GetAllStates(StateRequest request, IServerStreamWriter<StateResponse> responseStream, ServerCallContext context)
        {
            try
            {
               var states= _addressRuleManager.GetAllStates();
               foreach (var state in states)
               {
                   await responseStream.WriteAsync(new StateResponse
                   {
                     Id = state.Id,
                     StateAbbr = state.StateAbbr,
                     StateName = state.StateName
                   });
               }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new RpcException(new Status(StatusCode.Aborted,e.Message));
            }
        }
        /// <summary>
        /// Get All Address Type
        /// </summary>
        /// <param name="request"></param>
        /// <param name="responseStream"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="RpcException"></exception>
        public override async Task GetAllAddressTypes(AddressTypeRequest request, IServerStreamWriter<AddressTypeResponse> responseStream, ServerCallContext context)
        {
            try
            {
                var addressTypes= _addressRuleManager.GetAllAddressType();
                foreach (var addressType in addressTypes)
                {
                    await responseStream.WriteAsync(new AddressTypeResponse
                    {
                        Id = addressType.Id,
                        AddressTypeAbbr = addressType.AddressTypeAbbr,
                        AddressTypeName = addressType.AddressTypeName
                    });
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new RpcException(new Status(StatusCode.Aborted,e.Message));
            }
        }
        /// <summary>
        /// Get All Contact Types
        /// </summary>
        /// <param name="request"></param>
        /// <param name="responseStream"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="RpcException"></exception>
        public override async Task GetAllContactTypes(ContactTypeRequest request, IServerStreamWriter<ContactTypeResponse> responseStream, ServerCallContext context)
        {
            try
            {
                var contactTypes= _contactRuleManager.GetAllContactTypes();
                foreach (var contactType in contactTypes)
                {
                    await responseStream.WriteAsync(new ContactTypeResponse
                    {
                        Id = contactType.Id,
                        ContactTypeAbbr = contactType.ContactTypeAbbr,
                        ContactTypeName = contactType.ContactTypeName
                    });
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw new RpcException(new Status(StatusCode.Aborted,e.Message));
            }
        }
    }
}
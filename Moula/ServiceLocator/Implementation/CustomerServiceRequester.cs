
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moula.CustomerService;
using MoulaClient.Contract;
using ServiceLocator.Interfaces;

namespace ServiceLocator
{
    public class CustomerServiceRequester:ICustomerServiceRequester
    {
        protected readonly CustomerService.CustomerServiceClient _customerServiceClient;

        public CustomerServiceRequester(CustomerService.CustomerServiceClient customerServiceClient)
        {
            _customerServiceClient = customerServiceClient;
        }
       
        public bool CreateCustomer(CustomerRequestVM request)
        {
            try
            {
                    var customerRequest = new CustomerRequest
                    {
                        Id = request.Id,
                        LastName = request.LastName,
                        FirstName = request.FirstName,
                        CustomerCode = request.CustomerCode,
                        DateOfBirth = request.DateOfBirth,
                    };
                    foreach (var customerAdd in request.CustomerAddress)
                    {
                        customerRequest.CustomerAddress.Add(new CustomerAddressRequest
                        {
                            Id = customerAdd.Id,
                            AddressId = customerAdd.AddressId,
                            IsPrimary = customerAdd.IsPrimary,
                            CustomerId = customerAdd.CustomerId,
                            Address = new AddressRequest
                            {
                                Id = customerAdd.Address.Id,
                                Street = customerAdd.Address.Street,
                                Suburb = customerAdd.Address.Suburb,
                                Country = customerAdd.Address.Country,
                                Street2 = customerAdd.Address.Street2,
                                StateId = customerAdd.Address.StateId,
                                AddressTypeId = customerAdd.Address.AddressTypeId
                            }
                        });
                    }
                    foreach (var customerCon in request.CustomerContacts)
                    {
                        customerRequest.CustomerContacts.Add(new CustomerContactsRequest
                        {
                            Id = customerCon.Id,
                            ContactId = customerCon.ContactId,
                            IsPrimary = customerCon.IsPrimary,
                            CustomerId = customerCon.CustomerId,
                            Contact = new ContactRequest
                            {
                                Id = customerCon.Contact.Id,
                                Contact = customerCon.Contact.Contact,
                                ContactTypeId = customerCon.Contact.ContactTypeId
                            }
                        });
                    }
                 var response=_customerServiceClient.CreateCustomer(customerRequest);
                 return response.Successful;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<CustomerDetailVM>> GetTopCustomers(int topCount)
        {
            var customerList=new List<CustomerDetailVM>();
            using (var call = _customerServiceClient.GetTopCustomers(new CustomerDetailRequest {TopCustomers = topCount}))
            {
                var responseReaderTask = Task.Run(async () =>
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        var data = call.ResponseStream.Current;
                        customerList.Add(new CustomerDetailVM
                        {
                            Id = data.Id,
                            Street = data.Street,
                            Suburb = data.Suburb,
                            Contact = data.Contact,
                            Country = data.Country,
                            Street2 = data.Street2,
                            StateId = data.StateId,
                            LastName = data.LastName,
                            AddressId = data.AddressId,
                            ContactId = data.ContactId,
                            FirstName = data.FirstName,
                            FullName = data.FullName,
                            StateName = data.StateName,
                            CustomerCode = data.CustomerCode,
                            DateOfBirth = data.DateOfBirth,
                            AddressTypeId = data.AddressTypeId,
                            ContactTypeId = data.ContactTypeId,
                            CustomerAddressId = data.CustomerAddressId,
                            CustomerContactId = data.CustomerContactId
                        });
                    }
                });
                await responseReaderTask;
            }
            return customerList;
        }
        
    }
}
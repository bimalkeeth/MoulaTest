using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoulaClient.Contract;
using ServiceLocator.Interfaces;

namespace MoulaClient.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerApiController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly ICustomerServiceRequester _requester;

        public CustomerApiController(IMapper mapper,ICustomerServiceRequester requester)
        {
            _mapper = mapper;
            _requester = requester;
        }
        [HttpPut("[action]")]
        public bool CreateCustomer([FromBody]CustomerRequestVM request)
        {
          return  _requester.CreateCustomer(request);
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<CustomerDetailVM>>GetTopCustomer(int topCustomer)
        {
            return await _requester.GetTopCustomers(topCustomer);
        }
    }
}
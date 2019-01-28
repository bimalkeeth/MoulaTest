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
        public IActionResult CreateCustomer([FromBody]CustomerRequestVM request)
        {
            return NotFound("");
        } 
    }
}
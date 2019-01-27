using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoulaUi.Contract;

namespace MoulaUi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TriangularApiController : Controller
    {
        
        protected readonly IMapper _mapper;

        public TriangularApiController(IMapper mapper)
        {
           
            _mapper = mapper;
        }
        [HttpPut("[action]")]
        public IActionResult ProcessData([FromBody]RequestVM request)
        {
            return null;
        } 
    }
}
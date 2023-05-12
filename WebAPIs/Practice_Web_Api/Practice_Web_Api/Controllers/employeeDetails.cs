using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practice_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeeDetails : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

        }
    }
}

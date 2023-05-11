
using Microsoft.AspNetCore.Mvc;

namespace Console_app.Controllers
{

    [ApiController]
    [Route("test/[action]")]
   
    public class TestController: Controller
    {
        public string method1()
        {
            return "I'm Method 1 from Test page";
        }
        public string method2()
        {
            return "I'm Method 2 from Test page";
        }
    }
}

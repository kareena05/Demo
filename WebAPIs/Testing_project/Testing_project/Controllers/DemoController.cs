using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testing_project.Services;

namespace Testing_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly Singleclass singleclass;
        private readonly ITestSingeltonServicecs testSingletonService;
        private readonly ITestScopedService testScopedService;
        private readonly ITestTransientService testTransientService;

        public DemoController(Singleclass singleclass,ITestSingeltonServicecs testSingletonService,ITestScopedService testScopedService,ITestTransientService testTransientService)
        {
            this.singleclass = singleclass;
            this.testSingletonService = testSingletonService;
            this.testScopedService = testScopedService;
            this.testTransientService = testTransientService;
        }

        [HttpGet]
        public async Task<ActionResult> GetData()
        {
            testScopedService.test = 10;
            testTransientService.test = 10;
            singleclass.test = 10;
            return Ok(testSingletonService.GetData());
        }
    }
}

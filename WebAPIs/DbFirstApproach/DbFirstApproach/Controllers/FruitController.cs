using DbFirstApproach.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitController : ControllerBase
    {
        private readonly DemodbContext _context;
        public FruitController(DemodbContext context) {

            _context = context;
        }
        //get
        [HttpGet]
        public async Task<ActionResult<List<FruitTbl>>> get()
        {
            return Ok(await _context.FruitTbls.ToListAsync());
        }
        
    }
}

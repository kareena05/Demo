using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Controllers
{
    [Route("api/SuperHeros")]
    
    [ApiController]
    public class ValuesController : Controller
    {
        private static List<SuperHero>  heros = new List<SuperHero>
            {   
                new SuperHero { Id = 1,Name="Spider man",place="New York",Age=34},
                new SuperHero { Id = 2,Name="Iron man",place="New Jersy",Age=25},

            };
        private readonly DataContext context;

        public ValuesController(DataContext context)
        {
            this.context = context;
        }
        //get all the data 
        [HttpGet]
        public async Task<List<SuperHero>> GetAll()
        {
            return Ok(await context.SuperHeroes.ToListAsync());
           //return Ok(heros);
        }

        //Get the particular hero
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await context.SuperHeroes.FindAsync( id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found!");
            }
            return Ok(hero);
        }

        //update a hero
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero requested)
        {
            var dbhero = await context.SuperHeroes.FindAsync(requested.Id);
            if (dbhero == null)
            {
                return BadRequest("Hero Not Found!");
            }
            dbhero.Name = requested.Name;
            dbhero.place = requested.place;
            dbhero.Age = requested.Age;
            await context.SaveChangesAsync();
            return Ok(await context.SuperHeroes.ToListAsync());
        }


        //post the data
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddNewHero(SuperHero hero)
        {
            context.SuperHeroes.Add(hero);
            await context.SaveChangesAsync();
            return Ok(await context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var dbhero = await context.SuperHeroes.FindAsync(id);
            if (dbhero == null)
            {
                return BadRequest("Hero Not Found!");
            }
            

            context.SuperHeroes.Remove(dbhero);
            await context.SaveChangesAsync();
            return Ok(await context.SuperHeroes.ToListAsync());
        }
    }
}

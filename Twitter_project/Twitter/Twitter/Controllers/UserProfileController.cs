using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        
        private readonly DataContext _context;

        public UserProfileController(DataContext context)
        {
            _context = context;
        }

    }
}

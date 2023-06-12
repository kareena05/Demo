using DBfirstAgain.Models;
using DBfirstAgain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBfirstAgain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("UserDetails")]
        public async Task<IActionResult> UserDetails(int id)
        {
            return Ok(await _userRepository.UserDetails(id));
        }
    }
}

using MeraKhata.Data;
using MeraKhata.Model;
using MeraKhata.Models;
using MeraKhata.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeraKhata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {

            _userService = userService;
           

        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserModel model)
        {
            var data = await _userService.CreateUser(model);
            return Ok(data);
        }
        [HttpPost("AddUserBackup")]
        public async Task<IActionResult> AddUserBackup(BackUpModel model)
        {
            var data = await _userService.AddUserBackup(model);
            return Ok(data);
        }

        [HttpGet("GetBackup")]
        public async Task<IActionResult> GetBackup(string email)
        {
            var data = await _userService.GetBackup(email);   
            return Ok(data);
        }
    }
}

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
        public readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {

            _userRepository = userRepository;
           

        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserModel model)
        {
            var username = await _userRepository.CheckUserExists(model.Email);
            if(username > 0)
            {
                return Ok(new ResponseModel { Data= username,Status = true, Message = "User exists." });
            }
            else
            {
                var data = await _userRepository.CreateUser(model);
                if (data <= 0)
                {
                    return Ok(new ResponseModel {  Data= data, Status = false, Message = "User not add"});
                }
                
                else
                {
                return Ok(new ResponseModel { Data = data, Status = true, Message = "User added." });                
                }
            }
        }
        [HttpPost("AddUserBackup")]
        public async Task<IActionResult> AddUserBackup(BackUpModel model)
        {
            var data = await _userRepository.AddUserBackup(model);
            if (data <= 0)
            {
                return Ok(new ResponseModel { Data = data, Status = false, Message = "User backup not add" });
            }
            return Ok(new ResponseModel { Data = data, Status = true, Message = "User added." });
        }

        [HttpGet("GetBackup")]
        public async Task<IActionResult> GetBackup(string email)
        {
            var data = await _userRepository.GetBackup(email);
            if(data == null)
            {
                return Ok(new ResponseModel { Status = true, Data = data,Message = "No data found."  });
            }
            return Ok(new ResponseModel { Status = true, Data = data , Message = "Data found."});
        }
    }
}

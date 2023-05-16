using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

       public readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {

            _userRepository = userRepository;
            // _userRepository = _userRepository == null ? new UserRepository() : _userRepository;

        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _userRepository.GetUser());
        }


        //registration/ SignUp
        [HttpPost("AddUser")]
        public async Task<IActionResult>AddNewUser(SaveUserModel  saveUser)
        {
            return Ok(await _userRepository.AddNewUser(saveUser));
        }

        //Login
        [HttpGet("Login")]
        public async Task<ActionResult> Login(string emailorusername,string password)
        {
            return Ok(_userRepository.LoginUser(emailorusername,password));
        }

        //delete the account
        [HttpDelete("DeleteAccount")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            //deleting the user means simply inactivating the user
            return Ok(await _userRepository.DeleteUser(id));
        }



    }
}

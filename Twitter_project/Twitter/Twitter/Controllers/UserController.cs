using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Entities;
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
            return Ok(await _userRepository.LoginUser(emailorusername,password));
        }


        //change password
        [HttpPut("Change password")]
        public async Task<ActionResult> Change_Password(int id,string oldPassword,string newPassword)
        {
            return Ok( await _userRepository.Change_Password(id,oldPassword,newPassword));
        }


        //delete the account
        [HttpDelete("DeleteAccount")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            //deleting the user means simply inactivating the user
            return Ok(await _userRepository.DeleteUser(id));
        }



        ////////////////////Follow Activities//////////////////////
        [HttpPost("Follow")]
        public async Task<ActionResult> Follow(int myid, int friend_id)
        {
            //deleting the user means simply inactivating the user
            return Ok(await _userRepository.Follow(myid,friend_id));
        }

        //Show my follow requests
        [HttpGet("ShowFollowRequests")]
        public async Task<ActionResult> ShowFollowRequests(int myid)
        {
            //deleting the user means simply inactivating the user
            return Ok(await _userRepository.ShowFollowRequests(myid));
        }


        //Accept the follow Request
        [HttpGet("AcceptFollowRequests")]
        public async Task<ActionResult> AcceptFollowRequests(int myid,int requestid)
        {
            //deleting the user means simply inactivating the user
            return Ok(await _userRepository.AcceptFollowRequests(myid,requestid));
        }
        //Reject the follow Request
        [HttpDelete("RejectFollowRequests")]
        public async Task<ActionResult> RejectFollowRequests(int myid, int requestid)
        {
            //deleting the user means simply inactivating the user
            return Ok(await _userRepository.RejectFollowRequests(myid, requestid));
        }

        [HttpGet("ShowMyFollowers")]
        public async Task<IActionResult> ShowMyFollowers(int myid)
        {
                return Ok(await _userRepository.ShowMyFollowers(myid));
        }
        [HttpDelete("Unfollow")]
        public async Task<ActionResult> Unfollow(int myid, int followerid)
        {
            //deleting the user means simply inactivating the user
            return Ok(await _userRepository.RejectFollowRequests(myid, followerid));
        }



    }
}

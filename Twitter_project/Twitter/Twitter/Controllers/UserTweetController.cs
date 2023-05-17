using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Twitter.Repository;
using Twitter.Models;

namespace Twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTweetController : ControllerBase
    {
        public readonly IUserTweetRepository _usertweetRepository;

        public UserTweetController(IUserTweetRepository usertweetRepository)
        {
            _usertweetRepository = usertweetRepository;

        }

        [HttpGet("GetAllTweets")]
        public async Task<IActionResult> GetAllTweets()
        {
            return Ok( await _usertweetRepository.GetAllTweets());
        }

        //Post A new tweet
        [HttpPost("PostNewTweet")]
        public async Task<IActionResult> PostNewTweet(int id, SaveTweetModel model)
        {
            return Ok(await _usertweetRepository.PostNewTweet(id,model));
        }

        [HttpPut("EditTweet")]
        public async Task<IActionResult> EditTweet(int userid, int tweetid,SaveTweetModel model)
        {
            return Ok(await _usertweetRepository.EditTweet(userid,tweetid, model));
        }
    }
}

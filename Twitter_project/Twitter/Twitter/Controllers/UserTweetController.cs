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

        //Get my all tweets(deleted tweets will not be shown)
        [HttpGet("GetMyAllTweets")]
        public async Task<IActionResult> GetMyAllTweets(int id)
        {
            return Ok(await _usertweetRepository.GetMyAllTweets(id));
        }


        //Post A new tweet
        [HttpPost("PostNewTweet")]
        public async Task<IActionResult> PostNewTweet(int userid, SaveTweetModel model)
        {
            return Ok(await _usertweetRepository.PostNewTweet(userid,model));
        }

        //edits a portion of tweet entity that's why patch
        [HttpPatch("EditTweet")]
        public async Task<IActionResult> EditTweet(int userid, int tweetid,SaveTweetModel model)
        {
            return Ok(await _usertweetRepository.EditTweet(userid,tweetid, model));
        }


        //we are not deleting anything that's why Put
        [HttpPut("DeleteTweet")]
        public async Task<IActionResult> DeleteTweet(int userid, int tweetid)
        {
            return Ok(await _usertweetRepository.DeleteTweet(userid, tweetid));
        }


        //keep my tweet in draft
        [HttpPost("DraftTweet")]
        public async Task<IActionResult> DraftTweet(int userid, string tweet_text)
        {
            return Ok(await _usertweetRepository.DraftTweet(userid,tweet_text ));
        }

        //show my drafts
        [HttpGet("ShowMyDrafts")]
        public async Task<IActionResult> ShowMyDrafts(int userid)
        {
            return Ok(await _usertweetRepository.ShowMyDrafts(userid));
        }

        //post a tweet from draft
        [HttpPost("PostMyDraft")]
        public async Task<IActionResult> PostMyDraft(int userid, int draftid)
        {
            return Ok(await _usertweetRepository.PostMyDraft(userid,draftid));
        }

        //edit tweet in draft
        [HttpPatch("EditMyDraft")]
        public async Task<IActionResult> EditDraft(int userid, int draftid, string tweet_text)
        {
            return Ok(await _usertweetRepository.EditDraft(userid, draftid,tweet_text));
        }

        //delete a tweet from draft
        [HttpDelete("DeleteMyDraft")]
        public async Task<IActionResult> DeleteMyDraft(int userid, int draftid)
        {
            return Ok(await _usertweetRepository.DeleteMyDraft(userid,draftid));
        }
    }

}

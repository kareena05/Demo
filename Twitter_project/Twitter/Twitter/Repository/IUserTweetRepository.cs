using Microsoft.AspNetCore.Mvc;
using Twitter.Migrations;
using Twitter.Models;

namespace Twitter.Repository
{
    public interface IUserTweetRepository
    {
        Task<List<Tweet_entity>> GetAllTweets();
        Task<int> PostNewTweet(int id, SaveTweetModel model);
        Task<string> EditTweet(int userid, int tweetid, SaveTweetModel model);

    }
}





using Microsoft.AspNetCore.Mvc;
using Twitter.Entities;
using Twitter.Migrations;
using Twitter.Models;

namespace Twitter.Repository
{
    public interface IUserTweetRepository
    {
        Task<List<Tweet_entity>> GetAllTweets();
        Task<int> PostNewTweet(int userid, SaveTweetModel model);
        Task<string> EditTweet(int userid, int tweetid, SaveTweetModel model);
        Task<List<Tweet_entity>> GetMyAllTweets(int id);
        Task<string> DeleteTweet(int userid, int tweetid);
        Task<string> DraftTweet(int userid, string tweet_text);
        Task<List<Draft_entity>> ShowMyDrafts(int userid);
        Task<string> PostMyDraft(int userid, int draftid);
        Task<string> EditDraft(int userid, int draftid, string tweet_text);
        Task<string> DeleteMyDraft(int userid, int draftid);

    }
}





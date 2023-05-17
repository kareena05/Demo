using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Repository
{
    public class UserTweetRepository : IUserTweetRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UserTweetRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _context = dataContext;
        }
        public virtual async Task<List<Tweet_entity>> GetAllTweets()
        {
            return await _context.Tweets.ToListAsync();
            
        }
        public virtual async Task<int> PostNewTweet(int id,SaveTweetModel model)
        {
            var myUser = _context.Users.Where(a => a.id == id && a.is_active==true).FirstOrDefault();
            if (myUser != null)
            {
                
                Tweet_entity tweet_tbl = _mapper.Map<Tweet_entity>(model);
                tweet_tbl.UserId = id;
                tweet_tbl.created_on=DateTime.Now;
                await _context.AddAsync(tweet_tbl);
                await _context.SaveChangesAsync();
                return tweet_tbl.Id;
            }
            else
            {
                //user not found
                return 0;
            }
        }

        //show my all tweets (particular user's own tweets)

        //edit the tweet
        public virtual async Task<string> EditTweet(int userid, int tweetid, SaveTweetModel model)
        {
            var myTweet = _context.Tweets.Where(a=> a.Id == tweetid && a.UserId== userid).FirstOrDefault();
            
            if (myTweet != null) {
                
                 myTweet.tweet_text=model.tweet_text;
                myTweet.modified_on = DateTime.Now;

                _context.Update(myTweet);
                await _context.SaveChangesAsync();
                
                return "Edited successfully !";
            }
            else
            {
                return "Failed to Update the tweet!";
            }

        }
            
    }
}

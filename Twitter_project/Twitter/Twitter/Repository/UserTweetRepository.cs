﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Entities;
using Twitter.Migrations;
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
        //Get all the user's tweet

        public async Task<List<Tweet_entity>> GetAllTweets()
        {
            return await _context.Tweets.ToListAsync();

        }

        //post a new tweet
        public async Task<int> PostNewTweet(int userid, SaveTweetModel model)
        {
            var myUser = _context.Users.Where(a => a.id == userid && a.is_active == true).FirstOrDefault();
            if (myUser != null)
            {

                Tweet_entity tweet_tbl = _mapper.Map<Tweet_entity>(model);
                tweet_tbl.UserId = userid;
                tweet_tbl.created_on = DateTime.Now;

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
        public async Task<List<Tweet_entity>> GetMyAllTweets(int id)
        {
            var myList = await _context.Tweets.Where(a => a.UserId == id && a.is_deleted == false).ToListAsync();
            if (myList != null)
            {
                return myList;
            }
            else
            {
                return new List<Tweet_entity>();
            }
        }



        //edit the tweet
        public async Task<string> EditTweet(int userid, int tweetid, SaveTweetModel model)
        {
            var myTweet = _context.Tweets.Where(a => a.Id == tweetid && a.UserId == userid).FirstOrDefault();

            if (myTweet != null)
            {

                myTweet.tweet_text = model.tweet_text;
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
        //keep my tweet in draft
        public async Task<string> DraftTweet(int userid, string tweet_text)
        {
            var myDraft = new Draft_entity();
            myDraft.UserId = userid; ;
            myDraft.Tweet_text = tweet_text;
            await _context.AddAsync(myDraft);
            await _context.SaveChangesAsync();
            return "Draft Saved Successfully";

        }

        //show my drafts
        public async Task<List<Draft_entity>> ShowMyDrafts(int userid)
        {
            var myDrafts = _context.Drafts.Where(a => a.UserId == userid);
            if (myDrafts != null)
                return myDrafts.ToList();
            else
                return new List<Draft_entity>();
        }


        public async Task<string> EditDraft(int userid, int draftid, string tweet_text)
        {
            var myDraft = _context.Drafts.
                Where(a => a.Id == draftid && a.UserId == userid).FirstOrDefault();
            if (myDraft != null)
            {
                myDraft.Tweet_text = tweet_text;
                _context.Update(myDraft);
                await _context.SaveChangesAsync();
                return "Content of Draft Edited Successfully!";
            }
            else
            {
                return "Failed to Edit draft";
            }
        }

        //delete my draft or remove tweet from draft
        public async Task<string> DeleteMyDraft(int userid, int draftid)
        {
            var myDraft = _context.Drafts.
                Where(a => a.Id == draftid && a.UserId == userid).FirstOrDefault();

            _context.Remove(myDraft);
            await _context.SaveChangesAsync();
            return "Draft deleted"!;
        }

        //post my draft

        public async Task<string> PostMyDraft(int userid, int draftid)
        {

            var myDraft = _context.Drafts.Where(a => a.Id == draftid && a.UserId == userid).FirstOrDefault();

            Tweet_entity myNewTweet = new Tweet_entity();
            myNewTweet.UserId = userid;
            myNewTweet.created_on = DateTime.Now;
            myNewTweet.tweet_text = myDraft.Tweet_text;

            _context.Update(myNewTweet);
            await _context.SaveChangesAsync();
            DeleteMyDraft(userid, draftid);
            return "Draft is now Shared on your profile tweets";
        }

        //Delete the tweet  -> simply set is_deleted = true

        public async Task<string> DeleteTweet(int userid, int tweetid)
        {
            var myTweet = _context.Tweets.Where(a => a.Id == tweetid && a.UserId == userid).FirstOrDefault();
            if (myTweet != null)
            {
                myTweet.is_deleted = true;
                _context.Update(myTweet);
                await _context.SaveChangesAsync();
                return "Tweet Deleted Successfully!";
            }
            else
            {
                return "Failed to delete the tweet";
            }
        }

        //Like section
        public async Task<string> LikeTweet(int myid, int tweetid)
        {

            var tweet_not_deleted = _context.Tweets.Where(a => a.Id == tweetid && a.is_deleted == false).FirstOrDefault();
            if (tweet_not_deleted != null)
            {

                var if_liked = _context.like_Tweet.Where(a => a.tweet_id == tweetid && a.user_id == myid).FirstOrDefault();
                if (if_liked == null)
                {
                    var like = new Like_Tweet_entity();
                    like.tweet_id = tweetid;
                    like.user_id = myid;
                    like.created_on = DateTime.Now;

                    await _context.AddAsync(like);
                    await _context.SaveChangesAsync();
                    return "Liked 👍";
                }
                else
                {
                    return "";
                }

            }
            else
            {
                return "Unable to Like";
            }

        }

        public async Task<string> UnlikeTweet(int myid, int tweetid)
        {
            var like = _context.like_Tweet.
                Where(a => a.tweet_id == tweetid && a.user_id == myid).FirstOrDefault();

            if (like != null)
            {
                _context.Remove(like);
                await _context.SaveChangesAsync();
                return "Like removed";
            }
            return "Failed to UnLike.. Please Check your connection ";
        }

        public async Task<string> Comment(int myid, int tweetid, string comment_text)
        {


            var comment = new Comment_entity();
            comment.tweet_id = tweetid;
            comment.comment_text = comment_text;
            comment.user_id = myid;
            comment.created_on = DateTime.Now;
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();

            return "Comment added";

        }
        public async Task<string> EditComment(int myid, int commentid, string comment_text)
        {
            var comment = _context.comments.
                Where(a => a.user_id == myid && a.Id == commentid).FirstOrDefault();
            if (comment != null)
            {
                comment.comment_text = comment_text;
                comment.modified_on = DateTime.Now;
                _context.Update(comment);
                await _context.SaveChangesAsync();
                return "Comment Edited Successfully";
            }
            else
            {
                return "You can't edit someone else's comment";
            }
        }

        public async Task<string> DeleteComment(int myid, int commentid)
        {
            var comment = _context.comments.
                Where(a => a.user_id == myid && a.Id == commentid).FirstOrDefault();
            if (comment != null)
            {

                _context.Remove(comment);
                await _context.SaveChangesAsync();
                return "Comment Deleted Successfully";
            }
            else
            {
                return "You can't delete someone else's comment";
            }
        }

        public async Task<string> LikeComment(int myid, int commentid)
        {

            var comment_not_deleted = _context.comments.Where(a => a.Id == commentid).FirstOrDefault();
            if (comment_not_deleted != null)
            {

                //var if_liked = _context.comments.Where(a => a.Id == commentid && a.user_id == myid).FirstOrDefault();
                //if (if_liked == null)
                //{
                //    var like = new Like_Tweet_entity();
                //    like.tweet_id = tweetid;
                //    like.user_id = myid;
                //    like.created_on = DateTime.Now;

                //    await _context.AddAsync(like);
                //    await _context.SaveChangesAsync();
                //    return "Liked 👍";
                //}
                //else
                //{
                //    return "";
                //}

                //}
                //else
                //{
                //    return "Unable to Like";
                //}
                return "yes";
            }
            return "yes";
        }
    }
}

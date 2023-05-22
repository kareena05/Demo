using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Xml.Linq;
using Twitter.Data;
using Twitter.Entities;
using Twitter.Models;
using Twitter.Repository;

namespace Twitter
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UserRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _context = dataContext;
        }
        public virtual async Task<IList<User_entity>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }


        //Registration
        public virtual async Task<int> AddNewUser(SaveUserModel model)
        {

            var CheckUser = _context.Users.Where(a => a.email == model.email).FirstOrDefault();
            //if user does not already exists-> allow registration
            if (CheckUser == null)
            {
                User_entity user_tbl = _mapper.Map<User_entity>(model);
                //user_tbl.firstname = model.firstname;
                //user_tbl.lastname = model.lastname;
                //user_tbl.username = model.username;
                //user_tbl.email = model.email;
                //user_tbl.password = model.password;
                //user_tbl.birthdate = model.birthdate;
                //user_tbl.created_on = DateTime.Now;

                await _context.Users.AddAsync(user_tbl);
                await _context.SaveChangesAsync();
                return user_tbl.id;
            }
            else
            //if user email already exist but is not active ,means account is deleted so allow him to signup again

            {
                if (CheckUser.is_active == false)
                {
                    User_entity user_tbl = _mapper.Map<User_entity>(model);

                    await _context.Users.AddAsync(user_tbl);
                    await _context.SaveChangesAsync();
                    return user_tbl.id;
                }
                else
                {

                    //user already exists
                    return 0;
                }
            }
        }


        public virtual async Task<string> DeleteUser(int id)
        {
            var myUser = _context.Users.FirstOrDefault(a => a.id == id);
            //if user exists then inactivate it
            if (myUser != null)
            {
                myUser.is_active = false;
                _context.Update(myUser);
                await _context.SaveChangesAsync();
                var a = "Deleted your account from Twitter";
                return a;
            }
            else
            {
                return "User Does Not Exist";
            }
        }

        public virtual async Task<string> LoginUser(string emailorusername, string password)
        {
            var myUser = _context.Users.Where(a => a.email == emailorusername || a.username == emailorusername && a.is_active == true).FirstOrDefault();
            if (myUser != null)
            {
                if (myUser.password == password)
                {
                    return "Login Successfull !";
                }
                else
                {
                    return "Invalid Password";
                }
            }
            else
            {
                return "User Not Found";
            }
        }
        public virtual async Task<string> Change_Password(int id, string oldPassword, string newPassword)
        {

            var myUser = _context.Users.Where(a => a.id == id).FirstOrDefault();
            if (myUser != null)
            {


                if (myUser.password == oldPassword)
                {

                    myUser.password = newPassword;
                    _context.Update(myUser);
                    await _context.SaveChangesAsync();
                    return "Password changed successfully";
                }
                else
                {
                    return "Password does not match!";
                }
            }
            else
            {
                return "User not found";

            }



        }
        
        public async Task<string> Follow(int myid,int friend_id)
        {
           var friend = _context.Users.Where(a => a.id == friend_id && a.is_active==true).FirstOrDefault();
            // if user exist
            if (friend != null) {
                var follow = new Follower_entity();
               var check_acc_type = _context.UserProfile.Where(a => a.UserId==friend.id).FirstOrDefault();
                follow.follower_Id = myid;
                follow.user_id = friend_id;
                follow.created_on = DateTime.Now;
                //IF Profile is  added in profile table
                if (check_acc_type != null)
                {    
                    //if account is public
                    if (check_acc_type.account_type == true)
                    {
                        follow.is_approved = true;
                        await _context.AddAsync(follow);
                        await _context.SaveChangesAsync();
                        return $"You are now Following {friend.firstname}";
                    }
                    // if account is private 
                    else
                    {
                        follow.is_approved = false;
                        await _context.AddAsync(follow);
                        await _context.SaveChangesAsync();
                        return $"Follow Request Sent to {friend.firstname}";
                    }
                   
                }
                //IF Profile is not yet added in profile table
                //hence we assume the user has by default public account
                else
                {
                    follow.is_approved = true;
                    await _context.AddAsync(follow);
                    await _context.SaveChangesAsync();
                    return $"You are Now Following {friend.firstname}";
                }
            }
            //user does not exist
            else
            {
                return "Sorry ! This User Account is not available";
            }
        }


        public async Task<IList<string>> ShowFollowRequests(int myid)
        {
            var Requests = new List<string>();

            var myfollowers = _context.followers.Where( a => a.user_id==myid && a.is_approved==false).ToList();
            
            foreach(var myfollower in myfollowers)
            {
                var OneRequest = _context.Users.Where(a => a.id == myfollower.follower_Id).FirstOrDefault();    
                Requests.Add(OneRequest.firstname);

            }
            return Requests;

        }
        public async Task<string> AcceptFollowRequests(int myid, int requestid)
        {
            var request = _context.followers.Where(a => a.user_id==myid && a.follower_Id==requestid ).FirstOrDefault();
            if (request != null)
            {
                request.is_approved = true;
                _context.Update(request);
                await _context.SaveChangesAsync();  
                return "Follow Request Accepted";
            }
            else
            {
                return "Failed to Accept the request";
            }
        }


        //Reject the Request
        public async Task<string> RejectFollowRequests(int myid, int requestid)
        {
            var request = _context.followers.Where(a => a.user_id == myid && a.follower_Id == requestid).FirstOrDefault();
            if (request != null)
            {

                _context.Remove(request);
                await _context.SaveChangesAsync();
                return "Follow Request Rejected !!";
            }
            else
            {
                return "Failed to Reject the request";
            }
        }



        //Show my followers
        public async Task<IList<Follower_entity>> ShowMyFollowers(int myid)
        {
            var myfollowers =  _context.followers.Where(a => a.user_id==myid && a.is_approved==true).ToList();
            if (myfollowers.Count == 0)
            {
                return new List<Follower_entity>();
            }
            else
            {
                return myfollowers;
                
            }
            
            
            
        }

        //Unfollow 
        public async Task<string> Unfollow(int myid, int followerid)
        {
            var myfollower =  _context.followers
                .Where(a=> a.user_id== followerid && a.follower_Id== myid)
                .FirstOrDefault();
            if(myfollower != null)
            {
                _context.Remove(myfollower);
                await _context.SaveChangesAsync();
                return "Unfollwed";
            }
            else
            {
                return "Failed to unfollow";
            }
        }

        public async Task<IEnumerable<TweetsOfMyFollowers>> TweetsofFollowers(int myid)
        {

            var users = _context.Users.ToList();
            var followers = _context.followers.
                Where(a => a.user_id == myid).ToList();

            var tweets = _context.Tweets.ToList();
            var commentss = _context.comments.ToList();


            dynamic result = from f in followers
                             join t in tweets
                             on f.follower_Id equals t.UserId
                             where t.is_deleted == false
                             join u in users
                             on t.UserId equals u.id
                             select new TweetsOfMyFollowers
                             {
                                 Username = u.username,
                                 firstname = u.firstname,
                                 posted_on = t.created_on,
                                 tweet_text = t.tweet_text,
                                 likes = _context.like_Tweet.
                                 Where(a => a.tweet_id == t.Id).Count(),
                                 comments = from c in commentss
                                            join us in users
                                            on c.user_id equals us.id
                                            where c.tweet_id == t.Id
                                            select new Comments_and_Users
                                            {
                                                username = us.username,
                                                firstname = us.firstname,
                                                lastname = us.lastname,
                                                comment_text = c.comment_text,
                                                posted_on = c.created_on,
                                            },

                                 comments_count = _context.comments.
                                 Where(a => a.tweet_id == t.Id).Count()

                             };

            return result;
        }
        //public async Task<IEnumerable<TweetsOfMyFollowers>> TweetsofFollowers(int myid)
        //{

        //    var users = _context.Users.ToList();
        //    var followers = _context.followers.
        //        Where(a => a.user_id == myid).ToList();

        //    var tweets = _context.Tweets.ToList();
        //    var commentss = _context.comments.ToList();


        //    dynamic result = from f in followers
        //                     join t in tweets
        //                     on f.follower_Id equals t.UserId
        //                     where t.is_deleted == false
        //                     join u in users
        //                     on t.UserId equals u.id
        //                     select new TweetsOfMyFollowers
        //                     {
        //                         Username = u.username,
        //                         firstname = u.firstname,
        //                         posted_on = t.created_on,
        //                         tweet_text = t.tweet_text,
        //                         likes = _context.like_Tweet.
        //                         Where(a => a.tweet_id == t.Id).Count(),
        //                         comments = from c in commentss
        //                                    join us in users
        //                                    on c.user_id equals us.id
        //                                    where c.tweet_id == t.Id
        //                                    select new Comments_and_Users
        //                                    {
        //                                        username = us.username,
        //                                        firstname = us.firstname,
        //                                        lastname = us.lastname,
        //                                        comment_text = c.comment_text,
        //                                        posted_on = c.created_on,
        //                                    },

        //                         comments_count = _context.comments.
        //                         Where(a=>a.tweet_id==t.Id).Count()

        //                     };

        //    return result;
        //}

    }
}

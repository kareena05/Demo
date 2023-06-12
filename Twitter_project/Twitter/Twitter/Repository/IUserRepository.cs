using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Twitter.Entities;
using Twitter.Models;

namespace Twitter
{
    public interface IUserRepository
    {
        
        Task<IList<User_entity>> GetUser();
        Task<int> AddNewUser(SaveUserModel model);
        Task<string> DeleteUser(int id);
        Task<string> LoginUser(string emailorusername,string password);
        Task<string> Change_Password(int id ,string oldPassword,string newPassword);
        Task<string> Follow(int myid,int friend_id);
        Task<IList<string>> ShowFollowRequests(int myid);
        Task<string> AcceptFollowRequests(int myid, int requestid);
        Task<string> RejectFollowRequests(int myid, int requestid);
        Task<IList<Follower_entity>> ShowMyFollowers(int myid);
        Task<string> Unfollow(int myid, int followerid);
        Task<IEnumerable<TweetsOfMyFollowers>> TweetsofFollowers(int myid);
       // Task<User_entity> GetUserwithFollowers(int myid);

    }
}

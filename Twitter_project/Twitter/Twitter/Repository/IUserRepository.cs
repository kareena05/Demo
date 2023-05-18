﻿using Twitter.Models;

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
    }
}

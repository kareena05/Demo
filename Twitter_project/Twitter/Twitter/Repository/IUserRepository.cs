using Twitter.Models;

namespace Twitter
{
    public interface IUserRepository
    {
        
        Task<IList<User_tbl>> GetUser();
        Task<int> AddNewUser(SaveUserModel model);
        Task<string> DeleteUser(int id);
        Task<string> LoginUser(string emailorusername,string password);


    }
}

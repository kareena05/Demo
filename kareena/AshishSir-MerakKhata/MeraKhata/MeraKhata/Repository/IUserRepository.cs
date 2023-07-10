using MeraKhata.Model;
using MeraKhata.Models;

namespace MeraKhata.Repository
{
    public interface IUserRepository
    {
        Task<int> CreateUser(UserModel model);
        Task<int> AddUserBackup(BackUpModel model);
        Task<int> CheckUserExists(string email);

        Task<BackUpModel> GetBackup(string email);
        //string GetUsers();
    }
}

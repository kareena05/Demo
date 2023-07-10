using MeraKhata.Model;
using MeraKhata.Models;

namespace MeraKhata.Repository
{
    public interface IUserService
    {
        Task<ResponseModel> CreateUser(UserModel model);
        Task<ResponseModel> AddUserBackup(BackUpModel model);
        Task<ResponseModel> GetBackup(string email);
        //string GetUsers();
    }
}

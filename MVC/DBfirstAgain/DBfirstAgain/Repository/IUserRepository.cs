using DBfirstAgain.Models;

namespace DBfirstAgain.Repository
{
    public interface IUserRepository
    {
        Task<User> UserDetails(int id);
    }
}

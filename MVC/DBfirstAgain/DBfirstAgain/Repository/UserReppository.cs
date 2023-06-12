using DBfirstAgain.Models;
using Microsoft.EntityFrameworkCore;

namespace DBfirstAgain.Repository
{
    public class UserReppository:IUserRepository
    {

        public readonly TwitterContext _context;
        public UserReppository(TwitterContext context) {
            _context = context;

        }
        public virtual async Task<User> UserDetails(int id)
        {
            var user = await _context.Users.Where(x => x.Id == id).Include(x=>x.Drafts).FirstAsync();
            return user;
        }
    }
}

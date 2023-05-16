using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Models;


namespace Twitter
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public virtual async Task<IList<User_tbl>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }

        public virtual async Task<int> AddNewUser(SaveUserModel model)
        {
            if (model.id == 0)
            {
                User_tbl user_tbl = new User_tbl();
                user_tbl.firstname = model.firstname;
                user_tbl.lastname = model.lastname;
                user_tbl.username = model.username;
                user_tbl.email = model.email;
                user_tbl.password = model.password;
                user_tbl.birthdate = model.birthdate;
                user_tbl.created_on = DateTime.Now;


                await _context.Users.AddAsync(user_tbl);
                await _context.SaveChangesAsync();
                return user_tbl.id;
            }
            else
            {

                var myUser = await _context.Users.FirstOrDefaultAsync(a => a.id == model.id);
                myUser.firstname = model.firstname;
                myUser.lastname = model.lastname;
                myUser.password = model.password;
                myUser.birthdate = model.birthdate;
                myUser.modified_on = DateTime.Now;


                _context.Update(myUser);
                await _context.SaveChangesAsync();
                return myUser.id;



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
            var myUser = _context.Users.Where(a => a.email == emailorusername || a.username==emailorusername).FirstOrDefault();
            if (myUser != null)
            {
                if(myUser.password ==  password)
                {
                    return  "Login Successfull !";
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
    }
}

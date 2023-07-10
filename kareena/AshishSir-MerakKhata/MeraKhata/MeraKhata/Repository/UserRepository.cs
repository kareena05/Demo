using AutoMapper;
using MeraKhata.Data;
using MeraKhata.Model;
using MeraKhata.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeraKhata.Repository
{
    public class UserRepository:IUserRepository
    {
        public UserRepository() { }
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UserRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _context = dataContext;

        }
        public virtual async Task<int> CreateUser(UserModel model)
        {

            var newUser = _mapper.Map<UserEntity>(model);
           
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser.Id;

           
        }
        public virtual async Task<int> CheckUserExists(string email)
        {
            var userID = 0;
            var checkuser = await _context.Users.Where(x=>x.Email==email).ToListAsync();
            if(checkuser.Count >0)
            {userID=checkuser.FirstOrDefault().Id;}
            return userID;
        }
        public virtual async Task<int> AddUserBackup(BackUpModel model)
        {
            var newBackup =new BackUpEntity();
            newBackup.Userid = model.Userid;
            newBackup.Lastbackup = model.Lastbackup;
            newBackup.Filename = model.Filename;

            await _context.Backup.AddAsync(newBackup);
            await _context.SaveChangesAsync();
            return newBackup.Id;
        }
        public virtual async Task<BackUpModel> GetBackup(string email)
        {
            var user = _context.Users.Where(a=> a.Email== email).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            var backup = await _context.Backup.OrderBy(x => x.Id).LastOrDefaultAsync(a => a.Userid == user.Id);
            return _mapper.Map<BackUpModel>(backup);

           
        }


    }
}

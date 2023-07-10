using AutoMapper;
using MeraKhata.Data;
using MeraKhata.Model;
using MeraKhata.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeraKhata.Repository
{
    public class UserService:IUserService
    {
        public UserService() { }
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UserService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _context = dataContext;

        }
        public virtual async Task<ResponseModel> CreateUser(UserModel model)
        {

            var currentUser = _context.users.Where(a => a.email==model.Email).FirstOrDefault();
            if (currentUser != null)
            {
                return new ResponseModel { Data = null, Status = false, Message = "Email already Exist" };
            }
            

            var newUser = _mapper.Map<UserEntity>(model);
           
            await _context.users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return new ResponseModel { Data = newUser.id, Status = true, Message = "User added" };



        }
        public virtual async Task<ResponseModel> AddUserBackup(BackUpModel model)
        {

            var currentUser = _context.users.Where(a => a.id == model.Userid).FirstOrDefault();
            if (currentUser == null)
            {
                return new ResponseModel { Data = null, Status = false, Message = "User does not exist" };
            }
            var newBackup =new BackUpEntity();
            newBackup.userid = model.Userid;
            newBackup.lastbackup = model.Lastbackup;
            newBackup.filename = model.Filename;

            await _context.backup.AddAsync(newBackup);
            await _context.SaveChangesAsync();
            return   new ResponseModel { Data = newBackup.id, Status = true, Message = "User Backup Added" };
        }
        public virtual async Task<ResponseModel> GetBackup(string email)
        {
            var user = _context.users.Where(a=> a.email== email).FirstOrDefault();
            if (user == null)
            {
                return new ResponseModel { Data = null, Status = false, Message = "Backup not found" };
            }
            var backup = await _context.backup.OrderBy(x => x.id).LastOrDefaultAsync(a => a.userid == user.id);
            var backupModel = _mapper.Map<BackUpModel>(backup);
            return  new ResponseModel { Data = backupModel, Status = true, Message = "Backup Data found" };


        }


    }
}

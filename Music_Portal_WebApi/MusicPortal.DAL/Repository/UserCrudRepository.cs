using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Repository
{
    internal class UserCrudRepository : IUserCrud
    {



        PortalContext? _DB;
        public UserCrudRepository(PortalContext context)
        {


            _DB = context;

        }
        public async Task AddUserAsync(User user)
        {
            if (_DB != null)
            {
               await Task.Run(()=> _DB.Users.Add(user));
            }
            else
            {
                throw new NullReferenceException("Somthin wrone, NullReference!");
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            if (_DB != null)
            {
                var targetDelete= await _DB.Users.SingleOrDefaultAsync(u=>u.Id==id);
                if (targetDelete != null)
                {
                    await Task.Run(()=> _DB.Users.Remove(targetDelete));
                }
            }
            else
            {
                throw new NullReferenceException("Somthin wrone, NullReference!");
            }
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            if (_DB != null)
            {
                return await Task.Run(() => _DB.Users);
            }
            else
            {
                throw new NullReferenceException("Somthin wrone, NullReference!");
            }

            
        }

        public Task<User> GetUserById(int id)
        {

            if (_DB != null)
            {


                return _DB.Users.SingleOrDefaultAsync(u => u.Id == id);
            }
            else
            {
                throw new NullReferenceException("Somthin wrone, NullReference!");
            }
            
        }

        public async Task UpdateUserAsync(User user)
        {
            if (_DB != null)
            {
                var targeUpdate = await _DB.Users.SingleOrDefaultAsync(u => u.Id == user.Id);

                if (targeUpdate != null)
                {
                    targeUpdate.NickName=user.NickName;
                    targeUpdate.Confirmation=user.Confirmation;
                }
                else
                {

                    throw new Exception("User not found");
                }
            }
            else
            {
                throw new NullReferenceException("Somthin wrone, NullReference!");
            }
        }
    }
}

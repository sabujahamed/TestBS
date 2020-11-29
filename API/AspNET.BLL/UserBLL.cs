using ASPNET.DTO;
using ASPNET.DTO.VM;
using AspNetdbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNET.BLL
{
    public class UserBLL : IUser
    {
        private readonly AspContext _aspContext;
        public UserBLL(AspContext aspContext)
        {
            _aspContext = aspContext;
        }

        public async Task<User> AddUsers(User user)
        {
            try
            {
                var res = await _aspContext.User.AddAsync(user);
                await _aspContext.SaveChangesAsync();
                return res.Entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<User>> GetAll()
        {
            return await _aspContext.User.ToListAsync();
        }

       
    }
    public interface IUser
    {
        Task<User> AddUsers(User post);
        Task<List<User>> GetAll();



    }
}

using Infrastructure.Db.Data.Context;
using Infrastructure.Db.Data.Entities;
using Infrastructure.Db.Repository.Interface;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Db.Repository.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly BrazInvestDbContext _dbContext;
        
        public UserRepository(BrazInvestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserDto addUser(string username, string password, string email )
        {
            var user = new User
            {
                Email = email,
                UserName = username,
                Password = password,
                UserId = 0

            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var userDto = new UserDto
            {
                UserId = user.UserId,
                Email = user.Email,
                UserName= username,
            };

            return userDto;
        }

   
    }
    
}

using Infrastructure.Db.Data.Entities;
using Infrastructure.Dto;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Db.Repository.Interface
{
    public interface IUserRepository
    {
        UserDto addUser(string username, string password, string email);
    }
}

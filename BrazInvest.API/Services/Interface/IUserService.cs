using Infrastructure.Dto;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserService
    {
        UserDto AddUser(string username, string password, string email);

        bool ValidateEmail(string email);

        bool ValidatePassword(string password);

        bool ValidateUserName(string username);
    }


}

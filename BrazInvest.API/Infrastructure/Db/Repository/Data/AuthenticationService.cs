using Infrastructure.Db.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Db.Repository.Data
{
    internal class AuthenticationService : IAuthenticationService
    {
        public bool AuthenticateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}

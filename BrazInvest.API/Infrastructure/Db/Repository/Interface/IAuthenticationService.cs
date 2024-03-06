using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Db.Repository.Interface
{
    public interface IAuthenticationService
    {
        bool AuthenticateUser(string username, string password);

        string ValidateToken(string token);

    }
}

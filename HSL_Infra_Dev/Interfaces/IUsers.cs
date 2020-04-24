using HSL_Infra_Dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSL_Infra_Dev.Interfaces
{
    public interface IUsers
    {
        string CheckAdminLogin(string UserId,string Password);
        string CheckUserLogin(string UserId, string Password);
        Users GetUsers(int UserId);
        List<Users> GetUsers();
    }
}

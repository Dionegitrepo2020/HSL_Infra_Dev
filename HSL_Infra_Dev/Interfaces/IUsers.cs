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
        List<Users> GetUsers();
        //Users GetUser(int UserId);
        //string CreateUser(Users user);
        //int DeleteUser(int user_id);
        //string UpdateUser(Users user);
    }
}

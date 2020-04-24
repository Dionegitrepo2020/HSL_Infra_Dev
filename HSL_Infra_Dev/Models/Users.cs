using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Models
{
    public class Users
    {
        public int User_Id { get; set; }
        public int Company_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Password { get; set; }
        public string Name { get; set; }
        public int Department_Id { get; set; }
        public int Role_Id { get; set; }
        public bool Is_Active { get; set; }
        public Nullable<DateTime> Created_Date { get; set; }
        public Nullable<DateTime> Modified_Date { get; set; }
    }
}
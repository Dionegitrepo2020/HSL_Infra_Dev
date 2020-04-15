using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Department_Description { get; set; }
        public bool Is_Active { get; set; }
        public Nullable<DateTime> Created_Date { get; set; }
        public Nullable<DateTime> Updated_Date { get; set; }
    }
}
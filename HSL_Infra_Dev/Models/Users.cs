using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Models
{
    public class Users
    {
        public int USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string USER_PASSWORD { get; set; }
        public string NAME { get; set; }
        public int Department_id { get; set; }
        public int Role_id { get; set; }
        public bool Is_Active { get; set; }

        public Nullable<DateTime> Created_Date { get; set; }
        public Nullable<DateTime> Updated_Date { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Location_Description { get; set; }
        public bool Is_Active { get; set; }
        public int Department_id { get; set; }
        public Nullable<DateTime> Created_Date { get; set; }
        public Nullable<DateTime> Updated_Date { get; set; }
    }
}
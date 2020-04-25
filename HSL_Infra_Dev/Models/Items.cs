using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Models
{
    public class Items
    {
        public int Item_Id { get; set; }
        public string Item_Description { get; set; }
        public int Uom_Id { get; set; }
        public Nullable<DateTime> Created_Date { get; set; }
        public Nullable<DateTime> Updated_Date { get; set; }
    }
}
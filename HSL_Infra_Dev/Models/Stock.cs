using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Models
{
    public class Stock
    {
        public int Stock_Id { get; set; }
        public int Location_Id { get; set; }
        public int Item_Id { get; set; }
        public int Base_Uom_Id { get; set; }
        public decimal Stock_Quantity { get; set; }
        public Nullable<DateTime> Created_Date { get; set; }
        public Nullable<DateTime> Updated_Date { get; set; }
    }
}
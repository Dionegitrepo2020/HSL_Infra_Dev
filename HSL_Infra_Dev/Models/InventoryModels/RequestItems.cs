using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Models.InventoryModels
{
    public class RequestItems
    {
        public int Request_Dtl_Id { get; set; }
        public int Request_Id { get; set; }
        public int Item_Id { get; set; }
        public int To_Location { get; set; }
        public int Uom_Id { get; set; }
        public decimal Request_Quantity { get; set; }
        public decimal Issued_Quantity { get; set; }
        public string Comment { get; set; }
        public Nullable<DateTime> Created_Date { get; set; }
        public Nullable<DateTime> Modified_Date { get; set; }
    }
}
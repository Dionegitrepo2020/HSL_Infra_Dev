using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Models.InventoryModels
{
    public class MaterialRequest
    {
        public int Request_Id { get; set; }
        public string Request_Number { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Requester_Name { get; set; }
        public int Department_Id { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public List<RequestItems> RequestItemsList { get; set; }
    }
}
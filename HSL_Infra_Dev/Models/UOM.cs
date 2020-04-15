using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Models
{
    public class UOM
    {
        public int Id { get; set; }
        public string uom_key { get; set; }
        public string uom_desc { get; set; }
        public int unit_factor { get; set; }
        public int min_conversion { get; set; }
        public bool is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
    }
}
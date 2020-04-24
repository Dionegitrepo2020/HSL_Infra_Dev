using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Models
{
    public class CompanyLicense
    {
        public int LicenseId { get; set; }
        public int CompanyId { get; set; }
        public string LicenseKey { get; set; }
        public string Product { get; set; }
        public string Status { get; set; }
        public Nullable<DateTime> RegistrationDate { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public int NotificationDays { get; set; }
        public Nullable<DateTime> CreatednDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSL_Infra_Dev.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyZip { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyUserid { get; set; }
        public string CompanyPassword { get; set; }
        public string CompanyTelephone { get; set; }
        public string UserCount { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
        public List<CompanyLicense> CompanyLicense { get; set; }
    }
}
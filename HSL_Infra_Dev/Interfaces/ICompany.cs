using HSL_Infra_Dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSL_Infra_Dev.Interfaces
{
    public interface ICompany
    {
        Company GetCompany(int Id);
        string UpdateCompany(Company company);
    }
}

using HSL_Infra_Dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSL_Infra_Dev.Interfaces
{
    public interface IUOM
    {
        List<UOM> GetUOMs();
        UOM GetUOM(int Uom_Id);
        string CreateUom(UOM uom);
        int DeleteUom(int Uom_Id);
        string UpdateUom(UOM uom);
    }
}

using HSL_Infra_Dev.Models.InventoryModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSL_Infra_Dev.Interfaces
{
    public interface IRequest
    {
        int CreateRequest(MaterialRequest materialRequest);
        int CreateIssue(MaterialRequest materialRequest);
        DataTable GetAllRequestHeader();
        DataTable GetAllRequestDetailById(int RequestId);
    }
}

using HSL_Infra_Dev.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSL_Infra_Dev.Interfaces
{
    public interface IItem
    {
        List<Items> GetItems();
        Items GetItem(int ItemId);
        int CreateItem(Items items);
        DataTable GetItemsDataTable();
        //int DeleteItem(int Item_id);
        //string UpdateItem(Location Item_id);
    }
}

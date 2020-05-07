using HSL_Infra_Dev.Helpers;
using HSL_Infra_Dev.Interfaces;
using HSL_Infra_Dev.Models;
using HSL_Infra_Dev.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HSL_Infra_Dev.Pages.InventoryModule
{
    public partial class MaterialRequest : System.Web.UI.Page
    {
        DataTable dataTable = new DataTable();
        IItem item = new ItemImpl();
        IUOM uomsService = new UOMImpl();
        ILocation locationService = new LocationImpl();
        IStock stockService = new StockImpl();
        protected void Page_Load(object sender, EventArgs e)
        {
            dataTable.Columns.Add("ITEM_ID");
            dataTable.Columns.Add("ITEM_DESC");
            dataTable.Columns.Add("LOCATION_ID");
            dataTable.Columns.Add("TOTALQTY");
            //dataTable.Columns.Add("CREATED_DATE");
            //dataTable.Columns.Add("MODIFIED_DATE");
            LoadGridTable();
            LoadUoms();
            Loadlocations();
        }

        private void Loadlocations()
        {
            List<Location> locations = new List<Location>();
            locations = locationService.GetLocation();
            foreach (var location in locations)
            {
                ddlLocations.Items.Add(new ListItem(location.Location_Description, location.Id.ToString()));
            }
        }

        private void LoadUoms()
        {
            List<UOM> uoms = new List<UOM>();
            uoms = uomsService.GetUOMs();
            foreach (var uom in uoms)
            {
                ddluom.Items.Add(new ListItem(uom.uom_desc, uom.Id.ToString()));
            }
        }

        private void LoadGridTable()
        {
            dataTable = item.GetItemsDataTable();
            grdvCrudOperation.DataSource = dataTable;
            grdvCrudOperation.DataBind();
        }

        protected void grdvCrudOperation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell locCell = e.Row.Cells[2];
                Location location = locationService.GetLocation(Convert.ToInt32(locCell.Text));
                locCell.Text = location.Location_Description;
            }
        }
    }
}
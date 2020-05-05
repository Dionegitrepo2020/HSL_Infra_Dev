using HSL_Infra_Dev.Helpers;
using HSL_Infra_Dev.Interfaces;
using HSL_Infra_Dev.Models;
using HSL_Infra_Dev.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HSL_Infra_Dev.Pages
{
    public partial class ItemPage : System.Web.UI.Page
    {
        DataTable dataTable = new DataTable();
        IItem item = new ItemImpl();
        IUOM uomsService = new UOMImpl();
        ILocation locationService = new LocationImpl();
        IStock stockService = new StockImpl();

        ListtoDataTableConverter converter = new ListtoDataTableConverter();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Items itemsModel = new Items();
            Stock stock = new Stock();
            UOM uOM = new UOM();

            //Inserting an Items
            itemsModel.Item_Description = txt_Itemdesc.Text;
            itemsModel.Uom_Id = Convert.ToInt32(ddluom.SelectedItem.Value);
            itemsModel.Quantity = Convert.ToInt32(txtQuantity.Text);
            int ItemID = item.CreateItem(itemsModel);

            //Getting UOM Data for conversion item quantity
            uOM = uomsService.GetUOM(itemsModel.Uom_Id);

            stock.Location_Id= Convert.ToInt32(ddlLocations.SelectedItem.Value);
            stock.Item_Id = ItemID;
            stock.Base_Uom_Id = uOM.Id;
            stock.Stock_Quantity = itemsModel.Quantity * uOM.unit_factor;

            int result = stockService.CreateStock(stock);
            if(result>0)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success",
                        "alert('Item Added Successfully');", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success",
                        "alert('Something went wrong');", true);
            dataTable.Rows.Clear();
            LoadGridTable();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            //var DeletButton = (Control)sender;
            //GridViewRow row = (GridViewRow)DeletButton.NamingContainer;
            //int Loc_ID = Convert.ToInt32(row.Cells[0].Text);
            //int DeleteResult = location.DeleteLocation(Loc_ID);
            //if (DeleteResult > 0)
            //{
            //    dataTable.Rows.Clear();
            //    LoadGridTable();
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success",
            //            "alert('Location : " + Loc_ID + " was deleted');", true);
            //}
            //else
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
            //            "alert('Something went wrong');", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
            //            "confirm('Do you want to delete?');", true);
            //Location locations = new Location();
            //locations.Id = Convert.ToInt32(txt_Locationid.Text);
            //locations.Location_Description = txt_loationdesc.Text;
            //locations.Department_id = Convert.ToInt32(ddlDepts.SelectedItem.Value);
            //locations.Is_Active = chkActive.Checked ? true : false;
            //string result = location.UpdateLocation(locations);
            //if (result.Equals("Updated"))
            //{
            //    dataTable.Rows.Clear();
            //    LoadGridTable();
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success",
            //            "alert('Location : " + txt_Locationid.Text + " was updated');", true);
            //}
            //else
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
            //            "alert('Something went wrong');", true);
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
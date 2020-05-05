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
    public partial class UOMMasterPage : System.Web.UI.Page
    {
        DataTable dataTable = new DataTable();
        IUOM UomService = new UOMImpl();
        ListtoDataTableConverter converter = new ListtoDataTableConverter();
        protected void Page_Load(object sender, EventArgs e)
        {
            dataTable.Columns.Add("UOM_ID");
            dataTable.Columns.Add("UOM_NAME");
            dataTable.Columns.Add("UOM_DESC");
            dataTable.Columns.Add("UNIT_FACTOR");
            dataTable.Columns.Add("MIN_CONVERTION");
            dataTable.Columns.Add("ISACTIVE");
            dataTable.Columns.Add("CREATED_DATE");
            dataTable.Columns.Add("MODIFIED_DATE");
            LoadGridTable();
            LoadUoms();
        }

        private void LoadUoms()
        {
            List<UOM> uoms = new List<UOM>();
            uoms = UomService.GetUOMs();
            foreach (var uom in uoms)
            {
                ddluom.Items.Add(new ListItem(uom.uom_desc, uom.Id.ToString()));
            }
        }

        private void LoadGridTable()
        {
            List<UOM> uom = UomService.GetUOMs();
            dataTable = converter.ToDataTable(uom, dataTable);
            grdvCrudOperation.DataSource = dataTable;
            grdvCrudOperation.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UOM uom = new UOM();
            uom.uom_key = txt_uomkey.Text;
            uom.uom_desc = txt_UomDesc.Text;
            uom.unit_factor = Convert.ToInt32(txt_unitfactor.Text);
            uom.min_conversion = Convert.ToInt32(ddluom.SelectedItem.Value);
            uom.is_active = chkActive.Checked ? true : false;
            string result = UomService.CreateUom(uom);
            dataTable.Rows.Clear();
            LoadGridTable();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            var DeletButton = (Control)sender;
            GridViewRow row = (GridViewRow)DeletButton.NamingContainer;
            int Uom_ID = Convert.ToInt32(row.Cells[0].Text);
            int DeleteResult = UomService.DeleteUom(Uom_ID);
            if (DeleteResult > 0)
            {
                dataTable.Rows.Clear();
                LoadGridTable();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success",
                        "alert('UOM : " + Uom_ID + " was deleted');", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                        "alert('Something went wrong');", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UOM uom = new UOM();
            uom.Id = Convert.ToInt32(txt_uomid.Text);
            uom.uom_key = txt_uomkey.Text;
            uom.uom_desc = txt_UomDesc.Text;
            uom.unit_factor = Convert.ToInt32(txt_unitfactor.Text);
            uom.min_conversion = Convert.ToInt32(ddluom.SelectedItem.Value);
            uom.is_active = chkActive.Checked ? true : false;
            string result = UomService.UpdateUom(uom);
            if (result.Equals("Updated"))
            {
                dataTable.Rows.Clear();
                LoadGridTable();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Success",
                        "alert('Department : " + txt_uomid.Text + " was updated');", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                        "alert('Something went wrong');", true);
        }
    }
}
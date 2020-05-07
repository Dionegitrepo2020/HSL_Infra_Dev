using HSL_Infra_Dev.Interfaces;
using HSL_Infra_Dev.Models;
using HSL_Infra_Dev.Models.InventoryModels;
using HSL_Infra_Dev.Services;
using HSL_Infra_Dev.Services.InventoryServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HSL_Infra_Dev.Pages
{
    public partial class MaterialIssue : System.Web.UI.Page
    {
        IRequest requestService = new MaterialRequestImpl();
        IDepartment departmentService = new DepartmentImpl();
        IItem itemService = new ItemImpl();
        ILocation locationService = new LocationImpl();
        IUOM uomService = new UOMImpl();
        IUsers usersService = new UsersImpl();
        ICompany companyService = new CompanyImpl();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUserData();
            DataTable dataTable = requestService.GetAllRequestHeader();
            grdvCrudOperation.DataSource = dataTable;
            grdvCrudOperation.DataBind();
        }

        private void LoadUserData()
        {
            ddlDepartment.Items.Clear();

            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                Company company = companyService.GetCompany(Convert.ToInt32(Session["CompanyID"]));
                List<Department> departments = departmentService.GetDepartment();
                foreach (var department in departments)
                    ddlDepartment.Items.Add(new ListItem(department.Department_Description, department.Id.ToString()));
                txtRequesterName.Text = company.CompanyName;
            }
            else
            {
                Users usersModel = usersService.GetUsers(Convert.ToInt32(Session["UserID"]));
                Department department = departmentService.GetDepartment(usersModel.Department_Id);
                ddlDepartment.Items.Add(new ListItem(department.Department_Description, department.Id.ToString()));
                txtRequesterName.Text = usersModel.Name;
            }
        }

        protected void grdvCrudOperation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell DeptId = e.Row.Cells[5];
                Department department = departmentService.GetDepartment(Convert.ToInt32(DeptId.Text));
                DeptId.Text = department.Department_Description;

                TableCell Date = e.Row.Cells[2];
                string dateTime = Convert.ToDateTime(Date.Text).ToString("yyyy-MM-dd");
                Date.Text = dateTime;
            }
        }

        protected void BtnSelect_ServerClick(object sender, EventArgs e)
        {
            var DeletButton = (Control)sender;
            GridViewRow row = (GridViewRow)DeletButton.NamingContainer;
            string Req_ID = row.Cells[0].Text;
            txtReqNo.Text = Req_ID;
            DataTable dataTable = requestService.GetAllRequestDetailById(Convert.ToInt32(Req_ID));
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Item Bind
                TableCell ItemId = e.Row.Cells[3];
                Items items = itemService.GetItem(Convert.ToInt32(ItemId.Text));
                ItemId.Text = items.Item_Description;
                
                //Location Bind
                TableCell LocId = e.Row.Cells[4];
                Location location = locationService.GetLocation(Convert.ToInt32(LocId.Text));
                LocId.Text = location.Location_Description;

                //UOM Bind
                TableCell UomId = e.Row.Cells[5];
                UOM uom = uomService.GetUOM(Convert.ToInt32(UomId.Text));
                UomId.Text = uom.uom_desc;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Models.InventoryModels.MaterialRequest materialRequest = new Models.InventoryModels.MaterialRequest();
            materialRequest.Request_Id = Convert.ToInt32(txtReqNo.Text);
            materialRequest.Date = Convert.ToDateTime(txtDate.Text);
            materialRequest.Time = Convert.ToDateTime(txtTime.Text);
            materialRequest.Requester_Name = txtRequesterName.Text;
            materialRequest.Department_Id = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
            materialRequest.Description = txtDescription.Text;
            materialRequest.Comment = txtReqComment.Text;
            DataTable dt= requestService.GetAllRequestDetailById(Convert.ToInt32(txtReqNo.Text));
            List<RequestItems> reqItemsList = new List<RequestItems>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RequestItems Items = new RequestItems();
                Items.Request_Id = Convert.ToInt32(dt.Rows[i]["REQUEST_HDR_ID"]);
                Items.Item_Id = Convert.ToInt32(dt.Rows[i]["ITEM_ID"]);
                Items.To_Location = Convert.ToInt32(dt.Rows[i]["TO_LOCATION"]);
                Items.Uom_Id = Convert.ToInt32(dt.Rows[i]["UOM_ID"]);
                Items.Request_Quantity = Convert.ToDecimal(dt.Rows[i]["REQUEST_QUANTITY"]);
                HtmlInputText textbox = ((HtmlInputText)GridView1.Rows[i].FindControl("issqty"));
                Items.Issued_Quantity = Convert.ToDecimal(textbox.Value);
                Items.Comment = GridView1.Rows[i].Cells[5].Text;
                reqItemsList.Add(Items);
            }
            materialRequest.RequestItemsList = reqItemsList;
            int Result = requestService.CreateIssue(materialRequest);
            if (Result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                        "alert('Issue Created');", true);
                //ResetPage();
            }
            else ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Failed",
                       "alert('Something went wrong');", true);
        }
    }
}
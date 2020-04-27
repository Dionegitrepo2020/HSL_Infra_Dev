<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/SideBarMaster.Master" AutoEventWireup="true" CodeBehind="UsersMaster.aspx.cs" Inherits="HSL_Infra_Dev.Pages.UsersMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>HIMATSINGKA</title>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">
        <script src="../Scripts/jquery-3.0.0.min.js"></script>
        <script src="../Scripts/jquery-ui.js"></script>
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.css" />
        <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css" />
        <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js"></script>
        <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js"></script>
    </head>
    <body class="bg-light">
        <form runat="server">
            <div class="container-fluid shadow bg-white mb-2">
                <div class="row">
                    <h5 class="col align-items-centert m-1">DEPARTMENT MASTER</h5>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label for="txtpono" class="col-form-label">Company</label>
                            <asp:TextBox ID="txtCompany" class="form-control rounded-0" runat="server" />
                        </div>
                    </div>
                    
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label for="txtpono" class="col-form-label">Full Name</label>
                            <asp:TextBox ID="txtFullName" class="form-control rounded-0" placeholder="Full Name" runat="server" />
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label for="txtpono" class="col-form-label">Department</label>
                            <asp:DropDownList runat="server" ID="ddlDepts" CssClass="custom-select rounded-0">
                                <asp:ListItem Text="----Select Deprtment----" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label for="txtpono" class="col-form-label">Role</label>
                            <asp:DropDownList runat="server" ID="ddlRole" CssClass="custom-select rounded-0">
                                <asp:ListItem Text="----Select Role----" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label for="txtpono" class="col-form-label">User Name</label>
                            <asp:TextBox ID="txtUserName" class="form-control rounded-0" placeholder="Username" runat="server" />
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label for="txtpono" class="col-form-label">User Password</label>
                            <asp:TextBox ID="txtPassword" class="form-control rounded-0" placeholder="Password" runat="server" />
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="form-group">
                            <label for="txtpono" class="col-form-label invisible">Role</label>
                            <asp:Button runat="server" ID="SaveUser_Button" CssClass="btn btn-success form-control" Text="Save" OnClick="SaveUser_Button_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="container-fluid shadow bg-white mt-2">
                <div class="row">
                    <h5 class="col align-items-centert m-1">DEPARTMENT MASTER</h5>
                </div>
                <div class="row">
                    <div class="container-fluid">
                        <asp:GridView ID="grdvCrudOperation" runat="server" HorizontalAlign="Center" OnRowDataBound="grdvCrudOperation_RowDataBound"
                            AutoGenerateColumns="false" CssClass="table table-bordered table-sm table-striped table-hover">
                            <Columns>
                                <asp:BoundField DataField="USER_ID" HeaderText="USER ID" />
                                <asp:BoundField DataField="COMPANY_ID" HeaderText="COMPANY ID" />
                                <asp:BoundField DataField="USER_NAME" HeaderText="USERNAME" />
                                <asp:BoundField DataField="USER_PASSWORD" HeaderText="PASSWORD" Visible="false" />
                                <asp:BoundField DataField="NAME" HeaderText="NAME" />
                                <asp:BoundField DataField="DEPARTMENT_ID" HeaderText="DEPARTMENT" />
                                <asp:BoundField DataField="ROLE_ID" HeaderText="ROLE" />
                                <asp:BoundField DataField="ISACTIVE" HeaderText="ISACTIVE" />
                                <asp:BoundField DataField="CREATED_DATE" HeaderText="CREATED DATE" Visible="false" />
                                <asp:BoundField DataField="MODIFIED_DATE" HeaderText="MODIFIED DATE" Visible="false" />
                                <asp:TemplateField HeaderText="ACTION" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <i class="fa fa-lg fa-edit" id="edtRow" data-toggle="modal" data-target="#exampleModal" style="color: dodgerblue"></i>
                                        <a class="fa fa-lg fa-trash" runat="server" style="color: red"></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>THERE ARE NO DEPARTMENTS CREATED YET</EmptyDataTemplate>
                        </asp:GridView>
                        <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </form>
        <script type="text/javascript">
            $(function () {
                $('[id*=grdvCrudOperation]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                    "responsive": true,
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <script type="text/javascript">
            $(document).on("click", "[id*=btnNewItem]", function () {
                $("[id*=btnSave]").show();
                $("[id*=btnUpdate]").hide();
            });
        </script>
        <script type="text/javascript">
            $(document).on("click", "[id*=edtRow]", function () {
                var tableRow = $(this).closest("tr").find("td").eq(3).text();
                console.log("data is" + $("[id*=txt_DeptId]").val());
                $("[id*=txt_DeptId]").val($(this).closest("tr").find("td").eq(0).text());
                $("[id*=txt_DeptDesc]").val($(this).closest("tr").find("td").eq(1).text());
                var cat = $(this).closest("tr").find("td").eq(3).text();
                $("[id*=ddlitmcat] option").map(function () {
                    if ($(this).text() == cat) return this;
                }).prop('selected', true);
                $("[id*=btnSave]").hide();
                $("[id*=btnUpdate]").show();
                return false;
            });
        </script>
    </body>
    </html>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/SideBarMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="MaterialIssue.aspx.cs" Inherits="HSL_Infra_Dev.Pages.MaterialIssue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" runat="server">
    <!DOCTYPE html>
    <html>
    <head>
        <title>HIMATSINGKA</title>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">
        <script src="../Scripts/jquery-3.0.0.min.js"></script>
        <script src="../Scripts/jquery-ui.js"></script>
        <script src="../Scripts/jquery-ui-timepicker-addon.min.js"></script>
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.css" />
        <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css" />
        <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js"></script>
        <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js"></script>
        <style type="text/css">
            .modal-dialog-full-width {
                width: 100% !important;
                height: 100% !important;
                margin: 0 !important;
                padding: 0 !important;
                max-width: none !important;
            }
        </style>
    </head>
    <body>
        <form runat="server">
            <div class="container-fluid shadow bg-white mb-2">
                <div class="row">
                    <h5 class="col align-items-centert m-1">MATERIAL ISSUE</h5>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Requisition No :</label>
                            <asp:TextBox class="form-control ml-1" placeholder="Requisition No" runat="server" ID="txtReqNo" />
                            <div class="input-group-append">
                                <i runat="server" class="input-group-text fa fa-search" data-toggle="modal" data-target="#exampleModal"></i>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Date :</label>
                            <asp:TextBox class="form-control ml-1" placeholder="Date" runat="server" ID="txtDate" />
                            <div class="input-group-append">
                                <i class="input-group-text fa fa-calendar"></i>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Time :</label>
                            <asp:TextBox class="form-control ml-1" placeholder="Date" runat="server" ID="txtTime" />
                            <div class="input-group-append">
                                <i class="input-group-text fa fa-clock-o"></i>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Requester Name :</label>
                            <asp:TextBox class="form-control ml-1" runat="server" ID="txtRequesterName" />
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Department :</label>
                            <asp:DropDownList runat="server" ID="ddlDepartment" CssClass="custom-select rounded-0 ml-1">
                                <asp:ListItem Text="----Select Deprtment----" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group mb-3">
                            <input type="text" class="form-control ml-1" aria-label="Recipient's username" aria-describedby="basic-addon2">
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Description :</label>
                            <asp:TextBox class="form-control ml-1" placeholder="Description" runat="server" ID="txtDescription" />
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="input-group mb-3">
                            <label for="txtpono" class="col-form-label">Comments :</label>
                            <asp:TextBox class="form-control ml-1" placeholder="Comments" runat="server" ID="txtReqComment" />
                        </div>
                    </div>
                </div>
            </div>

            <%--ADD ITEMS TO GRIDVIEW--%>
            <div class="container-fluid shadow bg-white mt-2">
                <div class="row">
                    <h5 class="col align-items-centert m-1">ADD ITEMS</h5>
                </div>
                <div class="row">
                    <div class="container-fluid" style="height: 200px; overflow: scroll;">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-sm table-striped table-hover"
                            OnRowDataBound="GridView1_RowDataBound" RowStyle-HorizontalAlign="Center">
                            <Columns>
                                <asp:BoundField DataField="REQUEST_DTL_ID" HeaderText="REQUEST DETAIL ID" Visible="false" />
                                <asp:BoundField DataField="REQUEST_HDR_ID" HeaderText="REQUEST ID" Visible="false" />
                                <asp:BoundField DataField="ITEM_ID" HeaderText="ITEM ID" />
                                <asp:BoundField DataField="ITEM_ID" HeaderText="ITEM" />
                                <asp:BoundField DataField="TO_LOCATION" HeaderText="LOCATION" />
                                <asp:BoundField DataField="UOM_ID" HeaderText="UOM" />
                                <asp:BoundField DataField="REQUEST_QUANTITY" HeaderText="REQUESTED QUANTITY" />
                                <asp:TemplateField HeaderText="ITEM ISSUING" ItemStyle-Width="100px" HeaderStyle-Wrap="false">
                                    <ItemTemplate>
                                        <input type="text" class="form-control-range font-weight-bolder" value="0"
                                            autocomplete="off" id="issqty" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="COMMENTS" HeaderText="COMMENTS" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row container-fluid">
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-outline-success" Text="Submit" OnClick="btnSubmit_Click" />
                </div>
            </div>

            <%-- Modal --%>
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-full-width" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Select Item</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="container-fluid">
                                <asp:GridView ID="grdvCrudOperation" runat="server" HorizontalAlign="Center" RowStyle-Wrap="false" HeaderStyle-Wrap="false"
                                    AutoGenerateColumns="false" CssClass="table table-bordered table-sm table-striped table-hover table-responsive-lg"
                                    OnRowDataBound="grdvCrudOperation_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="REQUEST_HDR_ID" HeaderText="REQUEST ID" />
                                        <asp:BoundField DataField="REQUEST_NO" HeaderText="ITEM" />
                                        <asp:BoundField DataField="DATE" HeaderText="DATE" />
                                        <asp:BoundField DataField="TIME" HeaderText="TIME" />
                                        <asp:BoundField DataField="REQUESTER_NAME" HeaderText="REQUESTER NAME" />
                                        <asp:BoundField DataField="DEPARTMENT_ID" HeaderText="DEPARTMENT" />
                                        <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" />
                                        <asp:BoundField DataField="COMMENTS" HeaderText="COMMENT" />
                                        <asp:TemplateField HeaderText="ACTION" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Button runat="server" Text="select" OnClick="BtnSelect_ServerClick" />
                                                <i id="BtnSelect" class="text-primary" data-dismiss="modal">Select</i>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>THERE ARE NO ITEMS CREATED YET</EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
        <script type="text/javascript">
            $(function () {
                $('[id*=grdvCrudOperation]').prepend($("<thead></thead>").append($('[id*=grdvCrudOperation]').find("tr:first"))).DataTable({
                    "responsive": true,
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <script>
            $(document).ready(function () {
                //var dt = new Date();
                $('#<%=txtDate.ClientID%>').datepicker({
                    dateFormat: "yy-mm-dd"
                });
                $('#<%=txtTime.ClientID%>').timepicker({
                    timeFormat: "hh:mm:ss"
                });
            });
        </script>
    </body>
    </html>
</asp:Content>

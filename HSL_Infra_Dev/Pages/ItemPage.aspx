﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/SideBarMaster.Master" AutoEventWireup="true" CodeBehind="ItemPage.aspx.cs" Inherits="HSL_Infra_Dev.Pages.ItemPage" %>
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
            <div class="container-fluid shadow m-2 bg-white">
                <div class="row">
                    <h5 class="col align-items-centert m-1">ITEM MASTER</h5>
                    <a id="btnNewItem" href="frmCreateBOM.aspx" class="btn btn-primary col-2 align-self-end m-1" data-toggle="modal" data-target="#exampleModal"><i class="fa fa-plus"></i>&nbsp Create Location</a>
                </div>
                <div class="row">
                    <div class="container-fluid">
                        <asp:GridView ID="grdvCrudOperation" runat="server" HorizontalAlign="Center" OnRowDataBound="grdvCrudOperation_RowDataBound"
                            AutoGenerateColumns="false" CssClass="table table-bordered table-sm table-striped table-hover">
                            <Columns>
                                <asp:BoundField DataField="ITEM_ID" HeaderText="ITEM ID" />
                                <asp:BoundField DataField="ITEM_DESC" HeaderText="ITEM DESCRIPTION" />
                                <asp:BoundField DataField="LOCATION_ID" HeaderText="LOCATION" />
                                <asp:BoundField DataField="TOTALQTY" HeaderText="QUANTITY" />
                                <%--<asp:BoundField DataField="CREATED_DATE" HeaderText="CREATED DATE" />
                                <asp:BoundField DataField="MODIFIED_DATE" HeaderText="MODIFIED DATE" />--%>
                                <asp:TemplateField HeaderText="ACTION" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <i class="fa fa-lg fa-edit" id="edtRow" data-toggle="modal" data-target="#exampleModal" style="color: dodgerblue"></i>
                                        <a class="fa fa-lg fa-trash" runat="server" onserverclick="lnkDelete_Click" style="color: red"></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>THERE ARE NO ITEMS CREATED YET</EmptyDataTemplate>
                        </asp:GridView>
                        <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                    </div>
                </div>
            </div>

            <%-- Modal --%>
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Create Item</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="container-fluid">
                                <div class="row m-3">
                                    <label for="txtitemid" class="w-50 text-right">Item ID : &nbsp</label>
                                    <asp:TextBox ID="txt_Itemid" class="form-control-range w-50 rounded-0" runat="server" />
                                </div>

                                <div class="row m-3">
                                    <label for="txtitemdesc" class="w-50 text-right">Item Description : &nbsp</label>
                                    <asp:TextBox ID="txt_Itemdesc" class="form-control-range w-50 rounded-0" runat="server" />
                                </div>

                                <div class="row m-3">
                                    <label for="txtuomid" class="w-50 text-right">Location : &nbsp</label>
                                    <asp:DropDownList runat="server" ID="ddlLocations" CssClass="dropdown">
                                        <asp:ListItem Text="----Select Locations----" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="row m-3">
                                    <label for="txtuomid" class="w-50 text-right">Uom : &nbsp</label>
                                    <asp:DropDownList runat="server" ID="ddluom" CssClass="dropdown">
                                        <asp:ListItem Text="----Select Uom----" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="row m-3">
                                    <label for="txtitemdesc" class="w-50 text-right">Item Quantity : &nbsp</label>
                                    <asp:TextBox ID="txtQuantity" class="form-control-range w-50 rounded-0" runat="server" />
                                </div>

                                <%--<div class="row m-3">
                                    <asp:CheckBox ID="chkActive" Text="Is Active" Checked="true" CssClass="custom-checkbox col align-self-center" runat="server" />
                                </div>--%>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <asp:Button runat="server" CssClass="btn btn-primary" Text="save" ID="btnSave" OnClick="btnSave_Click" />
                            <asp:Button runat="server" CssClass="btn btn-primary" Text="Update" ID="btnUpdate" OnClick="btnUpdate_Click" />
                        </div>
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
                $("[id*=txt_Itemid]").val($(this).closest("tr").find("td").eq(0).text());
                $("[id*=txt_Itemdesc]").val($(this).closest("tr").find("td").eq(1).text());
                var location = $(this).closest("tr").find("td").eq(2).text();
                $("[id*=ddlLocations] option").map(function () {
                    if ($(this).text() == location) return this;
                }).prop('selected', true);
                $("[id*=btnSave]").hide();
                $("[id*=btnUpdate]").show();
                return false;
            });
        </script>
    </body>
    </html>
</asp:Content>

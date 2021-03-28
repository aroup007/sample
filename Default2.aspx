<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>


    <%--Install bootstrap--%>
    <%-- When use bootstrap need this link--%>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/bootstrap.js"></script>

    <%-- -------Design er moddhe Modal dekhar jonno ei link gulo off rakhte hobe------------ --%>

    <%-- 1st Content/bootstrap.css, Then Scripts/jquery-3.0.0.js, Then Scripts/bootstrap.js --%>
    <%-- Bootstrap use korar jonno jquery lage.tai jquery bootstrap er age hobe --%>

    <%--Insert,Update er somoy Image show korar jonno nicher code--%>
    <%--jQuery Command--%>
    <%--This code for Preview Image Before upload--%>
    <script>
        function readURL(input) {

            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.prev').attr('src', e.target.result);    //Image  CssClass="prev"
                }

                reader.readAsDataURL(input.files[0]);
            }
        }

        //$(".imgInp").change(function () {
        //    readURL(this);                         //FileUpload  onchange=" readURL(this);"
        //});
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--UpdatePanel nile ScriptManager nite hobe--%>
            <%--Button UpdatePanel er vitorei hobe--%>
            <%-- Literal message dekhte ContentTemplate and UpdatePanel er vitore nite hobe --%>

            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" EmptyDataText="There are no data records to display." ShowHeaderWhenEmpty="True" OnRowCommand="GridView1_RowCommand">
                        <Columns>
                            <asp:ButtonField CommandName="V" Text="View" />
                            <asp:ButtonField CommandName="U" Text="Update" />
                            <asp:ButtonField CommandName="D" Text="Delete" />
                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                            <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                            <asp:TemplateField HeaderText="ProductImage" SortExpression="ProductImage">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ProductImage") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("ProductImage","./Pic/{0}") %>' Width="100px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CategoryId" HeaderText="CategoryId" SortExpression="CategoryId" />
                        </Columns>

                    </asp:GridView>
                    <br />
                    &nbsp;
                <asp:Button ID="btnAddNewProduct" runat="server" OnClick="btnAddNewProduct_Click" Text="Add New Product" />

                    <br />

                </ContentTemplate>
            </asp:UpdatePanel>

            <br />
            <br />




            <!-- Modal -->
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>

                        <%-- Modal er vitore Table show korar jonno UpdatePanel er vitore Database Table dite hobe
        UpdatePanel nile must be ContentTemplate nite hobe--%>
                        <%-- GridView theke Modal er Button show korte holeo Button UpdatePanel er vitore Button nite hobe--%>

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>


                                <div class="modal-body">
                                    Product Information

           <table class="auto-style1">
               <tr>
                   <td>Product Id:</td>
                   <td>
                       <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Product Name:</td>
                   <td>
                       <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Quantity:</td>
                   <td>
                       <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Price:</td>
                   <td>
                       <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Photo</td>
                   <td>
                       <asp:Image ID="Image1" runat="server" CssClass="prev" Width="100px" />
                       <br />
                       <asp:FileUpload ID="FileUpload1" runat="server" onchange=" readURL(this);" />
                   </td>
               </tr>
               <tr>
                   <td>Category:</td>
                   <td>
                       <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True">
                           <asp:ListItem Value="0">---Select Item---</asp:ListItem>
                       </asp:DropDownList>
                   </td>
               </tr>
           </table>
                                </div>

                                <%-- Button er color change korar jonno class dite hobe.Example:class="btn btn-secondary" etc...--%>

                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                    <asp:Button ID="btnInsert" class="btn btn-primary" runat="server" OnClick="btnInsert_Click" Text="Insert" />
                                    <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                                    <asp:Button ID="btnDelete" class="btn btn-warning" runat="server" OnClick="btnDelete_Click" Text="Delete" />

                                </div>
                            </ContentTemplate>

                            <%-- Pic upload er jonno trigger er vitore nicher code.updatepanel click kore properties theke --%>
                            <%-- Image Insert,Update er jonno must be Triggers nite hobe--%>

                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                                <asp:PostBackTrigger ControlID="btnInsert" />
                                <asp:PostBackTrigger ControlID="btnUpdate" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

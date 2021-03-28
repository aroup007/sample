<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="CheckOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <%-- Install-Package jQuery.UI.Combined--%>

    <link href="Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <link href="Content/themes/base/datepicker.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/jquery-ui-1.12.1.js"></script>


    <%-- jQuery command--%>
    <%--This code for textbox DateTimePicker--%>
    <script>
        $(function () {
            $(".abc").datepicker({          //CssClass="abc" for textbox
                dateFormat: "dd-MM-yy",     //ekhane coma not semicolon Mind It
                autoSize: true,             //Case sensitive
                changeYear: true,
                changeMonth: true,
                maxDate: "+1m",             //ekhane m,d,w means month,day,week
                minDate: "0d",
                // minDate: "-1d",
                // minDate: "-1w",
                //yearRange: '-65:-13',     //yearRange: '-Minimum Year:-Maximum Year',
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" ShowFooter="True" ShowHeaderWhenEmpty="True" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="Product Id" HeaderText="Product Id" />
                    <asp:BoundField DataField="Product Name" HeaderText="Product Name" />
                    <asp:BoundField DataField="Product Quantity" HeaderText="Product Quantity" />
                    <asp:BoundField DataField="Sales Price" HeaderText="Sales Price" />
                    <asp:BoundField DataField="Total Price" HeaderText="Total Price" />
                </Columns>
            </asp:GridView>
        <br />
        
    </div>
        &nbsp;&nbsp;
        <asp:Label ID="lblCount" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnContinueShopping" runat="server" Text="Continue Shopping" OnClick="btnContinueShopping_Click" />
        <asp:Button ID="btnEndShopping" runat="server" Text="End Shopping" OnClick="btnEndShopping_Click" />
        &nbsp;<asp:Button ID="btnOrderHere" runat="server" OnClick="btnOrderHere_Click" Text="Order Here" />
        <br />
        <br />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
        <br />
       <div>
            <table class="auto-style1">
            <tr>
                <td>Customer Name:</td>
                <td>
                    <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomerName" ErrorMessage="Please Type Customer Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Phone No:</td>
                <td>
                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Address:</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Date of Enroll:</td>
                <td>
                    <asp:TextBox ID="txtEnroll" runat="server" CssClass="abc"></asp:TextBox>
                </td>
            </tr>
        </table>
       </div>
    </form>
</body>
</html>

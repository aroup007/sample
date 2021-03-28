<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyProduct.aspx.cs" Inherits="BuyProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" ShowFooter="True" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="ProductId" HeaderText="Product Id" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="ProductQuantity" HeaderText="Product Quantity" />
                    <asp:BoundField DataField="SalesPrice" HeaderText="Sales Price" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
                </Columns>
            </asp:GridView>
            
        
            <asp:Label ID="lblCount" runat="server"></asp:Label>
            
            <br />
            
            <asp:Button ID="btnCheckOut" runat="server" OnClick="btnCheckOut_Click" Text="Check Out" />
            
            
                <br />
            
            
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            
        
            <br />
            
        
            <asp:DataList ID="DataList1" runat="server" BorderColor="Black" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyField="Id" GridLines="Both" RepeatColumns="4" OnItemCommand="DataList1_ItemCommand">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ProductImage","./Pic/{0}") %>' Width="300px" />
                    <br />
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' Visible="False" />
                    <br />
                   
                    <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                    <br />
                
                    <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' Visible="False" />
                    <br />
                   Price:
                    <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                    <br />
                    
                    <asp:Label ID="ProductImageLabel" runat="server" Text='<%# Eval("ProductImage") %>' Visible="False" />
                    
                    <br />
                   
                    <asp:Label ID="CategoryIdLabel" runat="server" Text='<%# Eval("CategoryId") %>' Visible="False" />
                    <br />
                    <asp:Button ID="btnBuy" runat="server" CommandName="B" Text="Buy" />
<br />
                </ItemTemplate>
            </asp:DataList>
        
            
    
    </div>
       
    </form>
</body>
</html>

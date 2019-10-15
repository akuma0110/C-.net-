<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailPage.aspx.cs" Inherits="DangMNN_Project.DetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Product ID: <asp:TextBox ID="txtProductID" runat="server" ReadOnly="true">0</asp:TextBox><br />
    <br />
    Product Name: <asp:TextBox ID="txtProductName" runat="server" ></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name product cant be blank" ControlToValidate="txtProductName"></asp:RequiredFieldValidator><br />
    Category:  <asp:DropDownList ID="txtCate" runat="server" Height="22px" Width="260px"></asp:DropDownList><br />
    <br />
    Supplier: <asp:DropDownList ID="txtSub" runat="server"> </asp:DropDownList><br />
    Quantity: <asp:TextBox ID="txtQuantity" runat="server">0</asp:TextBox><br />
    <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ErrorMessage="*" ControlToValidate="txtQuantity"></asp:RequiredFieldValidator><br />
    Unit Price: <asp:TextBox ID="txtPrice" runat="server" ></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Price product cant be blank" ControlToValidate="txtPrice"></asp:RequiredFieldValidator><br />
    Units In Stock: <asp:TextBox ID="txtStock" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="rfvStock" runat="server" ErrorMessage="Stock product cant be blank" ControlToValidate="txtStock"></asp:RequiredFieldValidator><br />
    Units On Order: <asp:TextBox ID="txtOrder" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="rfvOrder" runat="server" ErrorMessage="Order product cant be blank" ControlToValidate="txtOrder"></asp:RequiredFieldValidator><br />
    Reorder Level: <asp:TextBox ID="txtReorder" runat="server">0</asp:TextBox><br />
    <asp:RequiredFieldValidator ID="rfvReorder" runat="server" ErrorMessage="Reorder product cant be blank" ControlToValidate="txtReorder"></asp:RequiredFieldValidator><br />
    Discontinuous: <asp:DropDownList ID="txtDisCon" runat="server">
                        <asp:ListItem Text="True" Value="true"></asp:ListItem>
                        <asp:ListItem Text="False" Value="false"></asp:ListItem>
                    </asp:DropDownList><br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <asp:LinkButton ID="Back" runat="server" PostBackUrl="~/ProductManager.aspx">Back</asp:LinkButton>
</asp:Content>

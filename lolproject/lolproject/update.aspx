<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="lolproject.update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    Product Name: <asp:TextBox ID="txtProductName" runat="server" Text='<%# Eval("txtProductName")%>'></asp:TextBox><br />
    Unit Price: <asp:TextBox ID="txtUnitprice" runat="server"></asp:TextBox><br />
    Unit in Stock: <asp:TextBox ID="txtUnitinStock" runat="server"></asp:TextBox><br />
    </div>
    <asp:Button ID="Update" runat="server" Text="Update" />

</asp:Content>

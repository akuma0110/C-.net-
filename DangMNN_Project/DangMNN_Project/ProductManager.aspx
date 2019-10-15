<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductManager.aspx.cs" Inherits="DangMNN_Project.ProductManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
  <div>
      Product Name: <asp:TextBox runat="server" ID="txtProName"></asp:TextBox>
      Min Price: <asp:TextBox runat="server" ID="txtMin">0</asp:TextBox>
      Max Price: <asp:TextBox runat="server" ID="txtMax">0</asp:TextBox>
      <asp:Button runat="server" Text="Search" ID="btnSearch" OnClick="btnSearch_Click" ValidationGroup="search"/>
      <asp:Button runat="server" Text="Add New" ID="btnAdd" OnClick="btnAdd_Click"  />
  </div>
  <div>
      <asp:GridView ID="mytbl" runat="server" DataKeyNames="ProductID" AutoGenerateColumns="false" OnRowDeleting="mytbl_RowDeleting" OnSelectedIndexChanged="mytbl_SelectedIndexChanged" OnRowEditing="mytbl_RowEditing" Width="351px" >
          <Columns>
              <asp:TemplateField>
                  <HeaderTemplate>Product Name</HeaderTemplate>
                  <ItemTemplate>
                      <%# Eval("ProductName") %>
                  </ItemTemplate>
              </asp:TemplateField>

               <asp:TemplateField>
                  <HeaderTemplate>Unit Price</HeaderTemplate>
                  <ItemTemplate>
                      <%# Eval("UnitPrice") %>
                  </ItemTemplate>
              </asp:TemplateField>

               <asp:TemplateField>
                  <HeaderTemplate>Units In Stock</HeaderTemplate>
                  <ItemTemplate>
                      <%# Eval("UnitsInStock") %>
                  </ItemTemplate>
              </asp:TemplateField>

              <asp:CommandField ShowDeleteButton="true" />
              <asp:CommandField ShowEditButton="true" />
          </Columns>
      </asp:GridView>
  </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="lolproject.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:GridView DataKeyNames="Product ID" ID="mytbl" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AutoGenerateColumns="False" ShowFooter="true" OnRowCommand="mytbl_RowCommand" OnRowEditing="mytbl_RowEditing">
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>Product Name</HeaderTemplate>
                <ItemTemplate>
                   <%#Eval("Product Name") %>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>Unit Price</HeaderTemplate>
                <ItemTemplate>
                   <%#Eval("Unit Price") %>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>Units in stock</HeaderTemplate>
                <ItemTemplate>
                   <%#Eval("Units in stock") %>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtUnitInStock" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>Edit</HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton> 
                    &#32;&#124;&#32;
                    <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton> 
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Update">Update</asp:LinkButton> 
                    &#32;&#124;&#32;
                    <asp:LinkButton ID="lbCancel" runat="server" CommandName="Cancle">Cancle</asp:LinkButton> 
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btnInsert" runat="server" Text="Save" CommandName="Insert"  />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

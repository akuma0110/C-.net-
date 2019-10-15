<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="testconnectDB.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                    <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
                    <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="National" HeaderText="National" SortExpression="National" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="Qualification" HeaderText="Qualification" SortExpression="Qualification" />
                    <asp:BoundField DataField="Salary" HeaderText="Salary" SortExpression="Salary" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetEmployees" TypeName="testconnectDB.Models.EmployeeRepository"></asp:ObjectDataSource>
    </form>
</body>
</html>

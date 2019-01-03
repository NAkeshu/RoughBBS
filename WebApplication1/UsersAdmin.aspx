<%@ Page Title="" Language="C#" MasterPageFile="~/header.Master" AutoEventWireup="true" CodeBehind="UsersAdmin.aspx.cs" Inherits="WebApplication1.UsersAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>用户管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>管理用户——删除用户，设置管理员</h1>
    <hr />
    <asp:GridView ID="UsersList" AutoGenerateColumns="False" Width="100%" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowCommand="UsersList_RowCommand">
        <AlternatingRowStyle BackColor="Gainsboro" />
        <Columns>
            <asp:BoundField DataField="userid" HeaderText="账号">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="username" HeaderText="昵称">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="email" HeaderText="邮箱">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="isAdmin" HeaderText="管理员？">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:ButtonField Text="设置管理员" ButtonType="Button" CommandName="setAdmin" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:ButtonField>
            <asp:ButtonField Text="删除用户" ButtonType="Button" CommandName="dl" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:ButtonField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
</asp:Content>

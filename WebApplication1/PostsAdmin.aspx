<%@ Page Title="" Language="C#" MasterPageFile="~/header.Master" AutoEventWireup="true" CodeBehind="PostsAdmin.aspx.cs" Inherits="WebApplication1.PostsAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>文章管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>管理<%=Request.QueryString["section"].ToString() %>区文章——删除帖子或者加精</h1>
    <asp:Button ID="backtoSections" runat="server" Text="返回板块列表" OnClick="backtoRefferer" />
    <asp:GridView ID="PostsAdminGV" Width="100%" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowCommand="PostsAdminGV_RowCommand">
        <AlternatingRowStyle BackColor="Gainsboro" />
        <Columns>
            <asp:BoundField DataField="postid" HeaderText="文章id">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="isstar" HeaderText="精品贴">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="topic" HeaderText="主题">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="commentnum" HeaderText="评论数">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="username" HeaderText="作者（作者id）">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="userid" HeaderText="作者id">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="posttime" HeaderText="发帖时间">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:ButtonField Text="加精" CommandName="star" />
            <asp:ButtonField Text="删除" CommandName="dl" />
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

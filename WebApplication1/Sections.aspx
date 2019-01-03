<%@ Page Title="" Language="C#" MasterPageFile="~/header.Master" AutoEventWireup="true" CodeBehind="Sections.aspx.cs" Inherits="WebApplication1.Sections" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>
        BBSBBSBBS--Sections
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>请选择分组板块</h1>
    <asp:GridView ID="SectionsList" runat="server" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <Columns>
            <asp:HyperLinkField DataTextField="sectionname" HeaderText="分组名" DataNavigateUrlFields="sectionname" DataNavigateUrlFormatString="PostsList.aspx?section={0}" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="sectiondetail" HeaderText="分组介绍">
                <ItemStyle Width="70%" />
            </asp:BoundField>
            <asp:BoundField DataField="username" HeaderText="版主" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="lastposttime" HeaderText="最后发帖时间" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
</asp:Content>

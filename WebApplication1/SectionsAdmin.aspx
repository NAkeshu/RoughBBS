<%@ Page Title="" Language="C#" MasterPageFile="~/header.Master" AutoEventWireup="true" CodeBehind="SectionsAdmin.aspx.cs" Inherits="WebApplication1.SectionAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>版区管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:auto; text-align:center;">
        <h1>管理版区，点击版区名可以进入该版区管理帖子</h1>
    </div>
    
    <asp:GridView ID="SectionsAdmin" Width="100%" AutoGenerateColumns="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" DataSourceID="SqlDataSource1" AllowPaging="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="sectionname" DataNavigateUrlFormatString="PostsAdmin.aspx?section={0}" DataTextField="sectionname" HeaderText="版区">
            <ItemStyle HorizontalAlign="Center" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="sectiondetail" HeaderText="简介" SortExpression="sectiondetail">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="username" HeaderText="版主" SortExpression="username">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="lastposttime" HeaderText="最后发帖时间">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
    SelectCommand="select * from section, users where ownerid=userid">
</asp:SqlDataSource>
    <hr />
    <h3>操作</h3>
    <h4>新增板块</h4>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="板块名称："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="newsectionname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="简介："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="newsectiondetail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="版主id："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="newownerid" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="newsectionBTN" runat="server" Text="新建板块" OnClick="createnewsection" />
            </td>
        </tr>
    </table>
    <h4>删除版区</h4>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="板块："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="deletesectionname" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="deleteBTN" runat="server" Text="删除" OnClick="deletesection" />
            </td>
        </tr>
    </table>
    <h4>更新版区</h4>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="版区："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="updatesectionname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="新版区名："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="newnametext" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="updatename" runat="server" Text="更新" OnClick="changesectionname" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="新简介："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="newdetail" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="updatedetail" runat="server" Text="更新" OnClick="changesectiondetail" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="新版主(id)："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="newowner" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="updateowner" runat="server" Text="更新" OnClick="changesectionowner" />
            </td>
        </tr>
    </table>
</asp:Content>

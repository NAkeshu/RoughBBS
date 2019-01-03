<%@ Page Title="" Language="C#" MasterPageFile="~/header.Master" AutoEventWireup="true" CodeBehind="PostsList.aspx.cs" Inherits="WebApplication1.PostsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>
        BBSBBSBBS--<%=Request.QueryString["section"].ToString() %>
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="SectionInfo" style="width:100%; border:dotted;">
        <tr>
            <th style="text-align:center; width:100%">
                <asp:Label ID="SectionNameInfo" runat="server" Text="" Width="100%" BackColor="#79CDCD"></asp:Label>
            </th>
        </tr>
        <tr>
            <td style="text-align:center; width:100%">
                <asp:Label ID="SectionDetailInfo" runat="server" Text="" Width="100%"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Button ID="backtoSections" runat="server" Text="返回板块列表" OnClick="backtoRefferer" />
    <asp:Button ID="Post_Top" runat="server" Text="发帖！" OnClick="Post_Click" />
    <asp:GridView ID="PostsListGV" runat="server" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <Columns>
            <asp:BoundField DataField="isstar" ShowHeader="False" >
            <ControlStyle Width="2em" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="topic,postid" DataNavigateUrlFormatString="PostDetail.aspx?topic={0}&id={1}" DataTextField="topic" HeaderText="主题" />
            <asp:BoundField DataField="username" HeaderText="作者" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="posttime" HeaderText="发表时间" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="commentnum" HeaderText="评论数" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="lastcommenttime" HeaderText="最新评论时间" >
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
    <asp:Button ID="Post_Bottom" runat="server" Text="发帖！" OnClick="Post_Click" />
</asp:Content>

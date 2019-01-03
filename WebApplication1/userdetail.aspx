<%@ Page Title="" Language="C#" MasterPageFile="~/header.Master" AutoEventWireup="true" CodeBehind="userdetail.aspx.cs" Inherits="WebApplication1.userdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>个人空间</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:Label ID="name" runat="server" Text=""></asp:Label>
    </h1>
    <h3>
        <asp:Label ID="id" runat="server" Text=""></asp:Label>
    </h3>
    <hr />
    <h4>个人资料</h4>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="发帖："></asp:Label>
            </td>
            <td>
                <asp:Label ID="posts" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="postslist" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="postid" HeaderText="帖子ID">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="isstar" HeaderText="加精">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="topic,postid" DataNavigateUrlFormatString="PostDetail.aspx?topic={0}&amp;id={1}" DataTextField="topic" HeaderText="主题">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField DataNavigateUrlFields="sectionname" DataNavigateUrlFormatString="PostsList.aspx?section={0}" DataTextField="sectionname" HeaderText="版区">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="posttime" HeaderText="发表时间">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="commentnum" HeaderText="评论数">
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
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="评论："></asp:Label>
            </td>
            <td>
                <asp:Label ID="comments" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="commentslist" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="topic,postid" DataNavigateUrlFormatString="PostDetail.aspx?topic={0}&amp;id={1}" DataTextField="topic" HeaderText="原主题">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="floor" HeaderText="楼层">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="text" HeaderText="评论内容">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="commenttime" HeaderText="评论时间">
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
            </td>
        </tr>
    </table>
    <hr />
    <h4>账户管理</h4>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="账号："></asp:Label>
            </td>
            <td>
                <asp:Label ID="useridinfo" runat="server" Text=""></asp:Label>
            </td>
            <td colspan="2">
                <asp:Label ID="cannotchange" runat="server" Text="不可修改"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="昵称："></asp:Label>
            </td>
            <td>
                <asp:Label ID="oldname" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="newname" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="chnameBTN" runat="server" Text="修改昵称" OnClick="changeusername" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="邮箱："></asp:Label>
            </td>
            <td>
                <asp:Label ID="oldmail" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="newmail" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="chmailBTN" runat="server" Text="修改邮箱" OnClick="changeemail" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="密码："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="oldpassword" TextMode="Password" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="newpassword" TextMode="Password" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="chpwdBTN" runat="server" Text="修改密码" OnClick="changepassword" />
            </td>
        </tr>
        </table>
</asp:Content>

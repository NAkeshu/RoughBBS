<%@ Page Title="" Language="C#" MasterPageFile="~/header.Master" AutoEventWireup="true" CodeBehind="PostDetail.aspx.cs" Inherits="WebApplication1.PostDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title id="PostDetailID">
        BBSBBSBBS--<%=Request.QueryString["topic"].ToString() %>
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="back" runat="server" Text="返回文章列表" OnClick="backtoRefferer" />
    <table>
        <tr>
            <td>
                <h1 id="PostTopic"><%=Request.QueryString["topic"].ToString() %></h1>
            </td>
        </tr>
        <tr>
            <asp:GridView ID="PostDetailGV" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="username" HeaderText="作者">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="text" HeaderText="文章内容">
                    <ItemStyle Width="70%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="posttime" HeaderText="发表时间">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField >
                        <ItemTemplate>
                            <asp:Button ID="CommentToPost" runat="server" Text="评论" OnClick="commentthePost" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </tr>
    </table>
    <h3>评论(<%Response.Write(countCommentNum().ToString()); %>)>>>>>></h3>
    <div>
        <asp:GridView ID="CommentsList" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="CommentsList_RowCommand">
            <Columns>
                <asp:BoundField DataField="floor" HeaderText="楼层">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="username" HeaderText="用户名">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="text" HeaderText="评论内容">
                    <ItemStyle Width="60%" />
                </asp:BoundField>
                <asp:BoundField DataField="commenttime" HeaderText="评论时间" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:ButtonField ButtonType="Button" Text="评论" CommandName="commenttoComment" />
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
    </div>
</asp:Content>

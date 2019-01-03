<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comment.aspx.cs" Inherits="WebApplication1.Comment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>评论</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="backtopost" runat="server" Text="返回" OnClick="backtoPostDetail" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="账户名："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="user" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="评论给："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="commenttowho" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="CommentText" runat="server" TextMode="MultiLine" Rows="6" Columns="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="评论时间："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="commenttime" runat="server" Text=""></asp:Label>
                    </td>
                    <td></td>
                    <td>
                        <asp:Button ID="comment" runat="server" Text="评论" OnClick="submitComment" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

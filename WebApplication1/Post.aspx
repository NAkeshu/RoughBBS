<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="WebApplication1.Post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>发布新的帖子！</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="backtolist" runat="server" Text="返回" OnClick="backtoPostsList" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="作者："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="authorni" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="分组："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="SectionName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="主题："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="posttopic" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="posttext" runat="server"  TextMode="MultiLine" Rows="10" Columns="150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="发布时间："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="posttime" runat="server" Text=""></asp:Label>
                    </td>
                    <td>

                    </td>
                    <td>
                        <asp:Button ID="submit" runat="server" Text="发布！" OnClick="submitPost" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

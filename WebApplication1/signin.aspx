<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="WebApplication1.signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录登录登录</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="用户ID"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="UserIDText" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="PasswordText" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="submit" runat="server" Text="登录" Width="100%" OnClick="submit_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="signupBTN" runat="server" Text="去注册" OnClick="signupBTN_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>    
        </div>
    </form>
</body>
</html>

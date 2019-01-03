<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="WebApplication1.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>注册注册注册</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="账号"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="IDText" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*账号必须输入" ControlToValidate="IDText"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="昵称"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="UsernameText" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="NameRequire" runat="server" ErrorMessage="*昵称必须输入" ControlToValidate="UsernameText"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="PasswordText" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="PwdRequire" runat="server" ErrorMessage="*密码必须输入" ControlToValidate="PasswordText"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="确认密码"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="ensurePassword" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:CompareValidator ID="PwdCompare" runat="server" ControlToValidate="ensurePassword" ControlToCompare="PasswordText" ErrorMessage="*密码不一致"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="邮箱"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="EmailText" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="EmailRequire" runat="server" ControlToValidate="EmailText" ErrorMessage="*邮箱必须填写"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="submit" runat="server" Text="注册" Width="100%" OnClick="submit_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="Button1" runat="server" Text="已有账号，直接登录" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

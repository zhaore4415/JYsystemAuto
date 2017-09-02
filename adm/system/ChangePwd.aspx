<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="NH.Web.adm.ChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <%=CssAndScript %>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    旧密码：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtOldPassword" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    新密码：
                </th>
                <td>
                    
                    <asp:TextBox runat="server" ID="txtPassword1" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    新密码：
                </th>
                <td>
                    
                    <asp:TextBox runat="server" ID="txtPassword2" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="修改" CssClass="btnSubmit" onclick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

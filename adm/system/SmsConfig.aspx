<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmsConfig.aspx.cs" Inherits="NH.Web.adm.system.SmsConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    帐户信息：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbInfo"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    机构ID：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtId"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    用户名：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtAccount"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    密码：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    发送手机号码：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtFrom"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btnSubmit" onclick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

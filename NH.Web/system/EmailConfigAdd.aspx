<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailConfigAdd.aspx.cs" Inherits="NH.Web.adm.system.EmailConfigAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
</head>
<body>
    <form id="form1" runat="server">
   <div class="table-add">
        <div class="frmborder">
            <p>
                <a href="<%=ListUrl %>">发件邮箱管理</a> -> 添加</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    SMTP服务器：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtServer"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    邮箱账号：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtAccount"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    邮箱密码：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    端口号：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPort">25</asp:TextBox>(数字)
                </td>
            </tr>
            <tr style=" display:none;">
                <th>
                    发件人名称：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtSender"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    是否身份验证：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblAuthentication" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>
                    是否SSL加密：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblSSL" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>
                    状　　态：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblIsShow" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">显示</asp:ListItem>
                        <asp:ListItem Value="0">关闭</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btnSubmit" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

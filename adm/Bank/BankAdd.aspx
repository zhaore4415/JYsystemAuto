<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankAdd.aspx.cs" Inherits="NH.Web.adm.Bank.BankAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
        <div class="frmborder">
            <p>
                <a href="<%=ListUrl %>">汇款账号管理</a> -> 添加</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    银行名称：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    银行账号：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtAccount" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    支行名称：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtBranchName" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    银行图标：
                </th>
                <td>
                    <asp:FileUpload runat="server" ID="file" />
                </td>
            </tr>
            <tr>
                <th>
                    状　　态：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblStatus" RepeatLayout="Flow" RepeatDirection="Horizontal">
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

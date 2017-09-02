<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyLevelModify.aspx.cs" Inherits="NH.Web.adm.CompanyLevel.CompanyLevelModify" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%=CssAndScript %>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
        <div class="frmborder">
            <p>
                <a href="<%=ListUrl %>">VIP等级管理</a> -> 编辑</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    等级名称：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    价格：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPrice"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>服务描述：</th>
                <td><asp:TextBox runat="server" ID="txtDesc" Columns="80" Rows="10" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <asp:PlaceHolder runat="server" ID="phDesc2">
            <tr>
                <th>特权描述：</th>
                <td><asp:TextBox runat="server" ID="txtDesc2" Columns="80" Rows="10" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            </asp:PlaceHolder>
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

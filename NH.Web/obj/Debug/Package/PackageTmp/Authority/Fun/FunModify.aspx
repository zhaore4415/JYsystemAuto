<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FunModify.aspx.cs" Inherits="NH.Web.adm.Authority.Fun.FunModify" %>

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
                <a href="<%=ListUrl %>">功能码管理</a> -> 添加</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    功能名称：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    功能码：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtCode"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    功能码类型：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblFunType" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1" Selected="True">查询</asp:ListItem>
                        <asp:ListItem Value="2">添加/编辑</asp:ListItem>
                        <asp:ListItem Value="3">删除</asp:ListItem>
                        <asp:ListItem Value="4">方法控制</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>
                    所属组：
                </th>
                <td>
                    <asp:DropDownList runat="server" ID="ddlParent"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btnSubmit" OnClick="btnSubmit_Click" />
                    <input type="button" class="btnSubmit" value="返回" onclick="javascript:window.location.href='<%=ListUrl %>'" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

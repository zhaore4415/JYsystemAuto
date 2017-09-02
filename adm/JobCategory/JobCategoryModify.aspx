<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobCategoryModify.aspx.cs" Inherits="NH.Web.adm.JobCategory.JobCategoryModify" %>

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
                <a href="<%=ListUrl %>">职位类别管理</a>->添加职位类别</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
        <tr>
            <th>上级分类：</th>
            <td>
                <asp:DropDownList runat="server" ID="ddlCategory">
                    <asp:ListItem Selected="True" Value="0">作为顶级分类</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>分类名称：</th>
            <td>
                <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>排序：</th>
            <td>
                <asp:TextBox runat="server" ID="txtSort"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>状态：</th>
            <td>
                <asp:RadioButtonList runat="server" ID="rblStatus" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="1">显示</asp:ListItem>
                    <asp:ListItem Value="0">隐藏</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <th></th>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btnSubmit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
    </div>
    
    </form>
</body>
</html>

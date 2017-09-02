<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FriendLinkModify.aspx.cs" Inherits="NH.Web.adm.FriendLink.FriendLinkModify" %>

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
                <a href="FriendLink.aspx">友情链接管理</a> -> 修改</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    网站名称：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    网　　址：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtUrl"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    排　　序：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtSort">1</asp:TextBox>(数字，值越小排在越靠前)
                </td>
            </tr>
            <tr>
                <th>
                    联系人：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtContact"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    联系电话：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox>
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

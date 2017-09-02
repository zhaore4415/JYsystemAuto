<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="NH.Web.adm.OnlineService.Contact" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <%=CssAndScript %>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
        <div class="frmborder">
            <p>
                联系方式</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    400客服电话：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtServiceTel1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    客服电话(非400)：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtServiceTel2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    首页友情链接联系方式：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtFriendLinkContact"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>联系方式描述信息：</th>
                <td>
                    <CKEditor:CKEditorControl ID="ckContact" runat="server" BasePath="../_ckeditor"></CKEditor:CKEditorControl>
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

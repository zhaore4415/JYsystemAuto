<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleModify.aspx.cs" Inherits="NH.Web.adm.Article.ArticleModify" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

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
            <p><a href="<%=ListUrl %>">文章管理</a> -> 添加</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>所属分类：</th>
                <td>
                    <asp:DropDownList runat="server" ID="ddlCategory">                        
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    标题：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtTitle" Width="400" CssClass="txtCls"></asp:TextBox>&nbsp;&nbsp;<asp:CheckBox runat="server" ID="chkHilight" Text="标题高亮显示" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <th>
                    链接地址：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtUrl" CssClass="txtCls" Width="200"></asp:TextBox><span>如果填写了链接地址，将会跳转到指定的这个地址，链接要以http://开头</span>
                </td>
            </tr>
            <tr>
                <th>
                    内容：
                </th>
                <td><%--<asp:Editor runat="server" ID="txtcontent" BasePath="OnflyEditor/" Height="320px" />--%>
                    <CKEditor:CKEditorControl ID="ckContent" runat="server" BasePath="../_ckeditor"></CKEditor:CKEditorControl>
                </td>
            </tr>
            <tr>
                <th>
                    状态：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblStatus" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1" Selected="True">发布</asp:ListItem>
                        <asp:ListItem Value="0">关闭</asp:ListItem>
                    </asp:RadioButtonList>
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

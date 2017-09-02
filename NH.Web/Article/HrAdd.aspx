<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HrAdd.aspx.cs" Inherits="NH.Web.adm.Article.HrAdd" %>
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
            <p><a href="HrList.aspx">Hr工具管理</a>->添加</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    所属分类：
                </th>
                <td>
                    <asp:DropDownList runat="server" ID="ddlCategory">
                        <asp:ListItem Value="0">选择分类</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    标题：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtTitle" CssClass="txtCls"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    上传文件：
                </th>
                <td>
                    <asp:FileUpload runat="server" ID="file" />
                </td>
            </tr>
            <tr>
                <th>
                    描述：
                </th>
                <td><%--<asp:Editor runat="server" ID="txtcontent" BasePath="OnflyEditor/" Height="220px" />--%>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteInfo.aspx.cs" Inherits="NH.Web.adm.SiteInfo" %>
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
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    网站名称：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtSiteName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    网页标题：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtSiteTitle" Width="400"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    网页关键字：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtSiteKeyword" TextMode="MultiLine" Columns="60" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    网页描述：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtSiteDescription" TextMode="MultiLine" Columns="60" Rows="5"></asp:TextBox>
                </td>
            </tr>
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
                <th>
                    开启手机短信验证：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblIsMobileValidate" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1" Selected="True">开启</asp:ListItem>
                        <asp:ListItem Value="0">关闭</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>网页底部内容：</th>
                <td>
                    <CKEditor:CKEditorControl ID="ckFoot" runat="server" BasePath="../_ckeditor"></CKEditor:CKEditorControl>
                </td>
            </tr>
            <tr>
                <th>水印图片：</th>
                <td>
                    <asp:Image runat="server" ID="imgWaterMarkPic" /><br /><br />
                    <asp:FileUpload runat="server" ID="fileWaterMarkPic" />(点击重新上传图片)
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

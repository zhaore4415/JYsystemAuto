<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyHelpmate.aspx.cs" Inherits="NH.Web.adm.Company.CompanyHelpmate" %>
<%--<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript" src="../_ckeditor/ckeditor.js"></script>
    <form id="formHelpmate" runat="server">
    <div>
        <div class="frmborder">
            <p>
                招聘伴侣</p>
        </div>
        <asp:PlaceHolder runat="server" ID="phContent">
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    企业等级：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbInfo"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    职位：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbJobCategory"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    地区：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbArea"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    Email：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbEmail"></asp:Label><asp:CheckBox runat="server" ID="cbEmail" Text="发送Email" />
                </td>
            </tr>
            <%--<tr>
                <th>
                    手机：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbMobile"></asp:Label><asp:CheckBox runat="server" ID="cbMobile" Text="发送Email" />
                </td>
            </tr>--%>
            <tr>
                <th>
                    内容：
                </th>
                <td>
                    <textarea name="ckContent" rows="2" cols="20" id="ckContent"></textarea>
                    <%--<script type="text/javascript">
                        CKEDITOR.replace('ckContent');
                    </script>--%>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <a id="btnYes" class="easyui-linkbutton" iconCls="icon-ok">发送</a>
                </td>
            </tr>
        </table>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phEmpty">
        <div>暂无资料</div>
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>

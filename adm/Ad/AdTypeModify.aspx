<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdTypeModify.aspx.cs" Inherits="NH.Web.adm.Ad.AdTypeModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ddlCategory').change(function () {
                $('#desc').html($(this).find('option:selected').attr('desc'));
            }).change();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
    <div class="frmborder">
            <p><a href="<%=ListUrl %>">广告位类别管理</a> -> 修改</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    广告位名称：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtName" CssClass="txtCls"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    广告显示数量：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtShowCount" CssClass="txtCls"></asp:TextBox>(0表示不限数量)
                </td>
            </tr>
            <tr>
                <th>
                    备注：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
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

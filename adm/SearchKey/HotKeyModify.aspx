<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotKeyModify.aspx.cs" Inherits="NH.Web.adm.SearchKey.HotKeyModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%=CssAndScript %>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ddlStyle').change(function () {
                $('#txtKeyName').removeClass().addClass('txtCls').addClass('style' + $(this).val());
            }).change();
        });
    </script>
    <style type="text/css">
        .style1{ color:#000000;}
        .style2{font-weight:bold; color:#000000;}
        .style3{font-weight:bold; color:#1a94dd}
        .style4{font-size:14px; color:#000000;}
        .style5{font-size:14px; font-weight:bold; color:#000000;}
        .style6{font-size:14px; font-weight:bold; color:#1a94dd}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
    <div class="frmborder">
            <p><a href="<%=ListUrl %>">热门关键词管理</a> -> 修改</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    关键词：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtKeyName" CssClass="txtCls"></asp:TextBox>
                    文字样式：<asp:DropDownList runat="server" ID="ddlStyle">
                        <asp:ListItem Value="1">样式1(12像素)</asp:ListItem>
                        <asp:ListItem Value="2">样式2(12像素,加粗)</asp:ListItem>
                        <asp:ListItem Value="3">样式3(12像素,加粗,蓝色)</asp:ListItem>
                        <asp:ListItem Value="4">样式4(14像素)</asp:ListItem>
                        <asp:ListItem Value="5">样式5(14像素,加粗)</asp:ListItem>
                        <asp:ListItem Value="6">样式6(14像素,加粗,蓝色)</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    链接地址：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtUrl" CssClass="txtCls" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    排序：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtSort" CssClass="txtCls"></asp:TextBox>
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

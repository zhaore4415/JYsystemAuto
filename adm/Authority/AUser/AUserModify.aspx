<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AUserModify.aspx.cs" Inherits="NH.Web.adm.Authority.AUser.AUserModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%=CssAndScript %>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[name=rblRoleType]').click(function () {
                if ($('[name=rblRoleType]:checked').val() == "0") {
                    $('#RolesList').show();
                } else {
                    $('#RolesList').hide();
                }
            }).filter(':checked').click();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
        <div class="frmborder">
            <p>
                <a href="<%=ListUrl %>">管理员帐号管理</a> -> 修改</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    登录帐号：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtLoginName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    登录密码：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword1" TextMode="Password"></asp:TextBox>(输入内容则修改密码，否则不修改)
                </td>
            </tr>
            <tr>
                <th>
                    确认密码：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword2" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    姓名：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtRealname"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    角色：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblRoleType" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0" Selected="True">普通管理员</asp:ListItem>
                        <asp:ListItem Value="1">超级管理员</asp:ListItem>
                    </asp:RadioButtonList>
                    <div id="RolesList" style=" display:none;">
                        选择普通管理员角色<br />
                        <asp:CheckBoxList runat="server" ID="chkRoles" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                    </div>
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

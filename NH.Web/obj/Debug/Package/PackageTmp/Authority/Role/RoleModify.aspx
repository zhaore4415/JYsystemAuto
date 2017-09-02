<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleModify.aspx.cs" Inherits="NH.Web.adm.Authority.Role.RoleModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%=CssAndScript %>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id^=fungroup_]').click(function () {
                $(this).parent().find(':checkbox').attr('checked', ($(this).attr('checked') ? true : false));
            });

            $('#btnSubmit').click(function () {
                if ($.trim($('#txtName').val()) == '') { alert('请填写角色名称'); return false; }
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
        <div class="frmborder">
            <p>
                <a href="<%=ListUrl %>">角色管理</a> -> 添加</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    角色名称：
                </th>
                <td>
                    <input type='checkbox' id='fungroup_{0}' disabled="disabled" />
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    操作权限：
                </th>
                <td>
                    <asp:Literal runat="server" ID="ltrFunCode"></asp:Literal>
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

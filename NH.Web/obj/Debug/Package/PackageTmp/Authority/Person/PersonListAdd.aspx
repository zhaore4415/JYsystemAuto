<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonListAdd.aspx.cs"
    Inherits="NH.Web.adm.Person.PersonReg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <%=CssAndScript %>
    <%--<%=EasyUI_CssAndScript %>--%>
    <script type="text/javascript">
        $(document).ajaxStart(function () {

        }).ajaxSend(function (e, jqxhr, settings) {
            if (/(\?|&)ajax=/.test(settings.url) == false) {
                if (settings.url.indexOf('?') == -1) {
                    settings.url += '?ajax=1';
                } else {
                    settings.url += '&ajax=1';
                }
            };
        });
        $.ajaxSetup({ type: 'post', dataType: 'json' });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="table-add">
        <div class="frmborder">
            <p>
                客户管理 -> 添加客户</p>
        </div>
        <div class="tbitem">
            <table width="100%" cellpadding="0" cellspacing="0" class="utable">
                <tr>
                    <th>
                        来源：
                    </th>
                    <td>
                        <asp:TextBox runat="server" ID="txtSource"></asp:TextBox>
                    </td>
                    <th>
                        微信号
                    </th>
                    <td>
                        <asp:TextBox runat="server" ID="txtText1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <span class="red">*</span>用户名：
                    </th>
                    <td>
                        <asp:TextBox runat="server" ID="txtLoginName"></asp:TextBox>
                    </td>
                    <th>
                        性别：
                    </th>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rblSex" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            CssClass="noinputbg">
                            <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                            <asp:ListItem Value="0">女</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <th>
                        <span class="red">*</span>手机号码：
                    </th>
                    <td>
                        <asp:TextBox runat="server" ID="txtMobile"></asp:TextBox>
                    </td>
                    <th>
                        QQ号：
                    </th>
                    <td>
                        <asp:TextBox runat="server" ID="txtQQ"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Email：
                    </th>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                    </td>
                    <th>
                        联系地址：
                    </th>
                    <td>
                        <asp:TextBox runat="server" ID="txtAddress"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        居住环境
                    </th>
                    <td>
                        <asp:TextBox runat="server" ID="txtEnvironment"></asp:TextBox>
                    </td>
                    <th>
                    </th>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        <div class="tbitem">
            <table width="100%" cellpadding="0" cellspacing="0" class="utable">
                <tr>
                    <th>
                    </th>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btnSubmit" OnClick="btnSubmit_Click"
                            OnClientClick="return beforsubmit();" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=form1.ClientID %>').ajaxForm({
                beforeSubmit: function () {
                    return true;
                    //return beforsubmit();
                }, success: function (data) {
                    switch (data.status) {
                        case 'ok':
                            alert('添加成功');
                            window.location.href = window.location.href;
                            break;
                        case 'error':
                            alert(data.msg);
                            break;
                        case "nologin":
                            alert('请登录');
                            break;
                    }
                },
                error: function () { alert('发生错误'); }
            });
        });
    </script>
    <%--   <script type="text/javascript">
        $("#ddlJobAddress").jAreaSelect({ select: 3, is_province: true });
        $("#ddlJobCategory").jJobSelect({ select: 3 });
    </script>
    <script type="text/javascript">
        function NewExp() {
            var objNew = $('#temp').clone().show().addClass("exptemplate");

            $('#btnAddNewExp').before(objNew);
            objNew.find('.txtStartTime,.txtEndTime').datepicker({
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1950:<%=DateTime.Now.Year %>',
                dateFormat: "yy-mm-dd",
                yearSuffix: '',
                beforeShow: function () {
                    setTimeout(function () {
                        $('#ui-datepicker-div').css('z-index', '1000');
                    }, 0);
                }
            });
            objNew.find('.delete').click(function () {
                if (!confirm('确定要删除吗？')) { return false; }
                objNew.remove();
                $('#expcount').val($('.exptemplate').length);
            });
            $('#expcount').val($('.exptemplate').length);

        }
    </script>--%>
</body>
</html>

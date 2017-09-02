<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonIdentityVerify.aspx.cs" Inherits="NH.Web.adm.Person.PersonIdentityVerify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        function VerifyIdentity(objLink,status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【审核通过】" : "【审核不通过】") + "吗？")) { return false; }
            $.ajax({
                url: 'PersonIdentityVerify.aspx?id=<%=Id %>&ajax=1',
                data: { 'action': 'verify', 'status': status },
                type: 'post',
                dataType: 'json',
                success: function (data) {
                    switch (data.status) {
                        case "nologin":
                            alert('请先登录');
                            break;
                        case "nopower":
                            alert('没有此操作的权限');
                            break;
                        case "error":
                            alert(data.msg);
                            break;
                        case "ok":
                            alert('操作成功');
                            if (status == 1) {
                                $('#btnYes').linkbutton('disable');
                                $('#btnNo').linkbutton('enable');
                                $('#lbStatus').html('审核通过');
                            } else {
                                $('#btnYes').linkbutton('enable');
                                $('#btnNo').linkbutton('disable');
                                $('#lbStatus').html('审核不通过');
                            }
                            break;

                    }
                }
            })
        }
    </script>
    <form id="formPersonIdentityVerify">
    <div>
        <div class="frmborder">
            <p>
                实名认证</p>
        </div>
        <asp:PlaceHolder runat="server" ID="phContent">
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    审核状态：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbStatus"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    身份证号码：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbIdentityNo"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    身份证有效期：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbExpireDate"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    性别：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbSex"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    联系电话：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbTel"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    性别：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbQQ"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    身份证附件：
                </th>
                <td>
                    <asp:Image runat="server" ID="imgIdentity" Visible="false" />
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <a id="btnYes" class="easyui-linkbutton" iconCls="icon-ok" <%=_status == 1 ? "disabled='true'" : ""%> onclick="javascript:VerifyIdentity(this,1)">审核通过</a>
                    <a id="btnNo" class="easyui-linkbutton" iconCls="icon-no" <%=_status == -1 ? "disabled='true'" : ""%> onclick="javascript:VerifyIdentity(this,-1)">审核不通过</a>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyIdentityVerify.aspx.cs" Inherits="NH.Web.adm.Company.CompanyIdentityVerify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <script type="text/javascript">
        function VerifyAuthenticate() {
            $.ajax({
                url: 'CompanyIdentityVerify.aspx?companyId=<%=_companyId %>&id=<%=_verifyId %>&ajax=1&action=verify',
                data: $('#formPersonIdentityVerify').serialize(),
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
                            break;
                    }
                }
            })
        }
    </script>
    <form id="formPersonIdentityVerify" runat="server">
    <div>
        <div class="frmborder">
            <p>
                企业认证</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>认证资料：</th>
                <td>
        <asp:PlaceHolder runat="server" ID="phContent">
                    <table width="100%" cellpadding="0" cellspacing="0" class="utable">
                        <%--<tr>
                            <th>
                                审核状态：
                            </th>
                            <td>
                                <asp:Label runat="server" ID="lbStatus"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <th>
                                营业执照号：
                            </th>
                            <td>
                                <asp:Label runat="server" ID="lbLicenceNo"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                执照有效期：
                            </th>
                            <td>
                                <asp:Label runat="server" ID="lbExpireDate"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                联系人：
                            </th>
                            <td>
                                <asp:Label runat="server" ID="lbContact"></asp:Label>
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
                                QQ：
                            </th>
                            <td>
                                <asp:Label runat="server" ID="lbQQ"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                营业执照附件：
                            </th>
                            <td>
                                <asp:Image runat="server" ID="imgIdentity" Visible="false" />
                            </td>
                        </tr>
                        <%--<tr>
                            <th>
                            </th>
                            <td>
                                <a id="btnYes" class="easyui-linkbutton" iconCls="icon-ok" <%=_status == 1 ? "disabled='true'" : ""%> onclick="javascript:VerifyIdentity(this,1)">审核通过</a>
                                <a id="btnNo" class="easyui-linkbutton" iconCls="icon-no" <%=_status == -1 ? "disabled='true'" : ""%> onclick="javascript:VerifyIdentity(this,-1)">审核不通过</a>
                            </td>
                        </tr>--%>
                    </table>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phEmpty">
        <div>暂无资料</div>
        </asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <th>认证选项：</th>
                <td>
                    <asp:CheckBox runat="server" ID="cbIdentityVerified" Text="认证企业" />
                    <asp:CheckBox runat="server" ID="cbIsFoodAdd" Text="餐补" />
                    <asp:CheckBox runat="server" ID="cbIsOfferRoom" Text="包住" />
                    <asp:CheckBox runat="server" ID="cbIsOfferFood" Text="包吃" />
                    <asp:CheckBox runat="server" ID="cbIsFiveInsurance" Text="五险" />
                    <asp:CheckBox runat="server" ID="cbIsFund" Text="一金" />
                    <asp:CheckBox runat="server" ID="cbIsCarFare" Text="车费报销" />
                    <asp:CheckBox runat="server" ID="cbIsYearGuarantee" Text="年度保障优质企业" />
                </td>
            </tr>
            <%--<tr>
                <th>认证企业：</th>
                <td>
                    <asp:CheckBox runat="server" ID="cbIdentityVerified" Text="认证企业" />
                </td>
            </tr>
            <tr>
                <th>餐补：</th>
                <td><asp:CheckBox runat="server" ID="cbIsFoodAdd" /></td>
            </tr>
            <tr>
                <th>包住：</th>
                <td><asp:CheckBox runat="server" ID="cbIsOfferRoom" /></td>
            </tr>
            <tr>
                <th>包吃：</th>
                <td><asp:CheckBox runat="server" ID="cbIsOfferFood" /></td>
            </tr>
            <tr>
                <th>五险：</th>
                <td><asp:CheckBox runat="server" ID="cbIsFiveInsurance" /></td>
            </tr>
            <tr>
                <th>一金：</th>
                <td><asp:CheckBox runat="server" ID="cbIsFund" /></td>
            </tr>
            <tr>
                <th>车费报销：</th>
                <td><asp:CheckBox runat="server" ID="cbIsCarFare" /></td>
            </tr>
            <tr>
                <th>年度保障优质企业：</th>
                <td><asp:CheckBox runat="server" ID="cbIsYearGuarantee" /></td>
            </tr>--%>
            <tr>
                <th></th>
                <td><a class="easyui-linkbutton" iconCls="icon-save" onclick="javascript:VerifyAuthenticate()">提交</a></td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>

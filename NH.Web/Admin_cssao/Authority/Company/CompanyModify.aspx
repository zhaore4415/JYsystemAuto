<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyModify.aspx.cs"
    Inherits="NH.Web.adm.Company.CompanyModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
      <title>巴克后台管理专业版</title>
    <script language="javascript" type="text/javascript" src="/My97DatePickerBeta/My97DatePicker/WdatePicker.js"></script>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/css/iframe.css" media="screen" />
</head>
<body>
    <form id="formEdit" runat="server" enableviewstate="false">
     <div id="shoufei">
        <div class="shoufei_con">
            <div class="sf">
                <div class="sf_tit">
                    <p>
                        省市县管理 -> 修改</p>
                    <span><a href="javascript:void(0)" onclick="javascript:window.self.close();">
                        <img src="/images/xx.gif" width="24" height="24" /></a></span>
                </div>
                <div class="sf_con">
                    <table width="748" border="1" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="186" align="center" valign="middle" bgcolor="#F6F6F6">
                                修改省
                            </td>
                            <td width="126" align="center">
                                <asp:DropDownList runat="server" ID="ddlBranchOne" AutoPostBack="true" OnTextChanged="ddlBranchOne_TextChanged">
                                    <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="186" align="center" valign="middle">
                                <asp:TextBox ID="txtshen" runat="server" CssClass="in_input"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnshen" runat="server" Text="修改" CssClass="sf_buts" OnClick="btnshen_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="186" align="center" valign="middle" bgcolor="#F6F6F6">
                                修改市
                            </td>
                            <td width="126" align="center">
                                <asp:DropDownList runat="server" ID="ddlBranchTwo" AutoPostBack="true" OnTextChanged="ddlBranchTwo_TextChanged">
                                    <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="186" align="center" valign="middle">
                                <asp:TextBox ID="txtshi" runat="server" CssClass="in_input"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnshi" runat="server" Text="修改" CssClass="sf_buts" OnClick="btnshi_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="186" align="center" valign="middle" bgcolor="#F6F6F6">
                                修改县
                            </td>
                            <td width="126" align="center">
                                <asp:DropDownList runat="server" ID="ddlBranchThird">
                                    <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="186" align="center" valign="middle">
                                <asp:TextBox ID="txtxian" runat="server" CssClass="in_input"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnxian" runat="server" Text="修改" CssClass="sf_buts" OnClick="btnxian_Click" />
                            </td>
                        </tr>
                        <%--<tr>
                            <td width="186" align="center" valign="middle" bgcolor="#F6F6F6">
                                备注
                            </td>
                            <td colspan="3" align="center" valign="middle">
                                <asp:TextBox runat="server" ID="txtRemark" CssClass="in_input"></asp:TextBox>
                            </td>
                        </tr>--%>
                    </table>
                    <%--<asp:Button ID="btnSubmit" runat="server" Text="" CssClass="sf_but" OnClick="btnSubmit_Click" OnClientClick="return beforsubmit()"/>--%>
                </div>
            </div>
        </div>
    </div>
    </form>
   
   
    <script type="text/javascript">

        function ChangeLoginStatus(status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【启用】" : "【禁用】") + "吗？")) { return false; }
            $.ajax({
                url: $('#formEdit').attr('action') + '&ajax=1',
                data: { 'action': 'ChangeLoginStatus', 'status': status },
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
                                $('#btnLoginYes').linkbutton('disable');
                                $('#btnLoginNo').linkbutton('enable');
                                $('#lbStatus').text('启用');
                            } else {
                                $('#btnLoginYes').linkbutton('enable');
                                $('#btnLoginNo').linkbutton('disable');
                                $('#lbStatus').text('禁用');
                            }
                            break;

                    }
                }
            })
        }
    </script>
    <script type="text/javascript">
        function VerifyNewInfo(status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【审核通过】" : "【审核不通过】") + "吗？")) { return false; }
            $.ajax({
                url: $('#formEdit').attr('action') + '&ajax=1',
                data: { 'action': 'VerifyNewInfo', 'status': status },
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
                            window.location.href = window.location.href
                            if (status == 1) {
                                $('#btnVerifyNewYes').linkbutton('disable');
                                $('#btnVerifyNewNo').linkbutton('enable');
                            } else {
                                $('#btnVerifyNewYes').linkbutton('enable');
                                $('#btnShowNo').linkbutton('disable');
                            }
                            break;

                    }
                }
            })
        }
    </script>
</body>
</html>

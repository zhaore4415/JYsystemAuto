<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyAdd.aspx.cs" Inherits="NH.Web.adm.Company.CompanyReg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>巴克后台管理专业版</title>
    <script language="javascript" type="text/javascript" src="/My97DatePickerBeta/My97DatePicker/WdatePicker.js"></script>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/css/iframe.css" media="screen" />
    <%--  <script type="text/javascript">
         function beforsubmit() {
             try {
//                 alert($.trim($('#txtshen').val()));
                 if ($.trim($('#txtshen').val()) == "") { alert('请填写省名称'); return false; };
                 if ($.trim($('#txtshi').val()) == "") { alert('请填写市名称'); return false; };
                 if ($.trim($('#txtxian').val()) == "") { alert('请填写县或区名称'); return false; };
                
                 return true;

             }
             catch (err) {
                 alert("error:" + err.Description);
                 return false;
             }
         }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div id="shoufei">
        <div class="shoufei_con">
            <div class="sf">
                <div class="sf_tit">
                    <p>
                        省市县管理 -> 添加</p>
                    <span><a href="javascript:void(0)" onclick="javascript:window.self.close();">
                        <img src="/images/xx.gif" width="24" height="24" /></a></span>
                </div>
                <div class="sf_con">
                    <table width="748" border="1" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="186" align="center" valign="middle" bgcolor="#F6F6F6">
                                添加省
                            </td>
                            <td width="126" align="center">
                                <span class="imgright">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/xx.gif" Width="20"
                                        Height="20" OnClick="ImageButton1_Click" /></span>
                                <asp:DropDownList runat="server" ID="ddlBranchOne" AutoPostBack="true" OnTextChanged="ddlBranchOne_TextChanged">
                                    <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="186" align="center" valign="middle">
                                <asp:TextBox ID="txtshen" runat="server" CssClass="in_input"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnshen" runat="server" Text="添加" CssClass="sf_buts" OnClick="btnshen_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="186" align="center" valign="middle" bgcolor="#F6F6F6">
                                添加市
                            </td>
                            <td width="126" align="center">
                                <span class="imgright">
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="/images/xx.gif" Width="20"
                                        Height="20" OnClick="ImageButton2_Click" /></span>
                                <asp:DropDownList runat="server" ID="ddlBranchTwo" AutoPostBack="true" OnTextChanged="ddlBranchTwo_TextChanged">
                                    <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="186" align="center" valign="middle">
                                <asp:TextBox ID="txtshi" runat="server" CssClass="in_input"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnshi" runat="server" Text="添加" CssClass="sf_buts" OnClick="btnshi_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="186" align="center" valign="middle" bgcolor="#F6F6F6">
                                添加县
                            </td>
                            <td width="126" align="center">
                                <span class="imgright">
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="/images/xx.gif" Width="20"
                                        Height="20" OnClick="ImageButton3_Click" /></span>
                                <asp:DropDownList runat="server" ID="ddlBranchThird">
                                    <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="186" align="center" valign="middle">
                                <asp:TextBox ID="txtxian" runat="server" CssClass="in_input"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnxian" runat="server" Text="添加" CssClass="sf_buts" OnClick="btnxian_Click" />
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
</body>
</html>

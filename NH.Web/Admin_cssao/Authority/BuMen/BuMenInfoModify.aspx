<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuMenInfoModify.aspx.cs"
    Inherits="NH.Web.adm.Authority.BuMen.BuMenInfoModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
    <script language="javascript" type="text/javascript">
        function PrintTable() {
            document.getElementById("PrintHide").style.visibility = "hidden"
            print();
            document.getElementById("PrintHide").style.visibility = "visible"
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="table">
        <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">
            <%-- <tr style="background-image: url(../images/bg_header.gif); background-repeat: repeat-x;
                height: 47px;">
                <td colspan="2">
                    <span style="float: left; background-image: url(../images/main_hl2.gif); width: 15px;
                        background-repeat: no-repeat; height: 47px"></span><span style="padding-right: 10px;
                            padding-left: 10px; float: left; background-image: url(../images/main_hb.gif);
                            padding-bottom: 10px; color: white; padding-top: 10px; background-repeat: repeat-x;
                            height: 47px; text-align: center;">修改部门信息</span><span style="float: left; background-image: url(../images/main_hr.gif);
                                width: 60px; background-repeat: no-repeat; height: 47px"></span>
                </td>
            </tr>--%>
            <tr>
                <td valign="middle" colspan="2">
                    &nbsp;<img src="../../images/BanKuaiJianTou.gif" />
                    系统管理&nbsp;>>&nbsp;修改部门信息
                </td>
            </tr>
            <tr>
                <td height="3px" colspan="2">
                </td>
            </tr>
        </table>
        <table style="width: 100%" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td align="right" style="width: 170px; height: 25px;">
                    部门名称：
                </td>
                <td style="height: 25px; padding-left: 5px;">
                    <asp:TextBox ID="TextBox1" runat="server" Width="350px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px;">
                    部门主管：
                </td>
                <td style="padding-left: 5px; height: 25px;">
                    <asp:TextBox ID="TextBox2" runat="server" Width="350px"></asp:TextBox>
                    <asp:DropDownList runat="server" ID="auser">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px;">
                    联系电话：
                </td>
                <td style="padding-left: 5px; height: 25px;">
                    <asp:TextBox ID="TextBox3" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px;">
                    传真：
                </td>
                <td style="padding-left: 5px; height: 25px;">
                    <asp:TextBox ID="TextBox4" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px;">
                    备注信息：
                </td>
                <td style="padding-left: 5px; height: 25px;">
                    <asp:TextBox ID="TextBox5" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" valign="middle" colspan="2">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Button/Submit.jpg"
                        OnClick="ImageButton1_Click" />
                    <img src="../../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../../images/Button/BtnExit.jpg" />&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

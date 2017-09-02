<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyInfo.aspx.cs" Inherits="NH.Web.adm.system.MyInfo" %>

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
      
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
           <tr>
                <td class="crumbs" colspan="12">
                   <p>
                <a href="<%=ListUrl %>">用户帐号管理</a> -> 修改</p>
                </td>
            </tr>
            <tr>
                <th>
                    用户帐号：
                </th>
                <td>
                    <asp:Label runat="server" ID="txtLoginName"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    姓名：
                </th>
                <td>
                    <asp:Label runat="server" ID="txtRealname"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    部门：
                </th>
                <td>
                    <asp:DropDownList runat="server" ID="bumen" Enabled="false">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    角色：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblRoleType" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" Enabled="false">
                        <asp:ListItem Value="0" Selected="True">普通管理员</asp:ListItem>
                        <asp:ListItem Value="1">超级管理员</asp:ListItem>
                    </asp:RadioButtonList>
                    <div id="RolesList" style="display: none;">
                        选择普通管理员角色<br />
                        <asp:CheckBoxList runat="server" ID="chkRoles" RepeatDirection="Horizontal" RepeatLayout="Flow"  Enabled="false">
                        </asp:CheckBoxList>
                    </div>
                </td>
            </tr>
            <tr>
                <th>
                    职位：
                </th>
                <td>
                    <asp:DropDownList runat="server" ID="zhiwei" Enabled="false">
                        <asp:ListItem Value="0" Selected="True">员工</asp:ListItem>
                        <asp:ListItem Value="1">部门主管</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    在岗状态：
                </th>
                <td>
                    <asp:DropDownList runat="server" ID="ZaiGang" Enabled="false">
                        <asp:ListItem Value="0" Selected="True">在岗</asp:ListItem>
                        <asp:ListItem Value="1">离职</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <strong>人事信息</strong>
                </td>
            </tr>
            <tr>
                <th>
                    性别：
                </th>
                <td>
                    <asp:DropDownList runat="server" ID="Sex"  Enabled="false">
                        <asp:ListItem Value="0" Selected="True">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    出生日期：
                </th>
                <td>
                    <asp:Label class="Wdate" ID="Wdate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    民族：
                </th>
                <td>
                    <asp:Label ID="txtMingZu" runat="server" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    身份证号：
                </th>
                <td>
                    <asp:Label ID="txtShenFengZheng" runat="server" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    婚姻状况：
                </th>
                <td>
                    <asp:Label ID="txtMarital" runat="server" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    政治面貌：
                </th>
                <td>
                    <asp:Label ID="txtZhenZhi" runat="server" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    籍贯：
                </th>
                <td>
                    <asp:Label ID="txtGuanJi" runat="server" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    户口所在地：
                </th>
                <td>
                    <asp:Label ID="txtHuKou" runat="server" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    学历：
                </th>
                <td>
                    <asp:Label ID="txtXueLi" runat="server" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    职称：
                </th>
                <td>
                    <asp:Label ID="txtZhiCheng" runat="server" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    毕业院校：
                </th>
                <td>
                    <asp:Label ID="txtBiYeXueXiao" runat="server" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    专业：
                </th>
                <td>
                    <asp:Label ID="txtZhuanYe" runat="server" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    参加工作时间：
                </th>
                <td>
                    <asp:Label class="Wdate" ID="GongZuoTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    加入本单位时间：
                </th>
                <td>
                    <asp:Label class="Wdate" ID="JiaRuTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    邮箱：
                </th>
                <td>
                    <asp:Label ID="txtEmail" runat="server" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    手机号码：
                </th>
                <td>
                    <asp:Label ID="txtShouJi" runat="server" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    家庭详细住址：
                </th>
                <td>
                    <asp:Label ID="txtJiaTingAddress" runat="server" Height="75px" TextMode="MultiLine"
                        Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    教育背景：
                </th>
                <td>
                    <asp:Label ID="txtJiaoYu" runat="server" Height="75px" TextMode="MultiLine" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    劳动合同签订情况：
                </th>
                <td>
                    <asp:Label ID="txtHeTong" runat="server" Height="75px" TextMode="MultiLine" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    社保缴纳情况：
                </th>
                <td>
                    <asp:Label ID="txtSheBao" runat="server" Height="75px" TextMode="MultiLine" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    备 注：
                </th>
                <td>
                    <asp:Label ID="txtNotes" runat="server" Height="75px" TextMode="MultiLine" Width="350px"></asp:Label>
                </td>
            </tr>
            <%--   <tr>
                <th>
                    附件：
                </th>
                <td>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal"
                        RepeatColumns="4">
                    </asp:CheckBoxList>
                    &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False"
                        ImageAlign="AbsMiddle" ImageUrl="../../images/Button/DelFile.jpg" OnClick="ImageButton3_Click" />
                </td>
            </tr>--%>
            <tr>
                <th>
                    附件：
                </th>
                <td>
                    <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank"> 查看</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <%--<input type="button" class="btnSubmit" value="返回" onclick="javascript:window.history.go(-1)'" />--%>
                    <%--<input type="button" class="btnSubmit" value="返回" onclick="javascript:window.location.href='<%=ListUrl %>'" />--%>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

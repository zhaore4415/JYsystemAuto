<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyJobInfo.aspx.cs" Inherits="NH.Web.adm.Company.CompanyJobInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="Add">
        <%--<div class="frmborder">
            <p>招聘信息</p>
        </div>--%>
        <div class="tbitem">
        <p class="title tab"><span>基本信息</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>招聘信息标题：</th>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbJobTitle"></asp:Label>
                    <asp:Label runat="server" ID="lbJobTitle_new" CssClass="block"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>招聘职位类别：</th>
                <td>                
                    <asp:Label runat="server" ID="lbJobCategory"></asp:Label>
                </td>
                <th>薪酬：</th>
                <td>
                    <asp:Label runat="server" ID="lbJobSalary"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>工作方式：</th>
                <td>
                    <asp:Label runat="server" ID="lbJobType"></asp:Label>
                </td>
                <th>教育程度：</th>
                <td>
                    <asp:Label runat="server" ID="lbJobDegree"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>工作经验：</th>
                <td>
                    <asp:Label runat="server" ID="lbJobExperience"></asp:Label>
                </td>
                <th>性别要求：</th>
                <td>
                    <asp:Label runat="server" ID="lbJobSex"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>是否报销车费：</th>
                <td>
                    <asp:Label runat="server" ID="lbCarfare"></asp:Label>
                </td>
                <th>是否提供食宿：</th>
                <td>
                    <asp:Label runat="server" ID="lbHousing"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>人员工作时间：</th>
                <td>
                    <asp:Label runat="server" ID="lbJobWorkTime"></asp:Label>
                </td>
                <th>招聘人数：</th>
                <td>
                    <asp:Label runat="server" ID="lbJobEmployeeQty"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>有效期：</th>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbJobExpireDate"></asp:Label>
                </td>
            </tr>
            <tr style=" display:none;">
                <th>招聘内容：</th>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbJobDescription"></asp:Label>
                    <asp:Label runat="server" ID="lbJobDescription_new" CssClass="block"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>拿多少钱：</th>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbSalaryDesc"></asp:Label>
                    <asp:Label runat="server" ID="lbSalaryDesc_new" CssClass="block"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>干什么活：</th>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbWorkContent"></asp:Label>
                    <asp:Label runat="server" ID="lbWorkContent_new" CssClass="block"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>有什么要求：</th>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbRequirements"></asp:Label>
                    <asp:Label runat="server" ID="lbRequirements_new" CssClass="block"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>吃住情况：</th>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbRoomAndFood"></asp:Label>
                    <asp:Label runat="server" ID="lbRoomAndFood_new" CssClass="block"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>有什么福利：</th>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbWelfare"></asp:Label>
                    <asp:Label runat="server" ID="lbWelfare_new" CssClass="block"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>审核：</th>
                <td colspan="3">
                    <input type="radio" id="rdJob_yes" name="rdJob" value="1" <%=_verifyStatus == 1 ? "checked=\"checked\"" : "" %> /><label for="rdJob_yes">审核通过</label>
                    <input type="radio" id="rdJob_no" name="rdJob" value="-1" <%=_verifyStatus == -1 ? "checked=\"checked\"" : "" %> /><label for="rdJob_no">审核不通过</label>
                </td>
            </tr>
        </table>
        </div>
    </div>
</body>
</html>

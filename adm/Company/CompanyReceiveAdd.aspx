<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyReceiveAdd.aspx.cs" Inherits="NH.Web.adm.Company.CompanyReceiveAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    
    <form id="formAddReceive">
        <input type="hidden" name="companyid" value="<%=Request.QueryString["companyid"]%>" />
        <input type="hidden" name="id" value="<%=Request.QueryString["action"]=="Update" ? Id : 0 %>" />
        <input type="hidden" name="action" value="<%=Request.QueryString["action"] %>" />
        <%--<div class="frmborder">
            <p>新增/修改接站日期</p>
        </div>--%>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>批次：</th>
                <td>第<input type="text" id="receiveTimes" name="receiveTimes" class="txtCls" style=" width:40px; text-align:center;" value="<%=maxtimes %>" />批</td>
            </tr>
            <tr>
                <th>接站日期：</th>
                <td><input type="text" id="receiveEndDate" name="receiveEndDate" class="easyui-datebox" value="<%=model != null ? model.EndDate.ToString("yyyy-MM-dd") : "" %>" /></td>
            </tr>
            <tr>
                <th>接站地点：</th>
                <td><input type="text" name="receiveAddress" class="txtCls" value="<%= model != null ? model.Address : "" %>" /></td>
            </tr>
            <tr>
                <th></th>
                <td><a class="easyui-linkbutton" iconcls="icon-add" onclick="AddReceive()">保存</a></td>
            </tr>
        </table>
        </form>
</body>
</html>

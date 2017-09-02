<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyJobSignUpChange.aspx.cs" Inherits="NH.Web.adm.Company.CompanyJobSignUpChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formChangeSignUp" runat="server" enableviewstate="false">
        <input type="hidden" name="SuCId" value="<%=Id %>" />
        <input type="hidden" name="SignUpID" value="<%=Request.QueryString["SignUpID"]%>" />
    <div id="Add">
        
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>选择新负责人：</th>
                <td>
                    <select id="service" name="service" class="easyui-combobox" data-options="valueField:'Id',textField:'Realname',url:'../Ajax/Common.ashx?action=GetCustomerService',onSelect:function(record){ $('#company').combobox('clear').combobox('reload','../Ajax/Common.ashx?action=GetCompanyByService&serviceid=' + record.Id)}"></select>
                </td>
            </tr>
            <tr>
                <th>选择企业：</th>
                <td>
                    <select id="company" name="company" class="easyui-combobox" data-options="valueField:'Id',textField:'CompanyName',"></select>                    
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <a class="easyui-linkbutton" iconCls="icon-save" onclick="ChangeSignUp()">确定</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script type="text/javascript">
        function ChangeSignUp() {
            $.ajax({
                url: 'CompanyJobSignUpChange.aspx?action=Update&id=<%=Id %>&ajax=1',
                data: $('#formChangeSignUp').serialize(),
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
                            Search_bm();
                            break;

                    }
                }, error: function () { alert('发生错误，请重试！'); }
            })
        }
    </script>
</body>
</html>

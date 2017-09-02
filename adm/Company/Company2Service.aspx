<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Company2Service.aspx.cs" Inherits="NH.Web.adm.Company.Company2Service" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formChangeCompanyService" runat="server" enableviewstate="false">
        <input type="hidden" name="companyid" value="<%=Id %>" />
    <div id="Add">
        
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>指定负责人：</th>
                <td>                
                    <input type="text" id="service" name="service" class="easyui-combobox" data-options="valueField:'Id',textField:'Realname',multiple:true,url:'../Ajax/Common.ashx?action=GetCustomerService',onLoadSuccess:function(){$('#service').combobox('setValues',<%=selectedId %>)}"  style=" width:200px;" />
                </td>
            </tr>
            <tr>
                <th></th>
                <td>
                    <a class="easyui-linkbutton" iconCls="icon-save" onclick="ChangeCompanyService()">确定</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script type="text/javascript">
        function ChangeCompanyService() {
            $.ajax({
                url: "Company2Service.aspx?action=Add&ajax=1",
                data: $('#formChangeCompanyService').serialize(),
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
            });
        }
    </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiveRecord.aspx.cs" Inherits="NH.Web.adm.ReceiveRecord.ReceiveRecord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <script type="text/javascript">
        var objTbList;
        $(document).ready(function () {
            objTbList = $('#tbdata');
            objTbList.datagrid({
                title: '接站查询',
                toolbar: '#toolbar',
                url: 'ReceiveRecord.aspx?action=GetList&ajax=1',
                queryParams: getSearchKeys(),
                singleSelect: true,
                pagination: true,
                pageSize: 10,
                rownumbers:true,
                idField: 'Id',
                columns: [[
//                    { field: 'Id', title: 'Id', width: 50 },
//                    { field: 'LoginName', title: '帐号', width: 80, align: 'center' },
                    {field: 'CompanyName', title: '企业名称', width: 200, align: 'center' },
                    { field: 'Times', title: '批次', width: 120, align: 'center' },
                    { field: 'EndDate', title: '接站日期', width: 80, align: 'center', formatter: function (value) { return value.split(' ')[0] } },
                    { field: 'AddTime', title: '添加时间', width: 120, align: 'center' }//,
                    //{ field: '操作', title: '操作', width: 120, align: 'center', formatter: GetButtons }
                ]]
            });
            function GetButtons(value, row, index) {
                return '<a href="#" onclick="return Manage(' + row.Id + ')">管理</a> <a href="#" onclick="return SetTop(' + row.Id + ')">置顶</a> <a href="CompanyVerify.aspx?id=' + row.Id + '" onclick="return Show(' + row.Id + ')">审核</a>'
                + ' <a href="#" onclick="return DeleteCompany(' + row.Id + ')">删除</a>';
            }
            $(window).resize(function () {
                objTbList.datagrid('resize');
            });
        });
        function getSearchKeys() {
            var keys = {
                loginname: $('#loginname').val(),
                companyname: $('#companyname').val(),
                starttime: $('[name=starttime]').val(),
                endtime: $('[name=endtime]').val()
            };
            return keys;
        }
        function Search() {
            objTbList.datagrid('options').queryParams = getSearchKeys();
            objTbList.datagrid('load');
        }
    </script>
</head>
<body>
    <div id="toolbar" style="padding: 5px; height: auto;">
        <%--用户名：<input type="text" id="loginname" name="loginname" class="txtSmall" />--%>
        企业名称：<input type="text" id="companyname" name="companyname" class="txtSmall" />
        接站日期：<input type="text" id="starttime" name="starttime" class="easyui-datebox" />至<input
            type="text" id="endtime" name="endtime" class="easyui-datebox" />
        <a id="btnSearch" class="easyui-linkbutton" iconcls="icon-search" onclick="Search()">
            搜索</a>
    </div>
    <table id="tbdata">
    </table>
    <div id="win">
    </div>
</body>
</html>

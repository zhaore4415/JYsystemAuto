<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyFavorite.aspx.cs" Inherits="NH.Web.adm.Company.CompanyFavorite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        var objTbList;
        $(document).ready(function () {
            objTbList = $('#tbdata_cf');
            objTbList.datagrid({
                title: '收藏夹',
                toolbar: '#toolbar_cf',
                url: 'CompanyFavorite.aspx?action=GetList&id=<%=Id %>&ajax=1',
                queryParams: getSearchKeys_cf(),
                singleSelect: true,
                pagination: true,
                idField: 'Id',
                columns: [[
                    { field: 'Realname', title: '姓名', width: 120, align: 'center' },
                    { field: 'JobCategoryName', title: '期望职位', width: 200, align: 'center' },
                    { field: 'SalaryName', title: '期望薪水', width: 120, align: 'center' },
                    { field: 'JobAddr', title: '期望地区', width: 200, align: 'center' },
                    { field: 'AddTime', title: '收藏时间', width: 120, align: 'center' }
                ]]
            });
            $(window).resize(function () {
                objTbList.datagrid('resize');
            });
        });
        function getSearchKeys_cf() {
            var keys = {
                starttime: $('[name=starttime_cf]').val(),
                endtime: $('[name=endtime_cf]').val()
            };
            return keys;
        }
        function Search_cf() {
            objTbList.datagrid('options').queryParams = getSearchKeys_cf();
            objTbList.datagrid('load');
        }

    </script>
    <div id="toolbar_cf" style="padding: 5px; height: auto;">
        日期：<input type="text" id="starttime_cf" name="starttime_cf" class="easyui-datebox" />
        至：<input type="text" id="endtime_cf" name="endtime_cf" class="easyui-datebox" />
        <a id="btnSearch_cf" class="easyui-linkbutton" iconcls="icon-search" onclick="Search_cf()">搜索</a>
    </div>
    <table id="tbdata_cf">
    </table>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyViewHistory.aspx.cs" Inherits="NH.Web.adm.Company.CompanyViewHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>    
    <script type="text/javascript">
        var objTbList;
        $(document).ready(function () {
            objTbList = $('#tbdata');
            objTbList.datagrid({
                title: '浏览过的简历',
                toolbar: '#toolbar_vh',
                url: 'CompanyViewHistory.aspx?action=GetList&id=<%=Id %>&ajax=1',
                queryParams: getSearchKeys_vh(),
                singleSelect: true,
                pagination: true,
                idField: 'Id',
                columns: [[
                    { field: 'Realname', title: '姓名', width: 120, align: 'center' },
                    { field: 'JobCategoryName', title: '期望职位', width: 200, align: 'center' },
                    { field: 'AddTime', title: '浏览时间', width: 120, align: 'center' },
                    { field: 'IP', title: '浏览IP', width: 200, formatter: function (value,row) {return row.IP + '(' + row.Address+')' } }
                ]]
            });
            $(window).resize(function () {
                objTbList.datagrid('resize');
            });
        });
        function getSearchKeys_vh() {
            var keys = {
                starttime: $('[name=starttime_vh]').val(),
                endtime: $('[name=endtime_vh]').val()
            };
            return keys;
        }
        function SearchVh() {
            objTbList.datagrid('options').queryParams = getSearchKeys_vh();
            objTbList.datagrid('load');
        }
        function Show(id) {
            objTbList.datagrid('selectRecord', id);
            var row = objTbList.datagrid('getSelected');
            //OpenWin(id, row.LoginName + (row.CompanyName != "" ? "[" + row.CompanyName + "]" : ""));
            return false;
        }

    </script>
    <div id="toolbar_vh" style="padding: 5px; height: auto;">
        日期：<input type="text" id="starttime_vh" name="starttime_vh" class="easyui-datebox" />
        至：<input type="text" id="endtime_vh" name="endtime_vh" class="easyui-datebox" />
        <a id="btnSearch_vh" class="easyui-linkbutton" iconcls="icon-search" onclick="SearchVh()">搜索</a>
    </div>
    <table id="tbdata">
    </table>
</body>
</html>

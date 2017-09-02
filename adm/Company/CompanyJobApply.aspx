<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyJobApply.aspx.cs" Inherits="NH.Web.adm.Company.CompanyJobApply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        var objTbList;
        $(document).ready(function () {
            objTbList = $('#tbdata_ja');
            objTbList.datagrid({
                title: '收到的简历',
                toolbar: '#toolbar_vh',
                url: 'CompanyJobApply.aspx?action=GetList&id=<%=Id %>&ajax=1',
                queryParams: getSearchKeys_ja(),
                singleSelect: true,
                pagination: true,
                idField: 'Id',
                columns: [[
                    { field: 'Realname', title: '姓名', width: 120, align: 'center' },
                    { field: 'JobCategoryName', title: '应聘职位', width: 200, align: 'center' },
                    { field: 'AddTime', title: '应聘时间', width: 120, align: 'center' },
                    { field: 'ReadStatus', title: '状态', width: 120, align: 'center', formatter: function (value) { return value == "True" ? "已阅" : "未阅"} },
                    { field: 'IsInvite', title: '面试通知', width: 120, align: 'center', formatter: function (value) { return value == "True" ? "已发送" : "未发送" } }
                ]]
            });
            $(window).resize(function () {
                objTbList.datagrid('resize');
            });
        });
        function getSearchKeys_ja() {
            var keys = {
                starttime: $('[name=starttime_ja]').val(),
                endtime: $('[name=endtime_ja]').val()
            };
            return keys;
        }
        function Search_ja() {
            objTbList.datagrid('options').queryParams = getSearchKeys_ja();
            objTbList.datagrid('load');
        }

    </script>
    <div id="toolbar_vh" style="padding: 5px; height: auto;">
        日期：<input type="text" id="starttime_ja" name="starttime_ja" class="easyui-datebox" />
        至：<input type="text" id="endtime_ja" name="endtime_ja" class="easyui-datebox" />
        <a id="btnSearch_ja" class="easyui-linkbutton" iconcls="icon-search" onclick="Search_ja()">搜索</a>
    </div>
    <table id="tbdata_ja">
    </table>
</body>
</html>

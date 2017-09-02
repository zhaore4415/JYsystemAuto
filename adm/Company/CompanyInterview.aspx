<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyInterview.aspx.cs" Inherits="NH.Web.adm.Company.CompanyInterview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        var objTbList;
        $(document).ready(function () {
            objTbList = $('#tbdata_iv');
            objTbList.datagrid({
                title: '收到的简历',
                toolbar: '#toolbar_iv',
                url: 'CompanyInterview.aspx?action=GetList&id=<%=Id %>&ajax=1',
                queryParams: getSearchKeys_iv(),
                singleSelect: true,
                pagination: true,
                idField: 'Id',
                columns: [[
                    { field: 'Title', title: '标题', width: 200, align: 'center' },
                    { field: 'Realname', title: '姓名', width: 120, align: 'center' },
                    { field: 'AddTime', title: '发送时间', width: 120, align: 'center' },
                    { field: 'ReadStatus', title: '人才状态', width: 120, align: 'center', formatter: function (value) { return value == "True" ? "已阅" : "未阅" } }
                ]]
            });
            $(window).resize(function () {
                objTbList.datagrid('resize');
            });
        });
        function getSearchKeys_iv() {
            var keys = {
                starttime: $('[name=starttime_iv]').val(),
                endtime: $('[name=endtime_iv]').val()
            };
            return keys;
        }
        function Search_iv() {
            objTbList.datagrid('options').queryParams = getSearchKeys_iv();
            objTbList.datagrid('load');
        }

    </script>
    <div id="toolbar_iv" style="padding: 5px; height: auto;">
        日期：<input type="text" id="starttime_iv" name="starttime_iv" class="easyui-datebox" />
        至：<input type="text" id="endtime_iv" name="endtime_iv" class="easyui-datebox" />
        <a id="btnSearch_iv" class="easyui-linkbutton" iconcls="icon-search" onclick="Search_iv()">搜索</a>
    </div>
    <table id="tbdata_iv">
    </table>
</body>
</html>

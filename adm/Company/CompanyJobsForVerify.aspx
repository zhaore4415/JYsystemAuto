<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyJobsForVerify.aspx.cs" Inherits="NH.Web.adm.Company.CompanyJobsForVerify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
</head>
<body>
    <style type="text/css">
        .hidden, .deleted
        {
            color: Red;
        }
    </style>
    <script type="text/javascript">
        var objTbList;
        $(document).ready(function () {
            objTbList = $('#tbdata_jl');
            objTbList.datagrid({
                title: '招聘信息审核',
                toolbar: '#toolbar',
                url: 'CompanyJobsForVerify.aspx?action=GetList&ajax=1',
                queryParams: getSearchKeys_jl(),
                singleSelect: true,
                pagination: true,
                pageSize: 10,
                idField: 'Id',
                columns: [[
                    { field: 'Id', title: 'Id', width: 50 },
                    { field: 'JobCategoryName', title: '招聘职位', width: 200, align: 'center' },
                    { field: 'CompanyName', title: '企业名称', width: 200, align: 'center' },
                    { field: 'UpdateTime', title: '修改日期', width: 120, align: 'center' },
                    { field: 'AddTime', title: '添加时间', width: 120, align: 'center' },
                    { field: '操作', title: '操作', width: 120, align: 'center', formatter: GetButtons }
                ]]
            });
            function GetButtons(value, row, index) {
                return '<a href="CompanyJobModify.aspx?id=' + row.Id + '" onclick="return ShowJob(' + row.Id + ')">查看</a>';
            }

            $(window).resize(function () {
                setTimeout(function () { objTbList.datagrid('resize'); }, 500);
            });
        });
        function getSearchKeys_jl() {
            var keys = {
                loginname: $('#loginname').val(),
                realname: $('#companyname').val(),
                starttime: $('[name=starttime_jl]').val(),
                endtime: $('[name=endtime_jl]').val()
            };
            return {};
        }
        function Search() {
            objTbList.datagrid('options').queryParams = getSearchKeys_jl();
            objTbList.datagrid('load');
        }
        function ShowJob(id) {
            objTbList.datagrid('selectRecord', id);
            var row = objTbList.datagrid('getSelected');
            var win = $('#winJob');
            win.window({
                title: '招聘信息',
                width: 800,
                height: 500,
                minimizable: false,
                collapsible: false,
                maximized: true,
                modal: true,
                content: '<iframe frameborder="0" src="CompanyJobModify.aspx?id=' + id + '" style="width:100%;height:100%;"></iframe>', //createFrame('CompanyJobModify.aspx?id=' + id),
                onMove: function (left, top) {
                    var l = left < 0 ? 0 : left;
                    var t = top < 0 ? 0 : top;

                    var windowH = $(window).height()

                    if (t > windowH) { t = windowH - 30; }
                    if (left < 0 || top < 0) {
                        win.window('move', { left: l, top: t });
                    }
                }
            });
            return false;
        }
    </script>
    
    <div id="toolbar" style="padding: 5px; height: auto;">
        企业名称：<input type="text" id="companyname" name="companyname" class="txtSmall" />
        更新时间：<input type="text" id="starttime" name="starttime" class="easyui-datebox" />至<input
            type="text" id="endtime" name="endtime" class="easyui-datebox" />
        <a id="btnSearch" class="easyui-linkbutton" iconcls="icon-search" onclick="Search()">
            搜索</a>
    </div>
    <table id="tbdata_jl">
    </table>
    <div id="winJob">
    </div>
</body>
</html>

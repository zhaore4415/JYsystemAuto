<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyJobs.aspx.cs" Inherits="NH.Web.adm.Company.CompanyJobs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                title: '招聘职位',
                toolbar: '#toolbar_jl',
                url: 'CompanyJobs.aspx?action=GetList&Id=<%=Id %>&ajax=1',
                queryParams: getSearchKeys_jl(),
                singleSelect: true,
                pagination: true,
                pageSize: 20,
                idField: 'Id',
                columns: [[
                    { field: 'Id', title: 'Id', width: 50 },
                    { field: 'JobCategoryName', title: '招聘职位', width: 200, align: 'center' },
                    { field: 'Status', title: '状态', width: 50, align: 'center', formatter: GetStatus },
                    { field: 'ViewCount', title: '浏览量', width: 50, align: 'center' },
                    { field: 'UpdateTime', title: '修改日期', width: 120, align: 'center' },
                    { field: 'RefreshTime', title: '上次置顶', width: 120, align: 'center' },
                    { field: 'AddTime', title: '添加时间', width: 120, align: 'center' },
                    { field: '操作', title: '操作', width: 120, align: 'center', formatter: GetButtons }
                ]]
            });
            function GetButtons(value, row, index) {
                return '<a href="CompanyJobModify.aspx?id=' + row.Id + '" onclick="return ShowJob(' + row.Id + ')">查看</a>'
                + ' <a href="#" onclick="return SetJobTop(' + row.Id + ')">置顶</a>'
                + ' <a href="#" onclick="return DeleteJob(' + row.Id + ')">删除</a>';
            }

            function GetStatus(status, row, index) {
                var result = null;
                switch (row.Verified) {
                    case "-1":
                        result = "<span class='deleted'>不通过</span>";
                        break;
                    case "0":
                        result = "<span class='deleted'>待审核</span>";
                        break;
                    case "1":
                        switch (status) {
                            case "-1":
                                result = "<span class='deleted'>已删除</span>";
                                break;
                            case "0":
                                result = "<span class='hidden'>已隐藏</span>";
                                break;
                            case "1":
                                result = "<span class='published'>已发布</span>";
                                break;
                        }
                        break;
                }
                return result;
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
        function Search_jl() {
            objTbList.datagrid('options').queryParams = getSearchKeys_jl();
            objTbList.datagrid('load');
        }
        function ShowJob(id) {
            objTbList.datagrid('selectRecord', id);
            var row = objTbList.datagrid('getSelected');
            var win = $('#winJob');
            var url;
            if (id) {
                url = 'CompanyJobModify.aspx?id=' + id;
            } else {
                url = 'CompanyJobModify.aspx?companyid=<%=Id %>';
            }
            win.window({
                title: '招聘信息',
                width: 800,
                height: 500,
                minimizable: false,
                collapsible: false,
                maximized: true,
                modal: true,
                //content: '<iframe frameborder="0" src="CompanyJobModify.aspx?id=' + id + '" style="width:100%;height:100%;"></iframe>', //createFrame('CompanyJobModify.aspx?id=' + id),
                content: '<iframe frameborder="0" src="' + url + '" style="width:100%;height:100%;"></iframe>', //createFrame('CompanyJobModify.aspx?id=' + id),
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

        function SetJobTop(id) {
            if (!confirm("确定要置顶吗？")) { return false; }
            $.ajax({
                url: 'CompanyJobs.aspx?action=SetTop&id=<%=Id %>&ajax=1',
                data: { 'jobid': id},
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
                            $('#lbTodayRefreshCount').text(data.data);
                            Search_jl();
                            break;

                    }
                }, error: function () { alert('发生错误，请重试！'); }
            })
            return false;
        }

        function DeleteJob(id) {
            if (!confirm("确定要删除吗？")) { return false; }
            $.ajax({
                url: 'CompanyJobs.aspx?action=Delete&id=<%=Id %>&ajax=1',
                data: { 'jobid': id },
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
                            //$('#lbTodayRefreshCount').text(data.data);
                            Search_jl();
                            break;

                    }
                }, error: function () { alert('发生错误，请重试！'); }
            })
            return false;
        }

        function CloseAndReload() {
            $('#winJob').window('close');
            Search_jl(); 
        }

        //消除拖动滚动条后出现条纹的问题
        var fixdelay;
        function fixbug() {
            if (fixdelay) {
                clearTimeout(fixdelay);
            }
            fixdelay = setTimeout(function () {
                var opts = $('#winJob').window('options');
                $('#winJob').window('resize', { width: opts.width, height: opts.height });
            }, 50);
        }
    </script>
    <div id="toolbar_jl" class="toolbar">
        每天可以置顶<asp:Label runat="server" ID="lbTotalRefreshCount" CssClass="red"></asp:Label>条招聘信息，今天置顶了<asp:Label runat="server" ID="lbTodayRefreshCount" CssClass="red"></asp:Label>条
        <a id="btnSearch" class="easyui-linkbutton" iconcls="icon-search" onclick="ShowJob()">添加招聘职位</a>(说明：对于开启报名接站的企业，只能添加一条招聘信息)
    </div>
    <table id="tbdata_jl">
    </table>
    <div id="winJob">
    </div>
</body>
</html>

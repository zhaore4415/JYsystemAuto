<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="NH.Web.adm.PersonList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <%--<script src="../Script/list.js" type="text/javascript"></script>
    <script src="../Script/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="../Script/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">

        function createFrame(url) {
            return '<iframe frameborder="0" src="' + url + '" style="width:100%;height:100%;"></iframe>';
        }

        function OpenWin(id,realname) {
            var win = $('#win');
            win.window({
                title:'人才信息-' + realname,
                width: 800,
                height: 500,
                minimizable: false,
                collapsible: false,
                maximized: true,
                modal:true,
                content: createFrame('PersonVerify.aspx?id=' + id),
                onMove: function (left, top) {
                    var l = left < 0 ? 0 : left;
                    var t = top < 0 ? 0 : top;

                    var windowH = $(window).height()

                    //win.window('setTitle', windowH + "|" + t)

                    if (t > windowH) { t = windowH - 30; }
                    if (left < 0 || top < 0) {
                        $('#win').window('move', { left: l, top: t });
                    }
                }
            });
        }
    </script>  
    <script type="text/javascript">
        var objTbList;
        $(document).ready(function () {
            objTbList = $('#tbdata');
            objTbList.datagrid({
                title: '人才列表',
                toolbar: '#toolbar',
                url: 'PersonList.aspx?action=GetList&ajax=1',
                queryParams: getSearchKeys(),
                singleSelect: false,
                pagination: true,
                pageSize: 25,
                idField: 'Id',
                columns: [[
                    { field: 'Id', title: 'Id', width: 50,checkbox:false },
                    { field: 'LoginName', title: '用户名', width: 80, align: 'center'},
                    { field: 'Realname', title: '姓名', width: 60, align: 'center' },
                    { field: 'Experience', title: '工作年限', width: 60, align: 'center' },
                    { field: 'JobCategoryName', title: '期望职位', width: 200, align: 'center' },
                    { field: 'JobAddr', title: '期望地区', width: 120, align: 'center' },
                    //{ field: 'Mobile', title: '手机', width: 80, align: 'center' },
                    //{ field: 'Phone', title: '电话', width: 70, align: 'center' },
                    //field: 'Email', title: '邮箱', width: 70, align: 'center' },
                    { field: 'AddTime', title: '注册时间', width: 120, align: 'center' },
                    { field: 'RefreshTime', title: '置顶时间', width: 120, align: 'center' },
                    { field: '操作', title: '操作', width: 90, align: 'center', formatter: GetButtons }
                ]]
            });
            function GetButtons(value, row, index) {
                return '<a href="PersonVerify.aspx?id=' + row.Id + '" onclick="return Show(' + row.Id + ')">查看</a>'
                + ' <a href="#" onclick="return PersonRefresh(' + row.Id + ')">置顶</a>'
                + ' <a href="#" onclick="return Delete(' + row.Id + ')">删除</a>';
            }
            $(window).resize(function () {
                objTbList.datagrid('resize');
            });
        });
        function getSearchKeys() {
            var keys = {
                loginname: $('#loginname').val(),
                realname: $('#realname').val(),
                starttime: $('[name=starttime]').val(),
                endtime: $('[name=endtime]').val(),
                newverify: $('#cbNewVerify').is(':checked') ? "1" : "0"
            };
            return keys;
        }
        function Search() {
            objTbList.datagrid('options').queryParams = getSearchKeys();
            objTbList.datagrid('load');
        }
        function Show(id) {
            objTbList.datagrid('selectRecord', id);
            var row = objTbList.datagrid('getSelected');
            OpenWin(id, row.LoginName + (row.Realname != "" ? "[" + row.Realname + "]" : ""));
            return false;
        }

        function PersonRefresh(id) {
            $.ajax({
                url: 'PersonList.aspx?action=refresh&id=' + id + '&ajax=1',
                cache: false,
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
                            Search();
                            break;

                    }
                }
            });
            return false;
        }
        function PersonRefresh2() {
            //return objTbList.datagrid('options').queryParams.loginname;
            var count = $('#tbdata').datagrid('getPager').pagination('options').total;
            if (!confirm("执行此操作的人才总数量是" + count + "人,是否继续？")) { return false; }
            $.ajax({
                url: 'PersonList.aspx?action=Refresh2&ajax=1',
                data: objTbList.datagrid('options').queryParams,
                type: 'post',
                cache: false,
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
                            Search();
                            break;

                    }
                }
            });
            return false;
        }
        function Delete(id) {
            if (!confirm("确定要删除吗？删除后无法恢复！")) { return false; }
            $.ajax({
                url: 'PersonList.aspx?action=Delete&id=' + id + '&ajax=1',
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
                            Search();
                            break;

                    }
                }, error: function () { alert('发生错误，请重试！'); }
            })
            return false;
        }
    </script> 
</head>
<body>
    
    <div id="toolbar" style="padding: 5px; height: auto;">
        用户名：<input type="text" id="loginname" name="loginname" class="txtSmall" />
        姓名：<input type="text" id="realname" name="realname" class="txtSmall" />
        注册时间：<input type="text" id="starttime" name="starttime" class="easyui-datebox" />至<input
            type="text" id="endtime" name="endtime" class="easyui-datebox" />
        <a id="btnSearch" class="easyui-linkbutton" iconcls="icon-search" onclick="Search()">
            搜索</a><a class="easyui-linkbutton" onclick="PersonRefresh2()">置顶所有搜索结果</a>
    </div>
    <table id="tbdata">
    </table>
    <div id="win"></div>
</body>
</html>

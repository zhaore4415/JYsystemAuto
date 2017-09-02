<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonListForVerify.aspx.cs" Inherits="NH.Web.adm.Person.PersonListForVerify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <script type="text/javascript">

        function createFrame(url) {
            return '<iframe frameborder="0" src="' + url + '" style="width:100%;height:100%;"></iframe>';
        }

        function OpenWin(id, realname) {
            var win = $('#win');
            win.window({
                title: '人才信息-' + realname,
                width: 800,
                height: 500,
                minimizable: false,
                collapsible: false,
                maximized: true,
                modal: true,
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
        function CloseWin() {
            $('#win').window('close');
            $('#tbdata').datagrid('reload');
        }
    </script>
    <script type="text/javascript">
        var objTbList;
        $(document).ready(function () {
            objTbList = $('#tbdata');
            objTbList.datagrid({
                title: '待审核人才列表',
                toolbar: '#toolbar',
                url: 'PersonListForVerify.aspx?action=GetList&ajax=1',
                queryParams: getSearchKeys(),
                singleSelect: true,
                pagination: true,
                pageSize: 25,
                idField: 'Id',
                columns: [[
                    { field: 'Id', title: 'Id', width: 50 },
                    { field: 'LoginName', title: '用户名', width: 80, align: 'center' },
                    { field: 'Realname', title: '姓名', width: 60, align: 'center' },
                    { field: 'Mobile', title: '手机', width: 80, align: 'center' },
                    { field: 'Phone', title: '电话', width: 70, align: 'center' },
                    { field: 'Email', title: '邮箱', width: 70, align: 'center' },
                    { field: 'JobCategoryName', title: '期望职位', width: 200, align: 'center' },
                    { field: 'CurAddr', title: '现所在地', width: 120, align: 'center' },
                    { field: 'AddTime', title: '注册时间', width: 120, align: 'center' },
                    { field: '操作', title: '操作', width: 80, align: 'center', formatter: GetButtons }
                ]]
            });
            function GetButtons(value, row, index) {
                return '<a href="PersonVerify.aspx?id=' + row.Id + '" onclick="return Show(' + row.Id + ')">查看</a>'
                + '  <a href="#" onclick="return Delete(' + row.Id + ')">删除</a>';
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
            搜索</a>
    </div>
    <table id="tbdata">
    </table>
    <div id="win"></div>
</body>
</html>

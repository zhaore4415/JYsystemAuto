<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suggest.aspx.cs" Inherits="NH.Web.adm.Suggest.Suggest" %>

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
                title: '意见与建议详情',
                width: 800,
                height: 500,
                minimizable: false,
                collapsible: false,
                maximized: true,
                modal: true,
                content: createFrame('SuggestModify.aspx?id=' + id),
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
                title: '意见与建议',
                toolbar: '#toolbar',
                url: 'Suggest.aspx?action=GetList&ajax=1',
                queryParams: getSearchKeys(),
                singleSelect: true,
                pagination: true,
                pageSize: 20,
                idField: 'Id',
                columns: [[
                    { field: 'Id', title: 'Id', width: 50 },
                    { field: 'Title', title: '标题', width: 80, align: 'center' },
                    { field: 'IsRead', title: '状态', width: 50, align: 'center', formatter: function (value) { return value == "False" ? "<span class='red'>未读</span>" : "<span class='blue'>已读</span>" } },
                    { field: 'LoginName', title: '帐号', width: 80, align: 'center' },
                    { field: 'UserType', title: '用户类型', width: 60, align: 'center', formatter: function (value) { return value == "1" ? "个人" : "企业" } },
                    { field: 'CompanyName', title: '企业名称', width: 120, align: 'center' },
                    { field: 'Name', title: '联系人姓名', width: 70, align: 'center' },
                    { field: 'Email', title: 'Email', width: 100, align: 'center' },
                    { field: 'Phone', title: '联系电话', width: 80, align: 'center' },
                    { field: 'AddTime', title: '时间', width: 120, align: 'center' },
                    { field: '操作', title: '操作', width: 80, align: 'center', formatter: GetButtons }
                ]]
            });
            function GetButtons(value, row, index) {
                return '<a href="SuggestModify.aspx?id=' + row.Id + '" onclick="return Show(' + row.Id + ')">查看</a>'
                + ' <a href="#" onclick="return Delete(' + row.Id + ')">删除</a>';
            }
            $(window).resize(function () {
                objTbList.datagrid('resize');
            });
        });
        function getSearchKeys() {
            var keys = {
                loginname: $('#loginname').val(),
                starttime: $('[name=starttime]').val(),
                endtime: $('[name=endtime]').val(),
                usertype: $('#ddlUserType').val(),
                readstatus: $('#ddlStatus').val()
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
            OpenWin(id);
            return false;
        }

        function Delete(id) {
            if (!confirm("确定要删除吗？")) { return false; }
            $.ajax({
                url: 'Suggest.aspx?action=Delete&id=' + id + '&ajax=1',
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
        时间：<input type="text" id="starttime" name="starttime" class="easyui-datebox" />至<input
            type="text" id="endtime" name="endtime" class="easyui-datebox" />
        <select id="ddlUserType" name="ddlUserType">
            <option value="">所有用户</option>
            <option value="1">个人</option>
            <option value="2">企业</option>
        </select>
        <select id="ddlStatus" name="ddlStatus">
            <option value="">所有状态</option>
            <option value="1">已读</option>
            <option value="0">未读</option>
        </select>
        <a id="btnSearch" class="easyui-linkbutton" iconcls="icon-search" onclick="Search()">
            搜索</a>
    </div>
    <table id="tbdata">
    </table>
    <div id="win"></div>
</body>
</html>

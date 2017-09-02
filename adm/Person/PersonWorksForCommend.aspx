<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonWorksForCommend.aspx.cs" Inherits="NH.Web.adm.Person.PersonWorksForCommend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <style type="text/css">
        .dialog-button
        {
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        var objTbList;
        $(document).ready(function () {
            objTbList = $('#tbdata');
            objTbList.datagrid({
                title: '推荐作品',
                toolbar: '#toolbar',
                url: 'PersonWorksForCommend.aspx?action=GetList&ajax=1',
                queryParams: getSearchKeys(),
                singleSelect: true,
                pagination: true,
                pageSize: 20,
                idField: 'Id',
                columns: [[
                    { field: 'Id', title: 'Id', width: 50 },
                    { field: 'Title', title: '标题', width: 100 },
                    { field: 'LoginName', title: '用户名', width: 100, align: 'center' },
                    { field: 'Realname', title: '姓名', width: 100, align: 'center' },
                    { field: 'Status', title: '状态', width: 80, align: 'center', formatter: GetStatus },
                    { field: 'AddTime', title: '时间', width: 120, align: 'center' },
                    { field: '操作', title: '操作', width: 120, align: 'center', formatter: GetButtons }
                ]]
            });
            function GetStatus(value) {
                var result;
                switch (value) {
                    case "0":
                        result = "未审核";
                        break;
                    case "1":
                        result = "<font color='blue'>审核通过</font>";
                        break;
                    case "-1":
                        result = "<font color='red'>审核不通过</font>";
                        break;
                }
                return result;
            }
            function GetButtons(value, row, index) {
                return '<a href="#" onclick="return Show(' + row.Id + ')">查看</a>';
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
                endtime: $('[name=endtime]').val()
            };
            return keys;
        }
        function Search() {
            objTbList.datagrid('options').queryParams = getSearchKeys();
            objTbList.datagrid('load');
        }
        function WinResize(objImg) {
            var minW = 600;
            var maxW = $(window).width();
            var width = 0;
            var imgW = $(objImg).width();
            if (imgW < minW) {
                width = minW + 50;
            } else if (imgW > minW) {
                width = imgW + 50;
            } else if (imgW > maxW) {
                width = maxW - 100;
            }

            $('#win').dialog('resize', {
                width: width,
                height: $(window).height() - 50
            });
        }
        function Show(id) {
            objTbList.datagrid('selectRecord', id);
            var row = objTbList.datagrid('getSelected');
            var objWin = $('<div id="win"></div>').dialog({
                title: '个人作品审核',
                width: 650,
                height: $(window).height() - 50,
                top: 25,
                maximizable: true,
                resizable: true,
                modal: true,
                content: '<div style="text-align:center"><div>' + row.Title + '</div><div><img src="<%=bigfolder %>' + row.ImgBig + '" onload="WinResize(this)" /></div><div>',
                buttons: [
                        {
                            id: 'btnYes',
                            iconCls: 'icon-ok',
                            text: '审核通过',
                            disabled:(row.Status == 1 ? true : false),
                            handler: function () { VerifyWorks(row.Id, 1); }
                        }, {
                            id: 'btnNo',
                            iconCls: 'icon-no',
                            text: '审核不通过',
                            disabled: (row.Status == -1 ? true : false),
                            handler: function () { VerifyWorks(row.Id, -1); }
                        }, {
                            id: 'btnCommendYes',
                            iconCls: 'icon-ok',
                            text: "推荐",
                            disabled: true,
                            handler: function () { SetCommendWorks(row.Id, 1); }
                        }, {
                            id: 'btnCommendNo',
                            iconCls: 'icon-no',
                            text: "取消推荐",
                            handler: function () { SetCommendWorks(row.Id, 0); }
                        }, {
                            id: 'btnDel',
                            iconCls: 'icon-cancel',
                            text: '删除',
                            handler: function () { DeleteWorks(row.Id, objWin); }
                        }
                    ],
                onClose: function () {
                    if ($('#win').data('reload') == "1") { objTbList.datagrid('reload'); }
                    objWin.dialog('destroy'); 
                }
            });
        }

        function VerifyWorks(id, status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【审核通过】" : "【审核不通过】") + "吗？")) { return false; }
            $.ajax({
                url: 'PersonWorks.aspx?id=' + id + '&ajax=1',
                data: { 'action': 'verify', 'status': status },
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
                            if (status == 1) {
                                $('#btnYes').linkbutton('disable');
                                $('#btnNo').linkbutton('enable');
                            } else {
                                $('#btnYes').linkbutton('enable');
                                $('#btnNo').linkbutton('disable');
                            }
                            break;

                    }
                    $('#win').data('reload', "1");//重新加载列表的标识
                }, error: function () { alert('发生错误！请重试！'); }
            })
        }
        function DeleteWorks(id, objWin) {
            if (!confirm("确定要删除吗？")) { return false; }
            $.ajax({
                url: 'PersonWorks.aspx?ajax=1',
                data: { 'action': 'delete', 'id': id },
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
                            $('#works-' + id).remove();
                            objWin.dialog('close');
                            break;

                    }
                    $('#win').data('reload', "1"); //重新加载列表的标识
                }, error: function () { alert('发生错误！请重试！'); }
            })
        }

        function SetCommendWorks(id, commend) {
            if (!confirm("确定" + (commend == 1 ? "设为【推荐】" : "【取消推荐】") + "吗？")) { return false; }
            $.ajax({
                url: 'PersonWorks.aspx?ajax=1',
                data: { 'action': 'SetCommend', 'id': id, 'commend': commend },
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
                            if (commend == 1) {
                                $('#btnCommendYes').linkbutton('disable');
                                $('#btnCommendNo').linkbutton('enable');
                            } else {
                                $('#btnCommendYes').linkbutton('enable');
                                $('#btnCommendNo').linkbutton('disable');
                            }
                            break;
                    }
                    $('#win').data('reload', "1"); //重新加载列表的标识
                }, error: function () { alert('发生错误！请重试！'); }
            });
        }
    </script>
</head>
<body>
    <div id="toolbar" style="padding: 5px; height: auto;">
        用户名：<input type="text" id="loginname" name="loginname" class="txtSmall" />
        姓名：<input type="text" id="realname" name="realname" class="txtSmall" />
        更新时间：<input type="text" id="starttime" name="starttime" class="easyui-datebox" />至<input
            type="text" id="endtime" name="endtime" class="easyui-datebox" />
        <a id="btnSearch" class="easyui-linkbutton" iconcls="icon-search" onclick="Search()">
            搜索</a>
    </div>
    <table id="tbdata">
    </table>
</body>
</html>

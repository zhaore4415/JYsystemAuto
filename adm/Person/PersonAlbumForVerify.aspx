<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonAlbumForVerify.aspx.cs" Inherits="NH.Web.adm.Person.PersonAlbumForVerify" %>

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
                title: '个人相册审核',
                toolbar: '#toolbar',
                url: 'PersonAlbumForVerify.aspx?action=GetList&ajax=1',
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
                    { field: 'AddTime', title: '时间', width: 120, align: 'center' },
                    { field: '操作', title: '操作', width: 120, align: 'center', formatter: GetButtons }
                ]]
            });
            function GetButtons(value, row, index) {
                return '<a href="#" onclick="return Show(' + row.Id + ')">审核</a>';
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
                title: '个人相册审核',
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
                            handler: function () { VerifyAlbum(row.Id, 1); }
                        }, {
                            id: 'btnNo',
                            iconCls: 'icon-no',
                            text: '审核不通过',
                            handler: function () { VerifyAlbum(row.Id, -1); }
                        }, {
                            id: 'btnDel',
                            iconCls: 'icon-cancel',
                            text: '删除',
                            handler: function () { DeleteAlbum(row.Id, objWin); }
                        }
                    ],
                onClose: function () {
                    if ($('#win').data('reload') == "1") { objTbList.datagrid('reload'); }
                    objWin.dialog('destroy');
                }
            });
        }

        function VerifyAlbum(id, status, objLink) {
            if (!confirm("确定要更改为" + (status == 1 ? "【审核通过】" : "【审核不通过】") + "吗？")) { return false; }
            $.ajax({
                url: 'PersonAlbum.aspx?id=' + id + '&ajax=1',
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
                }
            })
        }
        function DeleteAlbum(id, objWin) {
            if (!confirm("确定要删除吗？")) { return false; }
            $.ajax({
                url: 'PersonAlbum.aspx?ajax=1',
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
                            objWin.dialog('close');
                            Search();
                            break;

                    }
                }, error: function () { alert('发生错误！请重试！'); }
            })
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

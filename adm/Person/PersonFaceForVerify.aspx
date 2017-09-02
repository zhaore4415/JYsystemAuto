<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonFaceForVerify.aspx.cs" Inherits="NH.Web.adm.Person.PersonFaceForVerify" %>

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
                title: '待审核头像',
                toolbar: '#toolbar',
                url: 'PersonFaceForVerify.aspx?action=GetList&ajax=1',
                queryParams: getSearchKeys(),
                singleSelect: true,
                pagination: true,
                pageSize: 20,
                idField: 'Id',
                columns: [[
                    { field: 'Id', title: 'Id', width: 50 },
                    { field: 'LoginName', title: '用户名', width: 100, align: 'center' },
                    { field: 'Realname', title: '姓名', width: 100, align: 'center' },
                    { field: 'UpdateTime', title: '更新时间', width: 120, align: 'center' },
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
                realname: $('#realname').val()
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
                title: '个人头像审核',
                width: 650,
                height: $(window).height() - 50,
                top: 25,
                maximizable: true,
                resizable: true,
                modal: true,
                content:CreateHtml(row),
                //href:'PersonFace.aspx?id=' + id,
                buttons: [
                        {
                            id: 'btnYes',
                            iconCls: 'icon-ok',
                            text: '审核通过',
                            handler: function () { VerifyFace(row.Id, 1); }
                        }, {
                            id: 'btnNo',
                            iconCls: 'icon-no',
                            text: '审核不通过',
                            handler: function () { VerifyFace(row.Id, -1); }
                        }
                    ],
                onClose: function () {
                    if ($('#win').data('reload') == "1") { objTbList.datagrid('reload'); }
                    objWin.dialog('destroy');
                }
            });
            return false;
        }

        function CreateHtml(row) {
            var html = '<table width="100%" cellpadding="0" cellspacing="0" class="utable">';
            html += '<tr><th>当前头像：</th><td>' + (row.Photo != '' ? '<img src="<%=smallfolder %>' + row.Photo + '" />' : "") + '</td></tr>';
            html += '<tr><th>新头像：</th><td><img src="<%=smallfolder %>' + row.PhotoNew + '" /></td></tr>';
            html += '<tr><th>原始图片：</th><td><img src="<%=originalfolder %>' + row.PhotoOriginal + '" /></td></tr>';
            html += '</table>';
            return html;
        }

        function VerifyFace(id, status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【审核通过】" : "【审核不通过】") + "吗？")) { return false; }
            $.ajax({
                url: 'PersonFace.aspx?id=' + id + '&ajax=1',
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
                            $('#win').data('reload', "1").dialog('close'); //重新加载列表的标识
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
        <a id="btnSearch" class="easyui-linkbutton" iconcls="icon-search" onclick="Search()">搜索</a>
    </div>
    <table id="tbdata">
    </table>
</body>
</html>

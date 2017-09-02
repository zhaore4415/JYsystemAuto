<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyFaceForVerify.aspx.cs" Inherits="NH.Web.adm.Company.CompanyFaceForVerify" %>

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

        function createFrame(url) {
            return '<iframe frameborder="0" src="' + url + '" style="width:100%;height:100%;"></iframe>';
        }

        function OpenWin(id, realname) {
            var win = $('#win');
            win.window({
                title: '企业信息-' + realname,
                width: 800,
                height: 500,
                minimizable: false,
                collapsible: false,
                maximized: true,
                modal: true,
                content: createFrame('CompanyPanel.aspx?id=' + id + '&selected=CompanyFace'),
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
                title: '待审核形象照片',
                toolbar: '#toolbar',
                url: 'CompanyFaceForVerify.aspx?action=GetList&ajax=1',
                queryParams: getSearchKeys(),
                singleSelect: true,
                pagination: true,
                pageSize: 20,
                idField: 'Id',
                columns: [[
                    { field: 'Id', title: 'Id', width: 50 },
                    { field: 'LoginName', title: '用户名', width: 100, align: 'center' },
                    { field: 'CompanyName', title: '企业名', width: 100, align: 'center' },
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
            OpenWin(id, row.LoginName + (row.CompanyName != "" ? "[" + row.CompanyName + "]" : ""));
            return false;
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
    <div id="win"></div>
</body>
</html>

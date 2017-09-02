<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayList.aspx.cs" Inherits="NH.Web.adm.Payment.PayList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <script type="text/javascript">
        function OpenWin(id, realname) {
            //var win = $('#win');
            var win = $('<div id="win"></div>');
            win.window({
                title: '企业信息-' + realname,
                width: 900,
                height: 500,
                minimizable: false,
                collapsible: false,
                //maximized: true,
                modal: true,
                cache: false,
                href: 'VipCompanyLevel.aspx?id=' + id,
                //content: createFrame('VipCompanyLevel.aspx?id=' + id),
                onMove: function (left, top) {
                    var l = left < 0 ? 0 : left;
                    var t = top < 0 ? 0 : top;

                    var windowH = $(window).height()

                    //win.window('setTitle', windowH + "|" + t)

                    if (t > windowH) { t = windowH - 30; }
                    if (left < 0 || top < 0) {
                        win.window('move', { left: l, top: t });
                    }
                }, onClose: function () {
                    if (win.data('refresh') == "1") { objTbList.datagrid('reload'); win.data('refresh', '0'); }
                    win.window('destroy');
                }
            });
        }
    </script>  
    
    <script type="text/javascript">
        var objTbList;
        $(document).ready(function () {
            objTbList = $('#tbdata');
            objTbList.datagrid({
                title: '在线支付管理',
                toolbar: '#toolbar',
                url: 'PayList.aspx?action=GetList&ajax=1',
                queryParams: getSearchKeys(),
                singleSelect: true,
                pagination: true,
                pageSize: 10,
                idField: 'Id',
                columns: [[
                    //{ field: 'Id', title: 'Id', width: 50 },
                    { field: 'LoginName', title: '企业帐号', width: 100, align: 'left' },
                    { field: 'CompanyName', title: '企业名称', width: 130, align: 'left' },
                    { field: 'OrderDesc', title: '描述内容', width: 400, align: 'left' },
                    { field: 'TradeNo', title: '交易号', width: 120, align: 'center' },
                    { field: 'TradeTime', title: '付款时间', width: 120, align: 'center' }
                    //{field: '操作', title: '操作', width: 80, align: 'center', formatter: GetButtons }
                ]]
            });
            $(window).resize(function () {
                objTbList.datagrid('resize');
            });
        });
        function getSearchKeys() {
            var keys = {
                loginname: $('#loginname').val(),
                companyname: $('#companyname').val(),
                starttime: $('[name=starttime]').val(),
                endtime: $('[name=endtime]').val(),
                level: $('[name=ddlLevels]').val()
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
            OpenWin(id, row.LoginName + (row.CompanyName != "" ? "[" + row.CompanyName + "]" : ""));
            return false;
        }
    </script>
</head>
<body>
    <div id="toolbar" style="padding: 5px; height: auto;">
        用户名：<input type="text" id="loginname" name="loginname" class="txtSmall" />
        企业名称：<input type="text" id="companyname" name="companyname" class="txtSmall" />
        <select id="ddlLevels" name="ddlLevels">
            <option value="0">所有等级</option>
            <%=_levels %>
        </select>
        付款日期：<input type="text" id="starttime" name="starttime" class="easyui-datebox" />至<input
            type="text" id="endtime" name="endtime" class="easyui-datebox" />
        <a id="btnSearch" class="easyui-linkbutton" iconcls="icon-search" onclick="Search()">
            搜索</a>
            
    </div>
    <table id="tbdata">
    </table>
    <%--<div id="win"></div>--%>
</body>
</html>

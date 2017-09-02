<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyJobSignUp.aspx.cs" Inherits="NH.Web.adm.Company.CompanyJobSignUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        var objTbList;
        $(document).ready(function () {
            objTbList = $('#tbdata_bm');
            objTbList.datagrid({
                title: '求职报名',
                toolbar: '#toolbar_bm',
                url: 'CompanyJobSignUp.aspx?action=GetList&Id=<%=Id %>&ajax=1',
                queryParams: getSearchKeys_bm(),
                singleSelect: true,
                pagination: true,
                pageSize: 20,
                idField: 'Id',
                fit: true,
                columns: [[
                { field: 'Id', title: 'Id', width: 50 },
                    {field: 'Name', title: '姓名', width: 100, align: 'center' },
                    { field: 'Mobile', title: '手机号', width: 100, align: 'center' },
                    { field: 'Sex', title: '性别', width: 50, align: 'center', formatter: function (value) { return value == "0" ? "女" : "男" } },
                    { field: 'Born', title: '出生年份', width: 80, align: 'center' },
                    { field: 'IsContacted', title: '是否已联系', width: 80, align: 'center', formatter: function (value) { return value == "True" ? "是" : "否" } },
                    { field: 'IsIntent', title: '意向', width: 50, align: 'center', formatter: function (value) { if (value != "") { return value == "True" ? "是" : "否" } else { return "" } } },
                    { field: 'UserStatus', title: '状态', width: 80, align: 'center', formatter: GetStatus },
                    { field: 'AddTime', title: '报名时间', width: 120, align: 'center' },
                    { field: 'BelongUserName', title: '负责人', width: 80, align: 'center' },
                    { field: '操作', title: '操作', width: 150, align: 'center', formatter: GetButtons }
                ]]
            });
            function GetButtons(value, row, index) {
                return '<a href="CompanyJobSignUpRemark.aspx?id=' + row.Id + '&SignUpID=' + row.SignUpID + '" onclick="return ShowSignUpRemark(' + row.Id + ',' + row.SignUpID + ')">联系记录</a>'
                + ' <a href="#" onclick="return ShowChangeSignUp(' + row.Id + ')">转移</a>';
            }

            function GetStatus(status, row, index) {
                var result = null;
                switch (status) {
                    case "1":
                        result = "已达成";
                        break;
                    case "2":
                        result = "未达成";
                        break;
                    case "3":
                        result = "已就职";
                        break;
                    case "4":
                        result = "未就职";
                        break;
                    case "5":
                        result = "需回访";
                        break;
                }
                return result;
            }
        });
        function getSearchKeys_bm() {
            var keys = {
                name: $('#name').val(),
                mobile: $('#mobile').val(),
                iscontacted: $('#iscontacted').val(),
                isintent: $('#isintent').val(),
                status: $('#status').val(),
                starttime: $('[name=starttime]').val(),
                endtime: $('[name=endtime]').val()
            };
            return keys;
        }
        function Search_bm() {
            objTbList.datagrid('options').queryParams = getSearchKeys_bm();
            objTbList.datagrid('load');
        }
        function ShowSignUpRemark(id, SignUpID) {
            objTbList.datagrid('selectRecord', id);
            var row = objTbList.datagrid('getSelected');
            var winSignUpRemark = $('<div></div>');
            winSignUpRemark.window({
                title: '联系记录',
                width: 600,
                height: 300,
                minimizable: false,
                collapsible: false,
                maximized: false,
                modal: true,
                content: '<iframe frameborder="0" src="CompanyJobSignUpRemark.aspx?id=' + id + '&SignUpID=' + SignUpID + '" style="width:100%;height:100%;"></iframe>', //createFrame('CompanyJobModify.aspx?id=' + id),
                onMove: function (left, top) {
                    var l = left < 0 ? 0 : left;
                    var t = top < 0 ? 0 : top;

                    var windowH = $(window).height()

                    if (t > windowH) { t = windowH - 30; }
                    if (left < 0 || top < 0) {
                        winSignUpRemark.window('move', { left: l, top: t });
                    }
                },
                onClose: function () { winSignUpRemark.window('destroy'); }
            });
            return false;
        }
        function ShowChangeSignUp(id) {
            var changeWin = $('<div></div>');
            changeWin.window({
                title: '转移负责人',
                width: 600,
                height: 300,
                minimizable: false,
                collapsible: false,
                maximized: false,
                modal: true,
                href:'CompanyJobSignUpChange.aspx?Id=' + id,
                //content: '<iframe frameborder="0" src="CompanyJobSignUpRemark.aspx?id=' + id + '&SignUpID=' + SignUpID + '" style="width:100%;height:100%;"></iframe>', //createFrame('CompanyJobModify.aspx?id=' + id),
                onMove: function (left, top) {
                    var l = left < 0 ? 0 : left;
                    var t = top < 0 ? 0 : top;

                    var windowH = $(window).height()

                    if (t > windowH) { t = windowH - 30; }
                    if (left < 0 || top < 0) {
                        changeWin.window('move', { left: l, top: t });
                    }
                },
                onClose: function () { changeWin.window('destroy'); } 
            });
        }
        function DeleteSignUp(id) {
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
    </script>
    <div id="toolbar_bm" class="toolbar">
        姓名：<input type="text" id="name" name="name" class="txtSmall" />
        电话：<input type="text" id="mobile" name="mobile" class="txtSmall" />
        <select id="iscontacted" name="iscontacted"><option value="">是否已联系</option><option value="1">已联系</option><option value="0">未联系</option></select>
        <select id="isintent" name="isintent"><option value="">意向</option><option value="1">有</option><option value="0">无</option></select>
        <select id="status" name="status">
            <option value="">所有状态</option>
            <option value="1">已达成</option>
            <option value="2">未达成</option>
            <option value="3">已就职</option>
            <option value="4">未就职</option>
            <option value="5">需回访</option>
        </select>
        报名时间：<input type="text" id="starttime" name="starttime" class="easyui-datebox" />至<input type="text" id="endtime" name="endtime" class="easyui-datebox" />
        <a id="btnSearch" class="easyui-linkbutton" iconcls="icon-search" onclick="Search_bm()">搜索</a>
    </div>
    <table id="tbdata_bm">
    </table>
    <%--<div id="winSignUpRemark">
    </div>--%>
</body>
</html>

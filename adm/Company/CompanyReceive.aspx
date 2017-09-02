<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyReceive.aspx.cs" Inherits="NH.Web.adm.Company.CompanyReceive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        var objTbList;
        $(document).ready(function () {
            objTbList = $('#tbdata_cv');
            objTbList.datagrid({
                title: '接站历史记录',
                toolbar: '#toolbar_cv',
                url: 'CompanyReceive.aspx?action=GetList&id=<%=Id %>&ajax=1',
                //queryParams: getSearchKeys_iv(),
                singleSelect: true,
                pagination: true,
                idField: 'Id',
                columns: [[
                    { field: 'Times', title: '批次', width: 200, align: 'center', formatter: function (value) { return "第" + value + "批"; } },
                    { field: 'EndDate', title: '接站日期', width: 200, align: 'center', formatter: function (value) { return value.split(' ')[0] } },
                    { field: 'Address', title: '接站地点', width: 120, align: 'center' },
                    { field: 'SignUpStatus', title: '报名状态', width: 120, align: 'center', formatter: function (value) {return value > 0 ? "报名中" : "已停止" } },
                    { field: 'SignUpCount', title: '报名人数', width: 120, align: 'center' },
                    { field: 'ReadStatus', title: '操作', width: 120, align: 'center', formatter: GetButtons }
                ]]
            });
            $(window).resize(function () {
                objTbList.datagrid('resize');
            });
            function GetButtons(value, row, index) {
                return '<a href="#" onclick="return ShowUpdateReceive(' + row.Id + ')">修改</a>'
                + ' <a href="#" onclick="return DeleteReceive(' + row.Id + ')">删除</a>';
            }
        });
        var winAddReceive;
        function ShowAddReceive() {
            winAddReceive = $('<div id="winAddReceive"></div>');
            winAddReceive.window({
                title: "新增接站日期",
                width: 400,
                height: 300,
                minimizable: false,
                collapsible: false,
                maximized: false,
                modal: true,
                cache: false,
                href: 'CompanyReceiveAdd.aspx?companyid=<%=Id %>&action=Add',
                onMove: function (left, top) {
                    var l = left < 0 ? 0 : left;
                    var t = top < 0 ? 0 : top;

                    var windowH = $(window).height()
                    //win.window('setTitle', windowH + "|" + t)
                    if (t > windowH) { t = windowH - 30; }
                    if (left < 0 || top < 0) {
                        winAddReceive.window('move', { left: l, top: t });
                    }
                },
                onClose: function () { winAddReceive.window('destroy'); }
            });
        }

        function ShowUpdateReceive(id) {
            winAddReceive = $('<div id="winAddReceive"></div>');
            winAddReceive.window({
                title: "修改接站日期",
                width: 400,
                height: 300,
                minimizable: false,
                collapsible: false,
                maximized: false,
                modal: true,
                cache: false,
                href: 'CompanyReceiveAdd.aspx?action=Update&companyid=<%=Id %>&id=' + id,
                onMove: function (left, top) {
                    var l = left < 0 ? 0 : left;
                    var t = top < 0 ? 0 : top;

                    var windowH = $(window).height()
                    //win.window('setTitle', windowH + "|" + t)
                    if (t > windowH) { t = windowH - 30; }
                    if (left < 0 || top < 0) {
                        winAddReceive.window('move', { left: l, top: t });
                    }
                },
                onClose: function () { winAddReceive.window('destroy'); }
            });

//            objTbList.datagrid('selectRecord', id);
//            var row = objTbList.datagrid('getSelected');
//            var win = $('#winAddReceive');
//            win.window('open');
//            win.find('[name=action]').val('Update');
//            win.find('[name=id]').val(id);
//            win.find('#receiveEndDate').datebox('setValue',row.EndDate.split(' ')[0]);
//            win.find('[name=receiveAddress]').val(row.Address);
        }
        function AddReceive() {
            $.ajax({
                url: "CompanyReceive.aspx",
                data: $('#formAddReceive').serialize(),
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
                            winAddReceive.window('close');
                            objTbList.datagrid('load');
                            break;
                    }
                }
            });
        }


        function DeleteReceive(id) {
            if (!confirm("确定要删除吗？删除后无法恢复！")) { return false; }
            $.ajax({
                url: 'CompanyReceive.aspx?action=Delete&id=' + id + '&ajax=1',
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
                            //Search();
                            break;

                    }
                }, error: function () { alert('发生错误，请重试！'); }
            })
            return false;
        }

        function SwitchReceiveFunction(status) {
            var msg = "";
            if (status==1) {
                msg = "确定开启接站功能吗？";
            } else {
                msg = "确定关闭接站功能吗？";
            }

            if (!confirm(msg)) { return false; }
            $.ajax({
                url: 'CompanyReceive.aspx?action=SwitchReceiveFunction&id=<%=Id %>&ajax=1',
                data: { 'status': status },
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
                                $('#btnOpenReceive').linkbutton('disable');
                                $('#btnCloseReceive').linkbutton('enable');
                            } else {
                                $('#btnOpenReceive').linkbutton('enable');
                                $('#btnCloseReceive').linkbutton('disable');
                            }
                            break;
                    }
                }, error: function () { alert('发生错误！请重试！'); }
            });
        }
    </script>
    
    <div id="toolbar_cv" style="padding: 5px; height: auto;">
        <a class="easyui-linkbutton" onclick="SwitchReceiveFunction(1)" id="btnOpenReceive" <%=isreceive ? "disabled='true'" : "" %>>开启接站功能</a>
        <a class="easyui-linkbutton" onclick="SwitchReceiveFunction(0)" id="btnCloseReceive" <%=!isreceive ? "disabled='true'" : "" %>>关闭接站功能</a>
        <a class="easyui-linkbutton" iconcls="icon-add" onclick="ShowAddReceive()">新增/修改接站日期</a>
    </div>
    <table id="tbdata_cv">
    </table>
    <div id="winAddReceive"></div>
    <%--<div id="winAddReceive" class="easyui-window" data-options="title:'新增接站日期',iconCls:'icon-save',modal:true,closed:true,minimizable:false,collapsible:false">
        <form id="formAddReceive">
        <input type="hidden" name="companyid" value="<%=Id %>" />
        <input type="hidden" name="id" value="0" />
        <input type="hidden" name="action" value="add" />
        <div class="frmborder">
            <p>新增/修改接站日期</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>接站日期：</th>
                <td><input type="text" id="receiveEndDate" name="receiveEndDate" class="easyui-datebox" /></td>
            </tr>
            <tr>
                <th>接站地点：</th>
                <td><input type="text" name="receiveAddress" class="txtCls" /></td>
            </tr>
            <tr>
                <th></th>
                <td><a class="easyui-linkbutton" iconcls="icon-add" onclick="AddReceive()">保存</a></td>
            </tr>
        </table>
        </form>
    </div>--%>
</body>
</html>

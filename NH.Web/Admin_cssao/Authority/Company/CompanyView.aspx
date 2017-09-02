<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyView.aspx.cs" Inherits="NH.Web.adm.Company.CompanyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <%--<script src="/Script/Common.js" type="text/javascript"></script>--%>
    <script src="/Script/load_area.js" type="text/javascript"></script>
    <script type="text/javascript">

        function createFrame(url) {
            return '<iframe frameborder="0" src="' + url + '" style="width:100%;height:100%;"></iframe>';
        }
        function OpenWin(id, title,url) {
            var win = $('#win');
            win.window({
                title: title,
                width: 800,
                height: 500,
                minimizable: false,
                collapsible: false,
                maximized: true,
                modal: true,
                content: createFrame(url),
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
                title: '企业列表',
                toolbar: '#toolbar',
                url: 'CompanyList.aspx?action=GetList&ajax=1',
                queryParams: getSearchKeys(),
                singleSelect: true,
                pagination: true,
                pageSize: 10,
                idField: 'Id',
                columns: [[
                    { field: 'Id', title: 'Id', width: 50 },
                    { field: 'LoginName', title: '帐号', width: 80, align: 'center' },
                    { field: 'CompanyName', title: '企业名称', width: 120, align: 'center' },
                    { field: 'Area', title: '地区', width: 120, align: 'center' },
                    { field: 'Contact', title: '联系人', width: 70, align: 'center' },
                    { field: 'Phone', title: '联系电话', width: 80, align: 'center' },
                    { field: 'Email', title: 'Email', width: 100, align: 'center' },
                    { field: 'LevelName', title: '会员等级', width: 100, align: 'center' },
                    { field: 'ExpireDate', title: '到期时间', width: 80, align: 'center', formatter: function (value) { return value.split(' ')[0] } },
                    { field: 'AddTime', title: '注册时间', width: 120, align: 'center' },
                    { field: 'Status', title: '状态', width: 50, align: 'center', formatter: GetStatus },
                    { field: '操作', title: '操作', width: 120, align: 'center', formatter: GetButtons }
                ]]
            });
            function GetStatus(value, row) {
                var result = '';
                switch (row.Status) {
                    case "0":
                        result = "<span class='red'>已禁用</span>";
                        break;
                    case "1":
                        switch (row.VerifyStatus) {
                            case "0":
                                result = "<span class='red'>未审核</span>";
                                break;
                            case "1":
                                if (row.IsVerify == "True")
                                    result = "<span class='red'>待审核</span>";
                                else
                                    result = "<span class='blue'>已审核</span>";
                                break;
                            case "-1":
                                result = "<span class='red'>不通过</span>";
                                break;
                        }
                        break;
                }
                return result
            }
            function GetButtons(value, row, index) {
                return '<a href="#" onclick="return Manage(' + row.Id + ')">管理</a> <a href="#" onclick="return SetTop(' + row.Id + ')">置顶</a> <a href="CompanyVerify.aspx?id=' + row.Id + '" onclick="return Show(' + row.Id + ')">审核</a>'
                + ' <a href="#" onclick="return DeleteCompany(' + row.Id + ')">删除</a>';
            }
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
                expiredate1: $('[name=expiredate1]').val(),
                expiredate2: $('[name=expiredate2]').val(),
                level: $('[name=ddlLevels]').val(),
                area: $('#ddlAreaCity').val() != "0" ? $('#ddlAreaCity').val() : $('#ddlAreaProvince').val()
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
            OpenWin(id, "企业信息审核-" + row.LoginName + (row.CompanyName != "" ? "[" + row.CompanyName + "]" : ""), 'CompanyVerify.aspx?id=' + id);
            return false;
        }
        function Manage(id) {
            objTbList.datagrid('selectRecord', id);
            var row = objTbList.datagrid('getSelected');
            OpenWin(id, "企业信息管理-" + row.LoginName + (row.CompanyName != "" ? "[" + row.CompanyName + "]" : ""), 'CompanyPanel.aspx?id=' + id);
            return false;
        }

        function DeleteCompany(id) {
            if (!confirm("确定要删除吗？删除后无法恢复！")) { return false; }
            $.ajax({
                url: 'CompanyList.aspx?action=Delete&id=' + id + '&ajax=1',
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

        function SetTop(id) {
            if (!confirm("确定要置顶吗？")) { return false; }
            $.ajax({
                url: 'CompanyList.aspx?action=SetTop&id=' + id + '&ajax=1',
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
                            Search();
                            break;

                    }
                }, error: function () { alert('发生错误，请重试！'); }
            })
            return false;
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            LoadArea('ddlAreaProvince', 'ddlAreaCity', '', '', '', '');
        });
    </script>
</head>
<body>
    <div id="toolbar" style="padding: 5px; height: auto;">
        用户名：<input type="text" id="loginname" name="loginname" class="txtSmall" />
        企业名称：<input type="text" id="companyname" name="companyname" class="txtSmall" />
        注册时间：<input type="text" id="starttime" name="starttime" class="easyui-datebox" />至<input
            type="text" id="endtime" name="endtime" class="easyui-datebox" />
        <select id="ddlLevels" name="ddlLevels">
            <option value="0">所有等级</option>
            <%=_levels %>
        </select>
        <br />
        <select id="ddlAreaProvince" name="ddlAreaProvince">
            <option value="0">选择省</option>
        </select>
        <select id="ddlAreaCity" name="ddlAreaCity">
            <option value="0">选择城市</option>
        </select>
        到期时间：<input type="text" id="expiredate1" name="expiredate1" class="easyui-datebox" />至<input
            type="text" id="expiredate2" name="expiredate2" class="easyui-datebox" />
        <a id="btnSearch" class="easyui-linkbutton" iconcls="icon-search" onclick="Search()">
            搜索</a>
    </div>
    <table id="tbdata">
    </table>
    <div id="win">
    </div>
    <script type="text/javascript">var areas = <asp:Literal ID="ltrAreaJsObject" runat="server"></asp:Literal>;</script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ddlAreaProvince').formSelect({
                //emptyText : '请选择省份...',
                cols: 4,
                colWidth: 80,
                onSelect: function () {
                    $('#ddlAreaCity').children().remove();
                    $.each(areas[$('#ddlAreaProvince').val()], function (key, value) {
                        $('#ddlAreaCity').append($('<option value="' + key + '">' + value + '</option>'));
                    });

                    //调用内部函数刷新
                    $('#ddlAreaProvince').data('Obj').reflash($('#ddlAreaCity'));
                },
                onShow: function () {
                    $('#ddlAreaProvince').trigger('focusListener');
                },
                onClose: function () {
                    $('#ddlAreaProvince').trigger('blurListener');
                }

            });

            $('#ddlAreaCity').formSelect({
                emptyText: '请选择城市...',
                cols: 3,
                colWidth: 80
            });
        });
    </script>
</body>
</html>

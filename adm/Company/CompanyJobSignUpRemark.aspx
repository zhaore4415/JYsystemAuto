<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyJobSignUpRemark.aspx.cs" Inherits="NH.Web.adm.Company.CompanyJobSignUpRemark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript%>
    <%=EasyUI_CssAndScript %>
    
</head>
<body>
    <script type="text/javascript">
        var objTbList;
        $(document).ready(function () {
            objTbList = $('#tbdata_Remark');
            objTbList.datagrid({
                //title: '联系记录',
                toolbar: '#toolbar_Remark',
                url: 'CompanyJobSignUpRemark.aspx?action=GetList&Id=<%=Id %>&SignUpID=<%=Request.QueryString["SignUpID"]%>&ajax=1',
                queryParams: getSearchKeys_Remark(),
                singleSelect: true,
                pagination: true,
                pageSize: 10,
                idField: 'Id',
                fit: true,
                columns: [[
                //{ field: 'Id', title: 'Id', width: 50 },
                    {field: 'ContactTime', title: '联系时间', width: 120, align: 'center' },
                    { field: 'IsIntent', title: '是否有意向', width: 80, align: 'center', formatter: function (value) { return value == "True" ? "是" : "否" } },
                    { field: 'IsReIntroduce', title: '是否转介绍', width: 80, align: 'center', formatter: function (value) { return value == "True" ? "是" : "否" } },
                    { field: 'UserStatus', title: '状态', width: 60, align: 'center', formatter: GetStatus },
                    { field: 'Remark', title: '备注', width: 150, align: 'center' },
                    { field: 'AddUserName', title: '联系者', width: 80, align: 'center' }//,
                    //{ field: '操作', title: '操作', width: 220, align: 'center', formatter: GetButtons }
                ]]
            });
            function GetButtons(value, row, index) {
                return '<a href="CompanyJobSignUpRemark.aspx?id=' + row.Id + '" onclick="return ShowSignUpRemark(' + row.Id + ')">联系记录管理</a>'
                + ' <a href="#" onclick="return DeleteSignUp(' + row.Id + ')">删除</a>';
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
        function getSearchKeys_Remark() {
            var keys = {
                loginname: $('#loginname').val(),
                realname: $('#companyname').val(),
                starttime: $('[name=starttime_jl]').val(),
                endtime: $('[name=endtime_jl]').val()
            };
            return {};
        }
        function Search_Remark() {
            objTbList.datagrid('options').queryParams = getSearchKeys_Remark();
            objTbList.datagrid('load');
        }

        function ShowAdd() {
            $('#winSignUpRemark').window('open');
        }
        function Add() {
            $.ajax({
                url: "CompanyJobSignUpRemark.aspx?action=Add&ajax=1",
                data: $('#formAdd').serialize(),
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
                            $('#winSignUpRemark').window('close');
                            objTbList.datagrid('load');
                            window.parent.Search_bm();
                            break;
                    }
                }
            });
        }
    </script>
    <div id="toolbar_Remark" class="toolbar">
        <a class="easyui-linkbutton" iconcls="icon-add" onclick="ShowAdd()">新增联系记录</a>
    </div>
    <table id="tbdata_Remark">
    </table>
    <div id="winSignUpRemark" class="easyui-window" data-options="title:'新增联系记录',closed:true,minimizable:false,collapsible:false,maximized: false,modal: true">
        <form id="formAdd" runat="server" enableviewstate="false">
        <input type="hidden" name="SuCId" value="<%=Id %>" />
        <input type="hidden" name="SignUpID" value="<%=Request.QueryString["SignUpID"]%>" />
    <div id="Add">
        
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>联系时间：</th>
                <td>                
                    <input type="text" name="contacttime" class="easyui-datetimebox" value="<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>" style=" width:150px" />
                </td>
            </tr>
            <tr>
                <th>是否有意向：</th>
                <td>
                    <select id="ddlIsIntent" name="ddlIsIntent">
                        <option value="1">是</option>
                        <option value="0">否</option>
                    </select>                    
                </td>
            </tr>
            <tr>
                <th>是否转介绍：</th>
                <td>
                    <select id="ddlIsReIntroduce" name="ddlIsReIntroduce">
                        <option value="1">是</option>
                        <option value="0">否</option>
                    </select>                    
                </td>
            </tr>
            <tr>
                <th>状态：</th>
                <td>
                    <select id="ddlStatus" name="ddlStatus">
                        <option value="1">已达成</option>
                        <option value="2">未达成</option>
                        <option value="3">已就职</option>
                        <option value="4">未就职</option>
                        <option value="5">需回访</option>
                    </select>              
                </td>
            </tr>
            <tr>
                <th>备注：</th>
                <td>                
                    <input type="text" name="Remark" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <a class="easyui-linkbutton" iconCls="icon-save" onclick="Add()">确定</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
    </div>
</body>
</html>

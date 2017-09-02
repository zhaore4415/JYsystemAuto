<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobSuperFixAdd.aspx.cs" Inherits="NH.Web.adm.Ad.JobSuperFixAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <script src="../Script/jobStatus.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnQuery').click(function () {
                var id = $.trim($('#txtCompanyID').val());
                if (id == "") { alert('请输入企业ID'); return; } else if (isNaN(id)) {
                    alert('ID不正确'); return;
                }
                var objinfo = $('#cinfo');
                objinfo.text('正在查询...');
                $.ajax({
                    url: '../ajax/Common.ashx?action=GetCompanyModal&id=' + id,
                    cache: false,
                    dataType: 'json',
                    success: function (data) {
                        if (data.total > 0) {
                            objinfo.text(data.rows[0].CompanyName);
                            $('#companyid').val(id);
                            objTbList.datagrid('options').url = '../ajax/Common.ashx?action=GetCompanyJobs&companyid=' + id;
                            objTbList.datagrid('load');
                        } else {
                            objinfo.text('输入的ID不存在！');
                        }
                    }, error: function () {
                        alert('发生错误！');
                        objinfo.text('发生错误！');
                    }
                });
            });

            function getRadio(value, row, index) {
                return '<input type="radio" name="jid" value="' + row.Id + '" />';
            }
            objTbList = $('#tbdata');
            objTbList.datagrid({
                title: '招聘信息',
                singleSelect: true,
                pagination: false,
                pageSize: 10,
                idField: 'Id',
                columns: [[
                    { field: '选择', title: '选择', width: 50, checkbox: true },
                    { field: 'Id', title: 'Id', width: 50 },
                    { field: 'Name', title: '职位名称', width: 130, align: 'left' },
                    { field: 'UpdateTime', title: '修改时间', width: 120, align: 'center' },
                    { field: 'RefreshTime', title: '置顶时间', width: 120, align: 'center' },
                    { field: 'Status', title: '职位状态', width: 120, align: 'center', formatter: function (value, row, index) { return GetJobStatus(row.Status, row.Verified); } }
                ]]
            });
            $('#btnSubmit').click(function () {
                var row = objTbList.datagrid('getSelected');
                if (!row) {
                    alert('请选择招聘职位'); return false;
                } else {
                    $('#jobid').val(row.Id);
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
    <div class="frmborder">
            <p>广告管理 -> <a href="<%=ListUrl %>?cid=<%=Request.QueryString["cid"] %>"><asp:Literal runat="server" ID="ltrTypeName"></asp:Literal></a> -> 添加</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>所属类型：</th>
                <td>
                    <asp:Literal runat="server" ID="ltrTypeName2"></asp:Literal>
                    (<asp:Literal runat="server" ID="ltrDesc"></asp:Literal>)
                </td>
            </tr>
            <tr>
                <th>
                    企业ID：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtCompanyID" Width="50" CssClass="txtCls"></asp:TextBox><input type="button" id="btnQuery" class="btnSmall" value="查询" /><span id="cinfo" class="red"></span>
                </td> 
            </tr>
            <tr>
                <th>招聘职位：</th>
                <td>
                    <table id="tbdata"></table>
                </td>
            </tr>
            <tr>
                <th>
                    展示时间：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtStartDate" CssClass="easyui-datebox"></asp:TextBox>至<asp:TextBox runat="server" ID="txtEndDate" CssClass="easyui-datebox"></asp:TextBox>(时间留空表示无时间限制)
                </td>
            </tr>
            <tr>
                <th>
                    备注：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    状态：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblStatus" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1" Selected="True">发布</asp:ListItem>
                        <asp:ListItem Value="0">关闭</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btnSubmit" onclick="btnSubmit_Click" />
                    <input type="hidden" id="companyid" name="companyid" />
                    <input type="hidden" id="jobid" name="jobid" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

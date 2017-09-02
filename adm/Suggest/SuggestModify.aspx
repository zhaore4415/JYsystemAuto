<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuggestModify.aspx.cs" Inherits="NH.Web.adm.Suggest.SuggestModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <script type="text/javascript">
        $(document).ready(function () {
            var form = $('#form1');
            form.form({
                url:form.attr('action') + '&ajax=1',
                onSubmit: function () {
                    // do some check  
                    // return false to prevent submit;  
                },
                success: function (data) {
                    try {
                        data = eval('(' + data + ')');
                    } catch (err) {
                        alert('发生错误');
                        return;
                    }
                    switch (data.status) {
                        case "ok":
                            alert('保存成功');
                            break;
                        case "error":
                            alert(data.msg);
                            break;
                        case "nologin":
                            alert('请先登录');
                            break;
                        case "nopower":
                            alert('没有此操作的权限');
                            break;
                    }
                }
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
    <div class="frmborder">
            <p>意见与建议管理</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    标题：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbTitle"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    内容：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbDescription"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    用户类型：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbUserType"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    用户名：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbLoginName"></asp:Label>
                </td>
            </tr>
            <asp:PlaceHolder runat="server" ID="phCompanyName">
            <tr>
                <th>
                    企业名称：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbCompanyName"></asp:Label>
                </td>
            </tr>
            </asp:PlaceHolder>
            <tr>
                <th>
                    姓名：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbName"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    联系电话：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbPhone"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    邮箱：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbEmail"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    提交时间：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbAddTime"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    备注：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtRemark" Rows="5" Columns="50" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>                    
                    <input type="hidden" id="action" name="action" />
                    <a class="easyui-linkbutton" iconCls="icon-save" onclick="$('#action').val('modify');$('#form1').submit()">保存</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

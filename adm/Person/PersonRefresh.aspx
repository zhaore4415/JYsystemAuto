<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonRefresh.aspx.cs" Inherits="NH.Web.adm.Person.PersonRefresh" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        function PersonRefresh() {
            if (!confirm("确定要置顶吗？")) return false;
            $.ajax({
                url: 'PersonRefresh.aspx?id=<%=Id %>&ajax=1',
                data: { 'action': 'refresh' },
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
                            $('#lbLastRefreshTime').text(data.data);
                            alert('操作成功');
                            break;

                    }
                }
            });
        }
    </script>
    <div id="Add">
        <div class="frmborder">
            <p>
                简历置顶</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    上次置顶时间：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbLastRefreshTime"></asp:Label>
                </td>
                <td>
                    <a class="easyui-linkbutton" iconCls="icon-reload" onclick="javascript:PersonRefresh()">置顶</a>
                </td>
            </tr>
            
            
        </table>
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyFace.aspx.cs" Inherits="NH.Web.adm.Company.CompanyFace" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <script type="text/javascript">
        function VerifyFace(obj, status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【审核通过】" : "【审核不通过】") + "吗？")) { return false; }
            $.ajax({
                url: $('#formPersonFace').attr('action') + '&ajax=1',
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
                            $(obj).attr('disabled', true);
                            var tab = $('#tt').tabs('getSelected');  // get selected panel
                            tab.panel('refresh', '<%=Request.RawUrl %>');
                            break;

                    }
                }
            })
        }
    </script>
    <form id="formPersonFace" runat="server">
    <div id="Add">
        <div class="frmborder">
            <p>
                形象照片</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    当前头像：
                </th>
                <td>
                    <asp:Image runat="server" ID="imgCurrentFace" />
                </td>
            </tr>
            <asp:PlaceHolder runat="server" ID="phNewFace">
            <tr>
                <th>
                    新上传原图：
                </th>
                <td>
                    <asp:Image runat="server" ID="imgOriginalFace" />
                </td>
            </tr>
            <tr>
                <th>
                    新上传裁剪后：
                </th>
                <td>
                    <asp:Image runat="server" ID="imgNewSmallFace" />
                </td>
            </tr>
            </asp:PlaceHolder>
            <tr>
                <th>
                </th>
                <td>
                    <%if(_verifyStatus ==0){%>
                    <a class="easyui-linkbutton" iconCls="icon-ok" onclick="VerifyFace(this,1)">审核通过</a>
                    <a class="easyui-linkbutton" iconCls="icon-no" onclick="VerifyFace(this,-1)">审核不通过</a>
                    <%}else if(_verifyStatus == -1){%>
                    <a class="easyui-linkbutton" iconCls="icon-no" onclick="VerifyFace(this,1)">审核通过</a>
                    <%} %>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VipAdModify.aspx.cs" Inherits="NH.Web.adm.Ad.VipAdModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
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
                        } else {
                            objinfo.text('输入的ID不存在！');
                        }
                    }, error: function () {
                        alert('发生错误！');
                        objinfo.text('发生错误！');
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
    <div class="frmborder">
            <p>广告管理 -> <a href="<%=ListUrl %>?cid=<%=Request.QueryString["cid"] %>"><asp:Literal runat="server" ID="ltrTypeName"></asp:Literal></a> -> 修改</p>
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
                    <asp:TextBox runat="server" ID="txtCompanyID" Width="50" CssClass="txtCls"></asp:TextBox><input type="button" id="btnQuery" class="btnSmall" value="查询" /><asp:Label runat="server" id="cinfo" CssClass="red"></asp:Label>
                </td> 
            </tr>
            <tr>
                <th>
                    标题：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtTitle" Width="200" CssClass="txtCls"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    链接地址：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtUrl" CssClass="txtCls" Width="200"></asp:TextBox>
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
                    图片：
                </th>
                <td>
                    <asp:Image runat="server" ID="img" /><br /><br />
                    <asp:FileUpload runat="server" ID="file" />(点击重新上传图片)
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
                    排序值：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtSort"></asp:TextBox>
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
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

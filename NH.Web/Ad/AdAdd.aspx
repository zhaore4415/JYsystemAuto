<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdAdd.aspx.cs" Inherits="NH.Web.adm.Ad.AdAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <script src="../Script/Common.js" type="text/javascript"></script>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $('#ddlCategory').change(function () {
                $('#desc').html($(this).find('option:selected').attr('desc'));
            }).change();
        });
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
    <div class="frmborder">
            <p>广告管理 -> <a href="<%=ListUrl %>?<%=Request.QueryString.ToString() %>"><asp:Literal runat="server" ID="ltrTypeName"></asp:Literal></a> -> 添加</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>所属类型：</th>
                <td>
                    <asp:Literal runat="server" ID="ltrTypeName2"></asp:Literal>
                    (<asp:Literal runat="server" ID="ltrDesc"></asp:Literal>)
                    <%--<asp:DropDownList runat="server" ID="ddlCategory">                        
                    </asp:DropDownList><span id="desc"></span>--%>
                </td>
            </tr>
            <tr>
                <th>
                    所属地区：
                </th>
                <td>
                    <select id="ddlCurrProvince" name="ddlCurrProvince" style=" width:80px;">
                        <option>选择省</option>
                        <asp:Literal ID="ltrCurrProvince" runat="server"></asp:Literal>
                    </select>
                    <select id="ddlCurrCity" name="ddlCurrCity" style=" width:80px;">
                        <option>选择城市</option>
                        <asp:Literal ID="ltrCurrCity" runat="server"></asp:Literal>
                    </select>
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
                    <asp:FileUpload runat="server" ID="file" />
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
                </td>
            </tr>
        </table>
    </div>
    </form>
    
    <script type="text/javascript">var areas = <asp:Literal ID="ltrAreaJsObject" runat="server"></asp:Literal>;</script>
    <script type="text/javascript">
        $('#ddlCurrProvince').formSelect({
            //emptyText : '请选择省份...',
            cols: 4,
            colWidth: 80,
            onSelect: function () {
                $('#ddlCurrCity').children().remove();
                $.each(areas[$('#ddlCurrProvince').val()], function (key, value) {
                    $('#ddlCurrCity').append($('<option value="' + key + '">' + value + '</option>'));
                });

                //调用内部函数刷新
                $('#ddlCurrProvince').data('Obj').reflash($('#ddlCurrCity'));
            },
            onShow: function () {
                $('#ddlCurrProvince').trigger('focusListener');
            },
            onClose: function () {
                $('#ddlCurrProvince').trigger('blurListener');
            }

        });

        $('#ddlCurrCity').formSelect({
            emptyText: '请选择城市...',
            cols: 3,
            colWidth: 80
        });
    </script>
</body>
</html>

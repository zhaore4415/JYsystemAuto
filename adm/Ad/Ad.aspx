<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ad.aspx.cs" Inherits="NH.Web.adm.Ad.Ad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript%>
    <script src="../Script/Common.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Resize(img) {
            if (img.width > 300) {
                img.width = 300;
            }
        }
    </script>
</head>
<body>
    <div id="List">
        <form id="form1" runat="server">
        <div class="frmborder">
            <p>
                广告管理 -> <asp:Literal runat="server" ID="ltrTypeName"></asp:Literal></p>
        </div>
        <div class="frmborder">
            <select id="ddlAreaProvince" name="ddlAreaProvince">
                <option value="">选择省</option>
                <asp:Literal ID="ltrAreaProvince" runat="server"></asp:Literal>
            </select>
            <select id="ddlAreaCity" name="ddlAreaCity">
                <option value="">选择城市</option>
                <asp:Literal ID="ltrAreaCity" runat="server"></asp:Literal>
            </select>
            <asp:Button runat="server" ID="btnSearch" Text="搜索" onclick="btnSearch_Click" CssClass="btnSmall" />
            <asp:Button runat="server" ID="btnDelete" Text="删除" onclick="btnDelete_Click" CssClass="btnSmall"/>
            <input type="button" value="添加" class="btnSmall" onclick="window.location.href='<%=PagePreFix %>Add.aspx?<%=Request.QueryString.ToString() %>'" />
        </div>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table id="tablist" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="th">
                        <td width="40">
                            <input type="checkbox" id="chkAll" title="全选" />
                        </td>
                        <td>标题</td>
                        <td>图片</td>
                        <td>链接</td>
                        <td>地区</td>
                        <td>开始时间</td>
                        <td>结束时间</td>
                        <td>添加时间</td>
                        <td>排序值</td>
                        <td>状态</td>
                        <td width="100">
                            操作
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr">
                    <td>
                        <input type="checkbox" name="chkItem" value="<%#Eval("Id")%>" />
                    </td>
                    <td>
                        <%#Eval("Title")%>
                    </td>
                    <td>
                        <a href="<%# folder + Eval("Pic").ToString()%>" target="_blank"><img src="<%# folder + Eval("Pic").ToString()%>" onload="javascript:Resize(this)" /></a>
                    </td>
                    <td>
                        <%#Eval("Url")%>
                    </td>
                    <td>
                        <%#Eval("AreaName")%>
                    </td>
                    <td>
                        <%#Eval("StartDate","{0:yyyy-MM-dd}")%>
                    </td>
                    <td><%# Eval("EndDate", "{0:yyyy-MM-dd}")%></td>
                    <td><%# Eval("AddTime") %></td>
                    <td><%# Eval("Sort")%></td>
                    <td><%# (bool)Eval("IsShow") ? "开启" : "<font color='red'>关闭</font>"%></td>
                    <td>
                        <a href="<%=PagePreFix %>Modify.aspx?id=<%#Eval("Id")%>&cid=<%=Request.QueryString["cid"] %>">编辑</a> | <a href="#" onclick="javascript:return DeleteOne(<%#Eval("Id")%>)">
                            删除</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
        <%=_pager%>
        </form>
    </div>
    <script type="text/javascript">var areas = <asp:Literal ID="ltrAreaJsObject" runat="server"></asp:Literal>;</script>
    <script type="text/javascript">
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
    </script>
</body>
</html>

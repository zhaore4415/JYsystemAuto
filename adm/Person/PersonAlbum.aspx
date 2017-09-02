<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonAlbum.aspx.cs" Inherits="NH.Web.adm.Person.PersonAlbum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<%=CssAndScript%>
    <%=EasyUI_CssAndScript %>--%>
</head>
<body>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.PersonAlbum a.original').click(function () {
                var obj = $(this);
                var objWin = $('<div></div>').dialog({
                    title: '个人相册',
                    width: $(window).width() - 100,
                    height: $(window).height() - 50,
                    top: 25,
                    maximizable: true,
                    resizable: true,
                    modal: true,
                    content: '<div style="text-align:center"><div>' + obj.attr('title') + '</div><div><img src="' + obj.attr('href') + '" /></div><div>',
                    buttons: [
                        {
                            id: 'btnYes',
                            iconCls: 'icon-ok',
                            text: '审核通过',
                            disabled: obj.attr('status') == "1" ? true : false,
                            handler: function () { VerifyAlbum(obj.attr('aid'), 1,obj); }
                        }, {
                            id: 'btnNo',
                            iconCls: 'icon-cancel',
                            text: '审核不通过',
                            disabled: obj.attr('status') == "-1" ? true : false,
                            handler: function () { VerifyAlbum(obj.attr('aid'), -1,obj); }
                        }, {
                            id: 'btnDel',
                            iconCls: 'icon-cancel',
                            text: '删除',
                            handler: function () { DeleteAlbum(obj.attr('aid'), objWin); }
                        }
                    ],
                    onClose: function () { objWin.dialog('destroy'); }
                });
                return false;
            });
            function VerifyAlbum(id, status, objLink) {
                if (!confirm("确定要更改为" + (status == 1 ? "【审核通过】" : "【审核不通过】") + "吗？")) { return false; }
                $.ajax({
                    url: 'PersonAlbum.aspx?id=' + id + '&ajax=1',
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
                                if (status == 1) {
                                    $('#btnYes').linkbutton('disable');
                                    $('#btnNo').linkbutton('enable');
                                    objLink.attr('status', '1').siblings('.jsStatus').html("<font color='blue'>已通过</font>");
                                } else {
                                    $('#btnYes').linkbutton('enable');
                                    $('#btnNo').linkbutton('disable');
                                    objLink.attr('status', '-1').siblings('.jsStatus').html("<font color='red'>不通过</font>");
                                }
                                break;

                        }
                    }
                })
            }
            function DeleteAlbum(id, objWin) {
                if (!confirm("确定要删除吗？")) { return false; }
                $.ajax({
                    url: 'PersonAlbum.aspx?ajax=1',
                    data: { 'action': 'delete', 'id': id },
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
                                $('#album-' + id).remove();
                                objWin.dialog('close');
                                break;

                        }
                    }, error: function () { alert('发生错误！请重试！'); }
                })
            }
        });
    </script>
        <ul class="PersonAlbum">
        <asp:Repeater runat="server" ID="rptList">
            <ItemTemplate>
                <li id="album-<%#Eval("Id") %>">
                    <a class="pic" <%--href='<%=bigfolder %><%# Eval("ImgBig")%>'--%> title="<%# Eval("Title")%>"><img src='<%=smallfolder %><%# Eval("ImgSmall") %>' alt="<%# Eval("Title")%>" title="<%# Eval("Title")%>" /></a>
                    <%--<p><a href="<%#NH.Web.Urls.AlbumUpdate_P(Eval("Id").ToString()) %>" title="点击修改"><%#Eval("Title") %></a></p>--%>
                    <div>
                        <span class="jsStatus"><%#GetStatus((int)Eval("Status"))%></span>
                        <a class="original" href="<%=originalfolder %><%# Eval("ImgBig")%>" title="<%# HtmlEncode(Eval("Title").ToString()) %>" aid="<%#Eval("Id") %>" status="<%# Eval("Status") %>">查看大图</a>
                    </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        </ul>
</body>
</html>

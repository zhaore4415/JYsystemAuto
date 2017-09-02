<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonWorks.aspx.cs" Inherits="NH.Web.adm.Person.PersonWorks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style type="text/css">
        .albumcat{ font-weight:bold;}
        .albumlist li{ float:left; width:150px; height:160px; margin:10px; text-align:center;}
        .albumlist li div{ line-height:20px;}
        .albumlist li div.pic{ width:125px; height:125px; border:1px solid #dddddd; margin:auto;}
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            function WinResize(objImg) {
                var minW = 600;
                var maxW = $(window).width();
                var width = 0;
                var imgW = $(objImg).width();
                if (imgW < minW) {
                    width = minW + 50;
                } else if (imgW > minW) {
                    width = imgW + 50;
                } else if (imgW > maxW) {
                    width = maxW - 100;
                }

                $('#win').dialog('resize', {
                    width: width,
                    height: $(window).height() - 50
                }).window('hcenter');
            }
            $('.albumlist a.original').click(function () {
                var obj = $(this);
                var objWin = $('<div id="win"></div>').dialog({
                    title: '个人作品',
                    width: 650,
                    height: $(window).height() - 50,
                    top: 25,
                    maximizable: true,
                    resizable: true,
                    modal: true,
                    content: '<div style="text-align:center"><div>' + obj.attr('title') + '</div><div><img src="' + obj.attr('href') + '" onload="WinResize(this)" /></div><div>',
                    buttons: [
                        {
                            id: 'btnYes',
                            iconCls: 'icon-ok',
                            text: '审核通过',
                            disabled: obj.attr('status') == "1" ? true : false,
                            handler: function () { VerifyWorks(obj.attr('aid'), 1, obj); }
                        }, {
                            id: 'btnNo',
                            iconCls: 'icon-no',
                            text: '审核不通过',
                            disabled: obj.attr('status') == "-1" ? true : false,
                            handler: function () { VerifyWorks(obj.attr('aid'), -1, obj); }
                        }, {
                            id: 'btnCommendYes',
                            iconCls: 'icon-ok',
                            text: "推荐",
                            disabled: obj.attr('commend') == "True" ? true : false,
                            handler: function () { SetCommendWorks(obj.attr('aid'), 1, obj); }
                        }, {
                            id: 'btnCommendNo',
                            iconCls: 'icon-no',
                            text: "取消推荐",
                            disabled: obj.attr('commend') == "False" ? true : false,
                            handler: function () { SetCommendWorks(obj.attr('aid'), 0, obj); }
                        }, {
                            id: 'btnDel',
                            iconCls: 'icon-cancel',
                            text: '删除',
                            handler: function () { DeleteWorks(obj.attr('aid'), objWin); }
                        }
                    ],
                    onClose: function () { objWin.dialog('destroy'); }
                });
                return false;
            });
            function VerifyWorks(id, status, objLink) {
                if (!confirm("确定要更改为" + (status == 1 ? "【审核通过】" : "【审核不通过】") + "吗？")) { return false; }
                $.ajax({
                    url: 'PersonWorks.aspx?id=' + id + '&ajax=1',
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
                                    objLink.attr('status', '1').siblings('.jsStatus').html("[<font color='blue'>已通过</font>]");
                                } else {
                                    $('#btnYes').linkbutton('enable');
                                    $('#btnNo').linkbutton('disable');
                                    objLink.attr('status', '-1').siblings('.jsStatus').html("[<font color='red'>不通过</font>]");
                                }
                                break;

                        }
                    }, error: function () { alert('发生错误！请重试！'); }
                })
            }
            function DeleteWorks(id, objWin) {
                if (!confirm("确定要删除吗？")) { return false; }
                $.ajax({
                    url: 'PersonWorks.aspx?ajax=1',
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
                                $('#works-' + id).remove();
                                objWin.dialog('close');
                                break;

                        }
                    }, error: function () { alert('发生错误！请重试！'); }
                })
            }

            function SetCommendWorks(id, commend, objLink) {
                if (!confirm("确定" + (commend == 1 ? "设为【推荐】" : "【取消推荐】") + "吗？")) { return false; }
                $.ajax({
                    url: 'PersonWorks.aspx?ajax=1',
                    data: { 'action': 'SetCommend', 'id': id, 'commend': commend },
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
                                if (commend == 1) {
                                    $('#btnCommendYes').linkbutton('disable');
                                    $('#btnCommendNo').linkbutton('enable');
                                    objLink.attr('commend', 'True').siblings('.jsCommend').html("<font color='blue'>[已推荐]</font>");
                                } else {
                                    $('#btnCommendYes').linkbutton('enable');
                                    $('#btnCommendNo').linkbutton('disable');
                                    objLink.attr('commend', 'False').siblings('.jsCommend').html("");
                                }
                                break;
                        }
                    }, error: function () { alert('发生错误！请重试！'); }
                });
            }
        });

        function SetGood(commend) {
            if (!confirm("确定" + (commend == 1 ? "【推荐到精英摄区】" : "【取消精英摄区推荐】") + "吗？")) { return false; }
            $.ajax({
                url: 'PersonWorks.aspx?id=<%=Id %>&ajax=1',
                data: { 'action': 'SetGood', 'commend': commend },
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
                            if (commend == 1) {
                                $('#btnGoodYes').linkbutton('disable');
                                $('#btnGoodNo').linkbutton('enable');
                            } else {
                                $('#btnGoodYes').linkbutton('enable');
                                $('#btnGoodNo').linkbutton('disable');
                            }
                            break;
                    }
                }, error: function () { alert('发生错误！请重试！'); }
            });
        }
    </script>
    <div class="frmborder"><p>最多能上传<span><%=maxCount %></span>幅图片，每个分类最多能上传<span><%=Maticsoft.Common.Config.PersonWorksCount %></span>张图片，一共还可以上传<span><%=maxCount-count %></span>幅　<a id="btnGoodYes" class="easyui-linkbutton" data-options="iconCls:'icon-recommend'" <%=_isGood ? "disabled='true'" : "" %> onclick="javascript:SetGood(1)">设为精英</a> <a id="btnGoodNo" class="easyui-linkbutton" data-options="iconCls:'icon-no'" <%=!_isGood ? "disabled='true'" : "" %> onclick="javascript:SetGood(0)">取消精英</a></p></div>
    <asp:Repeater runat="server" ID="rptCategory">
        <ItemTemplate>
        <p class="albumcat"><%#Eval("Name") %></p>
        <ul class="albumlist">
        <asp:Repeater runat="server" ID="rptList" DataSource='<%#GetWorks(Eval("Id").ToString()) %>'>
            <ItemTemplate>
                <li id="works-<%#Eval("Id") %>">
                    <div class="pic"><img src='<%=smallfolder %><%# Eval("ImgSmall") %>' alt='' /></div>
                    <div><%#Eval("Title") %></div>
                    <div>
                        <span class="jsStatus">[<%#GetStatus((int)Eval("Status"))%>]</span>
                        <span class="jsCommend"><%#(bool)Eval("IsCommend") ? "[<font color='blue'>已推荐</font>]" : ""%></span>
                        <a class="original" href="<%=originalfolder %><%# Eval("ImgBig")%>" title="<%# HtmlEncode(Eval("Title").ToString()) %>" aid="<%#Eval("Id") %>" status="<%# Eval("Status") %>" commend="<%# Eval("IsCommend") %>" target="_blank">查看</a>
                    </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        </ul>
        <div class="clear"></div>
        </ItemTemplate>
    </asp:Repeater>
</body>
</html>

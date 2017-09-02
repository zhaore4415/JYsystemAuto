<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonVerify.aspx.cs" Inherits="NH.Web.adm.Person.PersonVerify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <script src="/Scripts/jquery-lightbox-0.5/js/jquery.lightbox-0.5.min.js" type="text/javascript"></script>
    <link href="/Scripts/jquery-lightbox-0.5/css/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .block{ display:block; color:Red;}
        .albumsverify{}
        .albumsverify li{ float:left; border:1px solid #dddddd; margin:1px; text-align:center; padding:2px; width:170px; height:175px;}
        .albumsverify li.yes{border:1px solid blue;}
        .albumsverify li.no{border:1px solid red;}
        .albumsverify li p{ height:auto;}
        .albumsverify li p.pic{ height:125px;}
        .albumsverify li p.pic img{ height:125px;}
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#albumlist a').lightBox({
                imageLoading: '/Scripts/jquery-lightbox-0.5/images/lightbox-ico-loading.gif',
                imageBtnPrev: '/Scripts/jquery-lightbox-0.5/images/lightbox-btn-prev.gif',
                imageBtnNext: '/Scripts/jquery-lightbox-0.5/images/lightbox-btn-next.gif',
                imageBtnClose: '/Scripts/jquery-lightbox-0.5/images/lightbox-btn-close.gif',
                imageBlank: '/Scripts/jquery-lightbox-0.5/images/lightbox-blank.gif'
            });
            $('#worklist a').lightBox({
                imageLoading: '/Scripts/jquery-lightbox-0.5/images/lightbox-ico-loading.gif',
                imageBtnPrev: '/Scripts/jquery-lightbox-0.5/images/lightbox-btn-prev.gif',
                imageBtnNext: '/Scripts/jquery-lightbox-0.5/images/lightbox-btn-next.gif',
                imageBtnClose: '/Scripts/jquery-lightbox-0.5/images/lightbox-btn-close.gif',
                imageBlank: '/Scripts/jquery-lightbox-0.5/images/lightbox-blank.gif'
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server" enableviewstate="false">
    <div id="Add">
        <div class="frmborder">
            <p>人才管理 -> 人才审核</p>
        </div>
        <div class="tbitem">
        <p class="title tab"><span>人才信息</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr class="title">
                <th colspan="4">头像</th>
            </tr>
            <tr>
                <th>头像：</th>
                <td colspan="3"><asp:Image runat="server" ID="imgFace" Visible="false" /><%=!_hasPhoto ? "暂无" : "" %></td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <%if(_hasPhoto) {%>
                        <%if(_photoVerifyStatus == 1){%>
                            已审核通过
                        <%}else{ %>
                            头像审核：
                            <input type="radio" id="rdPhoto_yes" name="rdPhoto" value="1" /><label for="rdPhoto_yes">审核通过</label>
                            <input type="radio" id="rdPhoto_no" name="rdPhoto" value="-1" <%=_photoVerifyStatus == -1 ? "checked=\"checked\"" : "" %> /><label for="rdPhoto_no">审核不通过</label>                        
                            <input type="hidden" id="val_photo" name="val_photo" value="<%=_photoVerifyStatus %>" />
                        <%} %>
                    <%} %>
                </td>
            </tr>
            <tr class="title">
                <th colspan="4">基本资料</th>
            </tr>
            <tr>
                <th>会员帐号：</th>
                <td width="250"><asp:Label runat="server" ID="lbLoginName"></asp:Label></td>
                <th>婚姻状态：</th>
                <td>
                    <asp:Label runat="server" ID="lbMarriage"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>真实姓名：</th>
                <td><asp:Label runat="server" ID="lbRealname"></asp:Label><asp:Label runat="server" ID="lbRealname_new" CssClass="block"></asp:Label></td>
                <th>最高学历：</th>
                <td>
                    <asp:Label runat="server" ID="lbDegree"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>性别：</th>
                <td>                    
                    <asp:Label runat="server" ID="lbSex"></asp:Label>
                </td>
                <th>工作年限：</th>
                <td>                                        
                    <asp:Label runat="server" ID="lbExperience"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>出生日期：</th>
                <td><asp:Label runat="server" ID="lbBirthday"></asp:Label></td>
                <th>籍贯：</th>
                <td>                    
                    <asp:Label runat="server" ID="lbResidence"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>身高(厘米)：</th>
                <td><asp:Label runat="server" ID="lbHeight"></asp:Label></td>
                <th>现所在地：</th>
                <td>
                    <asp:Label runat="server" ID="lbCurrAddr"></asp:Label>
                </td>
            </tr>
            <tr class="title">
                <th colspan="4">联系方式</th>
            </tr>
            <asp:PlaceHolder runat="server" ID="phContact">
            <tr>
                <th>手机：</th>
                <td width="250"><asp:Label runat="server" ID="lbMobile"></asp:Label></td>
                <th>QQ：</th>
                <td><asp:Label runat="server" ID="lbQQ"></asp:Label><asp:Label runat="server" ID="lbQQ_new" CssClass="block"></asp:Label></td>
            </tr>
            <tr>
                <th>联系电话：</th>
                <td><asp:Label runat="server" ID="lbPhone"></asp:Label><asp:Label runat="server" ID="lbPhone_new" CssClass="block"></asp:Label></td>
                <th>Email：</th>
                <td><asp:Label runat="server" ID="lbEmail"></asp:Label><asp:Label runat="server" ID="lbEmail_new" CssClass="block"></asp:Label></td>
            </tr>
            <tr>
                <%--<th>详细地址：</th>
                <td><asp:Label runat="server" ID="lbAddress"></asp:Label><asp:Label runat="server" ID="lbAddress_new" CssClass="block"></asp:Label></td>--%><%--
                <th>主页/博客：</th>
                <td colspan="3"><asp:Label runat="server" ID="lbHomePage"></asp:Label><asp:Label runat="server" ID="lbHomepage_new" CssClass="block"></asp:Label></td>--%>
                <th>微信：</th>
                <td colspan="3"><asp:Label runat="server" ID="lbWeixin"></asp:Label><asp:Label runat="server" ID="lbWeixin_new" CssClass="block"></asp:Label></td>
            </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="phHideContact">
            <tr class="title">
                <td colspan="4">无权查看</td>
            </tr>
            </asp:PlaceHolder>
            <tr class="title">
                <th colspan="4">求职意向</th>
            </tr>
            <%--<tr>
                <th>提供住宿：</th>
                <td width="250">
                    <asp:Label runat="server" ID="lbHousing"></asp:Label>
                </td>
                <th>是否报销路费：</th>
                <td>
                    <asp:Label runat="server" ID="lbCarFare"></asp:Label>
                </td>
            </tr>--%>
            <tr>
                <th>期望职位：</th>
                <td>
                    <asp:Label runat="server" ID="lbJobCategory"></asp:Label>
                </td>
                <th>期望地区：</th>
                <td>
                    <asp:Label runat="server" ID="lbJobAddress"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>期望薪水：</th>
                <td>
                    <asp:Label runat="server" ID="lbSalary"></asp:Label>
                </td>
                <th>工作方式：</th>
                <td>
                    <asp:Label runat="server" ID="lbJobType"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>个人简历：</th>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbResume"></asp:Label><asp:Label runat="server" ID="lbResume_new" CssClass="block"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>自我评价：</th>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbSelfEvaluation"></asp:Label><asp:Label runat="server" ID="lbSelfEvaluation_new" CssClass="block"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <%if (_newinfoVerifyStatus==0){%>
                    资料审核：<input type="radio" id="chkNewInfo_yes" name="chkNewInfo" value="1" /><label for="chkNewInfo_yes">审核通过</label><input type="radio" id="chkNewInfo_no" name="chkNewInfo" value="-1" /><label for="chkNewInfo_no">审核不通过</label><input type="hidden" id="val_info" name="val_info" value="<%=_newinfoVerifyStatus %>" />
                    <%}else{ %>
                    资料审核：已审核
                    <%} %>
                </td>
            </tr>
        </table>
        </div>

        <div class="tbitem">
        <p class="title tab"><span>工作经历</span></p>
        <asp:Repeater ID="rptExpList" runat="server">
            <HeaderTemplate>
                <table id="tablist" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="th">
                        <td>企业名称</td>
                        <td>担任职位</td>
                        <td>时间范围</td>
                        <%--<td>审核状态</td>--%>
                        <td>审核</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr">
                    <td><%#Eval("CompanyName") %></td>
                    <td><%#Eval("PositionName") %></td>
                    <td><%#Eval("StartTime","{0:yyyy-MM-dd}") %>至<%#Eval("EndTime","{0:yyyy-MM-dd}") %></td>
                    <%--<td><span id="jsExpStatus_<%#Eval("Id") %>"><%#NH.Web.adm.WebBase.ModelEnum.VerifyStatusDesc((NH.Web.adm.WebBase.ModelEnum.VerifyStatus)(int)Eval("Status")) %></span></td>--%>
                    <td align="center">
                        <input type="radio" id="rdExp_<%#Eval("Id") %>_yes" name="rdExp_<%#Eval("Id") %>" <%# (int)Eval("Status")==1 ? "checked=\"checked\"" : "" %> value="1" /><label for="rdExp_<%#Eval("Id") %>_yes">审核通过</label>
                        <input type="radio" id="rdExp_<%#Eval("Id") %>_no" name="rdExp_<%#Eval("Id") %>" <%# (int)Eval("Status")==-1 ? "checked=\"checked\"" : "" %> value="-1" /><label for="rdExp_<%#Eval("Id") %>_no">审核不通过</label>
                        <input type="hidden" name="val_exp_<%# Eval("Id")%>" value="<%# Eval("Status")%>" />
                        <input type="hidden" name="expId_<%# Eval("Id")%>" value="<%# Eval("Id")%>" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
        </div>
        
        <div class="tbitem">
        <p class="title tab"><span>个人相册</span></p>
        <ul id="albumlist" class="albumsverify">
            <asp:Repeater runat="server" ID="rptAlbums">
            <ItemTemplate>
            <li>
                <p class="pic"><a href="/Upload/PersonAlbum/Original/<%# Eval("ImgOriginal")%>" title="<%# Eval("Title")%>"><img src="/Upload/PersonAlbum/Small/<%# Eval("ImgSmall")%>" alt="<%# Eval("Title")%>" title="<%# Eval("Title")%>" /></a></p>
                <p class="albumtitle">标题：<%# Eval("Title")%></p>
                <p class="selector">
                    <input type="radio" id="rdAlbums_<%# Eval("Id")%>_yes" name="rdAlbums_<%# Eval("Id")%>" <%#(int)Eval("Status") == 1 ? "checked=\"checked\"" : "" %> value="1" /><label for="rdAlbums_<%# Eval("Id")%>_yes">审核通过</label>
                    <input type="radio" id="rdAlbums_<%# Eval("Id")%>_no" name="rdAlbums_<%# Eval("Id")%>" <%#(int)Eval("Status") == -1 ? "checked=\"checked\"" : "" %> value="-1" /><label for="rdAlbums_<%# Eval("Id")%>_no">审核不通过</label>
                    <input type="hidden" name="val_album_<%# Eval("Id")%>" value="<%# Eval("Status")%>" />
                    <input type="hidden" name="albumId_<%# Eval("Id")%>" value="<%# Eval("Id")%>" />
                </p>
            </li>
            </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="clear"></div>
        </div>
        
        <div class="tbitem">
        <p class="title tab"><span>个人作品</span></p>
        <ul id="worklist" class="albumsverify">
            <asp:Repeater runat="server" ID="rptWorks">
            <ItemTemplate>
            <li>
                <p class="pic"><a href="/Upload/PersonWorks/Original/<%# Eval("ImgOriginal")%>" title="<%# Eval("Title")%>"><img src="/Upload/PersonWorks/Small/<%# Eval("ImgSmall")%>" alt="<%# Eval("Title")%>" title="<%# Eval("Title")%>" /></a></p>
                <p class="albumtitle">标题：<%# Eval("Title")%></p>
                <p class="selector">
                    <input type="radio" id="rdWorks_<%# Eval("Id")%>_yes" name="rdWorks_<%# Eval("Id")%>" <%#(int)Eval("Status") == 1 ? "checked=\"checked\"" : "" %> value="1" /><label for="rdWorks_<%# Eval("Id")%>_yes">审核通过</label>
                    <input type="radio" id="rdWorks_<%# Eval("Id")%>_no" name="rdWorks_<%# Eval("Id")%>" <%#(int)Eval("Status") == -1 ? "checked=\"checked\"" : "" %> value="-1" /><label for="rdWorks_<%# Eval("Id")%>_no">审核不通过</label>
                    <input type="hidden" name="val_work_<%# Eval("Id")%>" value="<%# Eval("Status")%>" />
                    <input type="hidden" name="workId_<%# Eval("Id")%>" value="<%# Eval("Id")%>" />
                </p>
            </li>
            </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="clear"></div>
        </div>
        
        <div class="tbitem">
        <p class="title tab"><span>实名认证</span></p>
        <asp:PlaceHolder runat="server" ID="phContent">
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    身份证号码：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbIdentityNo"></asp:Label>
                </td>
                <th>
                    身份证有效期：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbIdentityExpireDate"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    性别：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbIdentitySex"></asp:Label>
                </td>
                <th>
                    联系电话：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbIdentityTel"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    QQ：
                </th>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbIdentityQQ"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    身份证附件：
                </th>
                <td colspan="3">
                    <asp:Image runat="server" ID="imgIdentity" Visible="false" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <input type="radio" id="rdIdentity_yes" name="rdIdentity" value="1" <%=_identitystatus == 1 ? "checked=\"checked\"" : "" %> /><label for="rdIdentity_yes">审核通过</label>
                    <input type="radio" id="rdIdentity_no" name="rdIdentity" value="-1" <%=_identitystatus == -1 ? "checked=\"checked\"" : "" %> /><label for="rdIdentity_no">审核不通过</label>
                    <input type="hidden" id="val_Identity" name="val_Identity" value="<%=_identitystatus %>" />
                </td>
            </tr>
        </table>
        </asp:PlaceHolder>
        </div>

        <div class="tbitem">
        <p class="title tab"><span>操作</span></p>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>审核：</th>
                <td>
                    <a id="btnVerifyYes" class="easyui-linkbutton" iconCls="icon-ok" onclick="Verify(1)">提交审核</a>
                </td>
                <th>精英推荐：</th>
                <td>
                    <a id="btnGoodYes" class="easyui-linkbutton" data-options="iconCls:'icon-recommend'" <%=_isGood ? "disabled='true'" : "" %> onclick="javascript:SetGood(1)">设为精英</a> <a id="btnGoodNo" class="easyui-linkbutton" data-options="iconCls:'icon-no'" <%=!_isGood ? "disabled='true'" : "" %> onclick="javascript:SetGood(0)">取消精英</a>
                </td>
                <%--<th>登录状态：</th>
                <td>
                    <asp:Label runat="server" ID="lbStatus"></asp:Label>
                    <a id="btnLoginYes" class="easyui-linkbutton" iconCls="icon-ok" <%=_loginStatus == 1 ? "disabled='true'" : ""%> onclick="ChangeLoginStatus(1)">启用</a>
                    <a id="btnLoginNo" class="easyui-linkbutton" iconCls="icon-no" <%=_loginStatus == 0 ? "disabled='true'" : ""%> onclick="ChangeLoginStatus(0)">禁用</a>
                </td>--%>
            </tr>
        </table>
        </div>

    </div>
    </form>
    <script type="text/javascript">
        $('#albumlist li,#worklist li').each(function () {
            var li = $(this);
            var radio = $(this).find(':radio');
            radio.click(function () {
                if ($(this).val() == 1) {
                    li.removeClass().addClass('yes');
                } else {
                    li.removeClass().addClass('no');
                }
            }).filter(':checked').click();
        });
    </script>
    <script type="text/javascript">
        function Verify() {
            var postdata = {
                "photo": undefined,
                "info": undefined,
                "identity": undefined,
                "al": null,
                "wl": null,
                "al_v": null,
                "wl_v": null,
                "el": null,
                "el_v": null
            };

            var objPhoto = $('[name=rdPhoto]:checked');
            if (objPhoto[0] && objPhoto.val() != $('#val_photo').val()) {
                postdata.photo = objPhoto.val();
            }

            var objNewInfo = $('[name=chkNewInfo]:checked');
            if (objNewInfo[0] && objNewInfo.val() != $('#val_info').val()) {
                postdata.info = objNewInfo.val();
            }

            var objIdentity = $('[name=rdIdentity]:checked');
            if (objIdentity[0] && objIdentity.val() != $('#val_Identity').val()) {
                postdata.identity = objIdentity.val();
            }

            var al = [], wl = [], al_v = [], wl_v = [], el = [], el_v = [];

            $('[name^=rdExp_]:checked').each(function () {
                var obj = $(this);
                if (obj.val() != obj.siblings('[name^=val_exp_]').val()) {
                    el.push(obj.siblings('[name^=expId_]').val());
                    el_v.push(obj.val());
                }
            });

            $('[name^=rdAlbums_]:checked').each(function () {
                var obj = $(this);
                if (obj.val() != obj.siblings('[name^=val_album_]').val()) {
                    al.push(obj.siblings('[name^=albumId_]').val());
                    al_v.push(obj.val());
                }
            });
            $('[name^=rdWorks_]:checked').each(function () {
                var obj = $(this);
                if (obj.val() != obj.siblings('[name^=val_work_]').val()) {
                    wl.push(obj.siblings('[name^=workId_]').val());
                    wl_v.push(obj.val());
                }
            });
            postdata.el = el.join(',');
            postdata.el_v = el_v.join(',');
            postdata.al = al.join(',');
            postdata.wl = wl.join(',');
            postdata.al_v = al_v.join(',');
            postdata.wl_v = wl_v.join(',');

            $.ajax({
                url: 'PersonVerify.aspx?action=verify&id=<%=Id %>',
                type: 'post',
                data: postdata,
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
                            window.parent.CloseWin();
                            //window.location.href = window.location.href;
                            break;

                    }

                }, error: function () { alert('发生错误！'); }
            });
        }
    </script>
    <script type="text/javascript">

        function SetGood(commend) {
            if (!confirm("确定" + (commend == 1 ? "【推荐到精英摄区】" : "【取消精英摄区推荐】") + "吗？")) { return false; }
            $.ajax({
                url: 'PersonVerify.aspx?id=<%=Id %>&ajax=1',
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
</body>
</html>

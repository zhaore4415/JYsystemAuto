<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyVerify.aspx.cs" Inherits="NH.Web.adm.Company.CompanyVerify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <script src="/Scripts/jquery-lightbox-0.5/js/jquery.lightbox-0.5.min.js" type="text/javascript"></script>
    <link href="/Scripts/jquery-lightbox-0.5/css/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
    <script src="../Script/jquery.ui.position.js" type="text/javascript"></script>
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
        });
    </script>
    <script type="text/javascript">
        $(window).scroll(function () {
            window.parent.fixbug();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server" enableviewstate="false">
    <div id="Add">
        <div class="frmborder">
            <p>企业管理 -> 企业审核</p>
        </div>
        <div class="tbitem">
        <p class="title tab"><span>企业信息</span></p>
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
                <th colspan="4">企业资料</th>
            </tr>
            <tr>
                <th>会员帐号：</th>
                <td><asp:Label runat="server" ID="lbLoginName"></asp:Label></td>
                <th>企业名称：</th>
                <td>
                    <asp:Label runat="server" ID="lbCompanyName"></asp:Label>
                    <asp:Label runat="server" ID="lbCompanyName_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>联系人：</th>
                <td><asp:Label runat="server" ID="lbContact"></asp:Label><asp:Label runat="server" ID="lbContact_new" CssClass="block"></asp:Label></td>
                <th>所在城市：</th>
                <td>
                    <asp:Label runat="server" ID="lbArea"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Email：</th>
                <td><asp:Label runat="server" ID="lbEmail"></asp:Label><asp:Label runat="server" ID="lbEmail_new" CssClass="block"></asp:Label></td>
                <th>QQ：</th>
                <td><asp:Label runat="server" ID="lbQQ"></asp:Label><asp:Label runat="server" ID="lbQQ_new" CssClass="block"></asp:Label></td>
            </tr>
            <tr>
                <th>联系电话：</th>
                <td><asp:Label runat="server" ID="lbPhone"></asp:Label><asp:Label runat="server" ID="lbPhone_new" CssClass="block"></asp:Label></td>
                <th>其它电话：</th>
                <td><asp:Label runat="server" ID="lbOtherPhone"></asp:Label><asp:Label runat="server" ID="lbOtherPhone_new"></asp:Label></td>
            </tr>
            <tr>
                <th>详细地址：</th>
                <td colspan="2"><asp:Label runat="server" ID="lbAddress"></asp:Label><asp:Label runat="server" ID="lbAddress_new" CssClass="block"></asp:Label></td>
                <%--<th>企业网址：</th>
                <td><asp:Label runat="server" ID="lbHomePage"></asp:Label><asp:Label runat="server" ID="lbHomepage_new"></asp:Label></td>--%>
            </tr>
            <%--<tr>
                <th>营业面积：</th>
                <td><asp:Label runat="server" ID="lbSpace"></asp:Label><asp:Label runat="server" ID="lbSpace_new" CssClass="block"></asp:Label></td>
                <th>员工数量：</th>
                <td><asp:Label runat="server" ID="lbEmployeeQty"></asp:Label><asp:Label runat="server" ID="lbEmployeeQty_new"></asp:Label></td>
            </tr>--%>
            <%--<tr>
                <th>相机型号及数量：</th>
                <td><asp:Label runat="server" ID="lbCamera"></asp:Label><asp:Label runat="server" ID="lbCamera_new" CssClass="block"></asp:Label></td>
                <th>影棚数量：</th>
                <td><asp:Label runat="server" ID="lbStudio"></asp:Label><asp:Label runat="server" ID="lbStudio_new" CssClass="block"></asp:Label></td>
            </tr>--%>
            <tr>
                <th>企业简介：</th>
                <td colspan="3"><asp:Label runat="server" ID="lbDescription"></asp:Label><asp:Label runat="server" ID="lbDescription_new" CssClass="block"></asp:Label></td>
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
        <p class="title tab"><span>招聘职位</span></p>
        <asp:Repeater ID="rptJobList" runat="server">
            <HeaderTemplate>
                <table id="tablist" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="th">
                        <td>职位</td>
                        <td>添加时间</td>
                        <td>审核</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr">
                    <td><%#Eval("JobCategoryName") %></td>
                    <td><%#Eval("AddTime") %></td>
                    <td align="center">
                        <input type="radio" id="rdJob_<%#Eval("Id") %>_yes" name="rdJob_<%#Eval("Id") %>" <%# (int)Eval("Verified")==1 ? "checked=\"checked\"" : "" %> value="1" /><label for="rdJob_<%#Eval("Id") %>_yes">审核通过</label>
                        <input type="radio" id="rdJob_<%#Eval("Id") %>_no" name="rdJob_<%#Eval("Id") %>" <%# (int)Eval("Verified")==-1 ? "checked=\"checked\"" : "" %> value="-1" /><label for="rdJob_<%#Eval("Id") %>_no">审核不通过</label>
                        <input type="hidden" name="val_job_<%# Eval("Id")%>" value="<%# Eval("Verified")%>" />
                        <input type="hidden" name="jobId_<%# Eval("Id")%>" value="<%# Eval("Id")%>" />
                        <a href="#" onclick="return ShowJob(<%# Eval("Id")%>)">查看</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
        </div>
        
        <div class="tbitem">
        <p class="title tab"><span>企业相册</span></p>
        <ul id="albumlist" class="albumsverify">
            <asp:Repeater runat="server" ID="rptAlbums">
            <ItemTemplate>
            <li>
                <p class="pic"><a href="/Upload/CompanyAlbum/Original/<%# Eval("ImgOriginal")%>" title="<%# Eval("Title")%>"><img src="/Upload/CompanyAlbum/Small/<%# Eval("ImgSmall")%>" alt="<%# Eval("Title")%>" title="<%# Eval("Title")%>" /></a></p>
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
        <p class="title tab"><span>实名认证</span></p>
        <asp:PlaceHolder runat="server" ID="phContent">
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    审核状态：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbIdentityStatus"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    营业执照号：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbIdentityLicenceNo"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    执照有效期：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbIdentityExpireDate"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    联系人：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbIdentityContact"></asp:Label>
                </td>
            </tr>
            <tr>
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
                <td>
                    <asp:Label runat="server" ID="lbIdentityQQ"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    营业执照附件：
                </th>
                <td>
                    <asp:Image runat="server" ID="imgIdentity" Visible="false" />
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
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
            </tr>
        </table>
        </div>

    </div>
    </form>
    <script type="text/javascript">
        $('#albumlist li').each(function () {
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
                "al_v": null,
                "jl": null,
                "jl_v": null
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

            var al = [], al_v = [], jl = [], jl_v = [];

            $('[name^=rdAlbums_]:checked').each(function () {
                var obj = $(this);
                if (obj.val() != obj.siblings('[name^=val_album_]').val()) {
                    al.push(obj.siblings('[name^=albumId_]').val());
                    al_v.push(obj.val());
                }
            });

            $('[name^=rdJob_]:checked').each(function () {
                var obj = $(this);
                if (obj.val() != obj.siblings('[name^=val_job_]').val()) {
                    jl.push(obj.siblings('[name^=jobId_]').val());
                    jl_v.push(obj.val());
                }
            });

            postdata.al = al.join(',');
            postdata.al_v = al_v.join(',');
            postdata.jl = jl.join(',');
            postdata.jl_v = jl_v.join(',');

            $.ajax({
                url: 'CompanyVerify.aspx?action=verify&id=<%=Id %>',
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
                            //alert($('#win', window.parent.document).html());
                            window.parent.CloseWin();
                            //$('#win', window.parent.document).window('close');
                            //window.location.href = window.location.href;
                            break;

                    }

                }, error: function () { alert('发生错误！'); }
            });
        }
    </script>
    
    <script type="text/javascript">
        function ShowJob(id) {
            var objWin = $('<div></div>').dialog({
                title: '招聘职位',
                href: 'CompanyJobInfo.aspx?id=' + id,
                width: 600,
                height: $(window).height() - 100,
                //top: 25,
                //maximizable: true,
                resizable: true,
                modal: true,
                closed: true,
                buttons: [
                        {
                            iconCls: 'icon-ok',
                            text: '确定',
                            handler: function () {
                                $('[name=rdJob_' + id + '][value=' + $('[name=rdJob]:checked').val() + ']').attr('checked', true);
                                objWin.dialog('close');
                            }
                        }, {
                            iconCls: 'icon-cancel',
                            text: '关闭',
                            handler: function () { objWin.dialog('close'); }
                        }
                    ],
                onClose: function () { objWin.dialog('destroy'); }
            }).dialog('open');
            return false;
        }
    </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonModify.aspx.cs" Inherits="NH.Web.adm.Person.PersonModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <%--<script src="../Script/load_area.js" type="text/javascript"></script>--%>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            LoadArea('ddlResidenceProvince', 'ddlResidenceCity', '', '<%=_residence_provinceId %>', '<%=_residence_cityId %>', '');
            LoadArea('ddlCurrProvince', 'ddlCurrCity', '', '<%=_currAddr_ProvinceId %>', '<%=_currAddr_CityId %>', '');
        });
    </script>--%>
</head>
<body>
    <script src="../Script/easyui/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../Script/Common.js" type="text/javascript"></script>
    <%--<%=JsTextBoxClass %>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#formEdit').form({
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
                    }
                }
            });
        })

        function Verify(status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【审核通过】" : "【审核不通过】") + "吗？")) {return false;}
            $.ajax({
                url: $('#formEdit').attr('action') + '&ajax=1',
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
                                $('#btnVerifyYes').linkbutton('disable');
                                $('#btnVerifyNo').linkbutton('enable');
                                $('#lbVerifyStatus').text('审核通过');
                            } else {
                                $('#btnVerifyYes').linkbutton('enable');
                                $('#btnVerifyNo').linkbutton('disable');
                                $('#lbVerifyStatus').text('审核不通过');
                            }
                            break;

                    }
                }
            })
        }

        function ChangeLoginStatus(status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【启用】" : "【禁用】") + "吗？")) { return false; }
            $.ajax({
                url: $('#formEdit').attr('action') + '&ajax=1',
                data: { 'action': 'ChangeLoginStatus', 'status': status },
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
                                $('#btnLoginYes').linkbutton('disable');
                                $('#btnLoginNo').linkbutton('enable');
                                $('#lbStatus').text('启用');
                            } else {
                                $('#btnLoginYes').linkbutton('enable');
                                $('#btnLoginNo').linkbutton('disable');
                                $('#lbStatus').text('禁用');
                            }
                            break;

                    }
                }
            })
        }

        function ChangeResumeStatus(status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【开放】" : "【隐藏】") + "吗？")) { return false; }
            $.ajax({
                url: $('#formEdit').attr('action') + '&ajax=1',
                data: { 'action': 'ChangeResumeStatus', 'status': status },
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
                                $('#btnShowYes').linkbutton('disable');
                                $('#btnShowNo').linkbutton('enable');
                                $('#lbResumeStatus').text('开放');
                            } else {
                                $('#btnShowYes').linkbutton('enable');
                                $('#btnShowNo').linkbutton('disable');
                                $('#lbResumeStatus').text('隐藏');
                            }
                            break;

                    }
                }
            })
        }


        function VerifyNewInfo(status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【审核通过】" : "【审核不通过】") + "吗？")) { return false; }
            $.ajax({
                url: $('#formEdit').attr('action') + '&ajax=1',
                data: { 'action': 'VerifyNewInfo', 'status': status },
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
                                $('#btnVerifyNewYes').linkbutton('disable');
                                $('#btnVerifyNewNo').linkbutton('enable');
                            } else {
                                $('#btnVerifyNewYes').linkbutton('enable');
                                $('#btnShowNo').linkbutton('disable');
                            }
                            break;

                    }
                }
            })
        }

        function VerifyExp(id,status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【审核通过】" : "【审核不通过】") + "吗？")) { return false; }
            $.ajax({
                url: $('#formEdit').attr('action') + '&ajax=1',
                data: { 'action': 'VerifyExp','id':id, 'status': status },
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
                                $('#btnExpVerifyYes_' + id).linkbutton('disable');
                                $('#btnExpVerifyNo_' + id).linkbutton('enable');
                                $('#jsExpStatus_' + id).text('审核通过');
                            } else {
                                $('#btnExpVerifyYes_' + id).linkbutton('enable');
                                $('#btnExpVerifyNo_' + id).linkbutton('disable');
                                $('#jsExpStatus_' + id).text('审核不通过');
                            }
                            break;

                    }
                }
            })
            return false;
        }
    </script>
    <form id="formEdit" runat="server" enableviewstate="false">
    <div id="Add">
        <div class="frmborder">
            <p>人才管理 -> 编辑资料</p>
        </div>
        <div class="tbitem">
        <p class="title tab"><span>基本信息</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>会员帐号：</th>
                <td width="250"><asp:Label runat="server" ID="lbLoginName"></asp:Label></td>
                <th>婚姻状态：</th>
                <td>
                    <asp:DropDownList runat="server" ID="ddlMarriage" Width="80">
                        <asp:ListItem Value="0">未婚</asp:ListItem>
                        <asp:ListItem Value="1">已婚</asp:ListItem>
                        <asp:ListItem Value="2">离异</asp:ListItem>
                        <asp:ListItem Value="3">丧偶</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>真实姓名：</th>
                <td><asp:TextBox runat="server" ID="txtTrueName"></asp:TextBox></td>
                <th>最高学历：</th>
                <td>
                    <select id="ddlDegree" name="ddlDegree" style=" width:80px;">
                        <option value="0">请选择..</option>
                        <asp:Literal ID="ltrDegree" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>性别：</th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblSex" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Value="-1" Selected="True">保密</asp:ListItem>
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="0">女</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <th>工作年限：</th>
                <td>                    
                    <select id="ddlExperience" name="ddlExperience" style=" width:80px;">
                        <option value="">请选择..</option>
                        <asp:Literal ID="ltrExperience" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>出生日期：</th>
                <td><asp:TextBox runat="server" ID="txtBirthday"></asp:TextBox></td>
                <th>籍贯：</th>
                <td>
                    <select id="ddlResidenceProvince" name="ddlResidenceProvince" style=" width:80px;">
                        <option>选择省</option>
                        <asp:Literal ID="ltrResidenceProvince" runat="server"></asp:Literal>
                    </select>
                    <select id="ddlResidenceCity" name="ddlResidenceCity" style=" width:80px;">
                        <option>选择城市</option>
                        <asp:Literal ID="ltrResidenceCity" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>身高：</th>
                <td><asp:TextBox runat="server" ID="txtHeight"></asp:TextBox>(厘米)</td>
                <th>现所在地：</th>
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
        </table>
        </div>

        <div class="tbitem">
        <p class="title tab"><span>联系方式</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr class="utable">
                <th>手机：</th>
                <td width="250"><asp:TextBox runat="server" ID="txtMobile"></asp:TextBox></td>
                <th>QQ：</th>
                <td><asp:TextBox runat="server" ID="txtQQ"></asp:TextBox></td>
            </tr>
            <tr>
                <th>联系电话：</th>
                <td><asp:TextBox runat="server" ID="txtPhone"></asp:TextBox></td>
                <th>Email：</th>
                <td><asp:TextBox runat="server" ID="txtEmail"></asp:TextBox></td>
            </tr>
            <tr>
                <th>详细地址：</th>
                <td><asp:TextBox runat="server" ID="txtAddress"></asp:TextBox></td>
                <th>主页/博客：</th>
                <td><asp:TextBox runat="server" ID="txtHomePage"></asp:TextBox></td>
            </tr>     
        </table>
        </div>

        <div class="tbitem">
        <p class="title tab"><span>求职意向</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>提供住宿：</th>
                <td width="250">
                    <asp:RadioButtonList runat="server" ID="rblHousing" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">提供</asp:ListItem>
                        <asp:ListItem Value="0">不提供</asp:ListItem>
                        <asp:ListItem Value="-1">面议</asp:ListItem>
                    </asp:RadioButtonList>                
                </td>
                <th>是否报销路费：</th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblCarFare" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">报销</asp:ListItem>
                        <asp:ListItem Value="0">不报销</asp:ListItem>
                        <asp:ListItem Value="-1">面议</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>期望职位：</th>
                <td>
                    <select id="ddlJobCategory" name="ddlJobCategory" multiple="multiple" style=" width:180px;">
                        <asp:Literal runat="server" ID="ltrJobCategor"></asp:Literal>
                    </select>
                </td>
                <th>期望地区：</th>
                <td>
                    <select id="ddlJobAddress" name="ddlJobAddress" multiple="multiple" style=" width:200px;">
                        <asp:Literal ID="ltrJobAddress" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>期望薪水：</th>
                <td>
                    <select id="ddlSalary" name="ddlSalary" style=" width:100px;">
                        <option value="">请选择..</option>
                        <asp:Literal ID="ltrSalary" runat="server"></asp:Literal>
                    </select>
                    <asp:CheckBox runat="server" ID="chkCommission" Text=" 加提成"  />
                </td>
                <th>工作方式：</th>
                <td>
                    <select id="ddlJobType" name="ddlJobType" multiple="multiple" style=" width:200px;">
                        <asp:Literal ID="ltrJobType" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>个人简历：</th>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtResume" TextMode="MultiLine" Rows="5" Columns="80"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>自我评价：</th>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtSelfEvaluation" TextMode="MultiLine" Rows="5" Columns="80"></asp:TextBox>
                </td>
            </tr>
        </table>
        </div>

        <div class="tbitem">
        <p class="title tab"><span>曾经工作经历</span></p>
        <asp:Repeater ID="rptExpList" runat="server">
            <HeaderTemplate>
                <table id="tablist" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="th">
                        <td>企业名称</td>
                        <td>担任职位</td>
                        <td>时间范围</td>
                        <td>审核状态</td>
                        <td>操作</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr">
                    <td><%#Eval("CompanyName") %></td>
                    <td><%#Eval("PositionName") %></td>
                    <td><%#Eval("StartTime","{0:yyyy-MM-dd}") %>至<%#Eval("EndTime","{0:yyyy-MM-dd}") %></td>
                    <td><span id="jsExpStatus_<%#Eval("Id") %>"><%#NH.Web.adm.WebBase.ModelEnum.VerifyStatusDesc((NH.Web.adm.WebBase.ModelEnum.VerifyStatus)(int)Eval("Status")) %></span></td>
                    <td align="center">
                        <a id="btnExpVerifyYes_<%#Eval("Id") %>" href="#" class="easyui-linkbutton" iconCls="icon-ok" <%# (int)Eval("Status")==1 ? "disabled=\"true\"" : "" %> onclick="return VerifyExp(<%#Eval("Id") %>,1)">审核通过</a>
                        <a id="btnExpVerifyNo_<%#Eval("Id") %>" href="#" class="easyui-linkbutton" iconCls="icon-no" <%# (int)Eval("Status")==-1 ? "disabled=\"true\"" : "" %> onclick="return VerifyExp(<%#Eval("Id") %>,-1)">不通过</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
        </div>
        
        <div class="tbitem">
        <p class="title tab"><span>操作</span></p>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>审核状态：</th>
                <td>
                    <asp:Label runat="server" ID="lbVerifyStatus"></asp:Label>
                    <a id="btnVerifyYes" class="easyui-linkbutton" iconCls="icon-ok" <%=_verifyStatus == 1 ? "disabled='true'" : ""%> onclick="Verify(1)">审核通过</a>
                    <a id="btnVerifyNo" class="easyui-linkbutton" iconCls="icon-no" <%=_verifyStatus == -1 ? "disabled='true'" : ""%> onclick="Verify(-1)">审核不通过</a>
                </td>
                <th>登录状态：</th>
                <td>
                    <asp:Label runat="server" ID="lbStatus"></asp:Label>
                    <a id="btnLoginYes" class="easyui-linkbutton" iconCls="icon-ok" <%=_loginStatus == 1 ? "disabled='true'" : ""%> onclick="ChangeLoginStatus(1)">启用</a>
                    <a id="btnLoginNo" class="easyui-linkbutton" iconCls="icon-no" <%=_loginStatus == 0 ? "disabled='true'" : ""%> onclick="ChangeLoginStatus(0)">禁用</a>
                </td>
            </tr>
            <tr>
                <th>简历状态：</th>
                <td>
                    <asp:Label runat="server" ID="lbResumeStatus"></asp:Label>
                    <a id="btnShowYes" class="easyui-linkbutton" iconCls="icon-ok" <%=_resumeStatus == 1 ? "disabled='true'" : ""%> onclick="ChangeResumeStatus(1)">开放</a>
                    <a id="btnShowNo" class="easyui-linkbutton" iconCls="icon-no" <%=_resumeStatus == 0 ? "disabled='true'" : ""%> onclick="ChangeResumeStatus(0)">隐藏</a>
                </td>
                <th>保存：</th>
                <td>
                    <input type="hidden" id="action" name="action" />
                    <a class="easyui-linkbutton" iconCls="icon-save" onclick="$('#action').val('modify');$('#formEdit').submit()">保存资料</a>
                </td>
            </tr>
        </table>
        </div>
        
        <asp:PlaceHolder runat="server" ID="phNewInfo1">
        <div class="tbitem">
        <p class="title tab"><span>资料更新审核</span></p>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>姓名：</th>
                <td>
                    <asp:Label runat="server" ID="lbRealname_new"></asp:Label>
                </td>
                <th>电话：</th>
                <td>
                    <asp:Label runat="server" ID="lbPhone_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>QQ：</th>
                <td>
                    <asp:Label runat="server" ID="lbQQ_new"></asp:Label>
                </td>
                <th>Email：</th>
                <td>
                    <asp:Label runat="server" ID="lbEmail_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>联系地址：</th>
                <td>
                    <asp:Label runat="server" ID="lbAddress_new"></asp:Label>
                </td>
                <th>主页：</th>
                <td>
                    <asp:Label runat="server" ID="lbHomepage_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>个人简历：</th>
                <td>
                    <asp:Label runat="server" ID="lbResume_new"></asp:Label>
                </td>
                <th>自我评价：</th>
                <td>
                    <asp:Label runat="server" ID="lbSelfEvaluation_new"></asp:Label>
                </td>
            </tr>
            <%--<tr>
                <th>工作经历：</th>
                <td colspan="3">
                <asp:Repeater ID="rptNewExp" runat="server">
                    <HeaderTemplate>
                        <table id="tablist" cellpadding="0" cellspacing="0" width="100%">
                            <tr class="th">
                                <td>企业名称</td>
                                <td>担任职位</td>
                                <td>时间范围</td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="tr">
                            <td><%#Eval("CompanyName") %></td>
                            <td><%#Eval("PositionName") %></td>
                            <td><%#Eval("StartTime","{0:yyyy-MM-dd}") %>至<%#Eval("EndTime","{0:yyyy-MM-dd}") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table></FooterTemplate>
                </asp:Repeater>
                </td>
            </tr>--%>
            <tr>
                <td colspan="4" align="center">
                    <a id="btnVerifyNewYes" class="easyui-linkbutton" iconCls="icon-ok" <%=_newinfoVerifyStatus == 1 ? "disabled='true'" : ""%> onclick="VerifyNewInfo(1)">通过</a>
                    <a id="btnVerifyNewNo" class="easyui-linkbutton" iconCls="icon-no" <%=_newinfoVerifyStatus == -1 ? "disabled='true'" : ""%> onclick="VerifyNewInfo(-1)">不通过</a>
                </td>
            </tr>
        </table>
        </div>
        </asp:PlaceHolder>
    </div>    

    <br />
    <br />
    <br />
    <br />
    </form>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtBirthday').datebox({});
        });
    </script>
    <script type="text/javascript">
        $("#<%=this.ddlMarriage.ClientID %>").formSelect({
            colWidth: 100,
            cols: 2,
            onShow: function () {
                $('#<%=this.ddlMarriage.ClientID %>').trigger('focusListener');
            },
            onClose: function () {
                $('#<%=this.ddlMarriage.ClientID %>').trigger('blurListener');
            }
        });
    </script>
    <script type="text/javascript">
        $("#ddlDegree").formSelect({
            colWidth: 100,
            cols: 2,
            onShow: function () {
                $('#ddlDegree').trigger('focusListener');
            },
            onClose: function () {
                $('#ddlDegree').trigger('blurListener');
            }
        });
    </script>

    <script type="text/javascript">
        $("#ddlExperience").formSelect({
            colWidth: 100,
            cols: 2,
            onShow: function () {
                $('#ddlExperience').trigger('focusListener');
            },
            onClose: function () {
                $('#ddlExperience').trigger('blurListener');
            }
        });
    </script>
    <script type="text/javascript">var areas = <asp:Literal ID="ltrAreaJsObject" runat="server"></asp:Literal>;</script>
    <script type="text/javascript">
        $('#ddlResidenceProvince').formSelect({
            cols: 4,
            colWidth: 80,
            onSelect: function () {
                $('#ddlResidenceCity').children().remove();
                $.each(areas[$('#ddlResidenceProvince').val()], function (key, value) {
                    $('#ddlResidenceCity').append($('<option value="' + key + '">' + value + '</option>'));
                });

                //调用内部函数刷新
                $('#ddlResidenceProvince').data('Obj').reflash($('#ddlResidenceCity'));
            },
            onShow: function () {
                $('#ddlResidenceProvince').trigger('focusListener');
            },
            onClose: function () {
                $('#ddlResidenceProvince').trigger('blurListener');
            }

        });

        $('#ddlResidenceCity').formSelect({
            emptyText: '请选择城市...',
            cols: 3,
            colWidth: 80
        });
    </script>

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
    <script type="text/javascript">
        $("#ddlJobCategory").formSelect({
            colWidth: 120,
            cols: 3,
            select: 3,
            onShow: function () {
                $('#ddlJobCategory').trigger('focusListener');
            },
            onClose: function () {
                $('#ddlJobCategory').trigger('blurListener');
            }
        });
    </script>
    <script type="text/javascript">
        $("#ddlJobAddress").formSelect({
            colWidth: 70,
            cols: 4,
            select: 3,
            withInner: { innerCols: 3, innerColWidth: 70 },
            onShow: function () {
                $('#ddlJobAddress').trigger('focusListener');
            },
            onClose: function () {
                $('#ddlJobAddress').trigger('blurListener');
            }
        });
    </script>
    <script type="text/javascript">
        $("#ddlSalary").formSelect({
            colWidth: 100,
            cols: 3,
            onShow: function () {
                $('#ddlSalary').trigger('focusListener');
            },
            onClose: function () {
                $('#ddlSalary').trigger('blurListener');
            }
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ddlJobType").formSelect({
                colWidth: 70,
                cols: 3,
                select: 3,
                onShow: function () {
                    $('#ddlJobType').trigger('focusListener');
                },
                onClose: function () {
                    $('#ddlJobType').trigger('blurListener');
                }
            });
        });
    </script>
</body>
</html>

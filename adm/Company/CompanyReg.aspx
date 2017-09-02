<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyReg.aspx.cs" Inherits="NH.Web.adm.Company.CompanyReg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <%=CssAndScript %>
    <link href="/Scripts/jquery-ui-1.8.23/themes/start/jquery-ui-1.8.23.custom.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/common.css" rel="stylesheet" type="text/css" />    
    <script src="/Scripts/jquery-ui-1.8.23/js/jquery-ui-1.8.23.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jAreaSelect.js" type="text/javascript"></script>
    <script src="/Scripts/jJobSelect.js" type="text/javascript"></script>
    <script src="/Scripts/Common.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.8.23/locale/jquery.ui.datepicker-zh-CN.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/jquery.form.js"></script>
    <script type="text/javascript">
        $(document).ajaxStart(function () {

        }).ajaxSend(function (e, jqxhr, settings) {
            if (/(\?|&)ajax=/.test(settings.url) == false) {
                if (settings.url.indexOf('?') == -1) {
                    settings.url += '?ajax=1';
                } else {
                    settings.url += '&ajax=1';
                }
            };
        });
        $.ajaxSetup({ type: 'post', dataType: 'json' });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
        <div class="frmborder">
            <p>企业管理 -> 添加企业</p>
        </div>
    <div class="tbitem">
        <p class="title tab"><span>基本信息</span></p>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    <span class="red">*</span>登录用户名：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtLoginName"></asp:TextBox>
                </td>
                <th>
                    <span class="red">*</span>企业名称：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtCompanyName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <span class="red">*</span>密码：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
                </td>
                <th>
                    <span class="red">*</span>确认密码：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword2" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <span class="red">*</span>联系人：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtContact"></asp:TextBox>
                </td>
                <th>
                    <span class="red">*</span>Email：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <span class="red">*</span>QQ：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtQQ"></asp:TextBox>
                </td>
                <th>
                    <span class="red">*</span>联系电话：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th><span class="red">*</span>所在城市：</th>
                <td>                                
                    <select id="ddlArea" name="ddlArea" class="hideselect" style=" width:158px;">
                        <option value="">选择城市</option>
                        <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                    </select>
                </td>
                <th>
                    其它电话：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtOtherPhone"></asp:TextBox>
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
                <th>
                    <span class="red">*</span>详细地址：
                </th>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtAddress"></asp:TextBox>
                </td>
                <%--<th>
                    企业网址：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtHomePage"></asp:TextBox>
                </td>--%>
            </tr>
            <%--<tr>
                <th>
                    营业面积：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtSpace"></asp:TextBox>
                </td>
                <th>
                    员工数量：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtEmployeeQty"></asp:TextBox>
                </td>
            </tr>--%>
            <%--<tr>
                <th>
                    相机型号及数量：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtCamera"></asp:TextBox>
                </td>
                <th>
                    影棚数量：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtStudio"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <th>
                    <span class="red">*</span>企业简介：
                </th>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Columns="80" Rows="8"></asp:TextBox>
                </td>
            </tr>
        </table>
        </div>

        <%--<div class="tbitem">
        <p class="title tab"><span>招聘信息</span></p>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable" id="temp" style=" display:none; margin-bottom:10px; width:98%;">
            <tr>
                <th><span class="red">*</span>招聘职位：</th>
                <td>
                    <select id="ddlJobCategory" name="ddlJobCategory" class="hideselect ddlJobCategory" style="width:150px;">
                        <option value="">请选择...</option>
                        <asp:Literal runat="server" ID="ltrJobCategory"></asp:Literal>
                    </select>
                </td>
                <th><span class="red">*</span>薪酬：</th>
                <td>
                    <select id="ddlSalary" name="ddlSalary" class="hideselect ddlSalary" style="width:110px;">
                        <option value="">请选择..</option>
                        <asp:Literal ID="ltrSalary" runat="server"></asp:Literal>
                    </select>
                    <asp:CheckBox runat="server" ID="cbCommission" Text="加提成" CssClass="cbCommission" />
                </td>
            </tr>
            <tr>
                <th><span class="red">*</span>工作方式：</th>
                <td>
                    <select id="ddlJobType" name="ddlJobType" multiple="multiple" class="hideselect ddlJobType" style="width:150px;">
                        <asp:Literal ID="ltrJobType" runat="server"></asp:Literal>
                    </select>
                </td>
                <th><span class="red">*</span>教育程度：</th>
                <td>
                    <select id="ddlDegree" name="ddlDegree" multiple="multiple" class="hideselect ddlDegree" style="width:150px;">
                        <option value="">请选择..</option>
                        <asp:Literal ID="ltrDegree" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th><span class="red">*</span>工作经验：</th>
                <td>
                    <select id="ddlExperience" name="ddlExperience" class="hideselect ddlExperience" style="width:100px;">
                        <option value="">请选择..</option>
                        <asp:Literal ID="ltrExperience" runat="server"></asp:Literal>
                    </select>
                </td>
                <th>性别要求：</th>
                <td>
                    <asp:DropDownList runat="server" ID="ddlSex" Width="100" CssClass="hideselect ddlSex">
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="0">女</asp:ListItem>
                        <asp:ListItem Value="-1" Selected="True">不限</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>是否报销车费：</th>
                <td>
                    <asp:RadioButtonList runat="server" ID="IsCarfare" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="radionstyle2 IsCarfare">
                        <asp:ListItem Value="1">报销</asp:ListItem>
                        <asp:ListItem Value="0">不报销</asp:ListItem>
                        <asp:ListItem Value="-1" Selected="True">面议</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <th>是否提供食宿：</th>
                <td>
                    <asp:RadioButtonList runat="server" ID="IsHousing" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="radionstyle2 IsHousing">
                        <asp:ListItem Value="1">提供</asp:ListItem>
                        <asp:ListItem Value="0">不提供</asp:ListItem>
                        <asp:ListItem Value="-1" Selected="True">面议</asp:ListItem>
                    </asp:RadioButtonList> 
                </td>
            </tr>
            <tr>
                <th>人员工作时间：</th>
                <td>
                    <asp:TextBox runat="server" ID="txtWorkTime" CssClass="txtWorkTime"></asp:TextBox>
                </td>
                <th>招聘人数：</th>
                <td>
                    <asp:TextBox runat="server" ID="txtQty" CssClass="txtQty"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>有效期：</th>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtExpireDate" CssClass="txtExpireDate"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>招聘内容：</th>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtJobDescription" TextMode="MultiLine" Columns="80" Rows="8" CssClass="txtJobDescription"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="right"><input type="button" class="btnSmall delete" value="删除" /></td>
            </tr>
        </table>

        <div id="btnAddNewJob" style=" text-align:center;"><input type="button" onclick="NewJob()" value="添加招聘信息" class="btnSmall" /><input type="hidden" id="jobcount" name="jobcount" /></div>
        </div>--%>

        <div class="tbitem">
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <td align="center">
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="btnSubmit" onclick="btnSubmit_Click" OnClientClick="return beforsubmit();" />
                </td>
            </tr>
        </table>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        function beforsubmit() {
            try
            {
                var txtLoginName = $('#txtLoginName');
                var txtCompanyName = $('#txtCompanyName');
                var txtPassword = $('#txtPassword');
                var txtPassword2 = $('#txtPassword2');
                var txtContact = $('#txtContact');
                var txtEmail = $('#txtEmail');
                var txtQQ = $('#txtQQ');
                var txtPhone = $('#txtPhone');
                var ddlArea = $('#ddlArea');
                var txtAddress = $('#txtAddress');
                var txtDescription = $('#txtDescription');

                if ($.trim(txtLoginName.val()) == "") { alert('请填写用户名'); txtLoginName.focus(); return false; }
                if ($.trim(txtCompanyName.val()) == "") { alert('请填写企业名称'); txtCompanyName.focus(); return false; }
                if ($.trim(txtPassword.val()) == "") { alert('请填写登录密码'); txtPassword.focus(); return false; }
                if ($.trim(txtPassword2.val()) != $.trim(txtPassword.val())) { alert('两次输入的密码不一致'); txtPassword2.focus(); return false; }
                if ($.trim(txtContact.val()) == "") { alert('请填写联系人'); txtContact.focus(); return false; }
                if ($.trim(txtEmail.val()) == "") { alert('请填写邮箱'); txtEmail.focus(); return false; }
                if ($.trim(txtQQ.val()) == "") { alert('请填写QQ'); txtQQ.focus(); return false; }
                if ($.trim(txtPhone.val()) == "") { alert('请填写联系电话'); txtPhone.focus(); return false; }
                if ($.trim(ddlArea.val()) == "") { alert('请选择所在城市'); ddlArea.focus(); return false; }
                if ($.trim(txtAddress.val()) == "") { alert('请填写详细地址'); txtAddress.focus(); return false; }
                if ($.trim(txtDescription.val()) == "") { alert('请填写企业简介'); txtDescription.focus(); return false; }

                return true;
//                var pass = true;
//                $('.jobtemplate').each(function (i, n) {
//                    var obj = $(this);

//                    var ddlJobCategory = obj.find('.ddlJobCategory').attr('name', 'ddlJobCategory_' + i);
//                    var ddlSalary = obj.find('.ddlSalary').attr('name', 'ddlSalary_' + i);
//                    var ddlJobType = obj.find('.ddlJobType').attr('name', 'ddlJobType_' + i);
//                    var ddlDegree = obj.find('.ddlDegree').attr('name', 'ddlDegree_' + i);
//                    var ddlExperience = obj.find('.ddlExperience').attr('name', 'ddlExperience_' + i);
//                    var txtJobDescription = obj.find('.txtJobDescription').attr('name', 'txtJobDescription_' + i);

//                    obj.find('.cbCommission input').attr('name', 'cbCommission_' + i);
//                    obj.find('.ddlSex').attr('name', 'ddlSex_' + i);
//                    obj.find('.IsCarfare input').attr('name', 'IsCarfare_' + i);
//                    obj.find('.IsHousing input').attr('name', 'IsHousing_' + i);
//                    obj.find('.txtWorkTime').attr('name', 'txtWorkTime_' + i);
//                    obj.find('.txtQty').attr('name', 'txtQty_' + i);
//                    obj.find('.txtExpireDate').attr('name', 'txtExpireDate_' + i);

//                    if ($.trim(ddlJobCategory.val()) == "") { alert('请选择招聘职位'); ddlJobCategory.focus(); pass = false; return false; };
//                    if ($.trim(ddlSalary.val()) == "") { alert('请选择薪水'); ddlSalary.focus(); pass = false; return false; };
//                    if ($.trim(ddlJobType.val()) == "") { alert('请选择工作方式'); ddlJobType.focus(); pass = false; return false; };
//                    if ($.trim(ddlDegree.val()) == "") { alert('请选择教育程度'); ddlDegree.focus(); pass = false; return false; };
//                    if ($.trim(ddlExperience.val()) == "") { alert('请选择工作经验'); ddlExperience.focus(); pass = false; return false; };
//                });

//                $('#jobcount').val($('.jobtemplate').length);

//                var val = $('#jobcount').val();
//                if (!val || val == "") {pass = false;}

//                return pass;
            }
            catch (err) {
                alert("error:" + err.Description);
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var form = $('#<%=form1.ClientID %>');
            form.ajaxForm({
                beforeSubmit: function () {
                    return true;
                    //return beforsubmit();
                    //return form.validate().form();
                }, success: function (data) {
                    switch (data.status) {
                        case 'ok':
                            alert('添加成功');
                            window.location.href = window.location.href;
                            break;
                        case 'error':
                            alert(data.msg);
                            break;
                        case "nologin":
                            alert('请登录');
                            break;
                    }
                },
                error: function () { alert('发生错误'); }
            });
        });
    </script>
    <script type="text/javascript">
        $('#ddlArea').jAreaSelect();
    </script>

    <%--<script type="text/javascript">
        function NewJob() {

            var objNew = $('#temp').clone().show().addClass("jobtemplate").removeAttr("id");

            $('#btnAddNewJob').before(objNew);


            var id = Math.random().toString().replace('0.', '');

            objNew.find('.ddlJobCategory').attr('id', 'ddlJobCategory_' + id).jJobSelect();
            objNew.find('.ddlSalary').attr('id', 'ddlSalary_' + id).formSelect({
                className: 'color_select',
                colWidth: 100,
                cols: 3,
                onShow: function () {
                    $('ddlSalary_' + id).trigger('focusListener');
                },
                onClose: function () {
                    $('ddlSalary_' + id).trigger('blurListener');
                }
            });

            objNew.find(".ddlJobType").attr('id', 'ddlJobType_' + id).formSelect({
                className: 'color_select',
                colWidth: 70,
                cols: 3,
                select: 3,
                onShow: function () {
                    $('ddlJobType_' + id).trigger('focusListener');
                },
                onClose: function () {
                    $('ddlJobType_' + id).trigger('blurListener');
                }
            });

            objNew.find(".ddlDegree").attr('id', 'ddlDegree_' + id).formSelect({
                className: 'color_select',
                colWidth: 100,
                cols: 2,
                onShow: function () {
                    $('ddlDegree_' + id).trigger('focusListener');
                },
                onClose: function () {
                    $('ddlDegree_' + id).trigger('blurListener');
                }
            });

            objNew.find(".ddlExperience").attr('id', 'ddlExperience_' + id).formSelect({
                className: 'color_select',
                colWidth: 100,
                cols: 2,
                onShow: function () {
                    $('ddlExperience_' + id).trigger('focusListener');
                },
                onClose: function () {
                    $('ddlExperience_' + id).trigger('blurListener');
                }
            });

            objNew.find(".ddlSex").attr('id', 'ddlSex_' + id).formSelect({
                className: 'color_select',
                colWidth: 100,
                cols: 2,
                onShow: function () {
                    $('ddlSex_' + id).trigger('focusListener');
                },
                onClose: function () {
                    $('ddlSex_' + id).trigger('blurListener');
                }
            });

            objNew.find('[name=IsCarfare]').attr('name', 'IsCarfare_' + id);
            objNew.find('[name=IsHousing]').attr('name', 'IsHousing_' + id);

            objNew.find('.txtExpireDate').attr('id', 'txtExpireDate_' + id).datepicker({
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true,
                yearRange: '1950:<%=DateTime.Now.Year %>',
                dateFormat: "yy-mm-dd",
                yearSuffix: '',
                beforeShow: function () {
                    setTimeout(function () {
                        $('#ui-datepicker-div').css('z-index', '1000');
                    }, 0);
                }
            });
            objNew.find('.delete').click(function () {
                if (!confirm('确定要删除吗？')) { return false; }
                objNew.remove();
                $('#jobcount').val($('.jobtemplate').length);
            });
            $('#jobcount').val($('.jobtemplate').length);
        }
    </script>--%>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonReg.aspx.cs" Inherits="NH.Web.adm.Person.PersonReg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <%=CssAndScript %>
    <%--<%=EasyUI_CssAndScript %>--%>
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
            <p>人才管理 -> 添加人才</p>
        </div>
        <div class="tbitem">
        <p class="title tab"><span>基本信息</span></p>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    <span class="red">*</span>登录用户名：
                </th>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtLoginName"></asp:TextBox>
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
                    <span class="red">*</span>姓名：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtTrueName"></asp:TextBox>
                </td>
                <th>
                    <span class="red">*</span>性别：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblSex" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="noinputbg">
                        <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                        <asp:ListItem Value="0">女</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>
                    <span class="red">*</span>出生日期：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtBirthday"></asp:TextBox>
                </td>
                <th>
                    身高(厘米)：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtHeight"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <span class="red">*</span>籍贯：
                </th>
                <td>
                    <select id="ddlResidence" name="ddlResidence" class="required hideselect" style=" width:100px;">
                        <option value="">选择城市</option>
                        <asp:Literal ID="ltrResidence" runat="server"></asp:Literal>
                    </select>
                </td>
                <th>
                    <span class="red">*</span>所在地区：
                </th>
                <td>
                    <select id="ddlCurr" name="ddlCurr" class="required hideselect" style=" width:100px;">
                        <option value="">选择城市</option>
                        <asp:Literal ID="ltrCurr" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>
                    婚姻状况：
                </th>
                <td>
                    <asp:DropDownList runat="server" ID="ddlMarriage" CssClass="required hideselect" Width="94">
                        <asp:ListItem Value="0">未婚</asp:ListItem>
                        <asp:ListItem Value="1">已婚</asp:ListItem>
                        <asp:ListItem Value="2">离异</asp:ListItem>
                        <asp:ListItem Value="3">丧偶</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <th>
                    <span class="red">*</span>工作年限：
                </th>
                <td>
                    <select id="ddlExperience" name="ddlExperience" class="required hideselect" style=" width:94px;">
                        <option value="">请选择</option>
                        <asp:Literal ID="ltrExperience" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>
                    <span class="red">*</span>教育程度：
                </th>
                <td colspan="3">
                    <select id="ddlDegree" name="ddlDegree" class="required hideselect" style=" width:94px;">
                        <option value="">请选择</option>
                        <asp:Literal ID="ltrDegree" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
        </table>
        </div>

        
        <div class="tbitem">
        <p class="title tab"><span>联系方式</span></p>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    <span class="red">*</span>手机号码：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtMobile"></asp:TextBox>
                </td>
                <th>
                    座机：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <span class="red">*</span>QQ号：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtQQ"></asp:TextBox>
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
                    主页/微博：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtHomePage"></asp:TextBox>
                </td>
                <th>
                    联系地址：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtAddress"></asp:TextBox>
                </td>
            </tr>
        </table>
        </div>

        
        <div class="tbitem">
        <p class="title tab"><span>求职意向</span></p>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    是否提供食宿：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblHousing" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="noinputbg radiostyle1">
                        <asp:ListItem Value="1">提供</asp:ListItem>
                        <asp:ListItem Value="0">不提供</asp:ListItem>
                        <asp:ListItem Value="-1" Selected="True">面议</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <th>
                    是否报销路费：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblCarFare" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="noinputbg radiostyle1">
                        <asp:ListItem Value="1">报销</asp:ListItem>
                        <asp:ListItem Value="0">不报销</asp:ListItem>
                        <asp:ListItem Value="-1" Selected="True">面议</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>
                    <span class="red">*</span>期望职位：
                </th>
                <td>
                    <select id="ddlJobCategory" name="ddlJobCategory" multiple="multiple" class="required" style=" width:270px;">
                        <asp:Literal runat="server" ID="ltrJobCategor"></asp:Literal>
                    </select>
                </td>
                <th>
                    <span class="red">*</span>期望薪水：
                </th>
                <td>
                    <select id="ddlSalary" name="ddlSalary" class="required" style=" width:94px;">
                        <option value="">请选择</option>
                        <asp:Literal ID="ltrSalary" runat="server"></asp:Literal>
                    </select>
                        <asp:CheckBox runat="server" ID="chkCommission" Text=" 加提成" CssClass="noinputbg"  />
                </td>
            </tr>
            <tr>
                <th>
                    <span class="red">*</span>到岗时间：
                </th>
                <td>
                    <select id="ddlComeTime" name="ddlComeTime" class="required" style=" width:94px;">
                        <option value="">请选择</option>
                        <asp:Literal ID="ltrComeTime" runat="server"></asp:Literal>
                    </select>
                </td>
                <th>
                    <span class="red">*</span>工作方式：
                </th>
                <td>
                    <select id="ddlJobType" name="ddlJobType" multiple="multiple" class="required" style=" width:160px;">
                        <asp:Literal ID="ltrJobType" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>
                    <span class="red">*</span>期望地区：
                </th>
                <td colspan="3">
                    <select id="ddlJobAddress" name="ddlJobAddress" multiple="multiple" class="required" style=" width:270px;">
                        <asp:Literal ID="ltrJobAddress" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>
                    个人简历：
                </th>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtResume" TextMode="MultiLine" Columns="80" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    自我评价：
                </th>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtSelfEvaluation" TextMode="MultiLine" Columns="80" Rows="5"></asp:TextBox>
                </td>
            </tr>
        </table>
        </div>
        
        <div class="tbitem">
        <p class="title tab"><span>工作经历</span></p>
        <table cellpadding="0" cellspacing="0" class="utable" id="temp" style=" display:none; width:98%; margin-bottom:10px;">
			<tbody>
				<tr>
					<th><span class="red">*</span>企业名称：</th>
					<td><input type="text" name="txtCompanyName" value="" class="txtCompanyName" /><p id="txtCompanyNameTip"></p></td>
					<th><span class="red">*</span>担任职位：</th>
					<td><input type="text" name="txtPositionName" value="" class="txtPositionName" /><p id="txtPositionNameTip"></p></td>
					<th><span class="red">*</span>时间范围：</th>
					<td><input type="text" name="txtStartTime" class="required dateISO txtStartTime" style=" width:75px;" /> 至 <input type="text" name="txtEndTime" class="dateISO txtEndTime" style=" width:75px;" /><p id="txtTimeTip"></p></td>
                    <td><input type="button" value="删除" class="btnSmall delete" /></td>
				</tr>
			</tbody>
		</table>
        <div id="btnAddNewExp" style=" text-align:center;"><input type="button" onclick="NewExp()" value="添加经历" class="btnSmall" /><input type="hidden" id="expcount" name="expcount" /></div>
        </div>

        <div class="tbitem">
            <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                </th>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btnSubmit" onclick="btnSubmit_Click" OnClientClick="return beforsubmit();" />
                </td>
            </tr>
            </table>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        function beforsubmit() {
            var pass = true;
            //var count = 0;
            $('.exptemplate').each(function (i, n) {
                var obj = $(this);
                var companyname = obj.find('.txtCompanyName').attr('name', 'txtCompanyName_' + i);
                var positionname = obj.find('.txtPositionName').attr('name', 'txtPositionName_' + i);
                var starttime = obj.find('.txtStartTime').attr('name', 'txtStartTime_' + i);
                var endtime = obj.find('.txtEndTime').attr('name', 'txtEndTime_' + i);

                if ($.trim(companyname.val()) == "") { alert('请填写工作经历企业名称'); companyname.focus(); pass = false; return false; };
                if ($.trim(positionname.val()) == "") { alert('请填写工作经历职位名称'); positionname.focus(); pass = false; return false; };
                if ($.trim(starttime.val()) == "") { alert('请填写工作经历开始时间'); starttime.focus(); pass = false; return false; };
                //count++;
            });
            //$('#expcount').val(count);
            $('#expcount').val($('.exptemplate').length);
            return pass;
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=form1.ClientID %>').ajaxForm({
                beforeSubmit: function () {
                    return true;
                    //return beforsubmit();
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
        $(document).ready(function () {
            $('#txtBirthday').datepicker({
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
        });
    </script>
    <script type="text/javascript">
        $("#<%=this.ddlMarriage.ClientID %>").formSelect({
            className: 'color_select',
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
        $('#ddlResidence').jAreaSelect();
        $('#ddlCurr').jAreaSelect();
    </script>

    <script type="text/javascript">
        $("#ddlExperience").formSelect({
            className: 'color_select',
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
    <script type="text/javascript">
        $("#ddlDegree").formSelect({
            className: 'color_select',
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
        $("#ddlSalary").formSelect({
            className: 'color_select',
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
        $("#ddlJobType").formSelect({
            className: 'color_select',
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
    </script>
    <script type="text/javascript">
        $("#ddlJobAddress").jAreaSelect({ select: 3, is_province: true });
        $("#ddlJobCategory").jJobSelect({ select: 3 });
    </script>
    <script type="text/javascript">
        $("#ddlComeTime").formSelect({
            className: 'color_select',
            colWidth: 120,
            cols: 3,
            select: 1,
            className: 'color_select',
            onShow: function () {
                $('#ddlComeTime').trigger('focusListener');
            },
            onClose: function () {
                $('#ddlComeTime').trigger('blurListener');
            }
        });
    </script>

    <script type="text/javascript">
        function NewExp() {
            var objNew = $('#temp').clone().show().addClass("exptemplate");

            $('#btnAddNewExp').before(objNew);
            objNew.find('.txtStartTime,.txtEndTime').datepicker({
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
                $('#expcount').val($('.exptemplate').length);
            });
            $('#expcount').val($('.exptemplate').length);

        }
    </script>
</body>
</html>

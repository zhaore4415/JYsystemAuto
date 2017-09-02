<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceUpload.aspx.cs"
    Inherits="NH.Web.adm.Authority.Staff.ExportUpload" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%=CssAndScript %>
    <style type="text/css">
        #solution li .cname
        {
            font-weight: bold;
            height: 20px;
            line-height: 20px;
        }
        #solution li ul
        {
            padding: 0px 0px 10px 10px;
        }
        #solution li ul li
        {
            line-height: 20px;
            height: 20px;
        }
        #solution li ul li.selected
        {
            color: Blue;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnAddFile').click(function () {
                var objnew = $('#temp').clone().removeAttr('id');
                objnew.find('input').val('');
                $(this).parent().before(objnew);
            });
            $('#btnAddfile2').click(function () {
                var objnew = $('#temp2').clone().removeAttr('id');
                objnew.find('input').val('');
                $(this).parent().before(objnew);
            });
            $('#btnAboutPro').click(function () {
                var objnew = $('#abouttemp').clone().removeAttr('id');
                objnew.find('input').val('');
                $(this).parent().before(objnew);
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#solution > li > ul > li').filter(':has(:checked)').addClass('selected').end().each(function () {
                var li = $(this);
                li.find('input:checkbox').click(function () {
                    if ($(this).is(':checked')) { li.addClass('selected') } else { li.removeClass('selected') }
                });
            });
        });
    </script>
    <script type="text/javascript">
        function beforesubmit() {
            $('#filecount1').val($('[name=filepic]').length);
            $('#AboutProcount').val($('[name=txtAboutProName]').length);
            return true
        }
    </script>
    <script type="text/javascript">
        function clearNoNum(obj) {
            obj.value = obj.value.replace(/[^\d.]/g, "");  //清除“数字”和“.”以外的字符   
            obj.value = obj.value.replace(/^\./g, "");  //验证第一个字符是数字而不是.   
            obj.value = obj.value.replace(/\.{2,}/g, "."); //只保留第一个. 清除多余的.   
            obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="table-add">
        <table cellpadding="0" cellspacing="1" class="utable">
            <tbody>
                <tr>
                    <td class="crumbs" colspan="2">
                        订单批量导入<span>&gt;</span>上传
                    </td>
                </tr>
                <tr>
                    <th>
                        年/月
                    </th>
                    <td>
                     <asp:DropDownList ID="DropDownList1" runat="server" CssClass="DropCss">
                         
                            <asp:ListItem>2015</asp:ListItem>
                            <asp:ListItem>2016</asp:ListItem>
                            <asp:ListItem>2017</asp:ListItem>
                            <asp:ListItem>2018</asp:ListItem>
                            <asp:ListItem>2019</asp:ListItem>
                            <asp:ListItem>2020</asp:ListItem>
                            <asp:ListItem>2021</asp:ListItem>
                            <asp:ListItem>2022</asp:ListItem>
                            <asp:ListItem>2023</asp:ListItem>
                            <asp:ListItem>2024</asp:ListItem>
                            <asp:ListItem>2025</asp:ListItem>
                            <asp:ListItem>2026</asp:ListItem>
                            <asp:ListItem>2027</asp:ListItem>
                            <asp:ListItem>2028</asp:ListItem>
                            <asp:ListItem>2029</asp:ListItem>
                            <asp:ListItem>2030</asp:ListItem>
                        </asp:DropDownList>年
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="DropCss">
                       
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                        </asp:DropDownList>月
                    </td>
                </tr>
                <tr>
                    <th>
                        Excel文件：
                    </th>
                    <td>
                        <p>
                            <asp:FileUpload runat="server" ID="file" CssClass="input-view" />
                            <asp:HyperLink ID="HyperLink1" runat="server">下载Excel模板（Excel第一行数据不能改变）</asp:HyperLink>
                            <%--<a href="/Upload/Queryorder/OrderTemplate.zip" target="_blank">下载Excel模板（Excel第一行数据不能改变）</a>--%>
                        </p>
                    </td>
                </tr>
                <tr>
                    <th>
                    </th>
                    <td>
                        <asp:Button runat="server" ID="btnSubmit" CssClass="submit" Text="开始上传" OnClick="btnSubmit_Click" /><input
                            type="hidden" value="<%=message %>" id="message" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>

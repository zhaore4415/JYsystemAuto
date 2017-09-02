<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonInfo.aspx.cs" Inherits="NH.Web.adm.Person.PersonInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="intro">
        <div class="tbitem">
        <p class="title tab"><span>基本信息</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>真实姓名：</th>
                <td><%=_realname %></td>
                <th>婚姻状态：</th>
                <td><%=_marrage %></td>
            </tr>
            <tr>
                <th>性别：</th>
                <td><%=_sex %></td>
                <th>最高学历：</th>
                <td><%=_degree %></td>
            </tr>
            <tr>
                <th>年龄：</th>
                <td><%=_age %></td>
                <th>工作年限：</th>
                <td><%=_experience %></td>
            </tr>
            <tr>
                <th>出生日期：</th>
                <td><%=_birthday %></td>
                <th>籍贯：</th>
                <td><%=_residence %></td>
            </tr>
            <tr>
                <th>身高：</th>
                <td><%=_height %></td>
                <th>现所在地：</th>
                <td><%=_curaddr %></td>
            </tr>
        </table>
        </div>

        <div class="tbitem">
        <p class="title tab"><span>联系方式</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr class="utable">
                <th>手机：</th>
                <td><%=_mobile %></td>
                <th>QQ：</th>
                <td><%=_qq%></td>
            </tr>
            <tr>
                <th>联系电话：</th>
                <td><%=_phone %></td>
                <th>Email：</th>
                <td><%=_email%></td>
            </tr>
            <tr>
                <th>邮编：</th>
                <td><%=_zipcode%></td>
                <th>主页/博客：</th>
                <td><%=_homepage%></td>
            </tr>
            <tr>
                <th>详细地址：</th>
                <td colspan="3"><%=_address%></td>
            </tr>        
        </table>
        </div>

        <div class="tbitem">
        <p class="title tab"><span>求职意向</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>提供住宿：</th>
                <td><%=_housing %></td>
                <th>报名路费：</th>
                <td><%=_carfare %></td>
            </tr>
            <tr>
                <th>期望职位：</th>
                <td><%=_jobcategory %></td>
                <th>期望地区：</th>
                <td><%=_jobaddr %></td>
            </tr>
            <tr>
                <th>期望薪水：</th>
                <td><%=_salary %></td>
                <th>工作方式：</th>
                <td><%=_jobtype %></td>
            </tr>
        </table>
        </div>
        
        <div class="tbitem">
        <p class="title tab"><span>个人简历</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <td><%=_resume %></td>
            </tr>
        </table>
        </div>
        
        <div class="tbitem">
        <p class="title tab"><span>教育背景</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <td><%=_education %></td>
            </tr>
        </table>
        </div>
        
        <div class="tbitem">
        <p class="title tab"><span>业余爱好</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <td><%=_hobby %></td>
            </tr>
        </table>
        </div>
        
        <div class="tbitem">
        <p class="title tab"><span>自我评价</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <td><%=_selfEvaluation %></td>
            </tr>
        </table>
        </div>
    </div>
        
    
    
    
    
    
    
    个人相册
    <ul>
        <asp:Repeater runat="server" ID="rptAlbums">
        <ItemTemplate>
        <li><img src="/Upload/PersonAlbum/Small/<%# Eval("ImgSmall")%>" alt="<%# Eval("Title")%>" title="<%# Eval("Title")%>" /></li>
        </ItemTemplate>
        </asp:Repeater>
    </ul>
    个人作品
    <ul>
        <asp:Repeater runat="server" ID="rptWorks">
        <ItemTemplate>
        <li><img src="/Upload/PersonWorks/Small/<%# Eval("ImgSmall")%>" alt="<%# Eval("Title")%>" title="<%# Eval("Title")%>" /></li>
        </ItemTemplate>
        </asp:Repeater>
    </ul>
    </form>
</body>
</html>

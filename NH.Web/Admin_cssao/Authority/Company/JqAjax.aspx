<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JqAjax.aspx.cs" Inherits="NH.Web.Authority.Company.JqAjax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../JS/jquery-1.2.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var addSelOption = function (jq) //方法addSelOption : 为匹配对象添加一项"请选择"， jq ： jQuery对象  
            {
                //创建option对象，并设置文本为"请选择"，value值为-1  
                var opt = $("<option/>").text("请选择").attr("value", "-1");
                //将option对象添加到select中  
                jq.append(opt);
            }
            //获取请求的URL  
            var requestUrl = "/Handler/GetBranchOne.aspx";
            /* 
            通过 HTTP GET 请求载入 JSON 数据 
            json : JSON对象 
            */
            $.getJSON(requestUrl, function (json) {
                //遍历JSON对象  
                $(json).each(function () {
//                    alert(json);
                    //创建option对象并设置相应的文本值和value值  
                    var opt = $("<option/>").text(this.name).attr("value", this.id);
                    //将option对象添加到匹配的jQuery对象中  
                    $("#ddlBranchOne").append(opt);  
                
                });
            });
            $("#ddlBranchOne").change(function () {
             
                //获取请求的URL  
                var requestUrl = "/Handler/GetBranchTwo.aspx";
                //获取下拉菜单的value值  
                var branchId = $(this).val();

                if (branchId != "-1") {
                 
                    // {"branchID" : branchId} ： 传入参数  
                    $.getJSON(requestUrl, {id:$(this).attr("value")},function (json) {
                        $("#ddlBranchTwo").empty();
                        
                        //$("#ddlBranchTwo").append($("<option/>").text("请选择").attr("value", "-1"));  
                        addSelOption($("#ddlBranchTwo"));
                        //遍历JSON对象  
                        $(json).each(function () {
                         
                            var opt = $("<option/>").text(this.name).attr("value", this.id);
                            //将option对象添加到匹配的jQuery对象中  
                            $("#ddlBranchTwo").append(opt);  
//                            $("#ddlBranchTwo").append($("<option/>").text(this.name).attr("value", this.id));
                        });
                        $("#ddlBranchTwo").change(function () {
                            //获取下拉菜单的value值   
                            var branchId = $(this).val();
                            //获取请求的URL  
                            var requestUrl = "/Handler/GetBranchThird.aspx";
                            if (branchId != "-1") {
                                $.getJSON(requestUrl, { id: $(this).attr("value") }, function (json) {
                                    $("#ddlBranchThird").empty();
                                    addSelOption($("#ddlBranchThird"));
                                    //遍历JSON对象  
                                    $(json).each(function () {
                                        //创建option对象并设置相应的文本值和value值  
                                        $("#ddlBranchThird").append($("<option/>").text(this.name).attr("value", this.id));
                                    });
                                });
                            }
                            else {
                                $("#ddlBranchThird").empty();
                                addSelOption($("#ddlBranchThird"));
                            }
                        });
                    });
                }
                else {
                    $("#ddlBranchTwo").empty();
                    addSelOption($("#ddlBranchTwo"));
                    $("#ddlBranchThird").empty();
                    addSelOption($("#ddlBranchThird"));
                }
            });
        });  
    </script>  

</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="I级机构"></asp:Label>
    &nbsp;
    <asp:DropDownList ID="ddlBranchOne" runat="server" Width="107px">
        <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
    </asp:DropDownList>
    <asp:HiddenField ID="hiddenBranchOne" runat="server" Value="-1" />
    <br />
    <asp:Label ID="Label2" runat="server" Text="II级机构"></asp:Label>&nbsp;
    <asp:DropDownList ID="ddlBranchTwo" runat="server" Width="105px">
        <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
    </asp:DropDownList>
    <asp:HiddenField ID="hiddenBranchTwo" runat="server" Value="-1" />
    <br />
    <asp:Label ID="Label3" runat="server" Text="III级机构"></asp:Label>
    <asp:DropDownList ID="ddlBranchThird" runat="server" Width="102px">
        <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
    </asp:DropDownList>
    <asp:HiddenField ID="hiddenBranchThird" runat="server" Value="-1" />
    </form>
</body>
</html>

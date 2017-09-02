<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AjaxShenShiXian.ascx.cs" Inherits="NH.Web.Controls.ShenShiXian" %>
<script src="../JS/ajax.js" type="text/javascript"></script>
<script type="text/javascript">
    var ddlBranchOne = null;
    var ddlBranchTwo = null;
    var ddlBranchThird = null;

    var hiddenBranchOne = null;
    var hiddenBranchTwo = null;
    var hiddenBranchThird = null;
    window.onload = function () {
        ddlBranchOne = document.getElementById("<%=ddlBranchOne.ClientID %>");
        ddlBranchTwo = document.getElementById("<%=ddlBranchTwo.ClientID %>");
        ddlBranchThird = document.getElementById("<%=ddlBranchThird.ClientID %>");

        hiddenBranchOne = document.getElementById("<%=hiddenBranchOne.ClientID %>");
        hiddenBranchTwo = document.getElementById("<%=hiddenBranchTwo.ClientID %>");
        hiddenBranchThird = document.getElementById("<%=hiddenBranchThird.ClientID %>");

     
        LoadBranchOne();
    }

    var LoadBranchOne = function () {
        //alert(1);
        var url = "/Handler/GetBranchOne.aspx?catch=" + (new Date()).getTime();
//        alert(url);
        var fnCallBack = function (oResult) {
      
            var result = eval(oResult);
            alert(1);
            //ClearDropDownList(ddlBranchOne);
            FillDropDownList(ddlBranchOne, result);
            ddlBranchOne.onchange = function () {
                alert(this.options[this.selectedIndex].value);
                var selectvalue = this.options[this.selectedIndex].value;
                //alert(selectvalue);
                if (hiddenBranchOne) hiddenBranchOne.value = selectvalue;
                LoadBranchTwo(selectvalue);
            }

        }
        var fnLoading = function () {

        }
        Http.Get(url, fnCallBack, fnLoading);

    }

    function LoadBranchTwo(oId) {
        var url = "/Handler/GetBranchTwo.aspx?id=" + oId + "&catch=" + (new Date()).getTime();
        //alert(url);
        var fnCallBack = function (oResult) {
            //          alert(oResult);
            var result = eval(oResult);
            FillDropDownList(ddlBranchTwo, result);
        }
        Http.Get(url, fnCallBack, null);
        ddlBranchTwo.onchange = function () {
            var selectvalue = this.options[this.selectedIndex].value;
            if (hiddenBranchTwo) hiddenBranchTwo.value = selectvalue;
            LoadBranchThird(selectvalue);
        }

    }

    function LoadBranchThird(oId) {
        var url = "/Handler/GetBranchThird.aspx?id=" + oId + "&catch=" + (new Date()).getTime();
        //alert(url);
        var fnCallBack = function (oResult) {
            var result = eval(oResult);
            //alert(ddlBranchThird);
            FillDropDownList(ddlBranchThird, result);

        }
        Http.Get(url, fnCallBack, null);

        ddlBranchThird.onchange = function () {
            hiddenBranchThird.value = this.options[this.selectedIndex].value;
        }


    }

    function FillDropDownList(ddl, oResult) {
        ClearDropDownList(ddl);
        var Option = document.createElement("option");
        var oText = document.createTextNode("请选择");
        Option.setAttribute("value", "-1");
        Option.appendChild(oText);
        ddl.appendChild(Option);
        for (var i = 0; i < oResult.length; i++) {
            var name = oResult[i].name;
            var id = oResult[i].id;
            var Option1 = document.createElement("option");
            Option1.setAttribute("value", id);
            Option1.appendChild(document.createTextNode(name));
            ddl.appendChild(Option1);
        }




    }
    ///清空select
    function ClearDropDownList(ddl) {
        //alert(ddl);
        for (var i = ddl.options.length - 1; i >= 0; i--) {
            ddl.remove(i);
        }
    }
</script>
&nbsp;<asp:Label ID="Label1" runat="server" Text="I级机构"></asp:Label>
&nbsp;
<asp:DropDownList ID="ddlBranchOne" runat="server" Width="107px">
    <asp:ListItem Value="-1">请选择</asp:ListItem>
</asp:DropDownList>
<asp:HiddenField ID="hiddenBranchOne" runat="server"  Value="-1"/>
<br />
<asp:Label ID="Label2" runat="server" Text="II级机构"></asp:Label>&nbsp;
<asp:DropDownList ID="ddlBranchTwo" runat="server" Width="105px">
    <asp:ListItem Value="-1">请选择</asp:ListItem>
</asp:DropDownList><asp:HiddenField ID="hiddenBranchTwo" runat="server"  Value="-1"/>
<br />
<asp:Label ID="Label3" runat="server" Text="III级机构"></asp:Label>
<asp:DropDownList ID="ddlBranchThird" runat="server" Width="102px">
    <asp:ListItem Value="-1">请选择</asp:ListItem>
</asp:DropDownList><asp:HiddenField ID="hiddenBranchThird" runat="server"  Value="-1"/>
&nbsp;

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="事务.aspx.cs" Inherits="NH.Web.事务" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button runat="server" Text="事务" OnClick="Unnamed1_Click" ID="Button2" />
        
        <br />
        <br />
        <br />
    <asp:Button runat="server" Text="事务" OnClick="Unnamed2_Click" ID="Button3" />
        
        <br />
        <br />
        <br />
        
        <asp:Button ID="Button1" runat="server" Text="分布式事务" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>

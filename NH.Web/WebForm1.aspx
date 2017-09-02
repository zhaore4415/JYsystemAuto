<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="NH.Web.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        function FixTableHeader() {
            var t = document.getElementById("table");
            var thead = t.getElementsByTagName("thead")[0];
            var t1 = t.cloneNode(false);
            t1.appendChild(thead);
            document.getElementById("tableHeader").appendChild(t1)
        }
        window.onload = FixTableHeader;
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="tableHeader">
    </div>
    <div style="overflow: scroll; height: 100px; width: 500px">
        <table id="table" width="500" style="table-layout: fixed">
            <thead>
                <tr id="thead" style="background-color: #BEBEBE">
                    <th>
                        Account Number
                    </th>
                    <th>
                        Account Name
                    </th>
                    <th>
                        City
                    </th>
                    <th>
                        Country
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Reapeter1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "AccountNumber")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "AccountName")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem,"City")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem,"Country")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>

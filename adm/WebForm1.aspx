<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Test2010.ckediter.WebForm1" %>

<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" BasePath="_ckeditor/" FilebrowserBrowseUrl="_ckeditor/ckfinder/ckfinder.html">
        </CKEditor:CKEditorControl>
    
    </div>
    </form>
</body>
</html>

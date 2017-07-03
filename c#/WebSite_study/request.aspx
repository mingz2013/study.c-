<%@ Page Language="C#" AutoEventWireup="true" CodeFile="request.aspx.cs" Inherits="request" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="获取服务器信息" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            Text="获取浏览器信息" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
            Text="写入cookies" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
            Text="读取cookies" />
    
        <br />
        <br />
        <asp:Button ID="Button5" runat="server" onclick="Button5_Click" Text="重定向" />
    
    </div>
    </form>
</body>
</html>

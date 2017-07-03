<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageshijian.aspx.cs" Inherits="pageshijian" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" />
    </div>
    
    <div>
            <asp:Button ID="Button2" runat="server" Text="谁是老大" onclick="Button2_Click" 
                oncommand="Button2_Command" />
        
            <br />
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        
    </div>
 </form>
</body>
</html>

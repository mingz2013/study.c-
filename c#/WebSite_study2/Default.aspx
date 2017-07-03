<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="button未被选中"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" CommandName="a" Height="50px" 
            onclick="Button1_Click" Text="a" Width="50px" />
        <asp:Button ID="Button2" runat="server" CommandName="b" Height="50px" 
            onclick="Button1_Click" Text="b" Width="50px" />
        <asp:Button ID="Button3" runat="server" CommandName="c" Height="50px" 
            onclick="Button1_Click" Text="c" Width="50px" />
        <br />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" BackColor="#CC66FF" 
            BorderColor="#00CC00" BorderStyle="Outset" BorderWidth="10px" ForeColor="Blue" 
            Height="104px" RepeatColumns="2" RepeatDirection="Horizontal" Width="165px">
            <asp:ListItem Selected="True">aaaaa</asp:ListItem>
            <asp:ListItem>bbbbb</asp:ListItem>
            <asp:ListItem>ccccc</asp:ListItem>
            <asp:ListItem Enabled="False">ddddd</asp:ListItem>
        </asp:CheckBoxList>
        <asp:ImageMap ID="ImageMap1" runat="server" Height="100px" 
            HotSpotMode="Navigate" Width="160px">
        </asp:ImageMap>
        <br />
        广告控件：<asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/ad.xml" 
            onload="AdRotator1_Load" />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
    
    </div>
    <div>

        <asp:Wizard ID="Wizard1" runat="server" BackColor="#FFFBD6" 
            BorderColor="#FFDFAD" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
            Height="109px" Width="400px">
            <HeaderStyle BackColor="#FFCC66" BorderColor="#FFFBD6" BorderStyle="Solid" 
                BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="#333333" 
                HorizontalAlign="Center" />
            <NavigationButtonStyle BackColor="White" BorderColor="#CC9966" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
                ForeColor="#990000" />
            <SideBarButtonStyle ForeColor="White" />
            <SideBarStyle BackColor="#990000" Font-Size="0.9em" VerticalAlign="Top" />
            <WizardSteps>
                <asp:WizardStep runat="server" title="Step 1">
                </asp:WizardStep>
                <asp:WizardStep runat="server" title="Step 2">
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>

    </div>
    </form>
</body>
</html>

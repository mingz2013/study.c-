<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Theme="blue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" SkinID="red1">
            <Columns>
                <asp:BoundField DataField="v刹吧" DataFormatString="吧" FooterText="改变风格" 
                    HeaderText="分的高分 " NullDisplayText="vbdg" />
                <asp:BoundField FooterText="改变风格" HeaderText="副歌部分" />
                <asp:BoundField FooterText="规划法规" HeaderText="国内的符合" />
                <asp:BoundField FooterText="吧" HeaderText="改变风格" />
                <asp:BoundField HeaderText="部分" />
                <asp:BoundField HeaderText="国防部" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" Height="153px" SkinID="red1" 
            Width="435px">
            <Columns>
                <asp:BoundField DataField="vcb" DataFormatString="vbgf" HeaderText="column0" />
                <asp:BoundField HeaderText="column1" />
                <asp:BoundField HeaderText="column2" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="Button3" runat="server" Text="Button" />
        <asp:ListBox ID="ListBox1" runat="server" BackColor="#0033CC" Font-Bold="True" 
            Font-Italic="True" Font-Names="Kozuka Mincho Pro H" Font-Size="Larger" 
            ForeColor="#CC33FF" Height="119px" Width="467px">
            <asp:ListItem>负的</asp:ListItem>
            <asp:ListItem>vbfg</asp:ListItem>
            <asp:ListItem>vbs</asp:ListItem>
            <asp:ListItem>vb个</asp:ListItem>
            <asp:ListItem>vb</asp:ListItem>
            <asp:ListItem Value="vb ">vb</asp:ListItem>
            <asp:ListItem Value="vfgf"></asp:ListItem>
        </asp:ListBox>
        <asp:Button ID="Button1" runat="server" BackColor="Lime" BorderColor="#3333CC" 
            BorderStyle="Outset" BorderWidth="32px" Font-Bold="True" Font-Italic="True" 
            Font-Names="Adobe Garamond Pro Bold" Font-Overline="True" Font-Size="Larger" 
            ForeColor="Red" Text="Button" />
        <asp:ListBox ID="ListBox3" runat="server" Width="298px"></asp:ListBox>
        <asp:ListBox ID="ListBox2" runat="server" style="margin-top: 0px" Width="220px">
        </asp:ListBox>
        <asp:Button ID="Button2" runat="server" Text="Button" />
    
    </div>
    <asp:Menu ID="Menu1" runat="server" BackColor="Fuchsia" BorderColor="White" 
        BorderStyle="None" DynamicHorizontalOffset="2" Font-Names="Verdana" 
        Font-Size="0.8em" ForeColor="#000099" Height="30px" Orientation="Horizontal" 
        RenderingMode="Table" StaticSubMenuIndent="10px" style="margin-left: 0px" 
        Width="724px">
        <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicMenuStyle BackColor="#E3EAEB" />
        <DynamicSelectedStyle BackColor="#1C5E55" />
        <Items>
            <asp:MenuItem Text="新建项" Value="新建项"></asp:MenuItem>
            <asp:MenuItem Text="新建项" Value="新建项"></asp:MenuItem>
            <asp:MenuItem Text="新建项" Value="新建项"></asp:MenuItem>
            <asp:MenuItem Text="新建项" Value="新建项"></asp:MenuItem>
            <asp:MenuItem Text="新建项" Value="新建项"></asp:MenuItem>
            <asp:MenuItem Text="新建项" Value="新建项"></asp:MenuItem>
            <asp:MenuItem Text="新建项" Value="新建项"></asp:MenuItem>
            <asp:MenuItem Text="新建项" Value="新建项"></asp:MenuItem>
        </Items>
        <StaticHoverStyle BackColor="#666666" ForeColor="White" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticSelectedStyle BackColor="#1C5E55" />
    </asp:Menu>
    <asp:TreeView ID="TreeView1" runat="server" ImageSet="Contacts" NodeIndent="10" 
        ShowLines="True">
        <HoverNodeStyle Font-Underline="False" />
        <Nodes>
            <asp:TreeNode Text="新建节点" Value="新建节点">
                <asp:TreeNode Text="新建节点" Value="新建节点">
                    <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="新建节点" Value="新建节点">
                    <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="新建节点" Value="新建节点">
                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
            HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
        <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" 
            VerticalPadding="0px" />
    </asp:TreeView>
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" />
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
    </asp:CreateUserWizard>
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
    </asp:PasswordRecovery>
    <asp:LoginView ID="LoginView1" runat="server">
    </asp:LoginView>
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
    <asp:ChangePassword ID="ChangePassword1" runat="server">
    </asp:ChangePassword>
    <asp:Login ID="Login1" runat="server">
    </asp:Login>
    </form>
</body>
</html>

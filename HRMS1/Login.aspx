<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HRMS1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;Email :
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <BR />
            <BR />
            Password :
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <BR />
            <BR />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Sign In" />
            <BR />
            <BR />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Reg.aspx">Create A New Account</asp:HyperLink>
        </div>
    </form>
</body>
</html>

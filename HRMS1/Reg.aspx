<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="HRMS1.Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Username :
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <BR />
            <BR />
            Email :
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <BR />
            <BR />
            Password :
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <BR />
            <BR />
            <BR />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign Up" />
        </div>
    </form>
</body>
</html>

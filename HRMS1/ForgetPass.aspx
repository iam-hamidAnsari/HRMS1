<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPass.aspx.cs" Inherits="HRMS1.ForgetPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
     <title>Forget Password</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="mb-4">Forget Password</h2>

            <div class="form-group">
                <label for="TextBox1">Email:</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"  OnTextChanged="TextBox1_TextChanged" Width="400px"></asp:TextBox>
            </div>

            <asp:Button ID="Button1" runat="server" Text="Send OTP" CssClass="btn btn-primary mb-3" />

            <div class="form-group">
                <label for="TextBox2">OTP:</label>
                <asp:TextBox ID="TextBox2" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Verify OTP" CssClass="btn btn-success mt-2" OnClick="Button2_Click" />
            </div>

            <div id="ChangePassword" runat="server">
                <div class="form-group">
                    <label for="TextBox3">New Password:</label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Width="400px" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button ID="Button3" runat="server" Text="Update Password" CssClass="btn btn-warning" OnClick="Button3_Click" />
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>

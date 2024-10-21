<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HRMS1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Login</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
        body {
            background-color: papayawhip;
        }
        .login-container {
            max-width: 400px;
            margin: 100px auto;
            padding: 20px;
            border: 1px solid #ced4da;
            border-radius: 5px;
            background-color: white;
            box-shadow: 0 0 10px darkgreen;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2 class="text-center">Sign In</h2>
            <div class="form-group">
                <label for="TextBox4">Email:</label>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Enter your email"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TextBox5">Password:</label>
                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
            </div>
            <div class="text-center">
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" CssClass="btn btn-primary" Text="Sign In" />
            </div>
            <div class="text-center mt-3">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ForgetPass.aspx" CssClass="btn btn-link">Forget Password?</asp:HyperLink>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.0.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>

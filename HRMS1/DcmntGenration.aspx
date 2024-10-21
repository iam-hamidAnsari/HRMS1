<%@ Page Title="" Language="C#" MasterPageFile="~/Hr.Master" AutoEventWireup="true" CodeBehind="DcmntGenration.aspx.cs" Inherits="HRMS1.DcmntGenration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
<style>
    body {
        background-color: moccasin;
    }

    .form-container {
        max-width: 600px;
        margin: 50px auto;
        padding: 30px;
        background-color: #ffffff;
        border-radius: 8px;
        box-shadow: 0 0 10px black;
    }

    h2 {
        color: #0d6efd;
        text-align: center;
        margin-bottom: 20px;
    }

    .btn-custom {
        background-color: #28a745;
        color: white;
    }

    .btn-custom:hover {
        background-color: #218838;
    }
</style>

<div class="form-container">
    <h2>Document Generation</h2>

    <table class="table table-borderless">
        <tr>
            <td><label for="txtEmail" class="form-label">Email:</label></td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" width="400px" CssClass="form-control" placeholder="Enter your email"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><label for="TxtName" class="form-label">Document Name:</label></td>
            <td>
                <asp:TextBox ID="TxtName" runat="server" width="400px" CssClass="form-control" placeholder="Enter document name"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><label for="FileUpload1" class="form-label">Document Upload:</label></td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" width="400px" CssClass="form-control" />
            </td>
        </tr>
    </table>
    <br />
    <div class="text-center">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="padding:10px; margin-top:15px;" Text="Add" CssClass="btn btn-custom mt-3" Height="47px" Width="105px" />
    </div>
</div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Emp.Master" AutoEventWireup="true" CodeBehind="Resign.aspx.cs" Inherits="HRMS1.Resign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container mt-4">
            <h2>Resignation Form</h2>

            <div class="mb-3">
                <label for="name" class="form-label">Name</label>
                <asp:TextBox ID="TextBoxName" Width="400px" runat="server" CssClass="form-control" />
            </div>
            
            <div class="mb-3">
                <label for="designation" class="form-label">Designation</label>
                <asp:TextBox ID="TextBoxDesignation" Width="400px" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="reason" class="form-label">Reason</label>
                <asp:TextBox ID="TextBoxReason" Width="400px" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="dateOfLeaving" class="form-label">Date Of Leaving</label>
                <asp:TextBox ID="TextBoxDateOfLeaving" Width="200px" runat="server" CssClass="form-control datepicker" TextMode="Date" />
            </div>

        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="ButtonSubmit_Click" />
        </div>

        
        



    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/js/bootstrap.bundle.min.js"></script>              
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js"></script>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketSolution.aspx.cs" Inherits="HRMS1.TicketSolution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Solution Page</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="card container mt-5">
    <div class="card-header">
        <h2>Submit Solution for Ticket ID: <asp:Label ID="lblTicketID" runat="server" CssClass="text-info"></asp:Label></h2>
    </div>
    <div class="card-body">
        <div class="form-group">

            <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control-file" />
        </div>
    
        <asp:Button ID="btnSubmitSolution" runat="server" Text="Submit Solution" OnClick="btnSubmitSolution_Click" CssClass="btn btn-primary" />
    </div>
</div>
    

<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>

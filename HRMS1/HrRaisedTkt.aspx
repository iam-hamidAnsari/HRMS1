<%@ Page Title="" Language="C#" MasterPageFile="~/Hr.Master" AutoEventWireup="true" CodeBehind="HrRaisedTkt.aspx.cs" Inherits="HRMS1.HrRaisedTkt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
    .card {
        /*border: 2px solid #343a40; */
        box-shadow: 0 4px 20px rgba(0, 0, 0, 0.5); 
    }
    </style>

    <div class="d-flex justify-content-center align-items-center min-vh-100 bg-" style="background-color : #ffffe6;">
            <div class="card " style="width: 500px;">
                <div class="card-header bg-primary text-white">
                    <h4 class="text-center">Raise a New Ticket</h4>
                </div>
                <div class="card-body">
                    <!-- Role Dropdown -->
                        <div class="form-group">
                           <label for="ddlRole">Select Role:</label>
                            <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged">
                                <asp:ListItem Value="" Text="Select Role"></asp:ListItem>
                                <asp:ListItem Value="Hr" Text="HR"></asp:ListItem>
                                <asp:ListItem Value="EMP" Text="Employee"></asp:ListItem>
                                <asp:ListItem Value="TRAINER" Text="Trainer"></asp:ListItem>
                            </asp:DropDownList>      
                        </div>
               
                        <br />

                        <!-- Raised To Dropdown (Populated based on role selection) -->
                        <div class="form-group">
                            <label for="ddlRaisedTo">Raised To:</label>
                            <asp:DropDownList ID="ddlRaisedTo" runat="server" CssClass="form-control">
                                <asp:ListItem Value="" Text="Select"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <br />

                        <!-- Ticket Name Input -->
                        <div class="form-group">
                            <label for="txtTicketName">Ticket Name:</label>
                            <asp:TextBox ID="txtTicketName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <br />

                        <!-- File Attachment -->
                        <div class="form-group">
                            <label for="fileUpload">Upload Attachment (Image):</label>
                            <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control-file" />
                        </div>

                        <br />

                        <!-- Raise Ticket Button -->
                        <div class="form-group">
                            <asp:Button ID="btnRaiseTicket" runat="server" Text="Raise Ticket" CssClass="btn btn-success btn-block" OnClick="btnRaiseTicket_Click" />
                        </div>
                </div>
                
            </div>
        </div>
    

    <!-- Include Bootstrap JS for interactive components -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>

</asp:Content>

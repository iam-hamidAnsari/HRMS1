<%@ Page Title="" Language="C#" MasterPageFile="~/Emp.Master" AutoEventWireup="true" CodeBehind="SlarySlip.aspx.cs" Inherits="HRMS1.SlarySlip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Salary Slip</title>
        <script type="text/javascript">
            function openPDF() {
                window.open('Show Salary Slip.aspx', '_blank', 'width=800,height=600');
            }
        </script>
        <!-- Add Font Awesome for icons -->
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
        <style>
            /* Style the PDF icon box */
            .pdf-icon {
                border: 1px solid #ccc;
                border-radius: 10px;
                padding: 20px;
                text-align: center;
                display: inline-block;
            }
            /* Align the buttons and icons */
            .pdf-icon i {
                font-size: 30px;
                color: red;
        
            }
            .pdf-buttons {
                margin-top: 10px;
            }
            .pdf-buttons button {
                margin: 5px;
            }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pdf-icon">
    <!-- PDF Icon -->
    <i class="fas fa-file-pdf" style="opacity:0.1"></i>
    <div class="pdf-buttons">
        <!-- Button to View the PDF (with Eye icon) -->
        <asp:Button ID="btnViewSalarySlip" runat="server" Text="View" CssClass="btn btn-primary"
            OnClientClick="openPDF(); return false;" />
         <i class="fas fa-eye"></i>

        <!-- Button to Download the PDF (with Download icon) -->
        <asp:Button ID="btnDownloadSalarySlip" runat="server" Text="Download" CssClass="btn btn-success"
            OnClick="btnDownloadSalarySlip_Click" />
        <i class="fas fa-download"></i>
    </div>
</div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Emp.Master" AutoEventWireup="true" CodeBehind="EmpShowOfferletter.aspx.cs" Inherits="HRMS1.EmpViewOfferletter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Offer Letter</title>
    <script type="text/javascript">
    function openPDF() {
        window.open('ViewOfferletter.aspx', '_blank', 'width=800,height=600');
    }

    </script>

    
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
    <div>
    <h2>Your Offer Letter</h2>
    

       <%--view button with icons--%>
    <div class="pdf-icon">
        <!-- PDF Icon -->
        <i class="fas fa-file-pdf" style="opacity:0.1"></i>
        <div class="pdf-buttons">
        <!-- Button to View the PDF (with Eye icon) -->
        <asp:Button ID="btnViewOfferLetter" runat="server" Text="View Offer Letter" OnClientClick="openPDF(); return false;" />
         <i class="fas fa-eye"></i>
    </div>
</div>
</div>
</asp:Content>

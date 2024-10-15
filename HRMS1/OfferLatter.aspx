<%@ Page Title="" Language="C#" MasterPageFile="~/Hr.Master" AutoEventWireup="true" CodeBehind="OfferLatter.aspx.cs" Inherits="HRMS1.OfferLatter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
    <h1>Offer Letter Generator</h1>

        <label for="name">Name:</label>
        <asp:TextBox ID="txtName" runat="server" Required="true"></asp:TextBox><br /><br />

        <label for="email">Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" Required="true" TextMode="Email"></asp:TextBox><br /><br />

        <label for="dateOfJoining">Date of Joining:</label>
        <%--<asp:TextBox ID="txtDateOfJoining" runat="server" Required="true"></asp:TextBox>--%>
        <%--<asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateOfJoining" Format="yyyy-MM-dd"></asp:CalendarExtender><br /><br />--%>
        <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
            <br>
             <br>

        <label for="designation">Designation:</label>
        <asp:TextBox ID="txtDesignation" runat="server" Required="true"></asp:TextBox><br /><br />

        <asp:Button ID="btnGenerate" runat="server" Text="Generate Offer Letter" OnClick="btnGenerate_Click" />
    </div>

</asp:Content>

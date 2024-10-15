<%@ Page Title="" Language="C#" MasterPageFile="~/Hr.Master" AutoEventWireup="true" CodeBehind="GenrateSlip.aspx.cs" Inherits="HRMS1.GenrateSlip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h1>Salary Slip Generator</h1>
    <label for="email">Email:</label>
    <asp:TextBox ID="txtEmail" runat="server" required="required"></asp:TextBox><br /><br />

    <label for="month">Select Month:</label>
    <asp:DropDownList ID="ddlMonth" runat="server" required="required">
        <asp:ListItem Value="">Select Month</asp:ListItem>
        <asp:ListItem Value="January">January</asp:ListItem>
        <asp:ListItem Value="February">February</asp:ListItem>
        <asp:ListItem Value="March">March</asp:ListItem>
        <asp:ListItem Value="April">April</asp:ListItem>
        <asp:ListItem Value="May">May</asp:ListItem>
        <asp:ListItem Value="June">June</asp:ListItem>
        <asp:ListItem Value="July">July</asp:ListItem>
        <asp:ListItem Value="August">August</asp:ListItem>
        <asp:ListItem Value="September">September</asp:ListItem>
        <asp:ListItem Value="October">October</asp:ListItem>
        <asp:ListItem Value="November">November</asp:ListItem>
        <asp:ListItem Value="December">December</asp:ListItem>
    </asp:DropDownList><br /><br />

    <label for="absentDays">Absent Days:</label>
    <asp:TextBox ID="txtAbsentDays" runat="server" type="number" min="0" required="required"></asp:TextBox><br /><br />

    <asp:Button ID="btnGenerate" runat="server" Text="Generate Slip" OnClick="btnGenerate_Click" />
</div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Hr.Master" AutoEventWireup="true" CodeBehind="HRReg.aspx.cs" Inherits="HRMS1.HRReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <H2>&nbsp;Add Employee Datails</H2>
    Name :
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <BR />
    <BR />
    Email :
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <BR />
    <BR />
    Password :
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <BR />
            <BR />
            Contact No :
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <BR />
            <BR />
            Address :
            <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox>
    <BR />
    <BR />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Employee" />
</div>
    </div>
</asp:Content>

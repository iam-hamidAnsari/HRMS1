<%@ Page Title="" Language="C#" MasterPageFile="~/Emp.Master" AutoEventWireup="true" CodeBehind="EmpHome.aspx.cs" Inherits="HRMS1.EmpHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
   
    <H2>Leave Application</H2>    
    &nbsp;&nbsp; 
   
        <div id ="leavedata">
        Leave Type : <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
            <asp:ListItem>PL</asp:ListItem>
            <asp:ListItem>CL</asp:ListItem>
            <asp:ListItem>SL</asp:ListItem>
        </asp:DropDownList>
        <BR />
        <BR />
        From :
            <asp:TextBox ID="Calendar1" runat="server" TextMode="Date"></asp:TextBox>
        <BR />
            <BR />
        To:
          <asp:TextBox ID="Calendar2" runat="server" TextMode="Date"></asp:TextBox>

        <BR />
            <BR />
        Reason :&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <BR />
        <BR />
        <asp:Button ID="Button2" runat="server" Text="Apply" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
    </div>
    
</asp:Content>

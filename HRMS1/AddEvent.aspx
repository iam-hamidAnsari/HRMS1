<%@ Page Title="" Language="C#" MasterPageFile="~/Hr.Master" AutoEventWireup="true" CodeBehind="AddEvent.aspx.cs" Inherits="HRMS1.AddEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 429px">
        <H2>Add Events</H2>
        <br />

     Date :&nbsp;
     <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
     <br />
     <br />
     Event Name : <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
     <br />
     <br />
     Event Type :&nbsp;
     <asp:DropDownList ID="DropDownList1" runat="server">
         <asp:ListItem>Holiday</asp:ListItem>
         <asp:ListItem>Birthday</asp:ListItem>
     </asp:DropDownList>
     <br />
     <br />
     <asp:Button ID="Button1" runat="server" Text="Add Event" OnClick="Button1_Click" />
     <br />
     <br />
     <asp:Calendar ID="Calendar2" runat="server" OnDayRender="Calendar2_DayRender"></asp:Calendar>
     <br />
     <br />
 </div>
</asp:Content>

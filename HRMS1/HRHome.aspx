<%@ Page Title="" Language="C#" MasterPageFile="~/Hr.Master" AutoEventWireup="true" CodeBehind="HRHome.aspx.cs" Inherits="HRMS1.HRHome" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;&nbsp; 
    <div>
        Here is All Employee details:


        <BR />
        <BR />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                <asp:BoundField DataField="from_date" HeaderText="from_date" SortExpression="from_date" />
                <asp:BoundField DataField="to_date" HeaderText="to_date" SortExpression="to_date" />
                <asp:BoundField DataField="rqstd_leave" HeaderText="rqstd_leave" SortExpression="rqstd_leave" />
                <asp:BoundField DataField="pl" HeaderText="pl" SortExpression="pl" />
                <asp:BoundField DataField="sl" HeaderText="sl" SortExpression="sl" />
                <asp:BoundField DataField="cl" HeaderText="cl" SortExpression="cl" />
                <asp:BoundField DataField="reason" HeaderText="reason" SortExpression="reason" />
                <asp:BoundField DataField="leave_type" HeaderText="leave_type" SortExpression="leave_type" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:data_implConnectionString2 %>" SelectCommand="SELECT [id],[username], [from_date], [to_date], [rqstd_leave], [pl], [sl], [cl], [reason], [leave_type] FROM [users] WHERE ([urole] = 'EMP')"></asp:SqlDataSource>


    </div>
</asp:Content>


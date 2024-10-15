<%@ Page Title="" Language="C#" MasterPageFile="~/Hr.Master" AutoEventWireup="true" CodeBehind="HRHome.aspx.cs" Inherits="HRMS1.HRHome" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;&nbsp; 
    <div>
        Here is All Employee details:


        <BR />
        <BR />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand" Height="283px" Width="797px">
            <Columns>
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="From_date" HeaderText="From_date" SortExpression="From_date" />
                <asp:BoundField DataField="To_date" HeaderText="To_date" SortExpression="To_date" />
                <asp:BoundField DataField="no_of_rqstd_leave" HeaderText="no_of_rqstd_leave" SortExpression="no_of_rqstd_leave" />
                <asp:BoundField DataField="leave_reason" HeaderText="leave_reason" SortExpression="leave_reason" />
                <asp:BoundField DataField="leave_typ" HeaderText="leave_typ" SortExpression="leave_typ" />
                <asp:BoundField DataField="pl" HeaderText="Remaining PL" SortExpression="pl" />
                <asp:BoundField DataField="cl" HeaderText="Remaining CL" SortExpression="cl" />
                <asp:BoundField DataField="sl" HeaderText="Remainig SL" SortExpression="sl" />
                <asp:BoundField DataField="leave_status" HeaderText="leave_status" SortExpression="leave_status" />
                <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="btnApprove" runat="server" Text="Approve" 
                    CommandName="approve" CommandArgument='<%# Container.DataItemIndex %>' />
                <asp:Button ID="btnReject" runat="server" Text="Reject" 
                    CommandName="reject" CommandArgument='<%# Container.DataItemIndex %>' />
            </ItemTemplate>
        </asp:TemplateField>            
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:data_implConnectionString3 %>" SelectCommand="SELECT [email], [From_date], [To_date], [no_of_rqstd_leave], [leave_reason], [leave_status], [leave_typ], [sl], [cl], [pl] FROM [leave] WHERE leave_status='pending'"></asp:SqlDataSource>


        <BR />
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <BR />


    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Hr.Master" AutoEventWireup="true" CodeBehind="HrTktHist.aspx.cs" Inherits="HRMS1.HrTktHist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />


    <div class="container mt-5">
    <div class="col-md-12">
        <h2>Closed Ticket History</h2>
        <div class="form-group">
             <asp:DropDownList ID="ddlTimeRange" runat="server">
                 <asp:ListItem Text="Select Time Range" Value="" />
                 <asp:ListItem Text="Today" Value="today" />
                 <asp:ListItem Text="This Week" Value="week" />
                 <asp:ListItem Text="This Month" Value="month" />
                 <asp:ListItem Text="This Year" Value="year" />
             </asp:DropDownList>
        </div>
        <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" CssClass="btn btn-primary" />
        <br />
        <asp:GridView ID="gvTickets" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
            PageSize="5" 
            OnPageIndexChanging="gvTickets_PageIndexChanging" 
            CssClass="table table-striped table-hover mt-4 shadow border border-dark" >
            <Columns>
                <asp:BoundField DataField="tid" HeaderText="Ticket ID" />
                <asp:BoundField DataField="email" HeaderText="Raised By" />
                <asp:BoundField DataField="raise_to" HeaderText="Raised To" />
                <asp:BoundField DataField="tkt_dtls" HeaderText="Ticket" />
                <asp:BoundField DataField="crnt_date" HeaderText="Ticket Date" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="t_img" HeaderText="Attachment" />
                <asp:BoundField DataField="t_status" HeaderText="Status" />
            </Columns>
        </asp:GridView>
    </div>
</div>

 <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>

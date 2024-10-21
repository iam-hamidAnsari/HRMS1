<%@ Page Title="" Language="C#" MasterPageFile="~/Trainer.Master" AutoEventWireup="true" CodeBehind="TrMyTkt.aspx.cs" Inherits="HRMS1.TrMyTkt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
<style>
    .container {
        /*border: 2px solid #343a40; */
        box-shadow: 0 4px 20px rgba(0, 0, 0, 0.5); /* Enhanced shadow */
    }
</style>

    <div class="container mt-5">
    <div class="col-md-12">
        <h2>My Tickets</h2>
        <div class="form-group">
            <asp:DropDownList ID="ddlTicketFilter" runat="server" CssClass="form-select mb-3" AutoPostBack="True" OnSelectedIndexChanged="ddlTicketFilter_SelectedIndexChanged">
                <asp:ListItem Value="RaisedByMe" Text="Raised by Me"></asp:ListItem>
                <asp:ListItem Value="RaisedForMe" Text="Raised for Me"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <%--<asp:DropDownList ID="ddlTickets" runat="server">
            <asp:ListItem>Select</asp:ListItem>
            <asp:ListItem>Raised By Me</asp:ListItem>
            <asp:ListItem>Raised For Me</asp:ListItem>
        </asp:DropDownList>--%>
        <p>&nbsp;</p>

        <div class="table-responsive">
            <asp:GridView ID="gvTickets" runat="server" AutoGenerateColumns="False" OnRowCommand="gvTickets_RowCommand"
                CssClass="table table-striped table-hover mt-4 shadow border border-dark" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvTickets_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="tid" HeaderText="ID" />
                    <asp:BoundField DataField="email" HeaderText="Raised From" />
                    <asp:BoundField DataField="raise_to" HeaderText="Raised To" />
                    <asp:BoundField DataField="tkt_dtls" HeaderText="Ticket" />
                     <asp:TemplateField HeaderText="Attachment">
                     <ItemTemplate>
                         <asp:HyperLink ID="lnkView" runat="server" NavigateUrl='<%# Eval("t_img") %>' 
                             Target="_blank" CssClass="me-2 text-primary">
                             <i class="fas fa-eye"></i> View
                         </asp:HyperLink>
                     </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="crnt_date" HeaderText="Created Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="t_status" HeaderText="Status" />
<%--                    <asp:BoundField DataField="t_soln" HeaderText="Solution" />--%>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnClose" runat="server" CommandName="CloseTicket" 
                                        CommandArgument='<%# Container.DataItemIndex %>' Text="Close" CssClass="btn btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
     </div>
    <div class="col-md-12">&nbsp;</div>
</div>


<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>

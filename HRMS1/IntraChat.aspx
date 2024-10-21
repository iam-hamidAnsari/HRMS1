<%@ Page Title="" Language="C#" MasterPageFile="~/Emp.Master" AutoEventWireup="true" CodeBehind="IntraChat.aspx.cs" Inherits="HRMS1.IntraChat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
    <h2 class="text-center my-4">Welcome To Intra Chat</h2>
        <div class="form-group">
            <label for="DropDownList1">To:</label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control w-25" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:DataList ID="DataList1" runat="server" CssClass="list-group w-25">
                <ItemTemplate>
                    <div class="list-group-item">
                        <%# Eval("message") %>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="form-group">
            <label for="TextBox2">Message:</label>
            <div class="d-flex">
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" CssClass="form-control me-2 w-25"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send" CssClass="btn btn-primary align-self-end" />
            </div>
        </div>
    </div>

    <link href="Content/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="Content/js/bootstrap.bundle.min.js"></script>
</asp:Content>

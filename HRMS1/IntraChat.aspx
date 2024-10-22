<%@ Page Title="" Language="C#" MasterPageFile="~/Emp.Master" AutoEventWireup="true" CodeBehind="IntraChat.aspx.cs" Inherits="HRMS1.IntraChat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .chat-container {
    background-color: #f9f9f9;
    padding: 10px;
    border-radius: 10px;
    max-height: 400px;
    overflow-y: auto;
            height: 277px;
            width: 509px;
        }

.chat-list {
    list-style-type: none;
    padding: 0;
}

.chat-message {
    display: inline-block;
    margin-bottom: 15px;
    max-width: 70%;
    padding: 10px;
    border-radius: 10px;
    word-wrap: break-word;
    clear: both;
}

.chat-message.left {
    float: left; /* Align to the left */
    background-color: #e2e2e2;
    border-top-left-radius: 0;
}

.chat-message.right {
    float: right; /* Align to the right */
    background-color: #007bff; /* Blue background for sender */
    color: white;
    border-top-right-radius: 0;
}

.message-content {
    margin-bottom: 5px;
}

.message-time {
    font-size: 12px;
    color: #888;
    display: block;
    text-align: right;
}

.clearfix::after {
    content: "";
    display: table;
    clear: both;
}

 .btn-primary {
            background-color: #007bff;
            border: none;
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
            margin-left: 10px; /* Space between the button and the textbox */
        }

        .btn-primary:hover {
            background-color: #0056b3;
        }

        .form-group {
            display: flex;
            align-items: center;
            margin-bottom: 10px;
        }

    </style>

  <div class="container mt-5">
    <h2 class="mb-4">Intra Chat</h2>

    <div class="form-group row">
        <label for="DropDownList1" class="col-sm-2 col-form-label">Select User:</label>
        <div class="col-sm-4">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="40px" Width="300px">
            </asp:DropDownList>
        </div>
    </div>

    <div class="chat-container">
    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Vertical" CssClass="chat-list">
        <ItemTemplate>
            <div class='<%# Eval("from_email").ToString() == Session["name"].ToString() ? "chat-message right clearfix" : "chat-message left clearfix" %>'>
                <div class="message-content">
                   <%-- <strong><%# Eval("from_email") %>:</strong>--%>
                    <span><%# Eval("message") %></span>
                </div>
                <%--<small class="message-time"><%# Eval("time_sent") %></small>--%>
            </div>
        </ItemTemplate>
    </asp:DataList>
</div>


   <div class="form-group mt-4">
    
    <span class="input-group-append">
        <label for="TextBox2" class="col-sm-2 col-form-label">Message:</label>
  
</span>
       
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Width="300px" ></asp:TextBox>
            <span class="input-group-append">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send" CssClass="btn btn-primary" />
            </span>
        </div>
</div>






    <link href="Content/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="Content/js/bootstrap.bundle.min.js"></script>
</asp:Content>

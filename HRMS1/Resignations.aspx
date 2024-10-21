<%@ Page Title="" Language="C#" MasterPageFile="~/Hr.Master" AutoEventWireup="true" CodeBehind="Resignations.aspx.cs" Inherits="HRMS1.Resignations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            color: #333;
        }

        .container {
            width: 80%;
            margin: 0 auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
            color: #4CAF50;
        }

        .form-group {
    display: flex;
    align-items: center; 
    justify-content: flex-start; 
    margin-bottom: 12px;
        }

        label {
    font-weight: bold;
    margin-right: 5px; 
    white-space: nowrap; 
}

input[type="date"] {
    width: 150px; /* Define a fixed width for the date input */
    padding: 8px;
    margin-right: 20px; /* Space between input boxes */
    border: 1px solid #ccc;
    border-radius: 5px;
    font-size: 14px;
}


       .btn-search {
                 background-color: #4CAF50;
                color: white;
                padding: 10px 20px;
                border: none;
                border-radius: 5px;
                cursor: pointer;
                font-size: 16px;
}

         .btn-search:hover {
            background-color: #45a049;
           margin-left: 10px; 
           }


        .grid-container {
            margin-top: 20px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th, td {
            padding: 12px;
            text-align: left;
        }

        th {
            background-color: #4CAF50;
            color: white;
        }

        .btn-approve {
            background-color: #28a745;
            color: white;
            padding: 5px 10px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

        .btn-approve:hover {
            background-color: #218838;
        }

        .btn-reject {
            background-color: #dc3545;
            color: white;
            padding: 5px 10px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

        .btn-reject:hover {
            background-color: #c82333;
        }

        @media (max-width: 768px) {
            .form-group {
                flex-direction: column;
            }

            label, input[type="text"] {
                width: 100%;
            }

            table, th, td {
                font-size: 12px;
            }
        }
    </style>


    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="container">
            <h2>Resignation Requests</h2>
            <div class="form-group">
                <label for="txtFromDate">From:</label>
                <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtToDate">To:</label>
                <asp:TextBox ID="txtToDate" runat="server" TextMode="Date"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" />
            </div>

            <div class="grid-container">
                <asp:GridView ID="gvResignation" runat="server" AutoGenerateColumns="False" OnRowCommand="gvResignation_RowCommand" DataKeyNames="email">
                    <Columns>
                        <asp:BoundField DataField="email" HeaderText="Email" />
                        <asp:BoundField DataField="desig" HeaderText="Designation" />
                        <asp:BoundField DataField="reason" HeaderText="Reason" />
                        <asp:BoundField DataField="date" HeaderText="Resignation Date" />
                        <asp:BoundField DataField="status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Resignation Letter">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkView" runat="server" NavigateUrl='<%# Eval("resig_letter") %>' 
                                    Target="_blank" CssClass="me-2 text-primary">
                                    <i class="fas fa-eye"></i> View
                                </asp:HyperLink>
                                &nbsp;&nbsp;
                                 <asp:HyperLink ID="lnkDownload" runat="server" NavigateUrl='<%# Eval("resig_letter") %>' 
                                     Download='<%# Eval("resig_letter") %>' CssClass="ms-2 text-success">
                                     <i class="fas fa-download"></i> Download
                                 </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button ID="btnApprove" runat="server" Text="Approve" CommandName="Approve" CommandArgument='<%# Eval("email") %>' 
                                            CssClass="btn-approve" Enabled='<%# Eval("status").ToString() == "Pending" %>' />
                                <asp:Button ID="btnReject" runat="server" Text="Reject" CommandName="Reject" CommandArgument='<%# Eval("email") %>' 
                                            CssClass="btn-reject" Enabled='<%# Eval("status").ToString() == "Pending" %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>


</asp:Content>

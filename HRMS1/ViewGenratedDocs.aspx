<%@ Page Title="" Language="C#" MasterPageFile="~/Emp.Master" AutoEventWireup="true" CodeBehind="ViewGenratedDocs.aspx.cs" Inherits="HRMS1.ViewGenratedDocs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet" />
    <style>
         body {
             background-color: papayawhip;
         }

         .container {
             max-width: 800px;
             margin: 50px auto;
             padding: 30px;
             background-color: #ffffff;
             border-radius: 8px;
             box-shadow: 0 0 10px black;
         }

         h2 {
             color: mediumorchid;
             text-align: center;
             margin-bottom: 20px;
         }

         .gridview-header {
             background-color: #3E4E5E;
             color: white;
         }
     </style>
    <div class="container">
     <h2>Uploaded Documents</h2>
     <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-hover" 
         AutoGenerateColumns="false" HeaderStyle-CssClass="gridview-header">
         <Columns>
          
             <asp:BoundField DataField="id" HeaderText="ID" />

           
             <asp:BoundField DataField="doc_name" HeaderText="Document Name" />

           
             <asp:TemplateField HeaderText="Action">
                 <ItemTemplate>
                 
                     <asp:HyperLink ID="lnkView" runat="server" NavigateUrl='<%# Eval("doc") %>' 
                         Target="_blank" CssClass="me-2 text-primary">
                         <i class="fas fa-eye"></i> View
                     </asp:HyperLink>

                 
                     <span>|</span>

                    
                     <asp:HyperLink ID="lnkDownload" runat="server" NavigateUrl='<%# Eval("doc") %>' 
                         Download='<%# Eval("doc_name") %>' CssClass="ms-2 text-success">
                         <i class="fas fa-download"></i> Download
                     </asp:HyperLink>
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
     </asp:GridView>
 </div>


</asp:Content>

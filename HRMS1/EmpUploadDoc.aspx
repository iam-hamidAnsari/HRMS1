<%@ Page Title="" Language="C#" MasterPageFile="~/Emp.Master" AutoEventWireup="true" CodeBehind="EmpUploadDoc.aspx.cs" Inherits="HRMS1.EmpUploadDoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <H2>Upload Documents</H2>

            Select Your Document :<BR />
&nbsp;<asp:DropDownList runat="server" id="ddlDocuments" AutoPostBack="True">
                <asp:ListItem>Addhar Card</asp:ListItem>
                <asp:ListItem>Pan card</asp:ListItem>
                <asp:ListItem>Ssc markshet</asp:ListItem>
                <asp:ListItem>Hsc marksheet</asp:ListItem>
                <asp:ListItem>Graduation Certificate</asp:ListItem>
            </asp:DropDownList>

            <BR />
            <BR />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <BR />
            <BR />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
            <br /><br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>

        <div>
            <h3>Uploaded Documents:</h3>
                <asp:Panel ID="pnlDocuments" runat="server"></asp:Panel>
        </div>


    </div>
</asp:Content>

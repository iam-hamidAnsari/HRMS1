<%@ Page Title="" Language="C#" MasterPageFile="~/Emp.Master" AutoEventWireup="true" CodeBehind="Tasks.aspx.cs" Inherits="HRMS1.Tasks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container mt-5">
    <h2 class="mb-4">Tasks</h2>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label runat="server" ID="tid" Text='<%# Eval("t_id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("crnt_date") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Task Name">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("task_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="View Task">
                <ItemTemplate>
                    <asp:Button runat="server" CommandName="ViewTask" CommandArgument='<%# Eval("task_attach") %>' Text="Download Task" CssClass="btn btn-info btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Upload Solution">
                <ItemTemplate>
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" Text="Submit" ID="Submitbtn" CommandName="UploadSoln" CommandArgument='<%# Eval("t_id") %>' CssClass="btn btn-success btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="table-dark" />
        <FooterStyle CssClass="bg-light" />
        <PagerStyle CssClass="bg-light" />
        <AlternatingRowStyle CssClass="table-secondary" />
    </asp:GridView>

    <br />
</div>
</asp:Content>

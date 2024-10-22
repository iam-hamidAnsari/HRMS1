<%@ Page Title="" Language="C#" MasterPageFile="~/Trainer.Master" AutoEventWireup="true" CodeBehind="TaskStatus.aspx.cs" Inherits="HRMS1.TaskStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container mt-5">
    <h2 class="mb-4">Task Status</h2>
    
    <div class="form-group row">
        <label for="DropDownList1" class="col-sm-2 col-form-label">Search:</label>
        <div class="col-sm-4">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                <asp:ListItem>completed</asp:ListItem>
                <asp:ListItem>not completd</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" CssClass="btn btn-primary" />
        </div>
    </div>

    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CssClass="table table-striped table-bordered">
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
                <asp:TemplateField HeaderText="Assign To">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("assign_email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Task Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("task_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Solutions">
                    <ItemTemplate>
                         <asp:HyperLink ID="lnkDownload" runat="server" NavigateUrl='<%# Eval("soln_task") %>' 
                             Download='<%# Eval("soln_task") %>' CssClass="ms-2 text-success">
                             <i class="fas fa-download"></i> Download
                         </asp:HyperLink> 
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="score" TextMode="Number" CssClass="form-control" Visible='<%# Eval("score") == DBNull.Value %>'></asp:TextBox>
                        <asp:Label ID="lblscore" runat="server" Text='<%# Eval("score") %>' CssClass="ml-2" Visible='<%# Eval("Score") != DBNull.Value %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Add Score" ID="addscore" CssClass="btn btn-success btn-sm" Visible='<%# Eval("score") == DBNull.Value %>' CommandName="UpdateScore" CommandArgument='<%# Eval("t_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>

     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
 <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet" />
</asp:Content>

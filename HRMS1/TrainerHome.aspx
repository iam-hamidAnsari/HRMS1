<%@ Page Title="" Language="C#" MasterPageFile="~/Trainer.Master" AutoEventWireup="true" CodeBehind="TrainerHome.aspx.cs" Inherits="HRMS1.TrainerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div>
        <H2>Top Proformers</H2>

        From Date :
        <asp:TextBox ID="TextBox1" runat="server" Height="16px" TextMode="Date" Width="161px"></asp:TextBox>
&nbsp; To Date:&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Height="16px" TextMode="Date" Width="190px"></asp:TextBox>
        &nbsp;
        <asp:Button ID="Button2" CssClass="btn btn-secondary"  runat="server" Height="28px" Text="Search" Width="83px" OnClick="Button2_Click" />
        <BR />
        <BR />
        <asp:DataList ID="DataList1" runat="server" Height="203px" RepeatColumns="3" RepeatDirection="Horizontal" Width="348px">
            <ItemTemplate>
               <div class="card" style="width: 18rem;">
                <h5 class="card-title" style="text-align: center;"><%#Eval("name") %></h5>
                <asp:Image runat="server" CssClass="circular-image" ImageUrl='<%# Eval("profile_img") %>' 
                    style="width: 100px; height: 100px; border-radius: 50%; object-fit: cover; display: block; margin: 0 auto;" />
                <div class="card-body" style="text-align: center;">
                    <h5 class="card-title"><%#Eval("total_score") %></h5>
                </div>
               </div>
            </ItemTemplate>
        </asp:DataList>
        <BR />

    </div>

 <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
 <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">


</asp:Content>

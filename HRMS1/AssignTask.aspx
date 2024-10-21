<%@ Page Title="" Language="C#" MasterPageFile="~/Trainer.Master" AutoEventWireup="true" CodeBehind="AssignTask.aspx.cs" Inherits="HRMS1.AssignTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <head>
        <!-- Other head elements -->
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.0.7/dist/umd/popper.min.js"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
        <style>
        ContentPlaceHolder1 {
            background-color: #f8f9fa;
        }

        h2 {
            color: #343a40;
        }

        .card {
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        </style>
    </head>
   
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    &nbsp;&nbsp; 
    <div class="container mt-5">
        <h2 class="text-center mb-4">Assign Task</h2>
        <div class="card">
            <div class="card-body">
           
                    <div class="form-group">
                        <label for="TextBox1">Task Name</label>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="FileUpload1">Task Resource</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
                    </div>

                    <div class="form-group">
                        <label>Assign To</label><br />
                        <asp:CheckBox ID="CheckBoxSelectAll" runat="server" Text="Select All" OnClick="selectAll(this)" CssClass="mr-2" />
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" ClientIDMode="Static" CssClass="list-unstyled"></asp:CheckBoxList>
                    </div>

                    <asp:Button ID="Button1" runat="server" Text="Assign" CssClass="btn btn-primary" OnClick="Button1_Click"  />
      
            </div>
        </div>
    </div>

    <script type="text/javascript">
        // JavaScript function to handle Select All functionality
        function selectAll(selectAllCheckbox) {
            // Get the CheckBoxList
            var checkBoxList = document.getElementById('CheckBoxList1');

            // Loop through each checkbox in the CheckBoxList
            var checkboxes = checkBoxList.getElementsByTagName('input');
            for (var i = 0; i < checkboxes.length; i++) {
                var checkbox = checkboxes[i];
                // Set the checkbox to the same state as the Select All checkbox
                checkbox.checked = selectAllCheckbox.checked;
            }
        }
    </script>
</asp:Content>

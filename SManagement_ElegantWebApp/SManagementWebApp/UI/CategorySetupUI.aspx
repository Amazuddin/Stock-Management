<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="CategorySetupUI.aspx.cs" Inherits="SManagementWebApp.UI.CategorySetupUI"%>
<%@ Import Namespace="System.ComponentModel" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Category Setup Page</title>
    <link rel="stylesheet" href="StyleCss/categorySetupStyleSheet.css"/>

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Datatables/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script src="../Scripts/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/jquery.dataTables.min.js"></script>
    <script src="../Scripts/dataTables.bootstrap4.min.js"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <script>
        setTimeout(function() {
            $("#warningLabel").hide().empty();
        }, 5000);

        //$(document).ready(function () {
        //    $(".categoryGridView").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        //});

        
</script>
</head>
<body class="kbody">

<nav class="navbar navbar-expand-sm bg-dark navbar-dark navdesign">

    <!-- Links -->
    <ul class="navbar-nav">
        <li class="nav-item active">
            <a class="nav-link" href="CategorySetupUI.aspx">Category</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="CompanySetupUI.aspx">Company</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="ItemSetupUI.aspx">Item</a>
        </li>
         <li class="nav-item">
            <a class="nav-link" href="StockInUI.aspx">StockIn</a>
        </li>
         <li class="nav-item">
            <a class="nav-link" href="StockOutUI.aspx">StockOut</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="ViewItemUI.aspx">ViewItem</a>
        </li>
         <li class="nav-item">
            <a class="nav-link" href="ViewSalesUI.aspx">ViewSales</a>
        </li>
    </ul>
</nav>

<div class="container">
    <center>
        <h1 class="jumbotron jumbotron-fluid header">Category Setup</h1>

        <form id="form1" runat="server">
            
             <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-2 ctlabel">
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                </div>
                <div class="col-md-4 fld">
                      <asp:TextBox ID="categoryTextBox" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        <br/>
        <br/>
            <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click"/><br/><br/>

            <asp:Label ID="warningLabel" runat="server" Text=""></asp:Label>
            <br/><br/>
            <div>

                <asp:GridView ID="categoryGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                  
                    <Columns >
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <div style="text-align: center;">Serial No.</div>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <%#Container.DataItemIndex + 1 %>

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px"/>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Category Name">
                            <ItemTemplate>
                               

                                <asp:Label ID="CLabel" runat="server" Text='<%#Eval("Category_Name") %>'></asp:Label>

                               <asp:TextBox ID="updateTextBox" class="updateTextBox" runat="server" Text='<%#Eval("Category_Name") %>'></asp:TextBox>
                                

                                
                                <asp:HiddenField ID="idHiddenField" runat="server" value='<%#Eval("Category_Id") %>'></asp:HiddenField>
                            
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="400px"/>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle/>
                            <HeaderTemplate>
                                <div style="text-align: center;">Action</div>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <%--<asp:Button ID="updateButton" class="update" runat="server" Text="Update" OnClick="updateButton_Click1" CausesValidation="False" ValidateRequestMode="Disabled"></asp:Button>--%>
                               
                                 <asp:LinkButton ID="updateLinkButton" CssClass="button" runat="server" onclick="updateLinkButton_OnClick">Update</asp:LinkButton>
                                
                                <asp:LinkButton ID="confirmUpdateLinkButton" CssClass="confirmBtn" class="confirmUpdateLinkButton" runat="server" onclick="confirmUpdateLinkButton_OnClick">Confirm</asp:LinkButton>

                                
                                
                                     </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px"/>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57"/>
                    <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True"/>
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"/>
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center"/>
                    <RowStyle BackColor="#E3EAEB"/>
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"/>
                    <SortedAscendingCellStyle BackColor="#F8FAFA"/>
                    <SortedAscendingHeaderStyle BackColor="#246B61"/>
                    <SortedDescendingCellStyle BackColor="#D4DFE1"/>
                    <SortedDescendingHeaderStyle BackColor="#15524A"/>
                </asp:GridView>

            </div>

        </form>
    </center>
</div>
<footer id="footer-design">
    <div class="footer-top">
        <div class="container">
            <div class="row">
                <div class="col-md-6 footer-contact">
                    <h3 class="fh">Follow Us</h3>
                    <div class="footer-social-icons ft">
                        <ul>
                            <li>
                                <a href="#" target="blank">
                                    <i class="fa fa-facebook"></i>
                                </a>
                            </li>
                            <li>
                                <a href="#" target="blank">
                                    <i class="fa fa-twitter"></i>
                                </a>
                            </li>
                            <li>
                                <a href="#" target="blank">
                                    <i class="fa fa-google-plus"></i>
                                </a>
                            </li>
                            <li>
                                <a href="#" target="blank">
                                    <i class="fa fa-youtube"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class=" col-md-4 footer-newsletter">
                    <h3 class="fh">
                        Designed & Developed By
                    </h3>
                    <div class="ft">
                        <p>
                            MD Amaz Uddin , Refat khan Pathan
                        </p>
                        <p>
                            Md.Ehsanul Islam Khan , Shushmita Dey
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</footer>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanySetupUI.aspx.cs" Inherits="SManagementWebApp.UI.CompanySetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Company Setup Page</title>
    <link href="StyleCss/companySetupStyleSheet.css" rel="stylesheet"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- Latest compiled and minified CSS -->
        <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>

    <script>
        setTimeout(function() {
            $("#warningLabel").hide().empty();
        }, 5000);
    </script>
</head>
<body class="Bbody">

<nav class="navbar navbar-expand-sm bg-dark navbar-dark navdesign">

    <!-- Links -->
    <ul class="navbar-nav">
        <li class="nav-item">
            <a class="nav-link" href="CategorySetupUI.aspx">Category</a>
        </li>
        <li class="nav-item active">
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
        <h1 class="jumbotron jumbotron-fluid">Company Setup</h1>
        <form id="form1" runat="server">
            
             <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-2 ctlabel">
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                </div>
                <div class="col-md-4 fld">
                      <asp:TextBox ID="nameTextBox" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        <br/>
        <br/>
            <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click"/><br/><br/>
            <asp:Label ID="warningLabel" runat="server"></asp:Label>
            <br/><br/>
            <div>
                <asp:GridView ID="companyNameGridView" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False" ForeColor="#333333">
                    <AlternatingRowStyle BackColor="White"/>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <div style="text-align: center;">Serial No.</div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Company Name">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Company_Name") %>'></asp:Label>
                            </ItemTemplate>
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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSetupUI.aspx.cs" Inherits="SManagement_Elegan_ItemSetuptWebApp.UI.ItemSetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Item Setup Page</title>
    <link href="StyleCss/ItemSetupStyleSheet.css" rel="stylesheet"/>
        <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <script>
        setTimeout(function() {
            $("#messageLabel").hide().empty();
        }, 5000);

    </script>

</head>
<body class="CBody">
<nav class="navbar navbar-expand-sm bg-dark navbar-dark navdesign">

    <!-- Links -->
    <ul class="navbar-nav">
        <li class="nav-item ">
            <a class="nav-link" href="CategorySetupUI.aspx">Category</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="CompanySetupUI.aspx">Company</a>
        </li>
        <li class="nav-item active">
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
        <h1 class="jumbotron jumbotron-fluid">Item Setup</h1>
        <form id="form1" runat="server">
            <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
            <br/><br/>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-2 ctlabel">
                    <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
                </div>
                <div class="col-md-4 fld">
                    <asp:DropDownList ID="categoryDropDownList" CssClass="form-control" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Selected="True" Value="-1">Select Category</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <br/>
            <br/>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-2 ctlabel">
                    <asp:Label ID="Label2" runat="server" Text="Company"></asp:Label>
                </div>
                <div class="col-md-4 fld">
                    <asp:DropDownList ID="companyDropDownList" CssClass="form-control" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Selected="True" Value="-1">Select Company</asp:ListItem>
                    </asp:DropDownList>
                    
                </div>
            </div>
            <br/>
            <br/>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-2 ctlabel">
                    <asp:Label ID="Label3" runat="server" Text="Item Name"></asp:Label>

                </div>
                <div class="col-md-4 fld">
                    <asp:TextBox ID="nameTextBox" CssClass="form-control" runat="server"></asp:TextBox>

                </div>
            </div>
            <br/>
            <br/>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-2 ctlabel">
                    <asp:Label ID="Label4" runat="server" Text="Reorder Level"></asp:Label>
                </div>
                <div class="col-md-4 fld">
                    <asp:TextBox ID="reorderTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

            </div>
            <br/>
            <br/>
            <asp:Button ID="saveButton" runat="server" OnClick="SaveButton_Click" Text="Save"/>
            <br/>
            <br/>

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
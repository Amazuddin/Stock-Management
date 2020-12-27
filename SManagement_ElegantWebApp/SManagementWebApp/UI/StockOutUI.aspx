<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="SManagementWebApp.UI.StockOutUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Out Page</title>
        <link href="StyleCss/stockOutStyleSheet.css" rel="stylesheet"/>
        <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
     <script>
         setTimeout(function () {
             $("#messageLabel").hide().empty();
         }, 5000);

    </script>
</head>
<body class="Dbody">
<nav class="navbar navbar-expand-sm bg-dark navbar-dark navdesign">

    <!-- Links -->
    <ul class="navbar-nav">
        <li class="nav-item">
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
         <li class="nav-item active">
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
        <h1 class="jumbotron jumbotron-fluid">Stock Out</h1>
    <form id="form1" runat="server">
    <asp:Label ID="messageLabel" runat="server"></asp:Label>
        <br />
        <br />
         <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-2 ctlabel">
                     <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
                </div>
                <div class="col-md-4 fld">
                      <asp:DropDownList ID="companyDropDownList" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="-1">Select Company</asp:ListItem>
        </asp:DropDownList>
                </div>
            </div>
        <br/>
        <br/>
        <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-2 ctlabel">
                     <asp:Label ID="Label2" runat="server" Text="Item"></asp:Label>
                </div>
                <div class="col-md-4 fld">
                     <asp:DropDownList ID="itemDropDownList" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="-1">Select Item</asp:ListItem>
        </asp:DropDownList>
                </div>
            </div>
        <br/>
        <br/>
         <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-2 ctlabel">
                     <asp:Label ID="Label3" runat="server" Text="Reorder Label"></asp:Label>
                </div>
                <div class="col-md-4 fld">
                    <asp:TextBox  CssClass="textBox" ID="reorderLevelTextBox" runat="server"></asp:TextBox>
                </div>
            </div>
        <br/>
        <br/>
         <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-2 ctlabel">
                     <asp:Label ID="Label4" runat="server" Text="Available Quantity"></asp:Label>
                </div>
                <div class="col-md-4 fld">
                     <asp:TextBox  CssClass="textBox" ID="availableQuantityTextBox" runat="server"></asp:TextBox>
                </div>
            </div>
        <br/>
        <br/>
        <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-2 ctlabel">
                    <asp:Label ID="Label5" runat="server" Text="Stock Out Quantity"></asp:Label>
                </div>
                <div class="col-md-4 fld">
                    <asp:TextBox  CssClass="form-control" ID="stockOutQuantityTextBox" runat="server"></asp:TextBox>
                </div>
            </div>
        <br/>
        <br/>
        <asp:Button ID="addButton" runat="server" Text="Add"   OnClick="addButton_Click" />
        <br />
        <br/>
        
        <asp:GridView ID="cartGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
             <AlternatingRowStyle BackColor="White" />
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

                    <asp:TemplateField HeaderText="Item">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Item_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Company">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Company_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                 <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("StockOutQuantity") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
             <EditRowStyle BackColor="#7C6F57" />
             <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
             <RowStyle BackColor="#E3EAEB" />
             <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#F8FAFA" />
             <SortedAscendingHeaderStyle BackColor="#246B61" />
             <SortedDescendingCellStyle BackColor="#D4DFE1" />
             <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <br />
        <asp:Button ID="sellButton" runat="server" Text="Sell" OnClick="sellButton_Click" />
        <asp:Button ID="damageButton" runat="server" Text="Damage" OnClick="damageButton_Click" />
        <asp:Button ID="lostButton" runat="server" Text="Lost" OnClick="lostButton_Click" />
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

<%@ Page AutoEventWireup="true" CodeBehind="ViewSalesUI.aspx.cs" Inherits="SManagementWebApp.UI.ViewSalesUI" Language="C#" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Sale Page</title>
    
    <link href="StyleCss/viewSaleStyleSheet.css" rel="stylesheet"/>

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <script src="../Scripts/bootstrap-datepicker.min.js"></script>
    <link href="../Content/bootstrap-datepicker.min.css" rel="stylesheet" />
    
    
    
    
    <script>
        $(document).ready(function () {
            $("#fromDateTextBox").datepicker({
                format: 'yyyy-mm-dd',
                weekStart: 6,
                autoclose: true,
                
                todayHighlight: true,
               
            }).on('changeDate', function (selected) {
                var minDate = new Date(selected.date.valueOf());
                $('#toDateTextBox').datepicker('setStartDate', minDate);
                $("#toDateTextBox").val($("#fromDateTextBox").val());
                $(this).datepicker('hide');
            });
            

            $("#toDateTextBox").datepicker({
                format: 'yyyy-mm-dd',
                weekStart: 6,
                autoclose: true,
                todayHighlight: true,
                
            }).on('changeDate', function (selected) {
                $(this).datepicker('hide');
            });
        });
       

       setTimeout(function() {
           $("#messageLabel").hide(1000).empty();
       }, 5000);

       
    </script>

</head>
<body class="gbody">
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
         <li class="nav-item">
            <a class="nav-link" href="StockOutUI.aspx">StockOut</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="ViewItemUI.aspx">ViewItem</a>
        </li>
         <li class="nav-item active">
            <a class="nav-link" href="ViewSalesUI.aspx">ViewSales</a>
        </li>
    </ul>
</nav>
    
   
        <div class="container">
             <center>
            <div class="mainBody">
                <h1 class="jumbotron jumbotron-fluid">View Sales Between Two Dates</h1>
                <form id="form1" runat="server">
                    <asp:Label ID="messageLabel" CssClass="mLabel" runat="server" Text=""></asp:Label>
                    <br/><br/>
                       <div class="row">
                <div class="col-md-4">
                    

                           </div>
                <div class="col-md-2 ctlabel">
                     <asp:Label ID="Label1"  runat="server" Text="From Date"></asp:Label>
                </div>
                <div class="col-md-4 fld">
                    <asp:TextBox ID="fromDateTextBox" cssClass="form-control" runat="server" Type="text"></asp:TextBox>
                </div>
            </div>
        <br/>
        <br/>
                      <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-2 ctlabel">
                      <asp:Label ID="Label3" runat="server" Text="To Date"></asp:Label>
                </div>
                <div class="col-md-4 fld">
                     <asp:TextBox ID="toDateTextBox" cssClass="form-control" runat="server" Type="text"></asp:TextBox>
                </div>
            </div>
        <br/>
        <br/>
                      <asp:Button ID="searchButton" runat="server" Text="Search"  OnClick="searchButton_OnClick" />
                      <br/>
                         <br />
        
                      <asp:GridView ID="viewSalesGridView" runat="server" CellPadding="4" GridLines="None" Width="630px" AutoGenerateColumns="False" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Serial No.">
                                <ItemTemplate>
                                     <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                            </asp:TemplateField>
                        
                             <asp:BoundField DataField="Item_Name" HeaderText="Item" />
              <asp:BoundField DataField="Company_Name" HeaderText="Company" />
              <asp:BoundField DataField="StockOut_Quantity" HeaderText="Sale Quantity" />

                           
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
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
                    <asp:Button ID="pdfButton" runat="server" OnClick="pdfButton_Click" Text="Convert to PDF" />
                   
                </form>
            </div>
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

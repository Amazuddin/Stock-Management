<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewItemUI.aspx.cs" Inherits="SManagementWebApp.UI.ViewItemUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>View Item Page</title>
    <link href="StyleCss/viewItemStyleSheet.css" rel="stylesheet"/>
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
        <li class="nav-item ">
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
         <li class="nav-item active ">
            <a class="nav-link" href="ViewItemUI.aspx">ViewItem</a>
        </li>
         <li class="nav-item ">
            <a class="nav-link" href="ViewSalesUI.aspx">ViewSales</a>
        </li>
    </ul>
</nav>
   
        
    <div class="container">
        <center>
        <h1 class="jumbotron jumbotron-fluid">View Item</h1>
             <form id="form1" runat="server">
                 
                  <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-2 ctlabel">
                    <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
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
                     <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label>
                </div>
                <div class="col-md-4 fld">
                     <asp:DropDownList ID="categoryDropDownList" CssClass="form-control" runat="server" AppendDataBoundItems="True">
         <asp:ListItem Selected="True" Value="-1">Select Category</asp:ListItem>
        </asp:DropDownList>
                </div>
            </div>
        <br/>
        <br/>
      
        <asp:Button ID="searchButton" runat="server" Text="Search"  OnClick="searchButton_Click" />
        <br />
        <br/>
        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
        <br/>
        <asp:GridView ID="viewItemGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
          <Columns>
                <asp:TemplateField>
                            <HeaderTemplate>
                                <div style="text-align: center;">Serial No.</div>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <%#Container.DataItemIndex + 1 %>

                            </ItemTemplate>
                            <ControlStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px"/>
                        </asp:TemplateField>

              <asp:BoundField DataField="Item_Name" HeaderText="Item" >
                <ControlStyle Width="150px" />
                </asp:BoundField>
              <asp:BoundField DataField="Company_Name" HeaderText="Company" />
              <asp:BoundField DataField="Category_Name" HeaderText="Category" />
              <asp:BoundField DataField="Item_Quantity" HeaderText="Quantity" />
              <asp:BoundField DataField="Item_Reorder_level" HeaderText="Reorder Level" />
                            
                <%--<asp:TemplateField HeaderText="Company">
                 <ItemTemplate>
                  <asp:Label  runat="server" Text='<%#Eval("Company_Name") %>'></asp:Label>
                   </ItemTemplate>
                   </asp:TemplateField>
              <asp:TemplateField HeaderText="Category">
                 <ItemTemplate>
                  <asp:Label  runat="server" Text='<%#Eval("Category_Name") %>'></asp:Label>
                   </ItemTemplate>
                   </asp:TemplateField>

             <asp:TemplateField HeaderText="Quantity">
                 <ItemTemplate>
                  <asp:Label  runat="server" Text='<%#Eval("Item_Quantity") %>'></asp:Label>
                   </ItemTemplate>
                   </asp:TemplateField>

             <asp:TemplateField HeaderText="Reorder Level">
                 <ItemTemplate>
                  <asp:Label  runat="server" Text='<%#Eval("Item_Reorder_level") %>'></asp:Label>
                   </ItemTemplate>
                   </asp:TemplateField>--%>
           </Columns>
        <AlternatingRowStyle BackColor="White" />
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
      
        <asp:Button ID="pdfButton" runat="server" Text="Convert to PDF"  OnClick="pdfButton_OnClick" />

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

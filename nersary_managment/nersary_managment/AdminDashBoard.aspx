<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashBoard.aspx.cs" Inherits="nersary_managment.AdminDashBoard" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="description" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- The above 4 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <!-- Title -->
    <title>GoGreen - Gardening &amp; Landscaping HTML Template</title>

    <!-- Favicon -->
    <link rel="icon" href="img/core-img/favicon.ico">

    <!-- Core Stylesheet -->
    <link rel="stylesheet" href="alazea-gh-pages/style.css">

    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
    </style>

</head>

<body>
    <!-- Preloader -->
    <div class="preloader d-flex align-items-center justify-content-center">
        <div class="preloader-circle"></div>
        <div class="preloader-img">
            <img src="alazea-gh-pages/img/core-img/leaf.png" alt="">
        </div>
    </div>

    <!-- ##### Header Area Start ##### -->
    <header class="header-area">

        <!-- ***** Top Header Area ***** -->
        <div class="top-header-area">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="top-header-content d-flex align-items-center justify-content-between">
                            <!-- Top Header Content -->
                            <div class="top-header-meta">
                                 <a href="#" data-toggle="tooltip" data-placement="bottom" title="Gogreen@gmail.com"><i class="fa fa-envelope-o" aria-hidden="true"></i> <span>Email: gogreen@gmail.com</span></a>
                                <a href="#" data-toggle="tooltip" data-placement="bottom" title="+0231 2420771"><i class="fa fa-phone" aria-hidden="true"></i> <span>Call Us: +0231 2420771</span></a>

                            </div>

                            <!-- Top Header Content -->
                            <div class="top-header-meta d-flex">
                                <!-- Language Dropdown -->
                                <div class="language-dropdown">
                                    <div class="dropdown">
                                        <button class="btn btn-secondary dropdown-toggle mr-30" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Language</button>
                                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                            <a class="dropdown-item" href="#">USA</a>
                                            <a class="dropdown-item" href="#">UK</a>
                                            <a class="dropdown-item" href="#">Bangla</a>
                                            <a class="dropdown-item" href="#">Hindi</a>
                                            <a class="dropdown-item" href="#">Spanish</a>
                                            <a class="dropdown-item" href="#">Latin</a>
                                        </div>
                                    </div>
                                </div>
                                <!-- Login -->
                                <div class="login">
                                    <a href="#"><i class="fa fa-user" aria-hidden="true"></i> <span>Login</span></a>
                                </div>
                                <!-- Cart -->
                                <div class="cart">
                                    <a href="#"><i class="fa fa-shopping-cart" aria-hidden="true"></i> <span>Cart <span class="cart-quantity">(1)</span></span></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- ***** Navbar Area ***** -->
        <div class="alazea-main-menu">
            <div class="classy-nav-container breakpoint-off">
                <div class="container">
                    <!-- Menu -->
                    <nav class="classy-navbar justify-content-between" id="alazeaNav">

                        <!-- Nav Brand -->
                        <a href="index.html" class="nav-brand"><img height="100px" width="200px" src="Search/alazea-gh-pages/img/go-green-png-5-transparent-1.png" alt=""></a>

                        <!-- Navbar Toggler -->
                        <div class="classy-navbar-toggler">
                            <span class="navbarToggler"><span></span><span></span><span></span></span>
                        </div>

                        <!-- Menu -->
                        <div class="classy-menu">

                            <!-- Close Button -->
                            <div class="classycloseIcon">
                                <div class="cross-wrap"><span class="top"></span><span class="bottom"></span></div>
                            </div>

                            <!-- Navbar Start -->
                            <div class="classynav">
                                <ul>
                                    <li><a href="Search/alazea-gh-pages/index.html">Home</a></li>
                                    
                                </ul>

                                <!-- Search Icon -->
                                <div id="searchIcon">
                                    <i class="fa fa-search" aria-hidden="true"></i>
                                </div>

                            </div>
                            <!-- Navbar End -->
                        </div>
                    </nav>

                    <!-- Search Form -->
                    <div class="search-form">
                        <form action="#" method="get">
                            <input type="search" name="search" id="search" placeholder="Type keywords &amp; press enter...">
                            <button type="submit" class="d-none"></button>
                        </form>
                        <!-- Close Icon -->
                        <div class="closeIcon"><i class="fa fa-times" aria-hidden="true"></i></div>
                    </div>
                </div>
            </div>
        </div>
    </header>
    <!-- ##### Header Area End ##### -->

    <!-- ##### Breadcrumb Area Start ##### -->
    <div class="breadcrumb-area">
        <!-- Top Breadcrumb Area -->
        <div class="top-breadcrumb-area bg-img bg-overlay d-flex align-items-center justify-content-center" style="background-image: url(alazea-gh-pages/img/bg-img/24.jpg);">
            <h2>Admin Dashboard</h2>
        </div>

      
    </div>
    <br /><br /><br />
    <!-- ##### Breadcrumb Area End ##### -->

   

    <!-- ##### Contact Area Start ##### -->
    <section class="contact-area">
        <div class="container">
            <div class="row align-items-center justify-content-between">
                <div class="col-12 col-lg-12">
                    <!-- Section Heading -->
                 
                    <!-- Contact Form Area -->
                   
    <form id="form1" runat="server">
        <table class="table">
            <tr>
                <td class="auto-style3">Manage</td>
                <td class="auto-style2">List Report</td>
                <td>Dynamic Report</td>
                <td>Datewise Report</td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Report/Customer_master.aspx">Customer List</asp:HyperLink>
                </td>
                <td>
                  
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Report/DateWisePayment.aspx">DateWise Payment</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Plant_Master.aspx">Plant Master</asp:HyperLink>
                </td>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Report/rpt_Plant_Master.aspx">Pant Master List</asp:HyperLink>
                </td>
                <asp:HyperLink ID="HyperLink15" runat="server">HyperLink</asp:HyperLink>
                <td> <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Report/Plant_Type_wise_Plant_Master.aspx">Plant Type wise Plant Master</asp:HyperLink>
             
                        </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Plant_Type.aspx">Plant type</asp:HyperLink>
                </td>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Report/rpt_Plant_type.aspx">Plant type List</asp:HyperLink>
                </td>
                <td>
                      </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Report/rpt_Payment.aspx">Payment List</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Report/rpt_Order_master.aspx">Order master List</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Report/rpt_Order_details.aspx">Order Detail List</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div>
    
    </div>
    </form>

                    <br /><br /><br />
                    
                </div>

               
            </div>
        </div>
    </section>
    <!-- ##### Contact Area End ##### -->

  
    <!-- ##### All Javascript Files ##### -->
    <!-- jQuery-2.2.4 js -->
    <script src="alazea-gh-pages/js/jquery/jquery-2.2.4.min.js"></script>
    <!-- Popper js -->
    <script src="alazea-gh-pages/js/bootstrap/popper.min.js"></script>
    <!-- Bootstrap js -->
    <script src="alazea-gh-pages/js/bootstrap/bootstrap.min.js"></script>
    <!-- All Plugins js -->
    <script src="alazea-gh-pages/js/plugins/plugins.js"></script>
    <!-- Active js -->
    <script src="alazea-gh-pages/js/active.js"></script>
</body>

</html>


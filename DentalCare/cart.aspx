<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="YourNamespace.cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta content="Free HTML Templates" name="keywords">
    <meta content="Free HTML Templates" name="description">


    <!-- Favicon -->
    <link href="img/favicon.ico" rel="icon">

    <!-- Google Web Fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Jost:wght@500;600;700&family=Open+Sans:wght@400;600&display=swap" rel="stylesheet">

    <!-- Icon Font Stylesheet -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css" rel="stylesheet">

    <!-- Libraries Stylesheet -->
    <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">
    <link href="lib/animate/animate.min.css" rel="stylesheet">
    <link href="lib/tempusdominus/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />
    <link href="lib/twentytwenty/twentytwenty.css" rel="stylesheet" />

    <!-- Customized Bootstrap Stylesheet -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Template Stylesheet -->
    <link href="css/style.css" rel="stylesheet">
    <title>Shopping Cart</title>
    <style>
        /* CSS styles for the cart items */
        .cart-item {
            border: 1px solid #ddd;
            padding: 10px;
            margin-bottom: 20px;
            line-height: 7.5;
            overflow: hidden;
            background-color: #fff; /* Set background color to white */
            border-radius: 8px; /* Add border radius for rounded corners */
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); /* Add box shadow */
        }

        .cart-item h3 {
            margin-top: 0;
            font-size: 18px;
            color: #333;
        }

        .cart-item p {
            margin-bottom: 10px;
            font-size: 14px;
            color: #666;
        }

        .cart-item img {
            float: left;
            margin-right: 15px;
            max-width: 10%;
        }
    </style>
</head>
<body>
    <!-- Topbar Start -->
    <div class="container-fluid bg-light ps-5 pe-0 d-none d-lg-block">
        <div class="row gx-0">
            <div class="col-md-6 text-center text-lg-start mb-2 mb-lg-0">
                <div class="d-inline-flex align-items-center">
                    <small class="py-2"><i class="far fa-clock text-primary me-2"></i>Opening Hours: Mon - Tues : 6.00 am - 10.00 pm, Sunday Closed </small>
                </div>
            </div>
            <div class="col-md-6 text-center text-lg-end">
                <div class="position-relative d-inline-flex align-items-center bg-primary text-white top-shape px-5">
                    <div class="me-3 pe-3 border-end py-2">
                        <p class="m-0"><i class="fa fa-envelope-open me-2"></i>dc@dentalcare.com</p>
                    </div>
                    <div class="py-2">
                        <p class="m-0"><i class="fa fa-phone-alt me-2"></i>+91 92345 67890</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Topbar End -->


 <!-- Navbar Start -->
 <nav class="navbar navbar-expand-lg bg-white navbar-light shadow-sm px-5 py-3 py-lg-0">
     <a href="index.html" class="navbar-brand p-0">
         <h1 class="m-0 text-primary"><i class="fa fa-tooth me-2"></i>DentCare</h1>
     </a>
     <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
         <span class="navbar-toggler-icon"></span>
     </button>
     <div class="collapse navbar-collapse" id="navbarCollapse">
         <div class="navbar-nav ms-auto py-0">
             <a href="index.aspx" class="nav-item nav-link">Home</a>
             <a href="kids.aspx" class="nav-item nav-link">Product</a>
             <a href="cart.aspx" class="nav-item nav-link active">Cart</a>
             <a href="FeedBack.aspx" class="nav-item nav-link">FeedBack</a>
         </div>
         <a href="appointment.aspx" class="btn btn-primary py-2 px-4 ms-3">Appointment</a>
     </div>
 </nav>
 <!-- Navbar End -->



 <!-- Hero End -->
    <form id="form1" runat="server">
        <div>
            <h1>Shopping Cart</h1>
            <asp:Repeater ID="CartRepeater" runat="server">
                <ItemTemplate>
                    <div class="cart-item">
                        <img src='<%# Eval("ImagePath") %>' alt='<%# Eval("Name") %>' />
                        <div>
                            <h3><%# Eval("Name") %></h3>
                            <p><%# Eval("Details") %></p>
                            <p>Rs: &nbsp; <%# Eval("Price") %></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>

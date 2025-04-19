<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="single-product.aspx.cs" Inherits="Lakshmi_Groceries.single_product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Lakshmi Groceries</title>
    <link href="https://fonts.googleapis.com/css?family=Cairo:400,600,700&amp;display=swap" rel="stylesheet"/>
    <link href="https://fonts.googleapis.com/css?family=Poppins:600&amp;display=swap" rel="stylesheet"/>
    <link href="https://fonts.googleapis.com/css?family=Playfair+Display:400i,700i" rel="stylesheet"/>
    <link href="https://fonts.googleapis.com/css?family=Ubuntu&amp;display=swap" rel="stylesheet"/>
    <link rel="shortcut icon" type="image/x-icon" href="assets/images/favicon.png"/>
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="assets/css/animate.min.css"/>
    <link rel="stylesheet" type="text/css" href="assets/css/font-awesome.min.css"/>
    <link rel="stylesheet" type="text/css" href="assets/css/nice-select.css"/>
    <link rel="stylesheet" type="text/css" href="assets/css/slick.min.css"/>
    <link rel="stylesheet" type="text/css" href="assets/css/style.css"/>
    <link rel="stylesheet" type="text/css" href="assets/css/main-color.css"/>
</head>
<body class="biolife-body">
    <form id="form1" runat="server">
            <!--Preloader-->
    <div id="biof-loading">
        <div class="biof-loading-center">
            <div class="biof-loading-center-absolute">
                <div class="dot dot-one"></div>
                <div class="dot dot-two"></div>
                <div class="dot dot-three"></div>
            </div>
        </div>
    </div>
        
    <!-- HEADER -->
    <header id="header" class="header-area style-01 layout-03">
    <div class="header-top bg-main hidden-xs">
        <div class="container">
            <div class="top-bar left">
                <ul class="horizontal-menu">
                    <li><a><i class="fa fa-envelope" aria-hidden="true"></i>lakshmigroceries@company.com</a></li>
                    <li style="padding-inline:2px;"><a>Free Shipping for all Order of ₹5000</a></li>
                </ul>
            </div>
            <div class="top-bar right">
                <ul class="social-list">
                    <li><a href="#"><i class="fa fa-twitter" aria-hidden="true"></i></a></li>
                    <li><a href="#"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>
                    <li><a href="#"><i class="fa fa-pinterest" aria-hidden="true"></i></a></li>
                </ul>
                <ul class="horizontal-menu">
                    <li class="horz-menu-item currency">
                        <asp:DropDownList name="currency" runat="server" OnSelectedIndexChanged="CurrencyList_select" ID="currencyList" AutoPostBack="true">
                            <asp:ListItem value="inr" Selected="True">₹ INR (Rupee)</asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li class="horz-menu-item lang">
                        <asp:DropDownList name="language" runat="server" OnSelectedIndexChanged="LanguageList_select" ID="languageList" AutoPostBack="true">
                            <asp:ListItem value="us" >English (US)</asp:ListItem>
                            <asp:ListItem value="in" Selected="True">English (IN)</asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li>
                        <a class="login-link" style="position:relative;">
                            <i class="biolife-icon icon-login"></i><asp:Button ID="btnLogin" runat="server" Text="Login/Register" style="background:0;border:0;" OnClick="BtnLogin_Click" UseSubmitBehavior="False" />
                            <asp:Button ID="btnLogOut" runat="server" Text="Logout" style="position:absolute;right:-80px;background:0;border:0;" Visible="False" OnClientClick="confirm('Need Logout Confirmation')" OnClick="BtnLogOut_Click" UseSubmitBehavior="False" />
                        </a>
                    </li>  
                </ul>
            </div>
        </div>
    </div>
    <div class="header-middle biolife-sticky-object ">
        <div class="container">
            <div class="row">
                <div class="col-lg-3 col-md-2 col-md-6 col-xs-6">
                    <a href="index-2.aspx" class="brand-logo"><img id="img_logo" runat="server" src="assets/images/Logo_lg.png" alt="biolife logo" width="135" height="34"/></a>
                </div>
                <div class="col-lg-6 col-md-7 hidden-sm hidden-xs">
                    <div class="primary-menu">
                    <ul class="menu biolife-menu clone-main-menu clone-primary-menu" id="primary-menu" data-menuname="main menu">
                        <li class="menu-item"><a href="index-2.aspx">Home</a></li>
                        <li class="menu-item menu-item-has-children has-megamenu">
                            <a class="menu-name" data-title="Shop" >Shop</a>
                            <div class="wrap-megamenu lg-width-900 md-width-750">
                                <div class="mega-content">
                                    <div class="col-lg-3 col-md-3 col-xs-12 md-margin-bottom-0 xs-margin-bottom-25">
                                        <div class="wrap-custom-menu vertical-menu">
                                            <h4 class="menu-title">List 1</h4>
                                            <ul class="menu">
                                                <li><asp:Button runat="server" Text="Fruits" Style="border: 0; background: none; padding: 0;" ID="btnFruits" OnClick="BtnFruits_Click" UseSubmitBehavior="False"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Vegetables" style="border:0;background:none;padding:0;" ID="btnVegetables" OnClick="BtnVegetables_Click" UseSubmitBehavior="False"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Nuts & Dry Fruits" style="border:0;background:none;padding:0;" ID="btnNutsDryFruits" OnClick="BtnNutsDryFruits_Click" UseSubmitBehavior="False"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Grains" style="border:0;background:none;padding:0;" ID="btnGrains" OnClick="BtnGrains_Click" UseSubmitBehavior="False"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Flours" style="border:0;background:none;padding:0;" ID="btnFlours" OnClick="BtnFlourss_Click" UseSubmitBehavior="False"></asp:Button></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-xs-12 md-margin-bottom-0 xs-margin-bottom-25">
                                        <div class="wrap-custom-menu vertical-menu">
                                            <h4 class="menu-title">List 2</h4>
                                            <ul class="menu">
                                                <li><asp:Button runat="server" Text="Milk Products" style="border:0;background:none;padding:0;" ID="btnMilkProducts" OnClick="BtnMilkProducts_Click" UseSubmitBehavior="False"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Fresh Meat" style="border:0;background:none;padding:0;" ID="btnFreshMeat" OnClick="BtnFreshMeat_Click" UseSubmitBehavior="False"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Ocean Foods" style="border:0;background:none;padding:0;" ID="btnOceanFoods" OnClick="BtnOceanFoods_Click" UseSubmitBehavior="False"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Packed Foods" style="border:0;background:none;padding:0;" ID="btnPackedFoods" OnClick="BtnPackedFoods_Click" UseSubmitBehavior="False"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Drinks" style="border:0;background:none;padding:0;" ID="btnDrinks" OnClick="BtnDrinks_Click" UseSubmitBehavior="False"></asp:Button></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-xs-12 md-margin-bottom-0 xs-margin-bottom-25">
                                        <div class="wrap-custom-menu vertical-menu">
                                            <h4 class="menu-title">List 3</h4>
                                            <ul class="menu">
                                                <li><asp:Button runat="server" Text="Fruits" style="border:0;background:none;padding:0;"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Vegetables" style="border:0;background:none;padding:0;"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Nuts & Dry Fruits" style="border:0;background:none;padding:0;"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Grains" style="border:0;background:none;padding:0;"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Flours" style="border:0;background:none;padding:0;"></asp:Button></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-xs-12 md-margin-bottom-0 xs-margin-bottom-25">
                                        <div class="wrap-custom-menu vertical-menu">
                                            <h4 class="menu-title">List 4</h4>
                                            <ul class="menu">
                                                <li><asp:Button runat="server" Text="Milk Products" style="border:0;background:none;padding:0;"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Fresh Meat" style="border:0;background:none;padding:0;"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Ocean Foods" style="border:0;background:none;padding:0;"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Packed Foods" style="border:0;background:none;padding:0;"></asp:Button></li>
                                                <li><asp:Button runat="server" Text="Drinks" style="border:0;background:none;padding:0;"></asp:Button></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="menu-item"><a href="blogs.aspx">Blogs</a></li>
                        <li class="menu-item"><a href="contact.aspx">Contact</a></li>
                    </ul>
                </div>
                </div>
                <div class="col-lg-3 col-md-3 col-md-6 col-xs-6">
                    <div class="biolife-cart-info">
                        <div class="mobile-search">
                            <a href="javascript:void(0)" class="open-searchbox"><i class="biolife-icon icon-search"></i></a>
                            <div class="mobile-search-content">
                                <asp:Panel runat="server" class="form-search" name="mobile-seacrh" method="get">
                                    <a class="btn-close"><span class="biolife-icon icon-close-menu"></span></a>
                                    <asp:TextBox ID="mobSearch" runat="server" class="input-text" placeholder="Search here..."/>
                                    
                                    <asp:DropDownList name="category" runat="server" ID="ListMobSearch">
                                        <asp:ListItem value="All" Selected="True">All Categories</asp:ListItem>
                                        <asp:ListItem value="vegetables">Vegetables</asp:ListItem>
                                        <asp:ListItem value="fresh_berries">Fresh Berries</asp:ListItem>
                                        <asp:ListItem value="ocean_foods">Ocean Foods</asp:ListItem>
                                        <asp:ListItem value="butter_eggs">Butter & Eggs</asp:ListItem>
                                        <asp:ListItem value="fastfood">Fastfood</asp:ListItem>
                                        <asp:ListItem value="fresh_meat">Fresh Meat</asp:ListItem>
                                        <asp:ListItem value="fresh_onion">Fresh Onion</asp:ListItem>
                                        <asp:ListItem value="papaya_crisps">Papaya & Crisps</asp:ListItem>
                                        <asp:ListItem value="oatmeal">Oatmeal</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button runat="server" Text="Go" type="submit" class="btn-submit" ID="btnMobSearch"  OnClick="BtnMobSearch_Click" UseSubmitBehavior="False"></asp:Button>
                                </asp:Panel>
                            </div>
                        </div>
                        <div class="wishlist-block hidden-sm hidden-xs">
                            <a class="link-to">
                                <span class="icon-qty-combine">
                                    <i class="icon-heart-bold biolife-icon"></i>
                                    <!--<span class="qty"></span>-->
                                </span>
                            </a>
                        </div>
                        <div class="minicart-block">
                            <div class="minicart-contain">
                                <asp:LinkButton ID="LinkButton1" class="link-to" runat="server" onclick="BtnTopCart_Click">
                                        <span class="icon-qty-combine">
                                            <i class="icon-cart-mini biolife-icon"></i>
                                            <!--<span class="qty"></span>-->
                                        </span>
                                    <span class="title">My Cart </span>
                                    <span class="sub-total"></span>
                                </asp:LinkButton>
                                
                            </div>
                        </div>
                        <div class="mobile-menu-toggle">
                            <a class="btn-toggle" data-object="open-mobile-menu" href="javascript:void(0)">
                                <span></span>
                                <span></span>
                                <span></span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="header-bottom hidden-sm hidden-xs">
        <div class="container">
            <div class="row">
                <div class="col-lg-3 col-md-4">
                    <div class="vertical-menu vertical-category-block">
                        <div class="block-title">
                            <span class="menu-icon">
                                <span class="line-1"></span>
                                <span class="line-2"></span>
                                <span class="line-3"></span>
                            </span>
                            <span class="menu-title">All departments</span>
                            <span class="angle" data-tgleclass="fa fa-caret-down"><i class="fa fa-caret-up" aria-hidden="true"></i></span>
                        </div>
                        <div class="wrap-menu">
                            <ul class="menu clone-main-menu">
                                <li class="menu-item"><a class="menu-name"><i class="biolife-icon icon-fruits"></i><asp:Button runat="server" Text="Fruit & Nut Gifts" style="border:0;background:none;padding:0;" ID="Button1"></asp:Button></a></li>
                                <li class="menu-item"><a class="menu-name"><i class="biolife-icon icon-broccoli-1"></i><asp:Button runat="server" Text="Vegetables" style="border:0;background:none;padding:0;" ID="Button2"></asp:Button></a></li>
                                <li class="menu-item"><a class="menu-name"><i class="biolife-icon icon-grape"></i><asp:Button runat="server" Text="Fresh Berries" style="border:0;background:none;padding:0;" ID="Button3"></asp:Button></a></li>
                                <li class="menu-item"><a class="menu-name"><i class="biolife-icon icon-fish"></i><asp:Button runat="server" Text="Ocean Foods" style="border:0;background:none;padding:0;" ID="Button4"></asp:Button></a></li>
                                <li class="menu-item"><a class="menu-name"><i class="biolife-icon icon-honey"></i><asp:Button runat="server" Text="Butter & Eggs" style="border:0;background:none;padding:0;" ID="Button5"></asp:Button></a></li>                                
                                <li class="menu-item"><a class="menu-title"><i class="biolife-icon icon-fast-food"></i><asp:Button runat="server" Text="Fastfood" style="border:0;background:none;padding:0;" ID="Button6"></asp:Button></a></li>
                                <li class="menu-item"><a class="menu-title"><i class="biolife-icon icon-beef"></i><asp:Button runat="server" Text="Fresh Meat" style="border:0;background:none;padding:0;" ID="Button7"></asp:Button></a></li>
                                <li class="menu-item"><a class="menu-title"><i class="biolife-icon icon-onions"></i><asp:Button runat="server" Text="Fresh Onion" style="border:0;background:none;padding:0;" ID="Button8"></asp:Button></a></li>
                                <li class="menu-item"><a class="menu-title"><i class="biolife-icon icon-avocado"></i><asp:Button runat="server" Text="Papaya & Crisps" style="border:0;background:none;padding:0;" ID="Button9"></asp:Button></a></li>
                                <li class="menu-item"><a class="menu-title"><i class="biolife-icon icon-contain"></i>Oatmeal<asp:Button runat="server" Text="Oatmeal" style="border:0;background:none;padding:0;" ID="Button11"></asp:Button></a></li>
                                <li class="menu-item"><a class="menu-title"><i class="biolife-icon icon-fresh-juice"></i><asp:Button runat="server" Text="Fresh Bananas & Plantains" style="border:0;background:none;padding:0;" ID="Button10"></asp:Button></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-lg-9 col-md-8 padding-top-2px">
                    <div class="header-search-bar layout-01">
                        <asp:Panel runat="server" action="#" class="form-search" name="desktop-seacrh" method="get">
                            <asp:TextBox ID="webSearch" runat="server" type="text" name="s" class="input-text" value="" placeholder="Search here..."/>
                            <asp:DropDownList runat="server" name="category"  ID="ListWebSearch">
                                <asp:ListItem value="All Categories" Selected="True"></asp:ListItem>
                                <asp:ListItem value="Vegetables"></asp:ListItem>
                                <asp:ListItem value="Fresh Berries"></asp:ListItem>
                                <asp:ListItem value="Ocean Foods"></asp:ListItem>
                                <asp:ListItem value="Butter & Eggs"></asp:ListItem>
                                <asp:ListItem value="Fastfood"></asp:ListItem>
                                <asp:ListItem value="Fresh Meat"></asp:ListItem>
                                <asp:ListItem value="Fresh Onion"></asp:ListItem>
                                <asp:ListItem value="Papaya & Crisps"></asp:ListItem>
                                <asp:ListItem value="Oatmeal"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:ImageButton runat="server" class="btn-submit" ImageUrl="~/assets/images/search-icon.png" ImageAlign="Bottom" ID="BtnWebSearch" Width="80px" Height="38" Style="padding: 2px;" OnClick="BtnWebSearch_Click"></asp:ImageButton>
                        </asp:Panel>
                    </div>
                    <div class="live-info">
                        <p class="telephone"><i class="fa fa-phone" aria-hidden="true"></i><b class="phone-number">+91 8888888888</b></p>
                        <p class="working-time">Mon-Fri: 8:30am-7:30pm; Sat-Sun: 9:30am-4:30pm</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </header>


    <div class="page-contain single-product">

        <div class="container">

            <!-- Main content -->
            <div id="main-content" class="main-content">
                    
                
                <!-- summary info -->
                <div class="sumary-product single-layout">
                    <div class="media">
                        <ul class="biolife-carousel slider-for" data-slick='{"arrows":false,"dots":false,"slidesMargin":30,"slidesToShow":1,"slidesToScroll":1,"fade":true,"asNavFor":".slider-nav"}'>
                            <li><asp:Image ID="Image1" runat="server" alt="" width="500" height="500"/></li>
                            <li><asp:Image ID="Image2" runat="server" alt="" width="500" height="500"/></li>
                            <li><asp:Image ID="Image3" runat="server" alt="" width="500" height="500"/></li>
                            <li><asp:Image ID="Image4" runat="server" alt="" width="500" height="500"/></li>
                            <li><asp:Image ID="Image5" runat="server" alt="" width="500" height="500"/></li>
                        </ul>
                        <ul class="biolife-carousel slider-nav" data-slick='{"arrows":false,"dots":false,"centerMode":false,"focusOnSelect":true,"slidesMargin":10,"slidesToShow":4,"slidesToScroll":1,"asNavFor":".slider-for"}'>
                            <li><asp:Image ID="Image6" runat="server" alt="" width="88" height="88"/></li>
                            <li><asp:Image ID="Image7" runat="server" alt="" width="88" height="88"/></li>
                            <li><asp:Image ID="Image8" runat="server" alt="" width="88" height="88"/></li>
                            <li><asp:Image ID="Image9" runat="server" alt="" width="88" height="88"/></li>
                            <li><asp:Image ID="Image10" runat="server" alt="" width="88" height="88"/></li>
                        </ul>
                    </div>
                    <div class="product-attribute">
                        <h3 id="detailedTitle" runat="server" class="title">XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX</h3>
                        <div class="rating">
                            <p style="position:relative;margin:0;padding:0;"><strong id="proRating" runat="server" style="position:absolute;top:12px;left:85px;">5</strong><i class="star-rating"></i></p>
                            <span class="review-count">(<span id="proRatingCount" runat="server">0</span>)Ratings</span>
                        </div>
                        <span class="sku"></span>
                        <p class="excerpt" id="proDescripton" runat="server">XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX</p>
                        <div class="price">
                            <ins><span class="price-amount" id="proPrize" runat="server"><span class="currencySymbol">₹</span>00.00</span></ins>
                            <del><span class="price-amount" id="proOrgPrize" runat="server"><span class="currencySymbol">₹</span>00.00</span></del>
                        </div>
                        <div class="shipping-info">
                            <p class="shipping-day">3-Day Shipping</p>
                            <p class="for-today">Free Pickup Today</p>
                        </div>
                    </div>
                    <div class="action-form">
                        <div class="buttons external-btn">
                            <asp:Button ID="BtnProBuyProduct" class="btn add-to-cart-btn" runat="server" Text="Add to Cart" style="padding-inline:25%;" OnClick="BtnProBuyProduct_Click" UseSubmitBehavior="False" />
                            <p class="pull-row">
                                <a class="btn wishlist-btn" style="margin-left:-100px;">
                                    <asp:Button ID="BtnProWishlist" runat="server" class="btn wishlist-btn" Text="Wishlist"/>
                                </a>
                            </p>
                        </div>
                        <div class="social-media">
                            <ul class="social-list">
                                <li><a lass="social-link"><i class="fa fa-twitter" aria-hidden="true"></i></a></li>
                                <li><a class="social-link"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>
                                <li><a class="social-link"><i class="fa fa-pinterest" aria-hidden="true"></i></a></li>
                                <li><a class="social-link"><i class="fa fa-share-alt" aria-hidden="true"></i></a></li>
                                <li><a class="social-link"><i class="fa fa-instagram" aria-hidden="true"></i></a></li>
                            </ul>
                        </div>
                        <div class="acepted-payment-methods">
                            <ul class="payment-methods">
                                <li><img src="assets/images/card1.jpg" alt="" width="51" height="36"/></li>
                                <li><img src="assets/images/card2.jpg" alt="" width="51" height="36"/></li>
                                <li><img src="assets/images/card3.jpg" alt="" width="51" height="36"/></li>
                                <li><img src="assets/images/card4.jpg" alt="" width="51" height="36"/></li>
                            </ul>
                        </div>
                    </div>
                </div>

                <!-- Tab info -->
                <div class="product-tabs single-layout biolife-tab-contain">
                    <div class="tab-head">
                        <ul class="tabs">
                            <li class="tab-element active"><a href="#tab_1st" class="tab-link">Products Descriptions</a></li>
                            <li class="tab-element" ><a href="#tab_2nd" class="tab-link">Customer Reviews</a></li>
                        </ul>
                    </div>
                    <div class="tab-content">
                        <div id="tab_1st" class="tab-contain desc-tab active">
                            <p id="proDescripton2" runat="server" class="desc">XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX</p>
                        </div>
                        <div id="tab_2nd" class="tab-contain review-tab">
                            <div class="container">
                                <div class="row">
                                    <div class="col-lg-5 col-md-5 col-sm-6 col-xs-12">
                                        <div class="rating-info">
                                            <p class="index"><strong id="proRating2" runat="server" class="rating">0</strong>out of 5</p>
                                            <div class="rating"><p class="star-rating"><span class="width-80percent"></span></p></div>
                                            <p class="see-all">See all reviews</p>
                                            <ul class="options">
                                                <li>
                                                    <div class="detail-for">
                                                        <span class="option-name">5stars</span>
                                                        <span class="progres">
                                                            <span class="line-100percent"><span class="percent"></span></span>
                                                        </span>
                                                        <span class="number">90</span>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="detail-for">
                                                        <span class="option-name">4stars</span>
                                                        <span class="progres">
                                                            <span class="line-100percent"><span class="percent"></span></span>
                                                        </span>
                                                        <span class="number">30</span>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="detail-for">
                                                        <span class="option-name">3stars</span>
                                                        <span class="progres">
                                                            <span class="line-100percent"><span class="percent"></span></span>
                                                        </span>
                                                        <span class="number">40</span>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="detail-for">
                                                        <span class="option-name">2stars</span>
                                                        <span class="progres">
                                                            <span class="line-100percent"><span class="percent"></span></span>
                                                        </span>
                                                        <span class="number">20</span>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="detail-for">
                                                        <span class="option-name">1star</span>
                                                        <span class="progres">
                                                            <span class="line-100percent"><span class="percent"></span></span>
                                                        </span>
                                                        <span class="number">10</span>
                                                    </div>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-lg-7 col-md-7 col-sm-6 col-xs-12">
                                        <div class="review-form-wrapper">
                                            <span class="title">Submit your review</span>
                                            <asp:Panel ID="Panel1" runat="server" name="frm-review">
                                                <div class="comment-form-rating">
                                                    <label>1. Your rating of this products:</label>
                                                    <p class="stars">
                                                        <span>
                                                            <a class="btn-rating" data-value="star-1"><i class="fa fa-star-o" aria-hidden="true"></i></a>
                                                            <a class="btn-rating" data-value="star-2"><i class="fa fa-star-o" aria-hidden="true"></i></a>
                                                            <a class="btn-rating" data-value="star-3"><i class="fa fa-star-o" aria-hidden="true"></i></a>
                                                            <a class="btn-rating" data-value="star-4"><i class="fa fa-star-o" aria-hidden="true"></i></a>
                                                            <a class="btn-rating" data-value="star-5"><i class="fa fa-star-o" aria-hidden="true"></i></a>
                                                        </span>
                                                    </p>
                                                </div>
                                                <p class="form-row">
                                                    <asp:TextBox ID="ReviewBox" runat="server" cols="30" rows="10" placeholder="Write your review here..." Required="Required"></asp:TextBox>
                                                </p>
                                                <p class="form-row">
                                                    <button type="submit">
                                                    <asp:Button ID="BtnReview" runat="server" Text="Submit review" style="all:unset;" OnClick="BtnReview_Click"/>
                                                    </button>
                                                </p>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- related products -->
                <div class="product-related-box single-layout">
                    <div class="biolife-title-box lg-margin-bottom-26px-im">
                        <span class="biolife-icon icon-organic"></span>
                        <span class="subtitle">All the best item for You</span>
                        <h3 class="main-title">Related Products</h3>
                    </div>
                    <ul class="products-list biolife-carousel nav-center-02 nav-none-on-mobile" data-slick='{"rows":1,"arrows":true,"dots":false,"infinite":true,"speed":400,"slidesMargin":0,"slidesToShow":5, "responsive":[{"breakpoint":1200, "settings":{ "slidesToShow": 3}},{"breakpoint":992, "settings":{ "slidesToShow": 3, "slidesMargin":30}},{"breakpoint":768, "settings":{ "slidesToShow": 2, "slidesMargin":10}}]}' >
                        <li class="product-item">
                            <div class="contain-product layout-02">
                                <div class="product-thumb">
                                    <a class="link-to-product">
                                        <asp:ImageButton ID="ImgBtnTopPro1" runat="server" alt="Vegetables" width="270" height="270" class="product-thumnail"/>
                                    </a>
                                </div>
                                <div class="info">
                                    <b id="prCategoriesTopPro1" class="categories" runat="server">XXXXXXXXXX</b>
                                    <h4 class="product-title"><a id="prNameTopPro1" class="pr-name" runat="server">XXXXXXXXXX</a></h4>
                                    <div class="price ">
                                        <ins><span class="price-amount" id="PrizeTopPro1" runat="server"><span class="currencySymbol">₹</span>00.00</span></ins>
                                        <del><span class="price-amount" id="OrgPrizeTopPro1" runat="server"><span class="currencySymbol">₹</span>00.00</span></del>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="product-item">
                            <div class="contain-product layout-02">
                                <div class="product-thumb">
                                    <a class="link-to-product">
                                        <asp:ImageButton ID="ImgBtnTopPro2" runat="server" alt="Vegetables" width="270" height="270" class="product-thumnail"/>
                                    </a>
                                </div>
                                <div class="info">
                                    <b id="prCategoriesTopPro2" class="categories" runat="server">XXXXXXXXXX</b>
                                    <h4 class="product-title"><a id="prNameTopPro2" class="pr-name" runat="server">XXXXXXXXXX</a></h4>
                                    <div class="price ">
                                        <ins><span class="price-amount" id="PrizeTopPro2" runat="server"><span class="currencySymbol">₹</span>00.00</span></ins>
                                        <del><span class="price-amount" id="OrgPrizeTopPro2" runat="server"><span class="currencySymbol">₹</span>00.00</span></del>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="product-item">
                            <div class="contain-product layout-02">
                                <div class="product-thumb">
                                    <a class="link-to-product">
                                        <asp:ImageButton ID="ImgBtnTopPro3" runat="server" alt="Vegetables" width="270" height="270" class="product-thumnail"/>
                                    </a>
                                </div>
                                <div class="info">
                                    <b id="prCategoriesTopPro3" class="categories" runat="server">XXXXXXXXXX</b>
                                    <h4 class="product-title"><a id="prNameTopPro3" class="pr-name" runat="server">XXXXXXXXXX</a></h4>
                                    <div class="price ">
                                        <ins><span class="price-amount" id="PrizeTopPro3" runat="server"><span class="currencySymbol">₹</span>00.00</span></ins>
                                        <del><span class="price-amount" id="OrgPrizeTopPro3" runat="server"><span class="currencySymbol">₹</span>00.00</span></del>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="product-item">
                            <div class="contain-product layout-02">
                                <div class="product-thumb">
                                    <a class="link-to-product">
                                        <asp:ImageButton ID="ImgBtnTopPro4" runat="server" alt="Vegetables" width="270" height="270" class="product-thumnail"/>
                                    </a>
                                </div>
                                <div class="info">
                                    <b id="prCategoriesTopPro4" class="categories" runat="server">XXXXXXXXXX</b>
                                    <h4 class="product-title"><a id="prNameTopPro4" class="pr-name" runat="server">XXXXXXXXXX</a></h4>
                                    <div class="price ">
                                        <ins><span class="price-amount" id="PrizeTopPro4" runat="server"><span class="currencySymbol">₹</span>00.00</span></ins>
                                        <del><span class="price-amount" id="OrgPrizeTopPro4" runat="server"><span class="currencySymbol">₹</span>00.00</span></del>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="product-item">
                            <div class="contain-product layout-02">
                                <div class="product-thumb">
                                    <a class="link-to-product">
                                        <asp:ImageButton ID="ImgBtnTopPro5" runat="server" alt="Vegetables" width="270" height="270" class="product-thumnail"/>
                                    </a>
                                </div>
                                <div class="info">
                                    <b id="prCategoriesTopPro5" class="categories" runat="server">XXXXXXXXXX</b>
                                    <h4 class="product-title"><a id="prNameTopPro5" class="pr-name" runat="server">XXXXXXXXXX</a></h4>
                                    <div class="price ">
                                        <ins><span class="price-amount" id="PrizeTopPro5" runat="server"><span class="currencySymbol">₹</span>00.00</span></ins>
                                        <del><span class="price-amount" id="OrgPrizeTopPro5" runat="server"><span class="currencySymbol">₹</span>00.00</span></del>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="product-item">
                            <div class="contain-product layout-02">
                                <div class="product-thumb">
                                    <a class="link-to-product">
                                        <asp:ImageButton ID="ImgBtnTopPro6" runat="server" alt="Vegetables" width="270" height="270" class="product-thumnail"/>
                                    </a>
                                </div>
                                <div class="info">
                                    <b id="prCategoriesTopPro6" class="categories" runat="server">XXXXXXXXXX</b>
                                    <h4 class="product-title"><a id="prNameTopPro6" class="pr-name" runat="server">XXXXXXXXXX</a></h4>
                                    <div class="price ">
                                        <ins><span class="price-amount" id="PrizeTopPro6" runat="server"><span class="currencySymbol">₹</span>00.00</span></ins>
                                        <del><span class="price-amount" id="OrgPrizeTopPro6" runat="server"><span class="currencySymbol">₹</span>00.00</span></del>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="product-item">
                            <div class="contain-product layout-02">
                                <div class="product-thumb">
                                    <a class="link-to-product">
                                        <asp:ImageButton ID="ImgBtnTopPro7" runat="server" alt="Vegetables" width="270" height="270" class="product-thumnail"/>
                                    </a>
                                </div>
                                <div class="info">
                                    <b id="prCategoriesTopPro7" class="categories" runat="server">XXXXXXXXXX</b>
                                    <h4 class="product-title"><a id="prNameTopPro7" class="pr-name" runat="server">XXXXXXXXXX</a></h4>
                                    <div class="price ">
                                        <ins><span class="price-amount" id="PrizeTopPro7" runat="server"><span class="currencySymbol">₹</span>00.00</span></ins>
                                        <del><span class="price-amount" id="OrgPrizeTopPro7" runat="server"><span class="currencySymbol">₹</span>00.00</span></del>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="product-item">
                            <div class="contain-product layout-02">
                                <div class="product-thumb">
                                    <a class="link-to-product">
                                        <asp:ImageButton ID="ImgBtnTopPro8" runat="server" alt="Vegetables" width="270" height="270" class="product-thumnail"/>
                                    </a>
                                </div>
                                <div class="info">
                                    <b id="prCategoriesTopPro8" class="categories" runat="server">XXXXXXXXXX</b>
                                    <h4 class="product-title"><a id="prNameTopPro8" class="pr-name" runat="server">XXXXXXXXXX</a></h4>
                                    <div class="price ">
                                        <ins><span class="price-amount" id="PrizeTopPro8" runat="server"><span class="currencySymbol">₹</span>00.00</span></ins>
                                        <del><span class="price-amount" id="OrgPrizeTopPro8" runat="server"><span class="currencySymbol">₹</span>00.00</span></del>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="product-item">
                            <div class="contain-product layout-02">
                                <div class="product-thumb">
                                    <a class="link-to-product">
                                        <asp:ImageButton ID="ImgBtnTopPro9" runat="server" alt="Vegetables" width="270" height="270" class="product-thumnail"/>
                                    </a>
                                </div>
                                <div class="info">
                                    <b id="prCategoriesTopPro9" class="categories" runat="server">XXXXXXXXXX</b>
                                    <h4 class="product-title"><a id="prNameTopPro9" class="pr-name" runat="server">XXXXXXXXXX</a></h4>
                                    <div class="price ">
                                        <ins><span class="price-amount" id="PrizeTopPro9" runat="server"><span class="currencySymbol">₹</span>00.00</span></ins>
                                        <del><span class="price-amount" id="OrgPrizeTopPro9" runat="server"><span class="currencySymbol">₹</span>00.00</span></del>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="product-item">
                            <div class="contain-product layout-02">
                                <div class="product-thumb">
                                    <a class="link-to-product">
                                        <asp:ImageButton ID="ImgBtnTopPro10" runat="server" alt="Vegetables" width="270" height="270" class="product-thumnail"/>
                                    </a>
                                </div>
                                <div class="info">
                                    <b id="prCategoriesTopPro10" class="categories" runat="server">XXXXXXXXXX</b>
                                    <h4 class="product-title"><a id="prNameTopPro10" class="pr-name" runat="server">XXXXXXXXXX</a></h4>
                                    <div class="price ">
                                        <ins><span class="price-amount" id="PrizeTopPro10" runat="server"><span class="currencySymbol">₹</span>00.00</span></ins>
                                        <del><span class="price-amount" id="OrgPrizeTopPro10" runat="server"><span class="currencySymbol">₹</span>00.00</span></del>
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
                
            </div>
        </div>

    </div>

    <!-- FOOTER -->
    <footer id="footer" class="footer layout-03">
        <div class="footer-content background-footer-03">
            <div class="container">
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-9">
                        <section class="footer-item">
                            <a href="index-2.aspx" class="logo footer-logo"><img src="assets/images/Logo_lg.png" alt="brand logo" width="135" height="34"/></a>
                            <div class="footer-phone-info">
                                <i class="biolife-icon icon-head-phone"></i>
                                <p class="r-info">
                                    <span>Got Questions ?</span>
                                    <span>+91 8888888888</span>
                                </p>
                            </div>
                            <div class="newsletter-block layout-01">
                                <h4 class="title">Newsletter Signup</h4>
                                <div class="form-content">
                                    <asp:Panel runat="server" name="new-letter-foter" DefaultButton="btnNewsletterSignup">
                                        <asp:TextBox ID="btnNewsletterEmail" runat="server" type="email" class="input-text email" value="" placeholder="Your email here..."></asp:TextBox>
                                        <asp:Button ID="btnNewsletterSignup" class="bnt-submit" runat="server" Text="Sign up" OnClick="BtnNewsletterSignup_Click" UseSubmitBehavior="False" />
                                    </asp:Panel>
                                </div>
                            </div>
                        </section>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-6 md-margin-top-5px sm-margin-top-50px xs-margin-top-40px">
                        <section class="footer-item">
                            <h3 class="section-title">Useful Links</h3>
                            <div class="row">
                                <div class="col-lg-6 col-sm-6 col-xs-6">
                                    <div class="wrap-custom-menu vertical-menu-2">
                                        <ul class="menu">
                                            <li><a>About Us</a></li>
                                            <li><a>About Our Shop</a></li>
                                            <li><a>Secure Shopping</a></li>
                                            <li><a>Delivery infomation</a></li>
                                            <li><a>Privacy Policy</a></li>
                                            <li><a>Our Sitemap</a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-sm-6 col-xs-6">
                                    <div class="wrap-custom-menu vertical-menu-2">
                                        <ul class="menu">
                                            <li><a>Who We Are</a></li>
                                            <li><a>Our Services</a></li>
                                            <li><a>Projects</a></li>
                                            <li><a>Contacts Us</a></li>
                                            <li><a>Innovation</a></li>
                                            <li><a>Testimonials</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-6 md-margin-top-5px sm-margin-top-50px xs-margin-top-40px">
                        <section class="footer-item">
                            <h3 class="section-title">Transport Offices</h3>
                            <div class="contact-info-block footer-layout xs-padding-top-10px">
                                <ul class="contact-lines">
                                    <li>
                                        <p class="info-item">
                                            <i class="biolife-icon icon-location"></i>
                                            <b class="desc">ZZZZZZZZZZZZZZ</b>
                                        </p>
                                    </li>
                                    <li>
                                        <p class="info-item">
                                            <i class="biolife-icon icon-phone"></i>
                                            <b class="desc">+91 8888888888</b>
                                        </p>
                                    </li>
                                    <li>
                                        <p class="info-item">
                                            <i class="biolife-icon icon-letter"></i>
                                            <b class="desc">Email: laksmigroceries@company.com</b>
                                        </p>
                                    </li>
                                    <li>
                                        <p class="info-item">
                                            <i class="biolife-icon icon-clock"></i>
                                            <b class="desc">Hours: 7 Days a week from 10:00 am</b>
                                        </p>
                                    </li>
                                </ul>
                            </div>
                            <div class="biolife-social inline">
                                <ul class="socials">
                                    <li><a title="twitter" class="socail-btn"><i class="fa fa-twitter" aria-hidden="true"></i></a></li>
                                    <li><a title="facebook" class="socail-btn"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>
                                    <li><a title="pinterest" class="socail-btn"><i class="fa fa-pinterest" aria-hidden="true"></i></a></li>
                                    <li><a title="youtube" class="socail-btn"><i class="fa fa-youtube" aria-hidden="true"></i></a></li>
                                    <li><a title="instagram" class="socail-btn"><i class="fa fa-instagram" aria-hidden="true"></i></a></li>
                                </ul>
                            </div>
                        </section>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="separator sm-margin-top-70px xs-margin-top-40px"></div>
                    </div>
                    <div class="col-lg-6 col-sm-6 col-xs-12">
                        <div class="copy-right-text"><p><a>©2024 <span style="font-weight: 800;">Cloud Service for all</span></a></p></div>
                    </div>
                    <div class="col-lg-6 col-sm-6 col-xs-12">
                        <div class="payment-methods">
                            <ul>
                                <li><a class="payment-link"><img src="assets/images/card1.jpg" width="51" height="36" alt=""//></a></li>
                                <li><a class="payment-link"><img src="assets/images/card2.jpg" width="51" height="36" alt=""//></a></li>
                                <li><a class="payment-link"><img src="assets/images/card3.jpg" width="51" height="36" alt=""//></a></li>
                                <li><a class="payment-link"><img src="assets/images/card4.jpg" width="51" height="36" alt=""//></a></li>
                                <li><a class="payment-link"><img src="assets/images/card5.jpg" width="51" height="36" alt=""//></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </footer>

    <!--Footer For Mobile-->
    <div class="mobile-footer">
        <div class="mobile-footer-inner">
            <div class="mobile-block block-menu-main">
                <a class="menu-bar menu-toggle btn-toggle" data-object="open-mobile-menu" href="javascript:void(0)">
                    <span class="fa fa-bars"></span>
                    <span class="text">Menu</span>
                </a>
            </div>
            <div class="mobile-block block-sidebar">
                <a class="menu-bar filter-toggle btn-toggle" data-object="open-mobile-filter" href="javascript:void(0)">
                    <i class="fa fa-sliders" aria-hidden="true"></i>
                    <span class="text">Sidebar</span>
                </a>
            </div>
            <div class="mobile-block block-minicart">
                <a class="link-to-cart">
                    <span class="fa fa-shopping-bag" aria-hidden="true"></span>
                    <span class="text"><asp:Button ID="btnCart2" runat="server" Text="Cart" BorderStyle="None" OnClick="BtnCart_Click" UseSubmitBehavior="False" /></span>
                </a>
            </div>
            <div class="mobile-block block-global">
                <a class="menu-bar myaccount-toggle btn-toggle" data-object="global-panel-opened" href="javascript:void(0)">
                    <span class="fa fa-globe"></span>
                    <span class="text">Global</span>
                </a>
            </div>
        </div>
    </div>
    <script src="assets/js/jquery-3.4.1.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery.countdown.min.js"></script>
    <script src="assets/js/jquery.nice-select.min.js"></script>
    <script src="assets/js/jquery.nicescroll.min.js"></script>
    <script src="assets/js/slick.min.js"></script>
    <script src="assets/js/biolife.framework.js"></script>
    <script src="assets/js/functions.js"></script>
    </form>
</body>
</html>

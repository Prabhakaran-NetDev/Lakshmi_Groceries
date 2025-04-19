<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="blog-post.aspx.cs" Inherits="Lakshmi_Groceries.blog_post" %>

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
    <div class="hero-section hero-background style-02">
        <h1 class="page-title">Organic Fruits</h1>
        <nav class="biolife-nav">
            <ul>
                <li class="nav-item"><a href="index-2.html" class="permal-link">Home</a></li>
                <li class="nav-item"><span class="current-page">Our Blog</span></li>
            </ul>
        </nav>
    </div>

    <!-- Page Contain -->
    <div class="page-contain blog-page left-sidebar">
        <div class="container">
            <div class="row">

                <!-- Main content -->
                <div id="main-content" class="main-content col-lg-9 col-md-8 col-sm-12 col-xs-12">

                    <!--Single Post Contain-->
                    <div class="single-post-contain">

                        <div class="post-head">
                            <div class="thumbnail">
                                <figure><img src="assets/images/blogpost/post_thumbnail.jpg" width="870" height="635" alt=""/></figure>
                            </div>
                            <h2 class="post-name">Ashwagandha: The #1 Herb in the World for Anxiety?</h2>
                            <p class="post-archive"><b class="post-cat">ORGANIC</b><span class="post-date"> / 20 Nov, 2018</span><span class="author">Posted By: Braum J.Teran</span></p>
                        </div>

                        <div class="post-content">
                            <p>The best Organic Food blogs from thousands of top Organic food blogs in our index using search and social metrics. We’ve carefully selected these websites because they are actively working to educate, inspire, and empower their readers with frequent updates and high-quality information.</p>
                            <p>Donec vitae hendrerit arcu, sit amet faucibus nisl. Cras pretium arcu ex. Aenean posuere libero eu augue condimentum roncus. Praesent ornare tortor ac ante egestas hendrerit. Aliquam et metus pharetra, bibendum massa nec, fermentum odio. Nunc id leo ultrices, mollis ligula in, finibus tortor. Mauris eu dui ut lectus fermentum eleifend. Pellentesque faucibus sem ante, non malesuada odio varius nec. Suspendisse potenti.</p>
                            <p>Suspendisse turpis ipsum, tempus in nulla eu, posuere pharetra nibh. In dignissim vitae lorem non mollis. Praesent pretium tellus in tortor viverra condimentum. Nullam dignissim facilisis nisl, accumsan placerat justo ultricies vel. Vivamus finibus mi a neque pretium, ut convallis dui lacinia. Morbi a rutrum velit. Curabitur sagittis quam quis consectetur mattis. Aenean sit amet quam vel turpis interdum sagittis et eget neque. Nunc ante quam, luctus et neque a, interdum iaculis metus. Aliquam vel ante mattis, placerat orci id, vehicula quam. Suspendisse quis eros cursus, viverra urna sed, commodo mauris. Cras diam arcu, fringilla a sem condimentum, viverra facilisis nunc. Curabitur vitae orci id nulla maximus maximus. Nunc pulvinar sollicitudin molestie. </p>
                            <blockquote>
                                <p>Maecenas vel nulla eleifend, euismod magna sed, tristique velit. Nam sed eleifend dui, eu eleifend leo. Mauris ornare eros quis placerat mollis. Duis ornare euismod risus at dictum. Proin at porttitor metus. Nunc luctus nisl suscipit, hendrerit ligula non, mattis dolor.</p>
                                <address>
                                    <a href="#" class="author">Naveen</a>
                                    <span>Creative Copywriter</span>
                                </address>
                            </blockquote>
                        </div>

                        <div class="post-foot">

                            <div class="post-tags">
                                <span class="tag-title">Tags:</span>
                                <ul class="tags">
                                    <li><a href="#" class="tag-link">Juice Drink</a></li>
                                    <li><a href="#" class="tag-link">Fast Food</a></li>
                                    <li><a href="#" class="tag-link">Fresh Food</a></li>
                                    <li><a href="#" class="tag-link">Hot</a></li>
                                    <li><a href="#" class="tag-link">Backpack</a></li>
                                    <li><a href="#" class="tag-link">Grooming</a></li>
                                </ul>
                            </div>

                            <div class="auth-info">
                                <div class="ath">
                                    <a href="#" class="avata"><img src="assets/images/blogpost/viewer-avt.png" width="29" height="28" alt="Christian Doe"/>Karthick</a>
                                    <span class="count-item viewer"><i class="fa fa-eye" aria-hidden="true"></i>630</span>
                                    <span class="count-item commented"><i class="fa fa-commenting" aria-hidden="true"></i>26</span>
                                </div>
                                <div class="socials-connection">
                                    <span class="title">Share:</span>
                                    <ul class="social-list">
                                        <li><a href="#" class="socail-link"><i class="fa fa-twitter" aria-hidden="true"></i></a></li>
                                        <li><a href="#" class="socail-link"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>
                                        <li><a href="#" class="socail-link"><i class="fa fa-pinterest" aria-hidden="true"></i></a></li>
                                        <li><a href="#" class="socail-link"><i class="fa fa-youtube" aria-hidden="true"></i></a></li>
                                        <li><a href="#" class="socail-link"><i class="fa fa-instagram" aria-hidden="true"></i></a></li>
                                    </ul>
                                </div>
                            </div>

                        </div>

                    </div>

                    <!--Comment Block-->
                    <div class="post-comments">
                        <h3 class="cmt-title">Comments<sup>(26)</sup></h3>

                        <div class="comment-form">
                            <div action="#" method="post" name="frm-post-comment">
                                <p class="form-row">
                                    <textarea name="txt-comment" id="txt-comment-ath-3364" cols="30" rows="10" placeholder="Write your comment"></textarea>
                                    <a href="#" class="current-author"><img src="assets/images/blogpost/viewer-avt.png" width="41" height="41" alt=""/></a>
                                </p>
                                <p class="form-row last-btns">
                                    <button type="submit" class="btn btn-sumit">post a comment</button>
                                    <a href="#" class="btn btn-fn-1"><i class="fa fa-smile-o" aria-hidden="true"></i></a>
                                    <a href="#" class="btn btn-fn-1"><i class="fa fa-paperclip" aria-hidden="true"></i></a>
                                    <a href="#" class="btn btn-fn-1"><i class="fa fa-file-image-o" aria-hidden="true"></i></a>
                                </p>
                            </div>
                        </div>


                    </div>

                </div>

                <!-- Sidebar -->
                <aside id="sidebar" class="sidebar blog-sidebar col-lg-3 col-md-4 col-sm-12 col-xs-12">

                    <div class="biolife-mobile-panels">
                        <span class="biolife-current-panel-title">Sidebar</span>
                        <a class="biolife-close-btn" href="#" data-object="open-mobile-filter">&times;</a>
                    </div>

                    <div class="sidebar-contain">

                        <!--Search Widget-->
                        <div class="widget search-widget">
                            <div class="wgt-content">
                                <div action="#" name="frm-search" method="get" class="frm-search">
                                    <input type="text" name="s" value="" placeholder="SEACH..." class="input-text"/>
                                    <button type="submit" name="ok"><i class="biolife-icon icon-search"></i></button>
                                </div>
                            </div>
                        </div>

                        <!--Categories Widget-->
                        <div class="widget biolife-filter">
                            <h4 class="wgt-title">Categories</h4>
                            <div class="wgt-content">
                                <ul class="cat-list">
                                    <li class="cat-list-item"><a href="#" class="cat-link">Beauty (30)</a></li>
                                    <li class="cat-list-item"><a href="#" class="cat-link">Fashion (50)</a></li>
                                    <li class="cat-list-item"><a href="#" class="cat-link">Food (10)</a></li>
                                    <li class="cat-list-item"><a href="#" class="cat-link">Life Style (60)</a></li>
                                    <li class="cat-list-item"><a href="#" class="cat-link">Travel (10)</a></li>
                                </ul>
                            </div>
                        </div>

                        <!--Posts Widget-->
                        <div class="widget posts-widget">
                            <h4 class="wgt-title">Recent post</h4>
                            <div class="wgt-content">
                                <ul class="posts">
                                    <li>
                                        <div class="wgt-post-item">
                                            <div class="thumb">
                                                <a href="#"><img src="assets/images/blogpost/post-wgt-01.jpg" width="80" height="58" alt=""/></a>
                                            </div>
                                            <div class="detail">
                                                <h4 class="post-name"><a href="#">Ashwagandha: The #1 Herb in the World</a></h4>
                                                <p class="post-archive">22 Jan 2019<span class="comment">15 Comments</span></p>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="wgt-post-item">
                                            <div class="thumb">
                                                <a href="#"><img src="assets/images/blogpost/post-wgt-02.jpg" width="80" height="58" alt=""/></a>
                                            </div>
                                            <div class="detail">
                                                <h4 class="post-name"><a href="#">Ashwagandha: The #1 Herb in the World</a></h4>
                                                <p class="post-archive">06 Apr 2019<span class="comment">06 Comments</span></p>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="wgt-post-item">
                                            <div class="thumb">
                                                <a href="#"><img src="assets/images/blogpost/post-wgt-03.jpg" width="80" height="58" alt=""/></a>
                                            </div>
                                            <div class="detail">
                                                <h4 class="post-name"><a href="#">Ashwagandha: The #1 Herb in the World</a></h4>
                                                <p class="post-archive">12 May 2019<span class="comment">08 Comments</span></p>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>

                        <!--Twitter Widget-->

                        <!--Comments Widget-->
                        <div class="widget comment-widget">
                            <h4 class="wgt-title">Recent Comments</h4>
                            <div class="wgt-content">
                                <ul class="comment-list">
                                    <li>
                                        <p class="cmt-item"><a href="#" class="auth-name"><i class="biolife-icon icon-conversation"></i>Jessica Alba</a><a href="#" class="link-post">on Healthy Organics</a></p>
                                    </li>
                                    <li>
                                        <p class="cmt-item"><a href="#" class="auth-name"><i class="biolife-icon icon-conversation"></i>Jessica Alba</a><a href="#" class="link-post">on Best Organics</a></p>
                                    </li>
                                    <li>
                                        <p class="cmt-item"><a href="#" class="auth-name"><i class="biolife-icon icon-conversation"></i>Jessica Alba</a><a href="#" class="link-post">on Healthy Organics</a></p>
                                    </li>
                                    <li>
                                        <p class="cmt-item"><a href="#" class="auth-name"><i class="biolife-icon icon-conversation"></i>Jessica Alba</a><a href="#" class="link-post">on Healthy Organics</a></p>
                                    </li>
                                </ul>
                            </div>
                        </div>

                    </div>
                </aside>
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

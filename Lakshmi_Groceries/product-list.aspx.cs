using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.Services.Description;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Security.Policy;

namespace Lakshmi_Groceries
{
    public partial class product_list : System.Web.UI.Page
    {
        private string newsqlcon = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        string SerachText = null;
        string Category = null;
        int? Prize1 = null;
        int? Prize2 = null;
        List<int> product_id = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //--------------------header-----------------------//
                if (Session["UserName"] != null)
                {
                    string sessionUserName = Session["UserName"].ToString();
                    btnLogin.Text = sessionUserName;
                    btnLogOut.Visible = true;
                }
                //---------------------------------------------------

                Default_method();

                if (!IsPostBack)
                {
                    Session["stored_procedure"] = "SP_product_list_center";
                }
                Custom_method();
            }
            catch
            {
                Response.Redirect("404.aspx");
            }
        }
        protected void Custom_method()
        {
            try
            {
                HtmlGenericControl Panel = (HtmlGenericControl)Page.FindControl("panelMaster");

                Panel.Controls.Clear();

                if (Session["SerachText"] != null)
                {
                    SerachText = Session["SerachText"].ToString();
                }
                if (Session["Category"] != null && Session["Category"].ToString() != "All Categories")
                {
                    Category = Session["Category"].ToString();
                }
                if (Session["Prize1"] != null)
                {
                    Prize1 = Convert.ToInt32(Session["Prize1"]);
                    Prize2 = Convert.ToInt32(Session["Prize2"]);
                }                
                using (SqlConnection DbCon = new SqlConnection(newsqlcon))
                {
                    DbCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Session["stored_procedure"].ToString(), DbCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@product_name", SerachText);
                    sqlCmd.Parameters.AddWithValue("@category_name", Category);
                    sqlCmd.Parameters.AddWithValue("@product_price1", Prize1);
                    sqlCmd.Parameters.AddWithValue("@product_price2", Prize2);
                    int a = sqlCmd.ExecuteNonQuery();
                    SqlDataReader SdR = sqlCmd.ExecuteReader();
                    if (SdR.HasRows)
                    {
                        List<string> CenConImageUrl = new List<string>();
                        List<string> CenConCategories = new List<string>();
                        List<string> CenConName = new List<string>();
                        List<string> CenConPrize = new List<string>();
                        List<string> CenConOrgPrize = new List<string>();
                        while (SdR.Read())
                        {
                            CenConImageUrl.Add(SdR[0].ToString());
                            CenConCategories.Add(SdR[1].ToString());
                            CenConName.Add(SdR[2].ToString());
                            CenConPrize.Add(SdR[3].ToString());
                            CenConOrgPrize.Add(SdR[4].ToString());
                            product_id.Add(Convert.ToInt32(SdR[5]));
                        }
                        int ResultCount = CenConImageUrl.Count();

                        for (int i = 0; i < ResultCount; i++)
                        {
                            HtmlGenericControl li = new HtmlGenericControl("li");
                            li.Attributes["class"] = "product-item col-lg-3 col-md-3 col-sm-4 col-xs-6";

                            HtmlGenericControl productDiv = new HtmlGenericControl("div");
                            productDiv.Attributes["class"] = "contain-product layout-default";

                            HtmlGenericControl thumbDiv = new HtmlGenericControl("div");
                            thumbDiv.Attributes["class"] = "product-thumb";

                            HtmlAnchor link = new HtmlAnchor();
                            link.Attributes["class"] = "link-to-product";

                            ImageButton ImageButtonObj = new ImageButton
                            {
                                ID = "img" + i,
                                CssClass = "product-thumnail",
                                ImageUrl = CenConImageUrl[i] ?? "",
                                CommandName = "ProductClick",
                                CommandArgument = product_id[i].ToString(),
                                AlternateText = "Picture",
                                Width = 270,
                                Height = 270
                            };
                            ImageButtonObj.Click += new ImageClickEventHandler(ImageButton_Click);

                            link.Controls.Add(ImageButtonObj);
                            thumbDiv.Controls.Add(link);
                            productDiv.Controls.Add(thumbDiv);

                            HtmlGenericControl infoDiv = new HtmlGenericControl("div");
                            infoDiv.Attributes["class"] = "info";

                            HtmlGenericControl category = new HtmlGenericControl("b") { ID = "prCategoriesCenPro" + i, InnerText = CenConCategories[i] ?? "" };
                            category.Attributes["class"] = "categories";

                            HtmlGenericControl title = new HtmlGenericControl("h4");
                            title.Attributes["class"] = "product-title";

                            HtmlAnchor titleLink = new HtmlAnchor { ID = "prNameCenPro" + i, InnerText = CenConName[i] ?? "" };
                            titleLink.Attributes["class"] = "pr-name";
                            title.Controls.Add(titleLink);

                            HtmlGenericControl priceDiv = new HtmlGenericControl("div");
                            priceDiv.Attributes["class"] = "price";

                            HtmlGenericControl ins = new HtmlGenericControl("ins");
                            HtmlGenericControl priceSpan = new HtmlGenericControl("span") { ID = "PrizeCenPro" + i, InnerHtml = "<span class=\"currencySymbol\">₹</span>" + CenConPrize[i] ?? "" + "" };
                            priceSpan.Attributes["class"] = "price-amount";
                            ins.Controls.Add(priceSpan);

                            HtmlGenericControl del = new HtmlGenericControl("del");
                            HtmlGenericControl orgPriceSpan = new HtmlGenericControl("span") { ID = "OrgPrizeCenPro" + i, InnerHtml = "<span class=\"currencySymbol\">₹</span>" + CenConPrize[i] ?? "" + "" };
                            orgPriceSpan.Attributes["class"] = "price-amount";
                            del.Controls.Add(orgPriceSpan);

                            priceDiv.Controls.Add(ins);
                            priceDiv.Controls.Add(del);

                            HtmlGenericControl shippingInfo = new HtmlGenericControl("div");
                            shippingInfo.Attributes["class"] = "shipping-info";

                            HtmlGenericControl shippingDay = new HtmlGenericControl("p");
                            shippingDay.Attributes["class"] = "shipping-day";
                            shippingDay.InnerText = "3-Day Shipping";

                            HtmlGenericControl freePickup = new HtmlGenericControl("p");
                            freePickup.Attributes["class"] = "for-today";
                            freePickup.InnerText = "Free Pickup Today";

                            shippingInfo.Controls.Add(shippingDay);
                            shippingInfo.Controls.Add(freePickup);

                            //HtmlGenericControl slideDownBox = new HtmlGenericControl("div");
                            //slideDownBox.Attributes["class"] = "slide-down-box";

                            HtmlGenericControl message = new HtmlGenericControl("p");
                            message.Attributes["class"] = "message";
                            message.InnerText = "All products are carefully selected to ensure food safety.";

                            HtmlGenericControl buttonsDiv = new HtmlGenericControl("div");
                            buttonsDiv.Attributes["class"] = "buttons";

                            HtmlAnchor wishlistBtn = new HtmlAnchor { ID = "anchor1" + i };
                            wishlistBtn.Attributes["class"] = "btn wishlist-btn";
                            wishlistBtn.InnerHtml = "<i class=\"fa fa-heart\" aria-hidden=\"true\"></i>";

                            HtmlAnchor addToCartBtn = new HtmlAnchor { ID = "anchor2" + i };
                            addToCartBtn.Attributes["class"] = "btn add-to-cart-btn";
                            addToCartBtn.InnerHtml = "<i class=\"fa fa-cart-arrow-down\" aria-hidden=\"true\"></i>";


                            //Button cartButton = new Button { ID = "btnCartCenPro" + i };
                            //cartButton.Style.Add("border", "0");
                            //cartButton.Style.Add("background", "none");
                            //cartButton.Text = "Add to cart";
                            //addToCartBtn.Controls.Add(cartButton);

                            HtmlAnchor compareBtn = new HtmlAnchor { ID = "anchor3" + i };
                            compareBtn.Attributes["class"] = "btn compare-btn";
                            compareBtn.InnerHtml = "<i class=\"fa fa-random\" aria-hidden=\"true\"></i>";

                            buttonsDiv.Controls.Add(wishlistBtn);
                            buttonsDiv.Controls.Add(addToCartBtn);
                            buttonsDiv.Controls.Add(compareBtn);

                            //slideDownBox.Controls.Add(message);
                            //slideDownBox.Controls.Add(buttonsDiv);

                            infoDiv.Controls.Add(category);
                            infoDiv.Controls.Add(title);
                            infoDiv.Controls.Add(priceDiv);
                            infoDiv.Controls.Add(shippingInfo);
                            //infoDiv.Controls.Add(slideDownBox);

                            productDiv.Controls.Add(infoDiv);
                            li.Controls.Add(productDiv);

                            HtmlGenericControl ListObj = (HtmlGenericControl)Page.FindControl("panelMaster");

                            ListObj.Controls.Add(li);
                        }
                    }
                    else
                    {
                        panelMaster.Visible = false;
                        Response.Write("<script>alert('No Products')</script>");
                    }
                    DbCon.Close();
                }
                if (!IsPostBack)
                {
                    Session["Prize1"] = null;
                    Session["Prize2"] = null;
                }
            }
            catch
            {
                Response.Redirect("404.aspx");
            }
        }
        protected void Default_method()
        {
            try
            {
                using (SqlConnection DbCon = new SqlConnection(newsqlcon))
                {
                    DbCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("SP_index_block3", DbCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader SdR1 = sqlCmd.ExecuteReader();

                    if (SdR1.HasRows)
                    {
                        List<string> TopConImageUrl = new List<string>();
                        List<string> TopConCategories = new List<string>();
                        List<string> TopConName = new List<string>();
                        List<string> TopConPrize = new List<string>();
                        List<string> TopConOrgPrize = new List<string>();
                        while (SdR1.Read())
                        {
                            TopConImageUrl.Add(SdR1[0].ToString());
                            TopConCategories.Add(SdR1[1].ToString());
                            TopConName.Add(SdR1[2].ToString());
                            TopConPrize.Add(SdR1[3].ToString());
                            TopConOrgPrize.Add(SdR1[4].ToString());
                        }
                        int listCount = TopConImageUrl.Count();

                        ImgBtnTopPro1.ImageUrl = TopConImageUrl[0];
                        prCategoriesTopPro1.InnerText = TopConCategories[0];
                        prNameTopPro1.InnerText = TopConName[0];
                        PrizeTopPro1.InnerText = TopConPrize[0];
                        OrgPrizeTopPro1.InnerText = TopConOrgPrize[0];

                        ImgBtnTopPro2.ImageUrl = TopConImageUrl[1];
                        prCategoriesTopPro2.InnerText = TopConCategories[1];
                        prNameTopPro2.InnerText = TopConName[1];
                        PrizeTopPro2.InnerText = TopConPrize[1];
                        OrgPrizeTopPro2.InnerText = TopConOrgPrize[1];

                        ImgBtnTopPro3.ImageUrl = TopConImageUrl[2];
                        prCategoriesTopPro3.InnerText = TopConCategories[2];
                        prNameTopPro3.InnerText = TopConName[2];
                        PrizeTopPro3.InnerText = TopConPrize[2];
                        OrgPrizeTopPro3.InnerText = TopConOrgPrize[2];

                        ImgBtnTopPro4.ImageUrl = TopConImageUrl[3];
                        prCategoriesTopPro4.InnerText = TopConCategories[3];
                        prNameTopPro4.InnerText = TopConName[3];
                        PrizeTopPro4.InnerText = TopConPrize[3];
                        OrgPrizeTopPro4.InnerText = TopConOrgPrize[3];

                        ImgBtnTopPro5.ImageUrl = TopConImageUrl[4];
                        prCategoriesTopPro5.InnerText = TopConCategories[4];
                        prNameTopPro5.InnerText = TopConName[4];
                        PrizeTopPro5.InnerText = TopConPrize[4];
                        OrgPrizeTopPro5.InnerText = TopConOrgPrize[4];

                        ImgBtnTopPro6.ImageUrl = TopConImageUrl[5];
                        prCategoriesTopPro6.InnerText = TopConCategories[5];
                        prNameTopPro6.InnerText = TopConName[5];
                        PrizeTopPro6.InnerText = TopConPrize[5];
                        OrgPrizeTopPro6.InnerText = TopConOrgPrize[5];

                        ImgBtnTopPro7.ImageUrl = TopConImageUrl[6];
                        prCategoriesTopPro7.InnerText = TopConCategories[6];
                        prNameTopPro7.InnerText = TopConName[6];
                        PrizeTopPro7.InnerText = TopConPrize[6];
                        OrgPrizeTopPro7.InnerText = TopConOrgPrize[6];

                        ImgBtnTopPro8.ImageUrl = TopConImageUrl[7];
                        prCategoriesTopPro8.InnerText = TopConCategories[7];
                        prNameTopPro8.InnerText = TopConName[7];
                        PrizeTopPro8.InnerText = TopConPrize[7];
                        OrgPrizeTopPro8.InnerText = TopConOrgPrize[7];

                        ImgBtnTopPro9.ImageUrl = TopConImageUrl[8];
                        prCategoriesTopPro9.InnerText = TopConCategories[8];
                        prNameTopPro9.InnerText = TopConName[8];
                        PrizeTopPro9.InnerText = TopConPrize[8];
                        OrgPrizeTopPro9.InnerText = TopConOrgPrize[8];

                        ImgBtnTopPro10.ImageUrl = TopConImageUrl[9];
                        prCategoriesTopPro10.InnerText = TopConCategories[9];
                        prNameTopPro10.InnerText = TopConName[9];
                        PrizeTopPro10.InnerText = TopConPrize[9];
                        OrgPrizeTopPro10.InnerText = TopConOrgPrize[9];
                    }
                    SdR1.Close();
                    DbCon.Close();
                }
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }

        //Header
        protected void CurrencyList_select(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void LanguageList_select(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    Response.Redirect("user-details.aspx");
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnLogOut_Click(object sender, EventArgs e)
        {

            try
            {
                Session.Clear();
                Response.Redirect("index-2.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnFruits_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = "Fruits";
                Session["Category"] = Category;
                Response.Redirect("product-list.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnVegetables_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = "Vegetables";
                Session["Category"] = Category;
                Response.Redirect("product-list.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnNutsDryFruits_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = "NutsDryFruits";
                Session["Category"] = Category;
                Response.Redirect("product-list.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnGrains_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = "Grains";
                Session["Category"] = Category;
                Response.Redirect("product-list.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnFlourss_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = "Flours";
                Session["Category"] = Category;
                Response.Redirect("product-list.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnMilkProducts_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = "MilkProducts";
                Session["Category"] = Category;
                Response.Redirect("product-list.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnFreshMeat_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = "FreshMeat";
                Session["Category"] = Category;
                Response.Redirect("product-list.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnOceanFoods_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = "OceanFoods";
                Session["Category"] = Category;
                Response.Redirect("product-list.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnPackedFoods_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = "PackedFoods";
                Session["Category"] = Category;
                Response.Redirect("product-list.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnDrinks_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = "Drinks";
                Session["Category"] = Category;
                Response.Redirect("product-list.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnMobSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string serachText = mobSearch.Text.ToString();
                string Category = ListMobSearch.Text.ToString();
                Session["serachText"] = serachText;
                Session["Category"] = Category;
                Response.Redirect("product-list.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnTopCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    Response.Redirect("shopping-cart.aspx");
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnWebSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string SerachText = webSearch.Text.ToString();
                string Category = ListWebSearch.Text.ToString();
                Session["serachText"] = SerachText;
                Session["Category"] = Category;
                Response.Redirect("product-list.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        //Footer
        protected void BtnNewsletterSignup_Click(object sender, EventArgs e)
        {

            try
            {
                if (btnNewsletterEmail.Text.Trim() != "" && btnNewsletterEmail.Text.Length >= 8)
                {
                    Response.Write("<script>alert('You are sucessfully Signup for Newsletters')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Enter your Email Id')</script>");
                }
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void BtnCart_Click(object sender, EventArgs e)
        {

            try
            {
                if (Session["UserName"] != null)
                {
                    Response.Redirect("shopping-cart.aspx");
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }

        //Main
        protected void BtnFilter_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (CategoryFilter.Text.ToString() != "Category")
                {
                    Session["Category"] = CategoryFilter.Text.ToString();
                }

                if (PrizeFilter.Text.ToString() == "Less than ₹50")
                {
                    Session["Prize1"] = 0;
                    Session["Prize2"] = 50;
                }
                else if (PrizeFilter.Text.ToString() == "₹50-100")
                {
                    Session["Prize1"] = 50;
                    Session["Prize2"] = 100;
                }
                else if (PrizeFilter.Text.ToString() == "₹100-500")
                {
                    Session["Prize1"] = 100;
                    Session["Prize2"] = 500;
                }
                else if (PrizeFilter.Text.ToString() == "₹500-1000")
                {
                    Session["Prize1"] = 500;
                    Session["Prize2"] = 1000;
                }
                else if (PrizeFilter.Text.ToString() == "₹1000-2000")
                {
                    Session["Prize1"] = 1000;
                    Session["Prize2"] = 2000;
                }
                else if (PrizeFilter.Text.ToString() == "₹2000-5000")
                {
                    Session["Prize1"] = 2000;
                    Session["Prize2"] = 5000;
                }
                else if (PrizeFilter.Text.ToString() == "More than ₹5000")
                {
                    Session["Prize1"] = 5000;
                    Session["Prize2"] = 10000000;
                }
                Custom_method();
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void Sorting_select(object sender, EventArgs e)
        {
            try
            {
                if (Sorting.Text.ToString() == "prize: low to high")
                {
                    Session["stored_procedure"] = "SP_product_list_center_asc";
                }
                else if (Sorting.Text.ToString() == "prize: high to low")
                {
                    Session["stored_procedure"] = "SP_product_list_center_desc";
                }
                else if (Sorting.Text.ToString() == "Default")
                {
                    Session["stored_procedure"] = "SP_product_list_center";
                }                
                Custom_method();
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton clickedButton = (ImageButton)sender;
                int productId = Convert.ToInt32(clickedButton.CommandArgument);
                Session["single_product_id"] = productId;
                Response.Redirect("single-product.aspx");
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
    }
}
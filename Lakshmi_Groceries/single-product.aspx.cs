using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Net.NetworkInformation;
using System.Net;
using System.Security.Policy;
using System.Xml.Linq;
using System.Web.Script.Serialization;

namespace Lakshmi_Groceries
{
    public partial class single_product : System.Web.UI.Page
    {
        private string newsqlcon = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        int product_id;
        int product_value_id;
        int user_id;
        int quantity = 1;
        string product_size = "Normal";
        string product_colour = "N/A";
        string product_flavour = "N/A";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //header-------------------------------------------
                if (Session["UserName"] != null)
                {
                    string sessionUserName = Session["UserName"].ToString();
                    btnLogin.Text = sessionUserName;
                    btnLogOut.Visible = true;
                }

                //Main---------------------------------------------

                string[] Ids = { "Image1", "Image2", "Image3", "Image4", "Image5", "Image6", "Image7", "Image8", "Image9", "Image10" };
                foreach (string ID in Ids) 
                {
                    Image ctrl = (Image)Page.FindControl(ID);
                    if (ctrl != null)
                    {
                        ctrl.ImageUrl = "assets/images/products/dummy.png";
                    }
                }
                product_id = Convert.ToInt32(Session["single_product_id"].ToString());
                string product_title = "YYYYY";
                string product_name = "YYYYY";
                string product_description = "YYYYY";
                string product_price = "YYYYY";
                string product_org_price = "YYYYY";
                List<string> group_image = new List<string>();
                string group_ratings_avg = "YYYYY";
                string group_ratings_count = "YYYYY";

                using (SqlConnection DbCon = new SqlConnection(newsqlcon))
                {
                    DbCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("SP_single_product", DbCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@product_id", product_id);
                    SqlDataReader SdR = sqlCmd.ExecuteReader();
                    while (SdR.Read())
                    {
                        product_id = Convert.ToInt32(SdR[0]);
                        product_title = SdR[1].ToString();
                        product_name = SdR[2].ToString();
                        product_description = SdR[3].ToString();
                        product_price = SdR[4].ToString();
                        product_org_price = SdR[5].ToString();
                    }
                    SdR.NextResult();
                    while (SdR.Read())
                    {
                        group_image.Add(SdR[0].ToString());
                    }
                    SdR.Close();

                    Image1.ImageUrl = group_image[0];
                    Image2.ImageUrl = group_image[1];
                    Image3.ImageUrl = group_image[2];
                    Image4.ImageUrl = group_image[3];
                    Image5.ImageUrl = group_image[4];
                    Image6.ImageUrl = group_image[0];
                    Image7.ImageUrl = group_image[1];
                    Image8.ImageUrl = group_image[2];
                    Image9.ImageUrl = group_image[3];
                    Image10.ImageUrl = group_image[4];

                    detailedTitle.InnerText = product_title;
                    proDescripton.InnerText = product_description;
                    proPrize.InnerText = product_price;
                    proOrgPrize.InnerText = product_org_price;
                    proDescripton2.InnerText = product_description;

                    SqlCommand sqlCmd1 = new SqlCommand("SP_single_product2", DbCon);
                    sqlCmd1.CommandType = CommandType.StoredProcedure;
                    sqlCmd1.Parameters.AddWithValue("@product_id", product_id);
                    SqlDataReader SdR1 = sqlCmd1.ExecuteReader();
                    while (SdR1.Read())
                    {
                        group_ratings_avg = SdR1[0].ToString();
                        group_ratings_count = SdR1[1].ToString();
                    }
                    SdR1.Close();
                    proRating.InnerText = group_ratings_avg;
                    proRatingCount.InnerText = group_ratings_count;
                    proRating2.InnerText = group_ratings_avg;

                    //related products
                    SqlCommand sqlCmd2 = new SqlCommand("SP_index_block3", DbCon);
                    sqlCmd2.CommandType = CommandType.StoredProcedure;
                    SqlDataReader SdR2 = sqlCmd2.ExecuteReader();

                    if (SdR2.HasRows)
                    {
                        List<string> TopConImageUrl = new List<string>();
                        List<string> TopConCategories = new List<string>();
                        List<string> TopConName = new List<string>();
                        List<string> TopConPrize = new List<string>();
                        List<string> TopConOrgPrize = new List<string>();
                        while (SdR2.Read())
                        {
                            TopConImageUrl.Add(SdR2[0].ToString());
                            TopConCategories.Add(SdR2[1].ToString());
                            TopConName.Add(SdR2[2].ToString());
                            TopConPrize.Add(SdR2[3].ToString());
                            TopConOrgPrize.Add(SdR2[4].ToString());
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
                    SdR2.Close();
                }
            }
            catch
            {
                
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
                
            }
        }
        protected void LanguageList_select(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {
                
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
                
            }
        }

        //Main
        protected void BtnProBuyProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    using (SqlConnection DbCon = new SqlConnection(newsqlcon))
                    {
                        DbCon.Open();
                        using (SqlCommand sqlCmd = new SqlCommand("SP_single_product_Buy1", DbCon))
                        {
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("@product_id", product_id);
                            sqlCmd.Parameters.AddWithValue("@group_size", product_size.ToString());
                            sqlCmd.Parameters.AddWithValue("@group_colour", product_colour.ToString());
                            sqlCmd.Parameters.AddWithValue("@group_flavour", product_flavour.ToString());
                            sqlCmd.Parameters.AddWithValue("@email", Session["Email"].ToString());
                            SqlDataReader SdR = sqlCmd.ExecuteReader();
                            if (SdR.Read())
                            {
                                product_value_id = Convert.ToInt32(SdR[0]);
                            }
                            SdR.NextResult();
                            while (SdR.Read())
                            {
                                user_id = Convert.ToInt32(SdR[0]);
                            }
                            SdR.Close();
                        }

                        using (SqlCommand sqlCmd2 = new SqlCommand("SP_single_product_Buy2", DbCon))
                        {
                            sqlCmd2.CommandType = CommandType.StoredProcedure;
                            sqlCmd2.Parameters.AddWithValue("@user_id", user_id);
                            sqlCmd2.Parameters.AddWithValue("@product_value_id", product_value_id);
                            sqlCmd2.Parameters.AddWithValue("@quantity", quantity);
                            string a = (string)sqlCmd2.ExecuteScalar();
                            if (a == null)
                            {
                                Response.Write("<script>alert('Product add to cart Failed')</script>");
                            }
                            Response.Redirect("shopping-cart.aspx");
                        }
                        DbCon.Close();
                    }
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
            catch
            {
                Response.Write("<script>alert('Product add to cart Failed')</script>");
            }
        }
        protected void BtnReview_Click(object sender, EventArgs e)
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
                
            }
        }
    }
}
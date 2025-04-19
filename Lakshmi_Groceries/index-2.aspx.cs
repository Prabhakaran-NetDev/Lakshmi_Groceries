using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Lakshmi_Groceries
{
    public partial class index_2 : System.Web.UI.Page
    {
        private string newsqlcon = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //header-------------------------------------------
                if (Session["UserName"] != null)
                {
                    string sessionUserName = Session["UserName"].ToString();
                    btnLogin.Text= sessionUserName;
                    btnLogOut.Visible = true;
                }

                //Main---------------------------------------------

                //body_block3
                SqlConnection DbConHead = new SqlConnection(newsqlcon);
                DbConHead.Open();
                SqlCommand sqlCmdHead = new SqlCommand("SP_index_block3", DbConHead);
                sqlCmdHead.CommandType = CommandType.StoredProcedure;
                SqlDataReader SdR1 = sqlCmdHead.ExecuteReader();

                if (SdR1.HasRows)
                {
                    List<string> Block3ImageUrl = new List<string>();
                    List<string> Block3Categories = new List<string>();
                    List<string> Block3Name = new List<string>();
                    List<string> Block3prize = new List<string>();
                    while (SdR1.Read())
                    {
                        Block3ImageUrl.Add(SdR1[0].ToString());
                        Block3Categories.Add(SdR1[1].ToString());
                        Block3Name.Add(SdR1[2].ToString());
                        Block3prize.Add(SdR1[3].ToString());                        
                    }
                    DbConHead.Close();

                    imgBtnTab01_1st1.ImageUrl = Block3ImageUrl[0];
                    prCategoriesTab01_1st1.InnerText = Block3Categories[0];
                    prNameTab01_1st1.InnerText = Block3Name[0];
                    prizeTab01_1st1.InnerText = Block3prize[0];
                    imgBtnTab01_1st2.ImageUrl = Block3ImageUrl[1];
                    prCategoriesTab01_1st2.InnerText = Block3Categories[1];
                    prNameTab01_1st2.InnerText = Block3Name[1];
                    prizeTab01_1st2.InnerText = Block3prize[1];
                    imgBtnTab01_1st3.ImageUrl = Block3ImageUrl[2];
                    prCategoriesTab01_1st3.InnerText = Block3Categories[2];
                    prNameTab01_1st3.InnerText = Block3Name[2];
                    prizeTab01_1st3.InnerText = Block3prize[2];
                    imgBtnTab01_1st4.ImageUrl = Block3ImageUrl[3];
                    prCategoriesTab01_1st4.InnerText = Block3Categories[3];
                    prNameTab01_1st4.InnerText = Block3Name[3];
                    prizeTab01_1st4.InnerText = Block3prize[3];
                    imgBtnTab01_1st5.ImageUrl = Block3ImageUrl[4];
                    prCategoriesTab01_1st5.InnerText = Block3Categories[4];
                    prNameTab01_1st5.InnerText = Block3Name[4];
                    prizeTab01_1st5.InnerText = Block3prize[4];
                    imgBtnTab01_1st6.ImageUrl = Block3ImageUrl[5];
                    prCategoriesTab01_1st6.InnerText = Block3Categories[5];
                    prNameTab01_1st6.InnerText = Block3Name[5];
                    prizeTab01_1st6.InnerText = Block3prize[5];
                    imgBtnTab01_1st7.ImageUrl = Block3ImageUrl[6];
                    prCategoriesTab01_1st7.InnerText = Block3Categories[6];
                    prNameTab01_1st7.InnerText = Block3Name[6];
                    prizeTab01_1st7.InnerText = Block3prize[6];
                    imgBtnTab01_1st8.ImageUrl = Block3ImageUrl[7];
                    prCategoriesTab01_1st8.InnerText = Block3Categories[7];
                    prNameTab01_1st8.InnerText = Block3Name[7];
                    prizeTab01_1st8.InnerText = Block3prize[7];
                    imgBtnTab01_1st9.ImageUrl = Block3ImageUrl[8];
                    prCategoriesTab01_1st9.InnerText = Block3Categories[8];
                    prNameTab01_1st9.InnerText = Block3Name[8];
                    prizeTab01_1st9.InnerText = Block3prize[8];
                    imgBtnTab01_1st10.ImageUrl = Block3ImageUrl[9];
                    prCategoriesTab01_1st10.InnerText = Block3Categories[9];
                    prNameTab01_1st10.InnerText = Block3Name[9];
                    prizeTab01_1st10.InnerText = Block3prize[9];
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
                if(btnNewsletterEmail.Text.Trim() != "" && btnNewsletterEmail.Text.Length >= 8)
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

    }
}
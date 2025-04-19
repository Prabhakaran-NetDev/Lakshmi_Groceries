using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lakshmi_Groceries
{
    public partial class login : System.Web.UI.Page
    {
        string newsqlcon = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
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
            }
            catch
            {
                Response.Redirect("404.aspx");
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
        protected void submiBtn_L_Click(object sender, EventArgs e)
        {    
            try
            {
                if (userMail_L.Text.Trim() != "" && pwd_L.Text.Trim() != "")
                {
                    if (!CheckBox1.Checked)
                    {
                        SqlConnection DbCon = new SqlConnection(newsqlcon);
                        DbCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("SP_login", DbCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@user_mail", userMail_L.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@user_pwd", pwd_L.Text.Trim());
                        SqlDataReader reader = sqlCmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            DbCon.Close();

                            SqlConnection DbCon2 = new SqlConnection(newsqlcon);
                            DbCon2.Open();
                            SqlCommand sqlCmd1 = new SqlCommand("SP_users", DbCon2);
                            sqlCmd1.CommandType = CommandType.StoredProcedure;
                            sqlCmd1.Parameters.AddWithValue("@user_mail", userMail_L.Text.Trim());
                            SqlDataReader SdR1 = sqlCmd1.ExecuteReader();
                            if (SdR1.HasRows)
                            {
                                while (SdR1.Read())
                                {
                                    Session["UserName"] = SdR1[1].ToString();
                                    Session["Email"] = SdR1[2].ToString();
                                }
                                string sessionUserName = Session["UserName"].ToString();
                                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Welcome " + sessionUserName + " , you are Successfully logged in'); window.location.href = 'index-2.aspx';", true);
                                DbCon2.Close();
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Login Failed')</script>");
                        }
                    }
                    else
                    {
                        SqlConnection DbCon = new SqlConnection(newsqlcon);
                        DbCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("sp_select_admin", DbCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@MasterMail", userMail_L.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Password", pwd_L.Text.Trim());
                        SqlDataReader reader = sqlCmd.ExecuteReader();

                        if (reader.HasRows)
                        { 
                            while (reader.Read())
                            {
                                Session["UserName"] = reader[2].ToString();
                                Session["Email"] = reader[1].ToString();
                            }
                            string sessionUserName = Session["UserName"].ToString();
                            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Welcome " + sessionUserName + " , you are Successfully logged in'); window.location.href = 'Review.aspx';", true);
                            DbCon.Close();
                        }                        
                        else
                        {
                            Response.Write("<script>alert('Login Failed')</script>");
                        }
                    }                    
                }
                else
                {
                    Response.Write("<script>alert('Field should not be Empty')</script>");
                }
            }
            catch
            {
                Response.Redirect("404.aspx");
            }
        }
    }
}
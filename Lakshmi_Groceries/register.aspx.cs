using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;

namespace Lakshmi_Groceries
{
    public partial class register : System.Web.UI.Page
    {
        string newsqlcon = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
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
        public bool EmailValidation(string Email)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex r = new Regex(pattern);
            return r.IsMatch(Email);
        }

        public bool passwordValidation(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            Regex r = new Regex(pattern);
            return r.IsMatch(password);
        }

        protected void submiBtn_R_Click(object sender, EventArgs e)
        {
            try
            {
                if (userName_R.Text.Trim() != "" && userMail_R.Text.Trim() != "" && pwd_R.Text.Trim() != "" && conPwd_R.Text.Trim() != "")
                {
                    string emailId = userMail_R.Text.Trim();
                    bool isValid_E = EmailValidation(emailId);
                    if (isValid_E)
                    {
                        string passwd = pwd_R.Text.Trim();
                        bool isValid_P = passwordValidation(passwd);
                        if (isValid_P)
                        {
                            if (pwd_R.Text.Trim() == conPwd_R.Text.Trim())
                            {
                                SqlConnection DbCon2 = new SqlConnection(newsqlcon);
                                DbCon2.Open();
                                SqlCommand sqlCmd2 = new SqlCommand("sp_select_users_mail", DbCon2);
                                sqlCmd2.CommandType = CommandType.StoredProcedure;
                                sqlCmd2.Parameters.AddWithValue("@email", userMail_R.Text.Trim());
                                SqlDataReader sdr = sqlCmd2.ExecuteReader();
                                
                                if (!sdr.HasRows) 
                                {
                                    SqlConnection DbCon = new SqlConnection(newsqlcon);
                                    DbCon.Open();
                                    SqlCommand sqlCmd = new SqlCommand("SP_user_register", DbCon);
                                    sqlCmd.CommandType = CommandType.StoredProcedure;
                                    sqlCmd.Parameters.AddWithValue("@user_name", userName_R.Text.Trim());
                                    sqlCmd.Parameters.AddWithValue("@user_mail", userMail_R.Text.Trim());
                                    sqlCmd.Parameters.AddWithValue("@user_pwd", pwd_R.Text.Trim());
                                    int a = sqlCmd.ExecuteNonQuery();
                                    DbCon.Close();
                                    if (a > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Regisdered Successfully'); window.location.href = 'login.aspx';", true);
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Regisder Failed')</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Email Already Regisdered')</script>");
                                }
                                DbCon2.Close();
                            }
                            else
                            {
                                Response.Write("<script>alert('Password should be same')</script>");
                            }

                        }
                        else
                        {
                            Response.Write("<script>alert('Password should be in correct format')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Email should be in correct format')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('Fill every Textboxes')</script>");
                }
            }
            catch
            {
                Server.Transfer("404.aspx");
            }
        }
    }
}
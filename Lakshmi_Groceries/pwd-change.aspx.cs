using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Configuration;

namespace Lakshmi_Groceries
{
    public partial class pwd_change : System.Web.UI.Page
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
        public bool passwordValidation(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            Regex r = new Regex(pattern);
            return r.IsMatch(password);
        }

        protected void submiBtn_C_Click(object sender, EventArgs e)
        {
            try
            {
                if (userMail_C.Text.Trim() != "" && oldPwd_C.Text.Trim() != "" && newPwd_C.Text.Trim() != "" && conPwd_C.Text.Trim() != "")
                {
                    string passwd = newPwd_C.Text.Trim();
                    bool isValid_P = passwordValidation(passwd);
                    if (isValid_P)
                    {
                        if (newPwd_C.Text.Trim() == conPwd_C.Text.Trim())
                        {

                            SqlConnection DbCon1 = new SqlConnection(newsqlcon);
                            DbCon1.Open();
                            SqlCommand sqlCmd = new SqlCommand("SP_login", DbCon1);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("@user_mail", userMail_C.Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@user_pwd", oldPwd_C.Text.Trim());
                            
                            int a = sqlCmd.ExecuteNonQuery();
                            DbCon1.Close();
                            if (a > 0)
                            {
                                SqlConnection DbCon2 = new SqlConnection(newsqlcon);
                                DbCon2.Open();
                                SqlCommand sqlCmd2 = new SqlCommand("SP_update_pwd", DbCon2);
                                sqlCmd2.CommandType = CommandType.StoredProcedure;
                                sqlCmd2.Parameters.AddWithValue("@user_mail", newPwd_C.Text.Trim());
                                sqlCmd2.Parameters.AddWithValue("@user_pwd", conPwd_C.Text.Trim());
                                int b = sqlCmd.ExecuteNonQuery();
                                DbCon1.Close();
                                if (b > 0)
                                {
                                    Response.Write("<script>alert('Password changed Successfully')</script>");
                                    Response.Redirect("index-2.aspx");
                                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Password changed Successfully'); window.location.href = 'login.aspx';", true);
                                }
                                else
                                {
                                    Response.Write("<script>alert('Failed')</script>");
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Old password is incorrect')</script>");
                            }
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Write a Strong password')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Field should not be Empty')</script>");
                }
            }
            catch
            {
                
            }
        }
    }
}
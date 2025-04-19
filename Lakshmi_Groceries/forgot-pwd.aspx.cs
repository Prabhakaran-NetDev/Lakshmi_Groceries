using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data.SqlTypes;

namespace Lakshmi_Groceries
{
    public partial class forgot_pwd : System.Web.UI.Page
    {
        string newsqlcon = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        string randomcode;
        string UserMail;
        string MasterMail;
        string MasterMailPass;
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
        protected void otpBtn_F_Click(object sender, EventArgs e)
        {
            try
            {
                if (userMail_F.Text.Trim() != "")
                {
                    SqlConnection DbCon = new SqlConnection(newsqlcon);
                    DbCon.Open();
                    SqlCommand sqlCmd1 = new SqlCommand("SP_master", DbCon);
                    sqlCmd1.CommandType = CommandType.StoredProcedure;
                    sqlCmd1.Parameters.AddWithValue("@user_mail", userMail_F.Text.Trim());
                    SqlDataReader SdR1 = sqlCmd1.ExecuteReader();
                    if (SdR1.HasRows)
                    {
                        while (SdR1.Read())
                        {
                            UserMail = SdR1[2].ToString();
                        }
                        SdR1.NextResult();
                        while (SdR1.Read())
                        {
                            MasterMail = SdR1[0].ToString();
                            MasterMailPass = SdR1[1].ToString();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid User')</script>");
                    }

                    if (userMail_F.Text.Trim() == UserMail)
                    {
                        string from, pass, messageBody, to;
                        Random random = new Random();
                        randomcode = (random.Next(999999)).ToString();
                        MailMessage message = new MailMessage();
                        to = (userMail_F.Text.Trim()).ToString();
                        from = MasterMail;
                        pass = MasterMailPass;
                        messageBody = "Your Email Verification Code: " + randomcode;
                        message.To.Add(to);
                        message.From = new MailAddress(from);
                        message.Body = messageBody;
                        message.Subject = "Verification Code:";
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(from, pass);

                        try
                        {
                            smtp.Send(message);
                            Response.Write("<script>alert('OTP Sended Successfully')</script>");
                        }
                        catch
                        {
                            
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid User')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Email Required')</script>");
                }
            }
            catch
            {
                
            }
        }

        protected void submiBtn_F_Click(object sender, EventArgs e)
        {
            try
            {
                if (userMail_F.Text.Trim() != "" && otp_F.Text.Trim() != "" && pwd_F.Text.Trim() != "" && conPwd_F.Text.Trim() != "")
                {
                    if(otp_F.Text.Trim() == randomcode)
                    {
                        SqlConnection DbCon = new SqlConnection(newsqlcon);
                        DbCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("SP_update_pwd", DbCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@user_mail", userMail_F.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@user_pwd", pwd_F.Text.Trim());
                        int a = sqlCmd.ExecuteNonQuery();
                        DbCon.Close();
                        if (a > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Password Successfully Updated'); window.location.href = 'login.aspx';", true);
                        }
                        else
                        {
                            Response.Write("<script>alert('Regisder Failed')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid OTP')</script>");
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
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Reflection;

namespace Lakshmi_Groceries
{
    public partial class shopping_cart : System.Web.UI.Page
    {
        private string newsqlcon = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        
        int user_id = 0;
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

                string UserName = null;
                string emailId = null;
                string addressvalue = null;
                string phoneNum = null;

                string orederId2 = null;
                string proName2 = null;
                string proPrice2 = null;
                string proquantity2 = null;
                string ordStatus = null;

                List<string> proValue = new List<string>();
                List<string> proName3 = new List<string>();
                List<string> proSize = new List<string>();
                List<string> proColour = new List<string>();
                List<string> ordFlavour = new List<string>();
                List<string> proquantity3 = new List<string>();
                List<decimal> proPrice3 = new List<decimal>();
                List<string> proImage = new List<string>();

                using (SqlConnection DbCon = new SqlConnection(newsqlcon))
                {
                    DbCon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("SP_user_details", DbCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@user_name", Session["UserName"].ToString());
                        SqlDataReader SdR = sqlCmd.ExecuteReader();
                        if (SdR.Read())
                        {
                            user_id = Convert.ToInt32(SdR[0]);
                            UserName = SdR[1].ToString();
                            emailId = SdR[2].ToString();
                            addressvalue = SdR[4].ToString();
                            phoneNum = SdR[5].ToString();
                        }
                        SdR.Close();
                    }
                    using (SqlCommand sqlCmd2 = new SqlCommand("SP_order_details", DbCon))
                    {
                        sqlCmd2.CommandType = CommandType.StoredProcedure;
                        sqlCmd2.Parameters.AddWithValue("@user_id", user_id);
                        SqlDataReader SdR2 = sqlCmd2.ExecuteReader();
                        if (SdR2.Read())
                        {
                            orederId2 = SdR2[0].ToString();
                            proName2 = SdR2[1].ToString();
                            proPrice2 = SdR2[2].ToString();
                            proquantity2 = SdR2[3].ToString();
                            ordStatus = SdR2[4].ToString();
                        }
                        SdR2.Close();
                    }
                    using (SqlCommand sqlCmd3 = new SqlCommand("SP_cart_items", DbCon))
                    {
                        sqlCmd3.CommandType = CommandType.StoredProcedure;
                        sqlCmd3.Parameters.AddWithValue("@user_id", user_id);
                        SqlDataReader SdR3 = sqlCmd3.ExecuteReader();
                        while (SdR3.Read())
                        {
                            proValue.Add(SdR3[1].ToString());
                            proName3.Add(SdR3[2].ToString());
                            proSize.Add(SdR3[3].ToString());
                            proColour.Add(SdR3[4].ToString());
                            ordFlavour.Add(SdR3[5].ToString());
                            proquantity3.Add(SdR3[6].ToString());
                            proPrice3.Add(Convert.ToDecimal(SdR3[7]));
                            proImage.Add(SdR3[8].ToString());
                        }
                        SdR3.Close();

                        int cartCount = proName3.Count();
                        cartTotalNos.InnerText = cartCount.ToString();
                        decimal sum = 0;

                        for (int i = 1; i <= cartCount; i++)
                        {  
                            string list = "Li" + i.ToString();
                            string image = "Img" + i.ToString();
                            string proQuan = "proQuantity" + i.ToString();
                            string proNam = "A" + i.ToString();
                            string proPriz = "proPrize" + i.ToString();
                            HtmlGenericControl controllist = (HtmlGenericControl)Page.FindControl(list);
                            Image controlimage = (Image)Page.FindControl(image);
                            HtmlGenericControl controlproQuan = (HtmlGenericControl)Page.FindControl(proQuan);
                            HtmlAnchor controlproNam = (HtmlAnchor)Page.FindControl(proNam);
                            HtmlGenericControl controlproPriz = (HtmlGenericControl)Page.FindControl(proPriz);
                            
                            if (controllist != null)
                            {
                                controllist.Visible = true;
                            }
                            if (controlimage != null)
                            {
                                controlimage.ImageUrl = proImage[i - 1];
                            }
                            if (controlproQuan != null)
                            {
                                controlproQuan.InnerText = proquantity3[i - 1];
                            }
                            if (controlproNam != null)
                            {
                                controlproNam.InnerText = proName3[i - 1];
                            }
                            if (controlproPriz != null)
                            {
                                controlproPriz.InnerText = proPrice3[i - 1].ToString();
                            }                            
                        }
                        for (int j = 1; j <= cartCount; j++)
                        {   
                            sum += proPrice3[j - 1];
                            Cart_Total.InnerText = sum.ToString();
                            Cart_Total2.InnerText = sum.ToString();
                        }
                    }
                    DbCon.Close();
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
        protected void BtnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    Response.Redirect("checkout.aspx");
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
        protected void BtnDeleteCart_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> proValue = new List<string>();
                int i = Convert.ToInt32(CartValue.Text);

                if (CartValue.Text != null)
                {
                    using (SqlConnection DbCon = new SqlConnection(newsqlcon))
                    {
                        DbCon.Open();
                        using (SqlCommand sqlCmd3 = new SqlCommand("SP_cart_items", DbCon))
                        {
                            sqlCmd3.CommandType = CommandType.StoredProcedure;
                            sqlCmd3.Parameters.AddWithValue("@user_id", user_id);
                            SqlDataReader SdR3 = sqlCmd3.ExecuteReader();
                            while (SdR3.Read())
                            {
                                proValue.Add(SdR3[1].ToString());
                            }
                            SdR3.Close();
                        }

                        int valueId = Convert.ToInt32(proValue[i-1].ToString());
                        using (SqlCommand sqlCmd = new SqlCommand("SP_cart_delete", DbCon))
                        {
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("@user_id", user_id);
                            sqlCmd.Parameters.AddWithValue("@product_value_id", valueId);
                            int a = sqlCmd.ExecuteNonQuery();
                            if (a > 0)
                            {
                                Response.Redirect("shopping-cart.aspx");
                            }
                            else
                            {
                                Response.Write("<script>alert('Failed to Delete" + valueId + "')</script>");
                            }
                        }
                        DbCon.Close();
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Product Not Found')</script>");
            }
        }
    }
}

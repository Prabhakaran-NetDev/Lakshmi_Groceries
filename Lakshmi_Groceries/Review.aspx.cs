using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlTypes;
using System.IO;

namespace Lakshmi_Groceries
{
    public partial class Review : System.Web.UI.Page
    {
        private string newsqlcon = ConfigurationManager.ConnectionStrings[@"MysqlConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //--------------------header-----------------------
            if (Session["UserName"] != null)
            {
                string sessionUserName = Session["UserName"].ToString();
                btnLogin.Text = sessionUserName;
                btnLogOut.Visible = true;
            }
            //--------------------------------------------------

            //----------------------Main------------------------
            using (SqlConnection DbCon = new SqlConnection(newsqlcon))
            {
                DbCon.Open();
                using (SqlCommand sqlCmd2 = new SqlCommand("SP_order_details", DbCon))
                {
                    sqlCmd2.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter SDA = new SqlDataAdapter(sqlCmd2);
                    DataTable Dt = new DataTable();
                    SDA.Fill(Dt);
                    OrdersGrid.DataSource = Dt;
                    OrdersGrid.DataBind();
                }
                using (SqlCommand sqlCmd2 = new SqlCommand("sp_fetch_products", DbCon))
                {
                    sqlCmd2.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter SDA = new SqlDataAdapter(sqlCmd2);
                    DataTable Dt = new DataTable();
                    SDA.Fill(Dt);
                    ProductsGrid.DataSource = Dt;
                    ProductsGrid.DataBind();
                }
                using (SqlCommand sqlCmd2 = new SqlCommand("sp_fetch_categories", DbCon))
                {
                    sqlCmd2.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter SDA = new SqlDataAdapter(sqlCmd2);
                    DataTable Dt = new DataTable();
                    SDA.Fill(Dt);
                    categoryGrid.DataSource = Dt;
                    categoryGrid.DataBind();
                }
            }
        }
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

        protected void OrdersBox_Click(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "UpdateClick")
            {
                int RowId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = OrdersGrid.Rows[RowId];
                int RowValue = Convert.ToInt32(row.Cells[0].Text);

                SqlConnection DbCon = new SqlConnection(newsqlcon);
                DbCon.Open();
                SqlCommand sqlCmd = new SqlCommand("sp_update_orders", DbCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@order_id", RowValue);
                sqlCmd.Parameters.AddWithValue("@status", Order_status.Text.ToString());
                int a = sqlCmd.ExecuteNonQuery();
                DbCon.Close();
                if (a > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Updateded Successfully'); window.location.href = 'Review.aspx';", true);
                }
            }
            else if (e.CommandName == "DeleteClick")
            {
                int RowId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = OrdersGrid.Rows[RowId];
                int RowValue = Convert.ToInt32(row.Cells[0].Text);

                SqlConnection DbCon = new SqlConnection(newsqlcon);
                DbCon.Open();
                SqlCommand sqlCmd = new SqlCommand("sp_delete_orders", DbCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@order_id", RowValue);
                int a = sqlCmd.ExecuteNonQuery();
                DbCon.Close();
                if (a > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Deleted Successfully'); window.location.href = 'Review.aspx';", true);
                }
            }
        }
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                try
                {
                    string folderPath = Server.MapPath("~/assets/images/products/");

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string fileName = Path.GetFileName(FileUpload.FileName);
                    string filePath = folderPath + fileName;
                    FileUpload.SaveAs(filePath);
                    File.Copy(fileName, folderPath);

                    SaveFilePathToDatabase("~/assets/images/products/" + fileName);
                }
                catch
                {
                    Server.Transfer("404.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Please select an image to upload.')</script>");
            }
        }
        private void SaveFilePathToDatabase(string filePath)
        {
            using (SqlConnection dbcon = new SqlConnection(newsqlcon))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_products", dbcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@product_name", Name.Text.ToString());
                    cmd.Parameters.AddWithValue("@product_description", Description.Text.ToString());
                    cmd.Parameters.AddWithValue("@product_price", Convert.ToDecimal(Prize.Text));
                    cmd.Parameters.AddWithValue("@product_status", Status.Text.ToString());
                    cmd.Parameters.AddWithValue("@product_img", filePath);
                    cmd.Parameters.AddWithValue("@product_org_price", Convert.ToDecimal(Orginal_Prize.Text));
                    cmd.Parameters.AddWithValue("@product_Title", Title.Text.ToString());
                    dbcon.Open();
                    int a = cmd.ExecuteNonQuery();
                    dbcon.Close();
                    if (a > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Uploaded Successfully'); window.location.href = 'Review.aspx';", true);
                    }
                }
            }
        }
        protected void Define_Category_Click(object sender, EventArgs e)
        {
            using (SqlConnection dbcon = new SqlConnection(newsqlcon))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_products_categories", dbcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@product_id", Convert.ToInt32(Product_id.Text));
                    cmd.Parameters.AddWithValue("@category_id", Convert.ToInt32(Category_id.Text));
                    dbcon.Open();
                    int a = cmd.ExecuteNonQuery();
                    dbcon.Close();
                }
            }
        }
        protected void BtnDeleteImage_Click(object sender, GridViewCommandEventArgs e)
        {
            //string imagePath = Server.MapPath("~/images/yourimage.jpg"); 

            //if (File.Exists(imagePath))
            //{ 
            //    File.Delete(imagePath);
            //    Response.Write("Image deleted successfully.");
            //}
            //else
            //{
            //   Response.Write("Image not found.");
            //}
            if (e.CommandName == "DeleteClick")
            {
                int RowId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = ProductsGrid.Rows[RowId];
                int RowValue = Convert.ToInt32(row.Cells[0].Text);

                SqlConnection DbCon = new SqlConnection(newsqlcon);
                DbCon.Open();
                SqlCommand sqlCmd = new SqlCommand("sp_delete_products", DbCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@product_id", RowValue);
                int a = sqlCmd.ExecuteNonQuery();
                DbCon.Close();
                if (a > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Deleted Successfully'); window.location.href = 'Review.aspx';", true);
                }
            }
        }
    }
}
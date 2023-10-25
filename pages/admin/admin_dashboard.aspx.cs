using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medical_ClinicManagementSystem.pages.admin
{
    public partial class addUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = (string)Session["username_a"];
            ShowData();
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            string query = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;
            
            if (rbReceptionist.Checked)
            {
                query = "insert into receptionist(receptionist_username, r_password) values(@username, @password)";
            }
            else if(rbpharmacist.Checked)
            {
                query = "insert into pharmacist(pharmacist_username, p_password) values(@username, @password)";
            }
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.ExecuteNonQuery();
                    ShowData();
                    con.Close();
                    
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error : " + ex.Message);
            }
        }

        protected void ShowData()
        {
            gvReceptionist.DataBind();
            gvPharmacist.DataBind();
            if (rbReceptionist.Checked == true)
            {
                gvReceptionist.Visible = true;
                gvPharmacist.Visible = false;
            }
            else if (rbpharmacist.Checked == true)
            {
                gvReceptionist.Visible = false;
                gvPharmacist.Visible = true;
            }

        }

        protected void rbReceptionist_CheckedChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        protected void rbpharmacist_CheckedChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            if (Session["username_a"] != null)
            {
                Session.Remove("username_a");
                Response.Redirect("~/pages/login.aspx");
            }
        }
    }
}
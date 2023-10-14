using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Medical_ClinicManagementSystem.pages
{
    public partial class sign_up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;
            try
            {
                using(con)
                {   
                    //admin
                    string query = "select * from users where username = '" + txtUsername.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while(sdr.Read())
                    {
                        if (String.Equals(txtPassword.Text, sdr["password"]))
                        {
                            Session["username_a"] = txtUsername.Text;
                            Response.Redirect("~/pages/admin/admin_dashboard.aspx");
                        }
                    }
                    con.Close();

                    //doctor
                    query = "select * from doctors where doctor_name = '" + txtUsername.Text + "'";
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        if (String.Equals(txtPassword.Text, sdr["d_password"]))
                        {
                            Session["username_d"] = txtUsername.Text;
                            Response.Redirect("~/pages/doctor/doctor_dashboard.aspx");
                        }
                    }
                    con.Close();

                    //receptionist
                    query = "select * from receptionist where receptionist_username = '" + txtUsername.Text + "'";
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        if (String.Equals(txtPassword.Text, sdr["r_password"]))
                        {
                            Session["username_r"] = txtUsername.Text;
                            Response.Redirect("~/pages/receptionist/receptionist_dashboard.aspx");
                        }
                    }
                    con.Close();

                    //pharmacist
                    query = "select * from pharmacist where pharmacist_username = '" + txtUsername.Text + "'";
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        if (String.Equals(txtPassword.Text, sdr["p_password"]))
                        {
                            Session["username_p"] = txtUsername.Text;
                            Response.Redirect("~/pages/pharmacist/pharmacist_dashboard.aspx");
                        }
                    }
                    con.Close();
                    Response.Write("<script>alert('Incorrect Username or Password');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error : " + ex.Message);
            }
        }
    }
}
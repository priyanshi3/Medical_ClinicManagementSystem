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
                    string query = "select * from users where username = '" + txtUsername.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while(sdr.Read())
                    {
                        if (String.Equals(txtPassword.Text, sdr["password"]))
                        {
                            if(String.Equals(txtUsername.Text, "doctor"))
                            {
                                Response.Redirect("~/pages/doctor/dashboard.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/pages/receptionist/dashboard.aspx");
                            }
                            
                        }
                    }
                    Response.Write("<center> Incorrect Username or Password </center>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error : " + ex.Message);
            }
        }
    }
}
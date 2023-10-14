using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Data;

namespace Medical_ClinicManagementSystem.pages.receptionist
{
    public partial class Appointment : System.Web.UI.Page
    {
        int pid;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = (string)Session["username_r"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;
            try
            {
                using(con)
                {
                    string query = "select p_id from patient where contact_number = '" + txtPhnNum.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        pid = (int)sdr["p_id"];
                    }
                    con.Close();
                }  
            }
            catch (Exception ex)
            {
                Response.Write("Error : " + ex.Message);
            } 
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;
                try
                {
                    string query = "insert into appointments (p_id, symptoms, date)" +
                        "values(@p_id, @symptoms, @date)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@p_id", pid);
                    cmd.Parameters.AddWithValue("@symptoms", txtSymptoms.Text);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    Response.Redirect("~/pages/receptionist/receptionist_dashboard.aspx");
                }
                catch (SqlException ex)
                {
                    Response.Write("<script>alert('Patient is new!!!');window.location = 'addNewPatient.aspx';</script>");
            }
                catch (Exception ex)
                {
                    Response.Write("Error : " + ex.Message);
                }            
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            if (Session["username_r"] != null)
            {
                Session.Remove("username_r");
                Response.Redirect("~/pages/login.aspx");
            }
        }
    }
}
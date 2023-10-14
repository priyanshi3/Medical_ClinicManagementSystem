using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medical_ClinicManagementSystem.pages.doctor
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = (string)Session["username_d"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;

            try
            {
                using (con)
                {
                    string query = "SELECT patient.first_name as 'First Name', patient.last_name as 'Last Name', " +
                        "patient.age as Age, patient.blood_group as 'Blood Group', appointments.symptoms as Symptoms,  " +
                        "date, appointments.prescription FROM patient INNER JOIN appointments ON patient.p_id = appointments.p_id" +
                        " where date = GETDATE()";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while(sdr.Read())
                    {
                        Panel1.Controls.Add(new LiteralControl("<br/> "));
                        HyperLink hyp = new HyperLink();
                        hyp.Text = (string)sdr["First Name"] + " " + (string)sdr["Last Name"];
                        hyp.NavigateUrl = "~/pages/doctor/prescription.aspx?fname=" + sdr["First Name"] + "&lname=" + sdr["Last Name"];
                        hyp.CssClass = "link";
                        if (!Convert.IsDBNull(sdr["prescription"]) && (DateTime)sdr["date"] == DateTime.Today)
                        {
                            hyp.CssClass = "disable-link link";
                        }
                        Panel1.Controls.Add(hyp);
                        Panel1.Controls.Add(new LiteralControl("<br/> <br/> "));
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error : " + ex.Message);
            }

        }

        protected void logout_Click(object sender, EventArgs e)
        {
            if (Session["username_d"] != null)
            {
                Session.Remove("username_d");
                Response.Redirect("~/pages/login.aspx");
            }
        }
    }
}
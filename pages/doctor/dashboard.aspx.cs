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
            DataTable dt = new DataTable("Appointment");

            dt.Columns.Add("Sr. No.", typeof(int));
            dt.Columns.Add("First Name", typeof(String));
            dt.Columns.Add("Last Name", typeof(String));
            dt.Columns.Add("Age", typeof(int));
            dt.Columns.Add("Blood Group", typeof(String));
            dt.Columns.Add("Symptoms", typeof(String));
            dt.Columns.Add("Actions", typeof(Control));

            DataRow dr;
            TextBox tb = new TextBox();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;

            try
            {
                using (con)
                {
                    string query = "select * from appointments";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while(sdr.Read())
                    {
                        dr = dt.NewRow();
                        dr["Sr. No."] = sdr["appointment_id"];
                        dr["First Name"] = sdr["fname"];
                        dr["Last Name"] = sdr["lname"];
                        dr["Age"] = sdr["age"];
                        dr["Blood Group"] = sdr["blood_group"];
                        dr["Symptoms"] = sdr["symptoms"];
                        
                        dt.Rows.Add(dr);
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error : " + ex.Message);
            }

        }
    }
}
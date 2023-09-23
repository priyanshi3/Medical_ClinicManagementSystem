using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medical_ClinicManagementSystem.pages.receptionist
{
    public partial class Appointment : System.Web.UI.Page
    {
        String fname, lname, blood_group;
        int age;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;
            try
            {
                using(con)
                {
                    string query = "select * from patient where first_name = '" + txtFname.Text + "' and last_name = '" + txtLname.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        fname = (string)sdr["first_name"];
                        lname = (string)sdr["last_name"];
                        age = (int)sdr["age"];
                        blood_group = (string)sdr["blood_group"];
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
            if(fname == null && lname == null)
            {
                Response.Write("Patient does not exist");
                Button AddPatient = new Button();
                AddPatient.Text = "Add Patient";
                //AddPatient.Left = 10; AddPatient.Top = 10;  //the button's location
                AddPatient.Click += new EventHandler(btnAddPtient_Click); 
                this.Controls.Add(AddPatient);
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;
                try
                {
                    string query = "insert into appointment (fname, lname, age, blood_group, symptoms)" +
                        "values(@fname, @lname, @age, @blood_group, @symptoms)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@lname", lname);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@blood_group", blood_group);
                    cmd.Parameters.AddWithValue("@symptoms", txtSymptoms.Text);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("Error : " + ex.Message);
                }
            }
            
        }

        protected void btnAddPtient_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/receptionist/addNewPatient.aspx");
        }
    }
}
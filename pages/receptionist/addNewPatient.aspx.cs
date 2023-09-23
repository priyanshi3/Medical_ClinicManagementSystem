using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Medical_ClinicManagementSystem.pages.receptionist
{
    public partial class addNewPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDOB.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void btnAddPatient_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;
            try
            {
                DateTime today = DateTime.Today;
                DateTime givenDate = DateTime.Parse(txtDOB.Text);
                int age = today.Year - givenDate.Year;

                using (con)
                {
                    string query = "insert into patient(first_name, last_name, DOB, age, contact_number, gender, address, blood_group) " +
                        "values(@FirstName, @LastName, @DOB, @age, @ContactNumber, @Gender, @Address, @BloodGroup)";
                           
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@ContactNumber", txtPhnNum.Text);
                    cmd.Parameters.AddWithValue("@Gender", rbGender.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@BloodGroup", ddBloodGrp.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("~/pages/receptionist/dashboard.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error : " + ex.Message);
            }
            
        }
    }
}
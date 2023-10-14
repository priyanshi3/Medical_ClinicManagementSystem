using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medical_ClinicManagementSystem.pages.receptionist
{
    public partial class updatePatient : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = (string)Session["username_r"];

            lblFirstName.Visible = false;
            lblLastName.Visible = false;
            lblPhnNum.Visible = false;
            lblGender.Visible = false;
            lblAddress.Visible = false;
            lblBloodGrp.Visible = false;

            txtFirstName.Visible = false;
            txtLastName.Visible = false;
            txtPhnNum.Visible = false;
            rbGenderMale.Visible = false;
            rbGenderFemale.Visible = false;
            txtAddress.Visible = false;
            ddBloodGrp.Visible = false;

            btnUpdatePatient.Visible = false;
        }

        protected void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;
            try
            {
                string gender = "Male";
                using (con)
                {
                    if (rbGenderFemale.Checked == true)
                    {
                        gender = rbGenderFemale.Text;
                    }
                    else if (rbGenderMale.Checked == true)
                    {
                        gender = rbGenderMale.Text;
                    }
                    string query = "update patient set contact_number = '" + txtPhnNum.Text + "', gender = '" + gender + "', " +
                         "address = '" + txtAddress.Text + "', blood_group = '" + ddBloodGrp.Text + "' where first_name = '" + 
                         txtSearchfname.Text + "' and last_name = '" + txtSearchlname.Text + "'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("~/pages/receptionist/receptionist_dashboard.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error : " + ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;
            try
            {
                using (con)
                {
                    string query = "select * from patient where first_name = '" +txtSearchfname.Text + "' and last_name = '" + txtSearchlname.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    lblFirstName.Visible = true;
                    lblLastName.Visible = true;
                    lblPhnNum.Visible = true;
                    lblGender.Visible = true;
                    lblAddress.Visible = true;
                    lblBloodGrp.Visible = true;

                    txtFirstName.Visible = true;
                    txtLastName.Visible = true;
                    txtPhnNum.Visible = true;
                    rbGenderMale.Visible = true;
                    rbGenderFemale.Visible = true;
                    txtAddress.Visible = true;
                    ddBloodGrp.Visible = true;
                    
                    btnUpdatePatient.Visible = true;

                    while (sdr.Read())
                    {

                        txtFirstName.Text = (string)sdr["first_name"];
                        txtLastName.Text = (string)sdr["last_name"];
                        txtPhnNum.Text = (string)sdr["contact_number"];
                        if (String.Equals(sdr["gender"], "Female"))
                        {
                            rbGenderFemale.Checked = true;
                        }
                        if (String.Equals(sdr["gender"], "Male"))
                        {
                            rbGenderMale.Checked = true;
                        }
                        txtAddress.Text = (string)sdr["address"];
                        ddBloodGrp.SelectedValue = (string)sdr["blood_group"];
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
            if (Session["username_r"] != null)
            {
                Session.Remove("username_r");
                Response.Redirect("~/pages/login.aspx");
            }
        }
    }
}
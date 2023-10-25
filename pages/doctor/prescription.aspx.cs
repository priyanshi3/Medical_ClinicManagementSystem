using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medical_ClinicManagementSystem.pages.doctor
{
    public partial class prescription : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        int appointmentId;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = (string)Session["username_d"];
            // lblLastVisitData.Visible = false;
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;
            try
            {
                using (con)
                {
                    string query = "SELECT patient.first_name, patient.last_name, patient.age, patient.blood_group , " +
                        "appointments.symptoms, appointments.appointment_id, appointments.checked, " +
                        "date, prescription FROM patient INNER JOIN " +
                        "appointments ON patient.p_id = appointments.p_id " +
                        "where patient.first_name = '" + Request.QueryString["fname"] + "' and " +
                        "patient.last_name = '" + Request.QueryString["lname"] + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        txtFirstName.Text = (string)sdr["first_name"];
                        txtLastname.Text = (string)sdr["last_name"];
                        txtAge.Text = sdr["age"].ToString();
                        txtBloodGroup.Text = (string)sdr["blood_group"];
                        txtSymptoms.Text = (string)sdr["symptoms"];

                        if (sdr["prescription"] != null)
                        {
                            lblLastVisitData.Text = "<b>Date: </b>" + sdr["date"] +
                                                    "<br/><b>Prescription: </b>" + (string)sdr["prescription"];
                        }
                        else
                        {
                            lblLastVisitData.Text = "First Visit";
                        }
                        appointmentId = (int)sdr["appointment_id"];
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error : " + ex.Message);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Response.Write(Request.QueryString["name"]);
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;
            try
            {
                using (con)
                {
                    string query = "update appointments set prescription = @prescription " +
                        "where appointment_id = " + appointmentId;
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@prescription", txtPrescription.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("~/pages/doctor/doctor_dashboard.aspx");
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
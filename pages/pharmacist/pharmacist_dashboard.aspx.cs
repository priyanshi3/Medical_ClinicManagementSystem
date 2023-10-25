using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medical_ClinicManagementSystem.pages.pharmacist
{
    public partial class dashboard : System.Web.UI.Page
    {
        bool flag = true;
        LiteralControl tab, br;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = (string) Session["username_p"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;
            try
            {
                using (con)
                {
                    string query = "SELECT patient.first_name as 'First Name', patient.last_name as 'Last Name', " +
                        "appointments.prescription, appointments.appointment_id FROM patient INNER JOIN appointments ON patient.p_id = appointments.p_id ";
                        /*"where checked = null";*/
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        if (!Convert.IsDBNull(sdr["prescription"]))
                        {
                            Label lbl = new Label();
                            lbl.Text = "<b>PATIENT : </b>" + (string)sdr["First Name"] + " " + (string)sdr["Last Name"] + 
                                " &nbsp; <b>PRESCIPTION : </b>" + sdr["prescription"];
                            Panel1.Controls.Add(lbl);

                            tab = new LiteralControl("&nbsp;  &nbsp;");
                            Panel1.Controls.Add(tab);

                            Button btn = new Button();
                            btn.Text = "DONE";
                            btn.ID = sdr["appointment_id"].ToString();
                            btn.Click += OnLinkClick;
                            btn.CssClass = "btn btn-success";
                            Panel1.Controls.Add(btn);

                            br = new LiteralControl("<br/> <br/>");
                            Panel1.Controls.Add(br);
                            
                        } 
                    }
                    if(!Panel1.HasControls())
                    {
                        Label lbl = new Label();
                        lbl.Text = "No Record!!";
                        Panel1.Controls.Add(lbl);
                        Panel1.Controls.Add(new LiteralControl("&nbsp;  &nbsp;"));
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error : " + ex.Message);
            }
        }

        protected void OnLinkClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Clinic"].ConnectionString;

            try
            {
                using (con)
                {
                    string query = "update appointments set checked = '" +  1 + "' where appointment_id = " + btn.ID;
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Panel1.Controls.Remove(tab);
                    Panel1.Controls.Remove(br);

                    Response.Redirect("~/pages/pharmacist/pharmacist_dashboard.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error : " + ex.Message);
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            if (Session["username_p"] != null)
            {
                Session.Remove("username_p");
                Response.Redirect("~/pages/login.aspx");
            }
        }
    }
}
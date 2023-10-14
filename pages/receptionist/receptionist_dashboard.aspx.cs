using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medical_ClinicManagementSystem.pages.receptionist
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = (string)Session["username_r"];
        }

        protected void btnAddPatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/receptionist/addNewPatient.aspx");
        }

        protected void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/receptionist/updatePatient.aspx");
        }

        protected void btnAppointment_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/receptionist/appointment.aspx");

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
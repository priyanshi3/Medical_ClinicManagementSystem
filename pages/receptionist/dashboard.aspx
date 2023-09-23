<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Medical_ClinicManagementSystem.pages.receptionist.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnAddPatient" runat="server" OnClick="btnAddPatient_Click" Text="Add New Patient" />
        </div>
        <p>
            <asp:Button ID="btnUpdatePatient" runat="server" OnClick="btnUpdatePatient_Click" Text="Update Patient" />
        </p>
        <asp:Button ID="btnAppointment" runat="server" OnClick="btnAppointment_Click" Text="Appointment" />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addNewPatient.aspx.cs" Inherits="Medical_ClinicManagementSystem.pages.receptionist.addNewPatient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDOB" runat="server" Text="Date of Birth"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDOB" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblPhnNum" runat="server" Text="Contact Number"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtPhnNum" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:RadioButtonList ID="rbGender" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblBloodGrp" runat="server" Text="Blood Group"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddBloodGrp" runat="server">
                        <asp:ListItem Enabled="False" Selected="True">Select Blood Group</asp:ListItem>
                        <asp:ListItem>A+</asp:ListItem>
                        <asp:ListItem>A-</asp:ListItem>
                        <asp:ListItem>B+</asp:ListItem>
                        <asp:ListItem>B-</asp:ListItem>
                        <asp:ListItem>AB+</asp:ListItem>
                        <asp:ListItem>AB-</asp:ListItem>
                        <asp:ListItem>O+</asp:ListItem>
                        <asp:ListItem>O-</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" >
                    <asp:Button ID="btnAddPatient" runat="server" Text="Add Patient" OnClick="btnAddPatient_Click" />
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>

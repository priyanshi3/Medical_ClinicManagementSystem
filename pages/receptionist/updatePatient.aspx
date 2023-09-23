<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updatePatient.aspx.cs" Inherits="Medical_ClinicManagementSystem.pages.receptionist.updatePatient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblSearchfname" runat="server" Text="First Name : "></asp:Label>
            <asp:TextBox ID="txtSearchfname" runat="server"></asp:TextBox>
            <asp:Label ID="lblSearchlname" runat="server" Text="Last Name : "></asp:Label>
            <asp:TextBox ID="txtSearchlname" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
            <table class="auto-style1">
                <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtFirstName" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" Enabled="False"></asp:TextBox>
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
                    <asp:RadioButton ID="rbGenderMale" runat="server" Text="Male" GroupName="gender" />  <br />
                    <asp:RadioButton ID="rbGenderFemale" runat="server" Text="Female" GroupName="gender" />  
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
                    <asp:Button ID="btnUpdatePatient" runat="server" Text="Update Patient" OnClick="btnUpdatePatient_Click" />
                </td>
            </tr>
            </table>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updatePatient.aspx.cs" Inherits="Medical_ClinicManagementSystem.pages.receptionist.updatePatient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <style type="text/css">
        .auto-style1 {
            width: 85%;
            margin: auto;
        }
        .auto-style3 {
            width: 50%;
            text-align: center;
            padding: 10px;
        }
        #form1 {
            margin: auto;
            position: relative;
            max-width: 75%;
            top: 50px;
            /*left: 50%;
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);*/
            border-radius: 25px !important;
			box-shadow: 2px 3px 10px !important;
            padding: 80px 20px !important;
        }
        .auto-style2 {
            width: 55%;
            text-align: center;
            padding: 10px;
        }

        /*logout*/

        .material-symbols-outlined {
          font-variation-settings:
          'FILL' 0,
          'wght' 400,
          'GRAD' 0,
          'opsz' 48
        }

        /*navbar*/
        html,
body {
	margin: 0;
	/*height: 100vh;
	width: 100vw;*/
	
}

body {
	font-family: "Roboto", sans-serif;
	background-image: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
}

h1 {
	margin: 20px 0;
	color: #fff;
}

.center {
	text-align: center;
}

.nav-wrapper {
	display: flex;
	position: relative;
	flex-direction: row;
	flex-wrap: nowrap;
	align-items: center;
	justify-content: space-between;
	margin: auto;
	width: 90%;
	height: 80px;
	border-radius: 0 0 15px 15px;
	padding: 0 25px;
	z-index: 2;
	background: #fff;
	box-shadow: 0 1px 2px rgba(0, 0, 0, 0.2);
}

.logo-container {
	display: flex;
	justify-content: center;
	align-items: center;
}

.logo {
    font-weight: 600;
	font-size: 18px;
}

.nav-tabs {
	display: flex;
	font-weight: 600;
	font-size: 18px;
	list-style: none;
}

.nav-tab:not(:last-child) {
	padding: 10px 25px;
	margin: 0;
	border-right: 1px solid #eee;
}

.nav-tab:last-child {
	padding: 10px 0 0 25px;
}

.nav-tab,
.menu-btn {
	cursor: pointer;
}

.hidden {
	display: none;
}

@media screen and (max-width: 800px) {
	.nav-container {
		position: fixed;
		display: none;
		overflow-y: auto;
		z-index: -1;
		top: 0;
		right: 0;
		width: 280px;
		height: 100%;
		background: #fff;
		box-shadow: -1px 0 2px rgba(0, 0, 0, 0.2);
	}

	.nav-tabs {
		flex-direction: column;
		align-items: flex-end;
		margin-top: 80px;
		width: 100%;
	}

	.nav-tab:not(:last-child) {
		padding: 20px 25px;
		margin: 0;
		border-right: unset;
		border-bottom: 1px solid #f5f5f5;
	}

	.nav-tab:last-child {
		padding: 15px 25px;
	}

	.menu-btn {
		position: relative;
		display: block;
		margin: 0;
		width: 20px;
		height: 15px;
		cursor: pointer;
		z-index: 2;
		padding: 10px;
		border-radius: 10px;
	}

	.menu-btn .menu {
		display: block;
		width: 100%;
		height: 2px;
		border-radius: 2px;
		background: #111;
	}

	.menu-btn .menu:nth-child(2) {
		margin-top: 4px;
		opacity: 1;
	}

	.menu-btn .menu:nth-child(3) {
		margin-top: 4px;
	}

	#menuToggle:checked + .menu-btn .menu {
		transition: transform 0.2s ease;
	}

	#menuToggle:checked + .menu-btn .menu:nth-child(1) {
		transform: translate3d(0, 6px, 0) rotate(45deg);
	}

	#menuToggle:checked + .menu-btn .menu:nth-child(2) {
		transform: rotate(-45deg) translate3d(-5.71429px, -6px, 0);
		opacity: 0;
	}

	#menuToggle:checked + .menu-btn .menu:nth-child(3) {
		transform: translate3d(0, -6px, 0) rotate(-45deg);
	}

	#menuToggle:checked ~ .nav-container {
		z-index: 1;
		display: flex;
		animation: menu-slide-left 0.3s ease;
	}
	@keyframes menu-slide-left {
		0% {
			transform: translateX(200px);
		}
		to {
			transform: translateX(0);
		}
	}
}
    </style>
</head>
<body>
    <form runat="server">
    <header>
        <div class="nav-wrapper">
            <div class="logo-container">
                <div class="logo" > GETWELL CLINIC</div>
            </div>
            <nav>
                <input class="hidden" type="checkbox" id="menuToggle">
                <label class="menu-btn" for="menuToggle">
                    <div class="menu"></div>
                    <div class="menu"></div>
                    <div class="menu"></div>
                </label>
                <div class="nav-container">
                    <ul class="nav-tabs">
                        <li class="nav-tab"><asp:Label ID="lblUser" runat="server" /> </li>
                        <li class="nav-tab">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="s" OnClick="logout_Click" ValidationGroup="none">
                                <span class="material-symbols-outlined">logout</span>
                            </asp:LinkButton>
                        <li>
                    </ul>
                </div>
            </nav>
        </div>
    </header>
    <div id="form1" class="shadow-lg p-3 mb-5 bg-white rounded" >
        <div>
            <br />
            <div style="width: fit-content; margin: 0 auto;" >
                <b> <asp:Label ID="lblSearchfname" runat="server" Text="First Name : "></asp:Label> &nbsp; &nbsp;
                <asp:TextBox ID="txtSearchfname" runat="server"></asp:TextBox> &nbsp;</b><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSearchfname" Display="Dynamic" ErrorMessage="First Name required" ForeColor="Red" ValidationGroup="search"></asp:RequiredFieldValidator>
                <br /> <br />
                <b> <asp:Label ID="lblSearchlname" runat="server" Text="Last Name : "></asp:Label> </b> &nbsp; &nbsp;
                <asp:TextBox ID="txtSearchlname" runat="server"></asp:TextBox> &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSearchlname" Display="Dynamic" ErrorMessage="Last name required" ForeColor="Red" ValidationGroup="search"></asp:RequiredFieldValidator>
                <br /> <br />
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" class="btn btn-info" ValidationGroup="search"/> <br />
            </div>
            <table class="auto-style1">
                <tr>
                <td class="auto-style2">
                    <b> <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label> </b>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtFirstName" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <b> <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label> </b>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtLastName" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <b> <asp:Label ID="lblPhnNum" runat="server" Text="Contact Number"></asp:Label> </b>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtPhnNum" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhnNum" Display="Dynamic" ErrorMessage="Contact Number required" ForeColor="Red" ValidationGroup="update"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPhnNum" Display="Dynamic" ErrorMessage="Must be of 10 digits" ForeColor="Red" ValidationExpression="[0-9]{10}" ValidationGroup="update"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <b> <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label> </b>
                </td>
                <td class="auto-style2">
                    <asp:RadioButton ID="rbGenderMale" runat="server" Text="&nbsp;Male" GroupName="gender" />  <br />
                    <asp:RadioButton ID="rbGenderFemale" runat="server" Text="&nbsp;Female" GroupName="gender" />  
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <b> <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label> </b>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Address required" ForeColor="Red" ValidationGroup="update"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <b> <asp:Label ID="lblBloodGrp" runat="server" Text="Blood Group"></asp:Label> </b>
                </td>
                <td class="auto-style2">
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
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="2" >
                    <asp:Button ID="btnUpdatePatient" runat="server" Text="Update Patient" OnClick="btnUpdatePatient_Click" class="btn btn-primary" ValidationGroup="update"/>
                </td>
                <td class="auto-style3" >
                    &nbsp;</td>
            </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Medical_ClinicManagementSystem.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:clinicConnectionString %>" DeleteCommand="DELETE FROM [appointments] WHERE [appointment_id] = @appointment_id" InsertCommand="INSERT INTO [appointments] ([fname], [lname], [age], [blood_group], [symptoms], [date]) VALUES (@fname, @lname, @age, @blood_group, @symptoms, @date)" ProviderName="<%$ ConnectionStrings:clinicConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [appointments]" UpdateCommand="UPDATE [appointments] SET [fname] = @fname, [lname] = @lname, [age] = @age, [blood_group] = @blood_group, [symptoms] = @symptoms, [date] = @date WHERE [appointment_id] = @appointment_id">
                <DeleteParameters>
                    <asp:Parameter Name="appointment_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="fname" Type="String" />
                    <asp:Parameter Name="lname" Type="String" />
                    <asp:Parameter Name="age" Type="Int32" />
                    <asp:Parameter Name="blood_group" Type="String" />
                    <asp:Parameter Name="symptoms" Type="String" />
                    <asp:Parameter DbType="Date" Name="date" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="fname" Type="String" />
                    <asp:Parameter Name="lname" Type="String" />
                    <asp:Parameter Name="age" Type="Int32" />
                    <asp:Parameter Name="blood_group" Type="String" />
                    <asp:Parameter Name="symptoms" Type="String" />
                    <asp:Parameter DbType="Date" Name="date" />
                    <asp:Parameter Name="appointment_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="appointment_id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="appointment_id" HeaderText="appointment_id" InsertVisible="False" ReadOnly="True" SortExpression="appointment_id" />
                    <asp:BoundField DataField="fname" HeaderText="fname" SortExpression="fname" />
                    <asp:BoundField DataField="lname" HeaderText="lname" SortExpression="lname" />
                    <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
                    <asp:BoundField DataField="blood_group" HeaderText="blood_group" SortExpression="blood_group" />
                    <asp:BoundField DataField="symptoms" HeaderText="symptoms" SortExpression="symptoms" />
                    <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

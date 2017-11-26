<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="WebApp.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome to the Members Page</h1>
        <p>Congratulations in becoming a member. There is currently nothing to do here. Please click the button to go back.</p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
    </div>
    </form>
</body>
</html>

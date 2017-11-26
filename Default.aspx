<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <div>
        <h1>Cookies & Session Testing Page / Register to write on XML</h1>
        <p>Please enter your information. The information will be stored in Cookies</p>
        <p>Name:&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>Email:&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            ________________________________________________________________________________________________________________________</p>
        <p>
            Wiki Finder: Please input a city.</p>
        <p>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            Here is the link to the webstrar site: <a href="http://webstrar48.fulton.asu.edu/index.html" style="font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px;">http://webstrar48.fulton.asu.edu/index.html</a></p>
        <p>
            Here is the link to the tryit page: <a href="http://webstrar48.fulton.asu.edu/page2/">http://webstrar48.fulton.asu.edu/page2/</a></p>
        <p>
            &nbsp;</p>


    </div>

</asp:Content>

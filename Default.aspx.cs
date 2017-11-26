using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Linq;
using System.Xml;

/*
    *IMPORTANT

    Here is the link to the webstrar site:

    http://webstrar48.fulton.asu.edu/index.html



    Here is the link to the tryit page:

    http://webstrar48.fulton.asu.edu/page2/



*/

namespace WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Text = "Login";
            Button2.Text = "Register";
            Button3.Text = "Find";
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if ((myCookies == null) || (myCookies["Name"] == ""))
            {
                Label1.Text = "Welcome, new user";
            }
            else {
                Label1.Text = "Welcome, " + myCookies["Name"];
                Label2.Text = "We have your email " + myCookies["Email"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Storing Cookies
            HttpCookie myCookies = new HttpCookie("myCookieId");
            myCookies["Name"] = TextBox1.Text;
            myCookies["Email"] = TextBox2.Text;
            myCookies.Expires = DateTime.Now.AddMonths(6);
            Response.Cookies.Add(myCookies);
            Label1.Text = "Name stored in cookies " + myCookies["Name"];
            Label2.Text = "Email stored in cookies " + myCookies["Email"];

            //Storing Session
            string fLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Member.xml");
            bool redirect = false;
            string name = TextBox1.Text;
            string email = TextBox2.Text;

             if (File.Exists(fLocation))
            {
                FileStream fS = new FileStream(fLocation, FileMode.Open, FileAccess.Read, FileShare.Read);
                XmlDocument xd = new XmlDocument();
                xd.Load(fS);
                XmlNode node = xd;
                XmlNodeList children = node.ChildNodes;
                //Check to see if account is registered (Search Functionality)
                foreach (XmlNode child in children.Item(1))
                {
                    if (TextBox1.Text == child.FirstChild.InnerText)
                    {
                        if (TextBox2.Text == child.LastChild.InnerText)
                        {
                            //Storing Cookies Again
                            myCookies["Username"] = TextBox1.Text;
                            myCookies["Password"] = TextBox2.Text;

                            //Storing Session
                            Session["Name"] = TextBox1.Text;
                            Session["Email"] = TextBox2.Text;
                            
                            myCookies.Expires = DateTime.Now.AddMonths(6);
                            Response.Cookies.Add(myCookies);
                            
                            redirect = true;
                            Label1.Text = "Your username and email is correct!";
                            Response.Redirect("Member.aspx");
                        }
                    }
                }
                fS.Close();
            }
            if (redirect == false) {
                Label1.Text = "Your username or email is incorrect!";
                Label2.Text = "";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string fLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Member.xml");
            string name = TextBox1.Text;
            string email = TextBox2.Text;
            bool registered = false;
            //Check to see if they have already registered (Search Functionality)
            if (File.Exists(fLocation))
            {
                FileStream fS = new FileStream(fLocation, FileMode.Open, FileAccess.Read, FileShare.Read);
                XmlDocument xd = new XmlDocument();
                xd.Load(fS);
                XmlNode node = xd;
                XmlNodeList children = node.ChildNodes;
                foreach (XmlNode child in children.Item(1))
                {
                    if (TextBox1.Text == child.FirstChild.InnerText)
                    {
                        if (TextBox2.Text == child.LastChild.InnerText)
                        {
                            registered = true;
                        }
                    }
                }
                fS.Close();
                if (!registered)
                {
                    //Add Account to Members.xml
                    XDocument xDocument = XDocument.Load(fLocation);
                    XElement root = xDocument.Element("Members");
                    IEnumerable<XElement> rows = root.Descendants("Member");
                    XElement firstRow = rows.First();
                    firstRow.AddBeforeSelf(
                       new XElement("Member",
                       new XElement("Name", name),
                       new XElement("Email", email)));
                    xDocument.Save(Server.MapPath("App_Data/Member.xml"));
                    Label1.Text = "Congratulations, you are now a member.";
                    Label2.Text = "Please hit the login button.";
                }
                else
                {
                    Label1.Text = "You have already registered.";
                    Label2.Text = "Please hit the login button.";
                }
            }
            else
            {
                Label1.Text = "There is no Member.xml document";
                Label2.Text = "";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //ServiceReference Wiki = new ServiceReference();
            Wiki.Service1Client service3 = new Wiki.Service1Client();
            try { Label4.Text = service3.GetData(TextBox3.Text); }
            catch (Exception ec) { Label4.Text = ec.Message.ToString(); }
        }
    }
}
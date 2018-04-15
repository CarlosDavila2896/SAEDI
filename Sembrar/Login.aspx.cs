using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sembrar
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string u = (string)Session["us"];
                    if (u.CompareTo("") != 0)
                    {
                        Response.Write("<script>window.alert('" + u + "');</script>");
                        u = "";
                        Session.Add("us", u);
                    }
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRESS
{
    public partial class PayrollCurrent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = Request.QueryString["uid"];
            if (userid != null)
            {
               // Response.Write("Welcome " + userid);
            }

        }
    }
}
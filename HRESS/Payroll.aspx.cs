using System;

namespace HRESS
{
    public partial class Payroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string empNo = ClassLib1.Decrypt(Request.QueryString["empNo"]);

        }
    }
}
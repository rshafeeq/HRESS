using System;

namespace HRESS
{
    public partial class TempLinks : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            const string empNo = "4328";
            
            Response.Redirect("Payroll.aspx?empNo=" + ClassLib1.Encrypt(empNo));
        }
    }
}
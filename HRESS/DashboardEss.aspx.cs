using System;
using System.Threading;
using System.Web.UI;

namespace HRESS
{
    public partial class Dashboardess : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Response.Write("Sleep for 2 seconds.");
                Thread.Sleep(1000);
            }

            Response.Write("Main thread exits.");
        }
    }
}
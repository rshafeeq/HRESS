using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRESS
{
    public partial class DashboardAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetGenderList();
            GetEmployeeStatus();
            GetEmployeeBU();
        }

        public void GetGenderList()
        {
            var dtGenderList = new DataTable();
            string constr = ConfigurationManager.AppSettings["conStr2"];

            using (var con = new SqlConnection(constr))
            {
                using (var cmd = new SqlCommand("SELECT 'Male' Gender, count(*) Count FROM [EmployeeInformation] " +
                                                "where gender='M' and ESTAT in (1,2,'',null) " +
                                                "Union SELECT 'Female' Gender, count(*) Count FROM [EmployeeInformation] " +
                                                "where gender='F' and ESTAT in (1,2,'',null) " +
                                                "Union SELECT 'Not Defined' Gender, count(*) Count FROM " +
                                                "[EmployeeInformation] where gender In('',null) and ESTAT in (1,2,'',null)")
                    )
                {
                    using (var sda = new SqlDataAdapter())
                    {
                        try
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dtGenderList);
                            grvGenderDetails.DataSource = dtGenderList;
                            grvGenderDetails.DataBind();

                            chGenderStatus.DataSource = dtGenderList;
                            chGenderStatus.Series["Series1"].XValueMember = "Gender";
                            chGenderStatus.Series["Series1"].YValueMembers = "Count";
                            chGenderStatus.DataBind();
                         
                        }
                        finally
                        {
                            cmd.Dispose();
                            con.Close();
                        }

                    }
                }

            }
        }

        public void GetEmployeeStatus()
        {
            var dtEmpStatus = new DataTable();
            string constr = ConfigurationManager.AppSettings["conStr2"];

            using (var con = new SqlConnection(constr))
            {
                using (var cmd = new SqlCommand("SELECT 'Active' Status, count(*) Count FROM [EmployeeInformation] " +
                                                "where ESTAT = 1  Union SELECT 'Vacation' Status, count(*) Count FROM [EmployeeInformation] " +
                                                "where ESTAT =2  Union SELECT 'Hold' Status, count(*) Count FROM [EmployeeInformation] " +
                                                "where ESTAT =3"))
                {
                    using (var sda = new SqlDataAdapter())
                    {
                        try
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dtEmpStatus);
                            grvEmpStatus.DataSource = dtEmpStatus;
                            grvEmpStatus.DataBind();
                            chEmpStatus.DataSource = dtEmpStatus;
                            chEmpStatus.Series["Series1"].XValueMember = "Status";
                            chEmpStatus.Series["Series1"].YValueMembers = "Count";
                            chEmpStatus.DataBind();
                        }
                        finally
                        {
                            cmd.Dispose();
                            con.Close();
                        }

                    }
                }

            }

        }

        public void GetEmployeeBU()
        {
            var dtEmpBU = new DataTable();
            string constr = ConfigurationManager.AppSettings["conStr2"];

            using (var con = new SqlConnection(constr))
            {
                using (
                    var cmd =
                        new SqlCommand("Select BusinessUnitCode, Count(*) Count from EmployeeInformation " +
                                       "where Estat in (1,2) group by BusinessUnitCode " +
                                       "order by BusinessUnitCode"))
                {
                    using (var sda = new SqlDataAdapter())
                    {
                        try
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dtEmpBU);
                            grvEmpBusinessUnit.DataSource = dtEmpBU;
                            grvEmpBusinessUnit.DataBind();
                             //chEmpBusinessUnit.DataSource = dtEmpBU;
                             // chEmpBusinessUnit.Series["Series1"].XValueMember = "BusinessUnitName";
                             // chEmpBusinessUnit.Series["Series1"].YValueMembers = "Count";
                             //chEmpBusinessUnit.DataBind();
                        }
                        finally
                        {
                            cmd.Dispose();
                            con.Close();
                        }

                    }
                }

            }
        }

        protected void grvEmpBusinessUnit_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            grvEmpBusinessUnit.PageIndex = e.NewPageIndex;
            grvEmpBusinessUnit.DataBind();
        }
        public string Replace(string BU)
        {
            string strBusinessUnit = BU.Replace("&", "and");
            return strBusinessUnit;
        }

        protected void grvEmpStatus_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
           
            string strCount = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Count"));
            var lnk2 = (HyperLink)e.Row.FindControl("HyperLink1");
            if (strCount == "0")
            {
                lnk2.Enabled = false;
            }
            
        }

        protected void grvGenderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string strCount = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Count"));
            var lnk2 = (HyperLink)e.Row.FindControl("HyperLink1");
            if (strCount == "0")
            {
                lnk2.Enabled = false;
            }
        }

        protected void grvEmpBusinessUnit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string strCount = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Count"));
            var lnk2 = (HyperLink)e.Row.FindControl("HyperLink1");
            if (strCount == "0")
            {
                lnk2.Enabled = false;
            }
        }

       
    }
}
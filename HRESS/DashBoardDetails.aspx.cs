using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HRESS
{
    public partial class DashBoardDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strType = Request.QueryString["GridType"];
            string strParam = Request.QueryString["Param"];
            switch (strType)
            {
                case "Gender":
                    GetGenderList(strParam);
                    break;
                case "Active":
                    GetEmployeeStatusDetails(strParam);
                    break;
                case "BU":
                    GetEmployeeBu(strParam);
                    break;


            }
        }
        public void GetGenderList(string gender)
        {
            string sql;
            switch (gender)
            {
                case "Male":
                    gender = "M";
                    sql = "Select Fullname,EmployeeNumber, Case when Gender='M' then 'Male' when Gender='F' then 'Female' else 'Not Defined' end [Gender] from EmployeeInformation where Gender='" + gender + "' and EStat in (1,2) order by EmployeeNumber";
                    break;
                case "Female":
                    gender = "F";
                    sql = "Select Fullname,EmployeeNumber, Case when Gender='M' then 'Male' when Gender='F' then 'Female' else 'Not Defined' end [Gender] from EmployeeInformation where Gender='" + gender + "' and EStat in (1,2) order by EmployeeNumber";
                    break;
                default:
                    sql = "Select Fullname,EmployeeNumber, Case when Gender='M' then 'Male' when Gender='F' then 'Female' else 'Not Defined' end [Gender] from EmployeeInformation where Gender not in ('M','F') and EStat in (1,2) order by EmployeeNumber";
                    break;
            }
            var dtGenderList = new DataTable();
            string constr = ConfigurationManager.AppSettings["conStr2"];

            using (var con = new SqlConnection(constr))
            {
                using (var cmd = new SqlCommand(sql)
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
                            grvDetails.DataSource = dtGenderList;
                            grvDetails.DataBind();

                         
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
        public void GetEmployeeStatusDetails(string strEstat)
        {
            switch (strEstat)
            {
                case "Active":
                    strEstat = "1";
                    break;
                case "Vacation":
                    strEstat = "2";
                    break;
                default:
                    strEstat = "3";
                    break;

            }
            var dtEmpStatus = new DataTable();
            string constr = ConfigurationManager.AppSettings["conStr2"];

            using (var con = new SqlConnection(constr))
            {
                using (var cmd = new SqlCommand("Select Fullname ,EmployeeNumber from EmployeeInformation where ESTAT=" + strEstat + " order by EmployeeNumber"))
                {
                    using (var sda = new SqlDataAdapter())
                    {
                        try
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dtEmpStatus);
                            grvDetails.DataSource = dtEmpStatus;
                            grvDetails.DataBind();
                            
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
        public void GetEmployeeBu(string strBuName)
        {
            var dtEmpBu = new DataTable();
            string constr = ConfigurationManager.AppSettings["conStr2"];

            using (var con = new SqlConnection(constr))
            {
                using (
                    var cmd =
                        new SqlCommand("Select  BusinessUnitName [BU Name],Fullname [Emp Name], EmployeeNumber [Emp Number] from EmployeeInformation where BusinessUnitCode='" + strBuName + "' and Estat in (1,2) Order by EmployeeNumber"))
                {
                    using (var sda = new SqlDataAdapter())
                    {
                        try
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dtEmpBu);
                            grvDetails.DataSource = dtEmpBu;
                            grvDetails.DataBind();
                            
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
    }
}
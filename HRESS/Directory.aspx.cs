using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.Web.UI;
using HRESS.vdell2001;

namespace HRESS
{
    public partial class Directory : Page
    {
        public static int Empno { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BinddllJobTitle();
                BinddllLocation();
                BindOnLoad();
            }
        }

        #region *****************DataBase Access**************************
        public static DataTable GetLineManagers(int empNo)
        {
            var con = new SqlConnection(ConfigurationManager.AppSettings["conStr2"]);
            var cmd = new SqlCommand();
            var da = new SqlDataAdapter();
            var dtLineManagers = new DataTable();
            try
            {
                cmd = new SqlCommand("sp_getLineManagers", con);
                cmd.Parameters.Add(new SqlParameter("@EmpNo", empNo));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dtLineManagers);
            }

            finally
            {
                cmd.Dispose();
                con.Close();
            }
            return dtLineManagers;
        }

        public static string GetPhone(int empNo)
        {
            var con = new SqlConnection(ConfigurationManager.AppSettings["conStr1"]);
            var cmd = new SqlCommand();
            var da = new SqlDataAdapter();
            var dt = new DataTable();
            string strPhoneNumber;
            try
            {
                cmd = new SqlCommand("sp_GetEmployeePhones", con);
                cmd.Parameters.Add(new SqlParameter("@EmpNo", empNo));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
                strPhoneNumber = dt.Rows.Count > 0 ? dt.Rows[0]["PHONENUMBER"].ToString() : "";
            }

            finally
            {
                cmd.Dispose();
                con.Close();
            }
            return strPhoneNumber;
        }

        private DataTable GetPicture(int empNumber)
        {
            var dtGetPicture = new DataTable();
            string constr = ConfigurationManager.AppSettings["conStr1"];

            using (var con = new SqlConnection(constr))
            {
                using (var cmd = new SqlCommand("SELECT [epic_picture]  " +
                                                "FROM [HRESS].[dbo].[hs_hr_emp_picture] where emp_number = " + empNumber +
                                                ""))
                {
                    using (var sda = new SqlDataAdapter())
                    {
                        try
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dtGetPicture);
                        }
                        finally
                        {
                            cmd.Dispose();
                            con.Close();
                        }

                    }
                }
                return dtGetPicture;
            }
        }

        private DataTable GetEmpLoad()
        {
            var dtGetPicture = new DataTable();
            string constr = ConfigurationManager.AppSettings["conStr2"];

            using (var con = new SqlConnection(constr))
            {
                using (
                    var cmd =
                        new SqlCommand(
                            "select Fullname ,JobFunctionName,CompanyName, BranchName from employeeinformation where ESTAT in (1,2) order by Fullname")
                    )
                {
                    using (var sda = new SqlDataAdapter())
                    {
                        try
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dtGetPicture);
                        }
                        finally
                        {
                            cmd.Dispose();
                            con.Close();
                        }

                    }
                }
                return dtGetPicture;
            }
        }

        private DataTable GetEmpLoadOnSearch(string strQuery)
        {
            var dtGetPicture = new DataTable();
            string constr = ConfigurationManager.AppSettings["conStr2"];

            using (var con = new SqlConnection(constr))
            {
                using (var cmd = new SqlCommand(strQuery))
                {
                    using (var sda = new SqlDataAdapter())
                    {
                        try
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dtGetPicture);
                        }
                        finally
                        {
                            cmd.Dispose();
                            con.Close();
                        }

                    }
                }
                return dtGetPicture;
            }
        }

        private DataTable GetJobTitles()
        {
            var dtGetPicture = new DataTable();
            string constr = ConfigurationManager.AppSettings["conStr2"];

            using (var con = new SqlConnection(constr))
            {
                using (
                    var cmd =
                        new SqlCommand(
                            "Select '0' [JobFunctionCode],' --Select-- ' [JobFunctionName] union SELECT Distinct [JobFunctionCode] , Replace([JobFunctionName],'.','')as [JobFunctionName] FROM [EmployeeInformation] where JobFunctionName<>null or (JobFunctionName<>'' and ltrim(JobFunctionName)<>'.') and JobFunctionCode<>'' order by JobFunctionName")
                    )
                {
                    using (var sda = new SqlDataAdapter())
                    {
                        try
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dtGetPicture);
                        }
                        finally
                        {
                            cmd.Dispose();
                            con.Close();
                        }

                    }
                }
                return dtGetPicture;
            }
        }

        private DataTable GetLocations()
        {
            var dtGetPicture = new DataTable();
            string constr = ConfigurationManager.AppSettings["conStr2"];

            using (var con = new SqlConnection(constr))
            {
                using (
                    var cmd =
                        new SqlCommand(
                            "Select '0' CityCode,' --Select-- ' CityName union SELECT Distinct CityCode , CityName FROM [EmployeeInformation]  where Ltrim(CityName)<>'.' order by CityName")
                    )
                {
                    using (var sda = new SqlDataAdapter())
                    {
                        try
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dtGetPicture);
                        }
                        finally
                        {
                            cmd.Dispose();
                            con.Close();
                        }

                    }
                }
                return dtGetPicture;
            }
        }

        #endregion

        #region  *****************Button Click*********************

        protected void btnReset_Click(object sender, EventArgs e)
        {
            BinddllJobTitle();
            BinddllLocation();
            txtEmpName.Text = "";
            BindOnLoad();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                var objWsempinfo = new wsempinfo();
                string strTxtSearch = txtEmpName.Text;
                string[] strEmpNoSearch = strTxtSearch.Split(':');
                string empNo = strEmpNoSearch[1];
                Empno = Convert.ToInt32(empNo);
                DataTable dtEmpInfo = objWsempinfo.GetEmployeeInfo(empNo, "UID");

                // txtFullname.Text = dtEmpInfo.Rows[0]["FullName"].ToString();
                // txtEmployeeID.Text = dtEmpInfo.Rows[0]["EmployeeNumber"].ToString();

                // txtBusinessUnit.Text = dtEmpInfo.Rows[0]["BusinessUnitName"].ToString();
                //  txtCompany.Text = dtEmpInfo.Rows[0]["CompanyName"].ToString();
                //  txtDesignation.Text = dtEmpInfo.Rows[0]["JobFunctionName"].ToString();

                // txtJobTitle.Text = dtEmpInfo.Rows[0]["UserName"].ToString();
                string username = dtEmpInfo.Rows[0]["UserName"].ToString();
                string[] splitEmai = username.Split('/');
                // txtEmail.Text = splitEmai[1] + "@sara.com.sa";
                // txtLocation.Text = dtEmpInfo.Rows[0]["BranchName"].ToString();
                // txtPhone.Text = GetPhone(Convert.ToInt32(empNo));

                DataTable dtLineManager = GetLineManagers(Convert.ToInt32(empNo));
                // txtLineManager.Text = dtLineManager.Rows[0]["fullname"].ToString();
                int id = Empno;
                imgEmployee.Visible = id != 0;
                if (id != 0)
                {
                    var bytes = (byte[]) (GetPicture(Empno).Rows[0]["epic_picture"]);
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    imgEmployee.ImageUrl = "data:image/png;base64," + base64String;


                }
                txtEmpName.Text = "";
            }
            catch (IndexOutOfRangeException)
            {

                lblMessage.Text = "Please Select correct Employee from the list";
            }
            catch (SqlException)
            {
                lblMessage.Text = "There is some technical issue please contact IT Team for Support";
            }

        }

        #endregion

        #region ******************Bind Controls*********

        public void BinddllJobTitle()
        {
            DataTable dtJobTitle = GetJobTitles();
            ddlJobTitle.DataSource = dtJobTitle.DefaultView;
            ddlJobTitle.DataTextField = "JobFunctionName";
            ddlJobTitle.DataValueField = "JobFunctionCode";
            ddlJobTitle.DataBind();
        }

        public void BinddllLocation()
        {
            DataTable dtLocation = GetLocations();
            ddlLocation.DataSource = dtLocation.DefaultView;
            ddlLocation.DataTextField = "CityName";
            ddlLocation.DataValueField = "CityCode";
            ddlLocation.DataBind();
        }

        public void BindOnLoad()
        {
            var sbEmpDetails = new StringBuilder();
            DataTable dtEmployeeDetails = GetEmpLoad();
            sbEmpDetails.Append("<table cellspacing='15'>");
            for (int i = 0; i <= dtEmployeeDetails.Rows.Count - 1; i++)
            {
                sbEmpDetails.Append("<tr><td style='font-weight: bold'>" + dtEmployeeDetails.Rows[i]["Fullname"] +
                                    "</td></tr>");
                for (int j = 1; j <= dtEmployeeDetails.Columns.Count - 1; j++)
                {
                    sbEmpDetails.Append("<tr><td>" + dtEmployeeDetails.Rows[i][j] + "</td></tr>");
                }
                sbEmpDetails.Append("<tr><td><hr></td></tr>");

            }
            sbEmpDetails.Append("</table>");
            divContent.InnerHtml = sbEmpDetails.ToString();

        }

        public void BindOnSearch()
        {
            if (txtEmpName.Text != "")
            {
                string strTxtSearch = txtEmpName.Text;
                string[] strEmpNoSearch = strTxtSearch.Split(':');
                string empNo = strEmpNoSearch[1];
                Empno = Convert.ToInt32(empNo);
            }
            var strQuery = new StringBuilder();
            strQuery.Append(
                "select Fullname ,JobFunctionName,CompanyName, BranchName from employeeinformation where ESTAT in (1,2) ");
            
            if (txtEmpName.Text != "" && ddlJobTitle.SelectedValue != "0" && ddlLocation.SelectedValue != "0")
            {
                strQuery.Append(" and EmployeeNumber= " + Empno + " and JobFunctionCode ='" + ddlJobTitle.SelectedValue + "' and CityCode='" +
                                ddlLocation.SelectedValue + "'");
            }
            else if (txtEmpName.Text == "" && ddlJobTitle.SelectedValue != "0" && ddlLocation.SelectedValue != "0")
            {
                strQuery.Append( " and JobFunctionCode ='" + ddlJobTitle.SelectedValue + "' and CityCode='" +
                                ddlLocation.SelectedValue + "'");
            }
            else if (txtEmpName.Text != "" && ddlJobTitle.SelectedValue == "0" && ddlLocation.SelectedValue == "0")
            {
                strQuery.Append(" and EmployeeNumber="+ Empno);
            }
            else if (txtEmpName.Text == "" && ddlJobTitle.SelectedValue != "0" && ddlLocation.SelectedValue == "0")
            {
                strQuery.Append(" and JobFunctionCode ='" + ddlJobTitle.SelectedValue + "'");
            }

            else if (txtEmpName.Text == "" && ddlJobTitle.SelectedValue == "0" && ddlLocation.SelectedValue != "0")
            {
                strQuery.Append(" and CityCode ='" + ddlLocation.SelectedValue + "'");

            }
            else if (txtEmpName.Text != "" && ddlJobTitle.SelectedValue != "0" && ddlLocation.SelectedValue == "0")
            {
                strQuery.Append(" and EmployeeNumber ='" + Empno + "' and JobFunctionCode= '"+ddlJobTitle.SelectedValue+"'");

            }
            else if (txtEmpName.Text != "" && ddlJobTitle.SelectedValue == "0" && ddlLocation.SelectedValue != "0")
            {
                strQuery.Append(" and EmployeeNumber ='" + Empno + "' and CityCode= '" + ddlLocation.SelectedValue + "'");

            }
            strQuery.Append(" order by Fullname");
            var sbEmpDetails = new StringBuilder();
            DataTable dtEmployeeDetails = GetEmpLoadOnSearch(strQuery.ToString());
            sbEmpDetails.Append("<table cellspacing='15'>");
            for (int i = 0; i <= dtEmployeeDetails.Rows.Count - 1; i++)
            {
                sbEmpDetails.Append("<tr><td style='font-weight: bold'>" + dtEmployeeDetails.Rows[i]["Fullname"] +
                                    "</td></tr>");
                for (int j = 1; j <= dtEmployeeDetails.Columns.Count - 1; j++)
                {
                    sbEmpDetails.Append("<tr><td>" + dtEmployeeDetails.Rows[i][j] + "</td></tr>");
                }
                sbEmpDetails.Append("<tr><td><hr></td></tr>");

            }
            sbEmpDetails.Append("</table>");
            
            divContent.InnerHtml = sbEmpDetails.ToString();
            

        }

       

    #endregion
        #region  *****************Web Method*********************
        [WebMethod]
        public static List<string> GetEmployeeName(string empName)
        {
            var empResult = new List<string>();
            using (var con = new SqlConnection(ConfigurationManager.AppSettings["conStr2"]))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText =
                        "SELECT  top 50 LTRIM(RTRIM([FullName])) + ':' + convert (varchar(8),EmployeeNumber) as [FullName]  FROM [EmployeeInformation] where estat in (1,2) and (EmployeeNumber like '%'+@SearchEmpName+'%' or  FullName LIKE '%'+@SearchEmpName+'%')";
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchEmpName", empName);
                    try
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            empResult.Add(dr["FullName"].ToString());
                        }
                    }
                    finally
                    {
                        con.Close();
                        cmd.Dispose();

                    }
                    return empResult;

                }
            }
        }
        #endregion

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            //GetEmpLoadOnSearch();
            BindOnSearch();
        }

       

    }
}


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayrollCurrent.aspx.cs" Inherits="HRESS.PayrollCurrent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Current Payroll</title>
    <link href="CSSJQ/jquery-ui.css" rel="stylesheet" />
    <script src="CSSJQ/external/jquery/jquery.js"></script>
    <script src="CSSJQ/jquery-ui.js"></script>
    </head>
<body>
    <form id="form1" runat="server">
        <div >

           <td rowspan="2" style="vertical-align: top; padding-left: 10px;">
                        <div id="divMainContainer" style="border: 1px solid lightblue; padding: 2px;">
                            <asp:Label ID="lblPayroll" runat="server"></asp:Label>
                            <hr />
                            <div class="ui-widget">
                                <table cellspacing="15">
                                    <tr>
                                        <td>Full Name</td>
                                        <td>
                                            <asp:TextBox ID="txtFullname" runat="server" />
                                        </td>
                                        <td>Arabic</td>
                                        <td>
                                            <asp:TextBox ID="txtArabicName" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <hr /></td>
                                    </tr>
                                    <tr>
                                        <td>Employee ID</td>
                                        <td>
                                            <asp:TextBox ID="txtEmployeeID" runat="server" />
                                        </td>
                                        <td>Job Title</td>
                                        <td>
                                            <asp:TextBox ID="txtJobTitle" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Bank Account</td>
                                        <td>
                                            <asp:TextBox ID="txtBankAccount" runat="server" />
                                        </td>
                                        <td>Bank Name</td>
                                        <td>
                                            <asp:TextBox ID="txtBankName" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Payslip </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <hr /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>

        </div>
    </form>
</body>
</html>

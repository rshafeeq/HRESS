<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Directory.aspx.cs" Inherits="HRESS.Directory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Directory</title>
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <link href="CSSJQ/jquery-ui.css" rel="stylesheet" />
    <script src="CSSJQ/external/jquery/jquery.js"></script>
    <script src="CSSJQ/jquery-ui.js"></script>
  
    
    <script type="text/javascript">
        
        $(document).ready(function () {
            SearchText();
        });
        function SearchText() {
            $("#txtEmpName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Directory.aspx/GetEmployeeName",
                        data: "{'empName':'" + document.getElementById('txtEmpName').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert("No Match");
                        }
                    });
                }
            });
        }

       
    </script>
    
     <script type="text/javascript">

       
       /* */
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 33px;
        }

        .auto-style2 {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="divMainContainer" style="border: 1px solid lightblue; padding: 2px;">
                <asp:Label ID="lblDirectory" runat="server"></asp:Label>
                <hr />
                <div class="ui-widget">
                    <table cellspacing="15">
                        <tr>
                            <td>Emp Name</td>
                            <td>
                                Job Title</td>
                            <td>
                                Location</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEmpName" runat="server" Width="216px" Height="17px" />
                                </td>
                            <td>
                                <asp:DropDownList ID="ddlJobTitle" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlLocation" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/key_enter.png" OnClick="ImageButton1_Click" Visible="False" />
                                <asp:Button ID="btnSearch1" runat="server" Text="Search" OnClick="btnSearch1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" class="auto-style1">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="auto-style1">
                               <div runat="server" id="divContent">
                                   
                               </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style2">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:Image ID="imgEmployee" runat="server" Height="80px" Width="70px" Visible="False" />
                            </td>
                            <td class="auto-style2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" class="auto-style1">
                                <hr />
                            </td>
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
        </div>
    </form>
</body>
</html>

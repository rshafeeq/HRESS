<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashboardAdmin.aspx.cs" Inherits="HRESS.DashboardAdmin" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
     <title>DashboardAdmin</title>
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <link href="CSSJQ/jquery-ui.css" rel="stylesheet" />
    <script src="CSSJQ/external/jquery/jquery.js"></script>
    <script src="CSSJQ/jquery-ui.js"></script>
     <style type="text/css">
         .auto-style1 {
             width: 100%;
         }
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 20%">
                    <asp:GridView ID="grvGenderDetails" runat="server" AutoGenerateColumns="False" Width="300px" DataKeyNames="Gender" OnRowDataBound="grvGenderDetails_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                            <asp:BoundField DataField="Count" HeaderText="Count" />
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# String.Format("~/DashBoardDetails.aspx?Param={0}&GridType={1}", Eval("Gender"),"Gender") %>'  Text="List"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    <asp:Chart ID="chGenderStatus" runat="server" Height="146px" Width="200px" Visible="False">
                        <series>
                            <asp:Series ChartType="Pie" Name="Series1">
                            </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </chartareas>
                    </asp:Chart>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grvEmpStatus" runat="server" AutoGenerateColumns="False" Width="300px" OnRowDataBound="grvEmpStatus_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:BoundField DataField="Count" HeaderText="Count" />
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# String.Format("~/DashBoardDetails.aspx?Param={0}&GridType={1}", Eval("Status"),"Active") %>' Text="List"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    <asp:Chart ID="chEmpStatus" runat="server" Height="156px" Width="200px" Visible="False">
                        <series>
                            <asp:Series ChartType="Pie" Name="Series1">
                            </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </chartareas>
                    </asp:Chart>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grvEmpBusinessUnit" runat="server" AutoGenerateColumns="False" Width="300px" DataKeyNames="BusinessUnitCode" AllowPaging="True" OnPageIndexChanging="grvEmpBusinessUnit_PageIndexChanging" OnRowDataBound="grvEmpBusinessUnit_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="BusinessUnitCode" HeaderText="BusinessUnit" />
                            <asp:BoundField DataField="Count" HeaderText="Count" />
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# String.Format("~/DashBoardDetails.aspx?Param={0}&GridType={1}", Eval("BusinessUnitCode"),"BU") %>' Text="List"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

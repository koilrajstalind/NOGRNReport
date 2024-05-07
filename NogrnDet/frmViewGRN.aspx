<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmViewGRN.aspx.cs" EnableEventValidation="false" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<style>
body {
width: 100%;
margin: 5px;
}

.table-condensed1 tr th {
border: 0px solid #AED6F1;
color: black;
background-color: #AED6F1;
font-family: Arial, Helvetica, sans-serif;
font-size: x-small;
}

.table-condensed1, .table-condensed1 tr td {
border: 0px solid #AED6F1;
font-family: Arial, Helvetica, sans-serif;
font-size: x-small;
}

tr:nth-child(even) {
background: #fff
}

tr:nth-child(odd) {
background: #D6EAF8;
}
</style>
<%--<style>
    $(document).ready(function () {
            var gridHeader = $('#<%=GrdItemDetails.ClientID%>').clone(true); // Here Clone Copy of Gridview with style
            $(gridHeader).find("tr:gt(0)").remove(); // Here remove all rows except first row (header row)
            $('#<%=GrdItemDetails.ClientID%> tr th').each(function (i) {
                // Here Set Width of each th from gridview to new table(clone table) th 
                $("th:nth-child(" + (i + 1) + ")", gridHeader).css('width', ($(this).width()).toString() + "px");
            });
            $("#GHead").append(gridHeader);
            $('#GHead').css('position', 'absolute');
            $('#GHead').css('top', $('#<%=GrdItemDetails.ClientID%>').offset().top);

        });

</style>--%>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-default">
            <br />
            <br />
            <div class="table-responsive"> 
                <div style="height:30px; padding-left:15px;"> 
                    <table style="font-family:Arial, Helvetica, sans-serif;font-size:medium;color:white;width:99%;" >
                        <tr style="background-color:#507CD1;font-family:Arial, Helvetica, sans-serif;font-size:medium;font-weight:bold;">
                            <td style="width:95%;text-align:center;">Customer Wise NO GRN Details as on <asp:Label ID="lbldate" runat="server"></asp:Label></td> 
                            <td style="text-align:right;">                            
                                 <asp:ImageButton ID="b1" runat="server" ToolTip="Export to excel" ImageUrl="~/Images/xl.jpg" Height="23px" Width="25px" ImageAlign="Right" OnClick="b1_Click" />
                            </td>
                        </tr>
                    </table>
                  </div>
                <div style="height:35px; padding-left:15px;"> 
                <%--<table id="nogrnpodststbl" style="font-family:Arial, Helvetica, sans-serif;font-size:x-small;color:white;width:150%;" >
                    <tr style="background-color:#507CD1;font-family:Arial, Helvetica, sans-serif;font-size:x-small;font-weight:bold;">
                        <td style="width:3%;text-align:center;">S.No</td>
                        <td style="width:4%;text-align:center;">Plant</td>
                        <td style="width:4%;text-align:center;">Line No</td>
                        <td style="width:5%;text-align:center;">Division</td>
                        <td style="width:4%;text-align:center;">Act.Type</td>
                        <td style="width:6%;text-align:center;">Inv No</td>
                        <td style="width:4%;text-align:center;">Date</td>
                        <td style="width:5%;text-align:center;">Cust.Code</td>
                        <td style="width:8%;text-align:center;">Cust.Name</td>
                        <td style="width:5%;text-align:center;">Cust.Group</td>
                        <td style="width:4%;text-align:center;">GST Inv.No</td>
                        <td style="width:4%;text-align:center;">Age</td>                        
                        <td style="width:5%;text-align:center;">Age Grp</td>
                        <td style="width:5%;text-align:center;">Sales Value</td>
                        <td style="width:3%;text-align:center;">CGST</td>
                        <td style="width:3%;text-align:center;">SGST</td>
                        <td style="width:3%;text-align:center;">IGST</td>
                        <td style="width:4%;text-align:center;">Dr.Val</td>
                        <td style="width:5%;text-align:center;">POD/BL Sts</td>
                        <td style="width:5%;text-align:center;">Mat.Code</td>
                        <td style="width:5%;text-align:center;">Cust.Matrl Code</td>
                        <td style="width:7%;text-align:center;">Description</td>
                        <td style="width:4%;text-align:center;">Quantity</td>
                        <td style="width:5%;text-align:center;">Cust PO.No</td>
                        <td style="width:4%;text-align:center;">Date</td>
                        <td style="width:4%;text-align:center;">LR.No</td>
                        <td style="width:5%;text-align:center;">Carrier</td>
                        <td style="width:5%;text-align:center;">POD Sts</td>
                    </tr>
                </table>--%>
             </div>
                <div id="gridcontainr" style="padding-left:15px; max-height:390px; overflow:scroll;">
                    <asp:GridView ID="grdnogrn" runat="server" CssClass="table-condensed1" emptydatatext="No data available." cellpadding="5" cellspacing="2" Width="150%"
                        AutoGenerateColumns="False" ShowFooter="true">
                     <Columns> 
                         <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="plant" HeaderText="Plant">
                            <HeaderStyle HorizontalAlign="Center" Width="4%"/>
                            <ItemStyle HorizontalAlign="left" Width="4%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="lineitem" HeaderText="Line No">
                            <HeaderStyle HorizontalAlign="Center" Width="4%"/>
                            <ItemStyle HorizontalAlign="left" Width="4%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="devision" HeaderText="Division">
                            <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                            <ItemStyle HorizontalAlign="Left" Width="5%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="acttype" HeaderText="Act.Type">
                            <HeaderStyle HorizontalAlign="Center" Width="4%"/>
                            <ItemStyle HorizontalAlign="Left" Width="4%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="invno" HeaderText="Inv No">
                            <HeaderStyle HorizontalAlign="Center" Width="6%" />
                            <ItemStyle HorizontalAlign="Left" Width="6%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="grndate" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" Width="4%" />
                            <ItemStyle HorizontalAlign="Left" Width="4%"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="custcode" HeaderText="Cust.Code">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="left" Width="5%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="custname" HeaderText="Cust.Name">
                            <HeaderStyle HorizontalAlign="Center" Width="8%" />
                            <ItemStyle HorizontalAlign="Left" Width="8%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="custgrp" HeaderText="Cust.Group">
                            <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                            <ItemStyle HorizontalAlign="Left"  Width="5%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="gstinvno" HeaderText="GST Inv.No">
                            <HeaderStyle HorizontalAlign="Center" Width="4%"/>
                            <ItemStyle HorizontalAlign="Left" Width="4%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="age" HeaderText="Age">
                            <HeaderStyle HorizontalAlign="Center" Width="4%" />
                            <ItemStyle HorizontalAlign="Left" Width="4%"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="agegrp" HeaderText="Age Group">
                            <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                            <ItemStyle HorizontalAlign="left" Width="5%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="salesval" HeaderText="Sales Value">
                            <HeaderStyle CssClass="HeaderCentered" Width="5%" />
                            <ItemStyle HorizontalAlign="Right" Width="5%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="cgstamnt" HeaderText="CGST" ItemStyle-HorizontalAlign="Right">
                            <HeaderStyle CssClass="HeaderCentered" Width="3%"/>
                            <ItemStyle HorizontalAlign="Right" Width="3%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="sgstamnt" HeaderText="SGST">
                            <HeaderStyle CssClass="HeaderCentered" Width="3%"/>
                            <ItemStyle HorizontalAlign="Right" Width="3%"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="igstamnt" HeaderText="IGST">
                            <HeaderStyle CssClass="HeaderCentered" Width="3%" />
                            <ItemStyle HorizontalAlign="Right" Width="3%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="drval" HeaderText="Dr.Val">
                            <HeaderStyle Width="4%" />
                            <ItemStyle HorizontalAlign="Right" Width="4%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="podblsts" HeaderText="POD/BL Sts">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Left" Width="5%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="matcode" HeaderText="Mat.Code">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" Width="5%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="custmatcode" HeaderText="Cust.Matrl Code">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Left" Width="5%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="descptn" HeaderText="Description">
                            <HeaderStyle HorizontalAlign="Center"  Width="7%"/>
                            <ItemStyle HorizontalAlign="Left" Width="7%"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="quantity" HeaderText="Quantity">
                            <HeaderStyle HorizontalAlign="Center"  Width="4%"/>
                            <ItemStyle HorizontalAlign="left" Width="4%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="custpono" HeaderText="Cust PO.No">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Left" Width="5%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="cdate" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" Width="4%" />
                            <ItemStyle HorizontalAlign="Left" Width="4%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="LRNo" HeaderText="LR.No">
                            <HeaderStyle HorizontalAlign="Center" Width="4%" />
                            <ItemStyle HorizontalAlign="Left" Width="4%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="carrier" HeaderText="Carrier">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Left" Width="5%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="podsts" HeaderText="POD Sts">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Left" Width="5%"/>
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" HorizontalAlign="Right" Font-Names="Arial, Helvetica, sans-serif" Font-Size="Small" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1"/>
                    </asp:GridView>
                </div>
                <table style="width:100%; height:24px;">
                    <tr>
                        <td style="background-color:white; text-align:center; padding-right:25px;">                            
                             <asp:Button ID="btnReset" CssClass="button" TabIndex="25" runat="server" Text="Back"
                            ToolTip="Reset The Page" Width="70px"  OnClick="btnReset_Click" />
                        </td>

                    </tr>
                </table>
              </div>
            </div>
            <br />             
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


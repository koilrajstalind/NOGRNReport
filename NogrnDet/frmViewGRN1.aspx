<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmViewGRN1.aspx.cs" Inherits="_Default" %>

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
<style>
.HeaderCentered   {
    text-align: right !important;    
}

</style>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-default">
                <br />
            <div class="panel-heading" style="height:33px; text-align:center;">
                <div style="font-family:Arial, Helvetica, sans-serif;font-size:medium;"><b>Customer Wise NO GRN Details as on <asp:Label ID="lbldate" runat="server"></asp:Label></b></div>
            </div>
            <div class="table-responsive"> 
                 <table style="width:100%; height:24px;">
                    <tr>
                        <td style="background-color:white; text-align:right; padding-right:25px;">                            
                             <asp:ImageButton ID="b1" runat="server" ToolTip="Export to excel" ImageUrl="~/Images/xl.jpg" Height="23px" Width="25px" ImageAlign="Right" OnClick="b1_Click" />
                        </td>

                    </tr>
                </table>
                <br />
                    <asp:GridView ID="grdnogrn" runat="server" CssClass="table-condensed1" emptydatatext="No data available." cellpadding="5" cellspacing="2" Width="150%"
                        AutoGenerateColumns="False" OnPageIndexChanging="OnPaging" AllowPaging="true" ShowFooter="true">
                     <Columns> 
                         <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="plant" HeaderText="Plant">
                            <HeaderStyle HorizontalAlign="Center" Width="4%"/>
                            <ItemStyle HorizontalAlign="left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="lineitem" HeaderText="Line No">
                            <HeaderStyle HorizontalAlign="Center" Width="4%"/>
                            <ItemStyle HorizontalAlign="left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="devision" HeaderText="Division">
                            <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="acttype" HeaderText="Act.Type">
                            <HeaderStyle HorizontalAlign="Center" Width="4%"/>
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="invno" HeaderText="Inv No">
                            <HeaderStyle HorizontalAlign="Center" Width="6%" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="grndate" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" Width="4%" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="custcode" HeaderText="Cust.Code">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="custname" HeaderText="Cust.Name">
                            <HeaderStyle HorizontalAlign="Center" Width="8%" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="custgrp" HeaderText="Cust.Group">
                            <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="gstinvno" HeaderText="GST Inv.No">
                            <HeaderStyle HorizontalAlign="Center" Width="4%"/>
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="age" HeaderText="Age">
                            <HeaderStyle HorizontalAlign="Center" Width="4%" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="agegrp" HeaderText="Age Group">
                            <HeaderStyle HorizontalAlign="Center" Width="5%"/>
                            <ItemStyle HorizontalAlign="left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="salesval" HeaderText="Sales Value">
                            <HeaderStyle CssClass="HeaderCentered" Width="5%" />
                            <ItemStyle HorizontalAlign="Right"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="cgstamnt" HeaderText="CGST" ItemStyle-HorizontalAlign="Right">
                            <HeaderStyle CssClass="HeaderCentered" Width="3%"/>
                            <ItemStyle HorizontalAlign="Right"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="sgstamnt" HeaderText="SGST">
                            <HeaderStyle CssClass="HeaderCentered" Width="3%"/>
                            <ItemStyle HorizontalAlign="Right"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="igstamnt" HeaderText="IGST">
                            <HeaderStyle CssClass="HeaderCentered" Width="3%" />
                            <ItemStyle HorizontalAlign="Right"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="drval" HeaderText="Dr.Val">
                            <HeaderStyle Width="4%" />
                            <ItemStyle HorizontalAlign="Right"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="podblsts" HeaderText="POD/BL Sts">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="matcode" HeaderText="Mat.Code">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" Width="5%"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="custmatcode" HeaderText="Cust.Matrl Code">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="descptn" HeaderText="Description">
                            <HeaderStyle HorizontalAlign="Center"  Width="7%"/>
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="quantity" HeaderText="Quantity">
                            <HeaderStyle HorizontalAlign="Center"  Width="4%"/>
                            <ItemStyle HorizontalAlign="left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="custpono" HeaderText="Cust PO.No">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="cdate" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Center" Width="4%" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="LRNo" HeaderText="LR.No">
                            <HeaderStyle HorizontalAlign="Center" Width="4%" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="carrier" HeaderText="Carrier">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="podsts" HeaderText="POD Sts">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" HorizontalAlign="Right" Font-Names="Arial, Helvetica, sans-serif" Font-Size="Small" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1"/>
                    </asp:GridView>
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


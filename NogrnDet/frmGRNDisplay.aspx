<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="frmGRNDisplay.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">  
<style>
body {
width: 100%;
margin: 5px;
}
.table-condensed1 tr th {
border: 0px solid #AED6F1;
color: black;
background-color: #507CD1;
font-family: Arial, Helvetica, sans-serif;
font-size: small;
}

.table-condensed1, .table-condensed1 tr td {
border: 0px solid #AED6F1;
font-family: Arial, Helvetica, sans-serif;
font-size: small;
}
tr:nth-child(even) {
background: #fff
}
tr:nth-child(odd) {
background: #D6EAF8;
}
.HeaderCentered   {
    text-align: right !important;    
}
</style>
<br />
<br />
 
    
<div id="NOGRNDIV1" Runat="Server" >
     
<br />
<div class="table-responsive" id="NOGRN1" Runat="Server" > 
        <div style="height:30px; padding-left:15px;"> 
        <table style="font-family:Arial, Helvetica, sans-serif;font-size:medium;color:white;width:92%;" >
            <tr style="background-color:#507CD1;font-family:Arial, Helvetica, sans-serif;font-size:medium;font-weight:bold;">
                <td style="width:60%;text-align:center;">NO GRN (Without POD) details as on <asp:Label ID="lbldate" runat="server"></asp:Label></td> 
                <td style="width:12%;text-align:left;"> (Values in Lakhs)</td>                        
                <td style="width:23%;text-align:right;">Total Value : <asp:Label ID="lbltot1" runat="server"></asp:Label></td>
                <td style="text-align:right;">                            
                        <asp:ImageButton ID="b1" runat="server" ToolTip="Export to excel" ImageUrl="~/Images/xl.jpg" Height="23px" Width="25px" ImageAlign="Right" OnClick="b1_Click" />
                </td>
            </tr>
        <tr><td></td></tr>
        </table>
        </div>
    <div style="height:30px; padding-left:15px;"> 
        <table id="nogrntbl" style="font-family:Arial, Helvetica, sans-serif;font-size:small;color:black;width:92%;" >
            <tr style="background-color:#AED6F1;font-family:Arial, Helvetica, sans-serif;font-size:small;font-weight:bold;">
                <td style="width:15%;text-align:left;">Customer Group</td>
                <td style="width:7%;text-align:right;">0-10</td>
                <td style="width:7%;text-align:right;">11-20</td>
                <td style="width:7%;text-align:right;">21-30</td>
                <td style="width:7%;text-align:right;">31-45</td>
                <td style="width:7%;text-align:right;">46-60</td>
                <td style="width:7%;text-align:right;">61-90</td>
                <td style="width:7%;text-align:right;">91-180</td>
                <td style="width:11%;text-align:right;">181-365</td>
                <td style="width:11%;text-align:right;">Above 365 day</td>
                <td style="width:10%;text-align:right;">Total value</td>
            </tr>
        </table>
    </div>
    <div id="gridcontainr" style="padding-left:15px; overflow-x:hidden;overflow-y:scroll; max-height:175px;height:auto;max-width:98%; width:auto;">
        <asp:GridView ID="grdnogrn" runat="server" CssClass="table-condensed1" ShowHeader="false" emptydatatext="No data available." cellpadding="5" cellspacing="2" OnRowDataBound="grdnogrn_RowDataBound" Width="95%"
            AutoGenerateColumns="False" OnRowCommand="grdnogrn_RowCommand" ShowFooter="true" OnSelectedIndexChanging="grdnogrn_SelectedIndexChanging" >
            <Columns>                         
            <asp:TemplateField HeaderText="Customer Group" HeaderStyle-Width="15%">
                <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                <ItemTemplate>
                    <asp:LinkButton CommandName="cmdBind" runat="server" Text='<%#Eval("custgrp")%>' ID="custgrp"
                        ToolTip="click view details">LinkButton </asp:LinkButton>
                    <ItemStyle HorizontalAlign="left" />
                </ItemTemplate> 
                <HeaderStyle ForeColor="White" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="0-10">
                <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>
                <ItemTemplate>
                    <asp:LinkButton CommandName="cmdtot1" runat="server" CausesValidation="false"  Text='<%#Eval("0-10")%>' ToolTip="click view details" ID="totval1" ForeColor="Black">  </asp:LinkButton>
                </ItemTemplate>  
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot1" runat="server" CausesValidation="false"  ID="ftrtotval1" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>
                <HeaderStyle CssClass="HeaderCentered" Width="7%" ForeColor="White"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="11-20">
                <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot2" runat="server"  Text='<%#Eval("11-20")%>' ToolTip="click view details" ID="totval2" ForeColor="Black">  </asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot2" runat="server" CausesValidation="false" ID="ftrtotval2" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>
                    <HeaderStyle CssClass="HeaderCentered"  Width="7%" ForeColor="White"/>
            </asp:TemplateField>                         
                <asp:TemplateField HeaderText="21-30">
                <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>                     
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot3" runat="server"  Text='<%#Eval("21-30")%>' ToolTip="click view details" ID="totval3" ForeColor="Black">  </asp:LinkButton>   
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot3" runat="server" CausesValidation="false" ID="ftrtotval3" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>
                    <HeaderStyle CssClass="HeaderCentered"  Width="7%" ForeColor="White"/>
            </asp:TemplateField>                         
                <asp:TemplateField HeaderText="31-45">
                <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot4" runat="server"  Text='<%#Eval("31-45")%>' ToolTip="click view details" ID="totval4" ForeColor="Black">  </asp:LinkButton>   
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot4" runat="server" CausesValidation="false" ID="ftrtotval4" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>
                    <HeaderStyle CssClass="HeaderCentered"  Width="7%" ForeColor="White"/>
            </asp:TemplateField>                         
                <asp:TemplateField HeaderText="46-60">
                <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot5" runat="server"  Text='<%#Eval("46-60")%>' ToolTip="click view details" ID="totval5" ForeColor="Black">  </asp:LinkButton>   
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot5" runat="server" CausesValidation="false" ID="ftrtotval5" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>
                    <HeaderStyle CssClass="HeaderCentered" Width="7%" ForeColor="White"/>
            </asp:TemplateField>                         
                <asp:TemplateField HeaderText="61-90">
                <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot6" runat="server"  Text='<%#Eval("61-90")%>' ToolTip="click view details" ID="totval6" ForeColor="Black">  </asp:LinkButton>   
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot6" runat="server" CausesValidation="false" ID="ftrtotval6" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>
                    <HeaderStyle CssClass="HeaderCentered" Width="7%" ForeColor="White"/>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="91-180">
                <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot7" runat="server"  Text='<%#Eval("91-180")%>' ToolTip="click view details" ID="totval7" ForeColor="Black">  </asp:LinkButton>  
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot7" runat="server" CausesValidation="false" ID="ftrtotval7" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>
                    <HeaderStyle CssClass="HeaderCentered" Width="7%" ForeColor="White"/>
            </asp:TemplateField>                         
                <asp:TemplateField HeaderText="181-365">
                <ItemStyle HorizontalAlign="right" Width="11%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot8" runat="server"  Text='<%#Eval("181-365")%>' ToolTip="click view details" ID="totval8" ForeColor="Black">  </asp:LinkButton> 
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot8" runat="server" CausesValidation="false" ID="ftrtotval8" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>
                    <HeaderStyle CssClass="HeaderCentered" Width="8%" ForeColor="White"/>
            </asp:TemplateField>                         
            <asp:TemplateField HeaderText="Above 365 day">
                <ItemStyle HorizontalAlign="right" Width="11%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot9" runat="server"  Text='<%#Eval("Above 365 day")%>' ToolTip="click view details" ID="totval9" ForeColor="Black">  </asp:LinkButton> 
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot9" runat="server" CausesValidation="false" ID="ftrtotval9" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>
                    <HeaderStyle CssClass="HeaderCentered"  Width="11%" ForeColor="White"/>
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="Total Value">
                <ItemStyle HorizontalAlign="right" Width="10%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="totval" runat="server" Text='<%#Eval("Totalvalue")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot" runat="server" CausesValidation="false" ID="lbltotal" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>
                    <HeaderStyle CssClass="HeaderCentered"  Width="10%" ForeColor="White"/>
            </asp:TemplateField> 
        </Columns>
            <FooterStyle BackColor="#AED6F1" Font-Bold="True" HorizontalAlign="Right" Font-Names="Arial, Helvetica, sans-serif" Font-Size="Small" ForeColor="black" />
            <HeaderStyle BackColor="#507CD1"/>
        </asp:GridView>
    </div>                
    </div>
    <br />
        
<div class="table-responsive" id="gridcontainrmiddle1" Runat="Server" > 
    <div style="height:30px; padding-left:15px;"> 
    <table style="font-family:Arial, Helvetica, sans-serif;font-size:medium;color:white;width:92%;">
            <tr style="background-color:#507CD1;font-family:Arial, Helvetica, sans-serif;font-size:medium;font-weight:bold;">
                <td style="width:60%;text-align:center;">NO GRN (With POD / Bill of Lading Received) details as on <asp:Label ID="lbldate1" runat="server"></asp:Label></td>
                <td style="width:12%;text-align:left;"> (Values in Lakhs)</td>
                <td style="width:23%;text-align:right;">Total Value : <asp:Label ID="lbltot2" runat="server"></asp:Label></td>
                <td style="text-align:right;">                   
                    <asp:ImageButton ID="b2" runat="server" ToolTip="Export to excel" ImageUrl="~/Images/xl.jpg" Height="23px" Width="25px" ImageAlign="Right" OnClick="b2_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div style="height:30px; padding-left:15px;"> 
        <table id="nogrnpodststbl" style="font-family:Arial, Helvetica, sans-serif;font-size:small;color:black;width:92%;" >
            <tr style="background-color:#AED6F1;font-family:Arial, Helvetica, sans-serif;font-size:small;font-weight:bold;">
                <td style="width:15%;text-align:left;">Customer Group</td>
                <td style="width:7%;text-align:right;">0-10</td>
                <td style="width:7%;text-align:right;">11-20</td>
                <td style="width:7%;text-align:right;">21-30</td>
                <td style="width:7%;text-align:right;">31-45</td>
                <td style="width:7%;text-align:right;">46-60</td>
                <td style="width:7%;text-align:right;">61-90</td>
                <td style="width:7%;text-align:right;">91-180</td>
                <td style="width:11%;text-align:right;">181-365</td>
                <td style="width:11%;text-align:right;">Above 365 day</td>
                <td style="width:10%;text-align:right;">Total value</td>
            </tr>
        </table>
    </div>
    <div id="gridcontainr1" style="padding-left:15px; overflow-x:hidden;overflow-y:scroll; max-height:175px;height:auto;max-width:98%; width:auto;">
        <asp:GridView ID="grdgrnpodsts" Runat="Server" CssClass="table-condensed1" ShowHeader="false" 
            emptydatatext="No data available." cellpadding="5" cellspacing="2" OnRowDataBound="grdgrnpodsts_RowDataBound" Width="95%" Font-Size="8"
            OnRowCommand="grdgrnpodsts_RowCommand" AutoGenerateColumns="False" OnSelectedIndexChanged="grdgrnpodsts_SelectedIndexChanged"  ShowFooter="true">
            <Columns>                         
            <asp:TemplateField HeaderStyle-Width="16%" HeaderText="Customer Group">
                <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                <ItemTemplate>
                    <asp:LinkButton CommandName="cmdpostsBind" runat="server" Text='<%#Eval("custgrp")%>' ID="custgrp"
                        ToolTip="click view details">LinkButton </asp:LinkButton>
                    <ItemStyle HorizontalAlign="left" />
                </ItemTemplate>
                <HeaderStyle ForeColor="White" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="0-10">
                <ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                <ItemTemplate>
                    <asp:LinkButton CommandName="cmdtot1" runat="server" CausesValidation="false"  Text='<%#Eval("0-10")%>' ToolTip="click view details" ID="totval1" ForeColor="Black">  </asp:LinkButton>
                </ItemTemplate>  
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot1" runat="server" CausesValidation="false" ID="ftrtotval1" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>                                 
                <HeaderStyle CssClass="HeaderCentered" Width="7%" ForeColor="White"/>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="11-20">
                <ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot2" runat="server"  Text='<%#Eval("11-20")%>' ToolTip="click view details" ID="totval2" ForeColor="Black">  </asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot2" runat="server" CausesValidation="false" ID="ftrtotval2" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>                        
                <HeaderStyle CssClass="HeaderCentered" Width="7%" ForeColor="White"/>
            </asp:TemplateField>                         
                <asp:TemplateField HeaderText="21-30">
                <ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot3" runat="server"  Text='<%#Eval("21-30")%>' ToolTip="click view details" ID="totval3" ForeColor="Black">  </asp:LinkButton>   
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot3" runat="server" CausesValidation="false" ID="ftrtotval3" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>                        
                <HeaderStyle CssClass="HeaderCentered" Width="7%" ForeColor="White"/>
            </asp:TemplateField>                         
                <asp:TemplateField HeaderText="31-45">
                <ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot4" runat="server"  Text='<%#Eval("31-45")%>' ToolTip="click view details" ID="totval4" ForeColor="Black">  </asp:LinkButton>   
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot4" runat="server" CausesValidation="false" ID="ftrtotval4" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>                        
                <HeaderStyle CssClass="HeaderCentered" Width="7%" ForeColor="White"/>
            </asp:TemplateField>                         
                <asp:TemplateField HeaderText="46-60">
                <ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot5" runat="server"  Text='<%#Eval("46-60")%>' ToolTip="click view details" ID="totval5" ForeColor="Black">  </asp:LinkButton>   
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot5" runat="server" CausesValidation="false" ID="ftrtotval5" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>                         
                <HeaderStyle CssClass="HeaderCentered" Width="7%" ForeColor="White"/>
            </asp:TemplateField>                         
            <asp:TemplateField HeaderText="61-90">
                <ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot6" runat="server"  Text='<%#Eval("61-90")%>' ToolTip="click view details" ID="totval6" ForeColor="Black">  </asp:LinkButton>   
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot6" runat="server" CausesValidation="false" ID="ftrtotval6" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>                        
                <HeaderStyle CssClass="HeaderCentered" Width="7%" ForeColor="White"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="91-180">
                <ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot7" runat="server"  Text='<%#Eval("91-180")%>' ToolTip="click view details" ID="totval7" ForeColor="Black">  </asp:LinkButton>  
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot7" runat="server" CausesValidation="false" ID="ftrtotval7" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>                        
                <HeaderStyle CssClass="HeaderCentered" Width="7%" ForeColor="White"/>
            </asp:TemplateField>                         
                <asp:TemplateField HeaderText="181-365">
                <ItemStyle HorizontalAlign="Right" Width="11%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot8" runat="server"  Text='<%#Eval("181-365")%>' ToolTip="click view details" ID="totval8" ForeColor="Black">  </asp:LinkButton> 
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot8" runat="server" CausesValidation="false" ID="ftrtotval8" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>
                <HeaderStyle CssClass="HeaderCentered" Width="8%" ForeColor="White"/>
            </asp:TemplateField>                         
            <asp:TemplateField HeaderText="Above 365 day">
                <ItemStyle HorizontalAlign="Right" Width="11%"></ItemStyle>
                <ItemTemplate>
                        <asp:LinkButton CommandName="cmdtot9" runat="server"  Text='<%#Eval("Above 365 day")%>' ToolTip="click view details" ID="totval9" ForeColor="Black">  </asp:LinkButton> 
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot9" runat="server" CausesValidation="false" ID="ftrtotval9" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>
                <HeaderStyle CssClass="HeaderCentered" Width="11%" ForeColor="White"/>
            </asp:TemplateField>  
                <asp:TemplateField HeaderText="Total Value">
                <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="totval" runat="server" Text='<%#Eval("Totalvalue")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                        <asp:LinkButton CommandName="ftrcmdtot" runat="server" CausesValidation="false" ID="lbltotal" ForeColor="Black">  </asp:LinkButton>
                </FooterTemplate>
                    <HeaderStyle CssClass="HeaderCentered" ForeColor="White"/>
            <HeaderStyle CssClass="HeaderCentered" Width="10%"/>
            </asp:TemplateField> 
        </Columns>
            <FooterStyle BackColor="#AED6F1" Font-Bold="True" HorizontalAlign="Right" Font-Names="Arial, Helvetica, sans-serif" Font-Size="Small" ForeColor="black" />
            <HeaderStyle BackColor="#507CD1"/>
        </asp:GridView>
    </div>                
    </div>
    <br />
    <div id="TotalNoGrn1" Runat="Server" > 
        <table style="font-family:Arial, Helvetica, sans-serif;font-size:medium;color:white;width:92%;" >
            <tr style="background-color:#507CD1;font-family:Arial, Helvetica, sans-serif;font-size:medium;font-weight:bold;">
                <td style="text-align:right;padding-right:60px;">Total NOGRN Net Value :  <asp:Label ID="lblnetval" runat="server"></asp:Label></td>
            </tr>
        </table>
    </div>            
</div>  
</asp:Content>


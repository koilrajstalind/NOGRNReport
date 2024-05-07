<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmCustDetWthPOD.aspx.cs" EnableEventValidation="false" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
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

        .HeaderCentered {
            text-align: right !important;
        }

        .FixedHeader {
            position: absolute;
            font-weight: bold;
        }
    </style>
    <br />
    <br />
    <div class="table-responsive">
        <div style="height: 30px; padding-left: 15px;">
            <table style="font-family: Arial, Helvetica, sans-serif; font-size: medium; color: white; width: 93%;">
                <tr style="background-color: #507CD1; font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight: bold;">
                    <td style="width: 60%; text-align: center;">NO GRN (Without POD) details as on
                                <asp:Label ID="lbldate" runat="server"></asp:Label></td>
                    <td style="width: 12%; text-align: left;">(Values in Lakhs)</td>
                    <td style="width: 23%; text-align: right;">Total Value :
                                <asp:Label ID="lbltot1" runat="server"></asp:Label></td>
                    <td style="text-align: right;">
                        <asp:ImageButton ID="b1" runat="server" ToolTip="Export to excel" ImageUrl="~/Images/xl.jpg" Height="23px" Width="25px" ImageAlign="Right" OnClick="b1_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
        </div>
        <div style="height: 30px; padding-left: 15px;">
            <table id="nogrntbl" style="font-family: Arial, Helvetica, sans-serif; font-size: small; color: black; width: 93%;">
                <tr style="background-color: #AED6F1; font-family: Arial, Helvetica, sans-serif; font-size: small; font-weight: bold;">
                    <td style="width: 15%; text-align: left;">Customer Name</td>
                    <td style="width: 7%; text-align: right;">0-10</td>
                    <td style="width: 7%; text-align: right;">11-20</td>
                    <td style="width: 7%; text-align: right;">21-30</td>
                    <td style="width: 7%; text-align: right;">31-45</td>
                    <td style="width: 7%; text-align: right;">46-60</td>
                    <td style="width: 7%; text-align: right;">61-90</td>
                    <td style="width: 7%; text-align: right;">91-180</td>
                    <td style="width: 11%; text-align: right;">181-365</td>
                    <td style="width: 11%; text-align: right;">Above 365 day</td>
                    <td style="width: 10%; text-align: right;">Total value</td>
                </tr>
            </table>
        </div>
        <div id="gridcontainr" style="padding-left: 15px; overflow-x: hidden; overflow-y: scroll; max-height: 375px; height: auto; max-width: 98%; width: auto;">
            <asp:GridView ID="grdnogrn" runat="server" CssClass="table-condensed1" ShowHeader="false" EmptyDataText="No data available." CellPadding="5" CellSpacing="2" OnRowDataBound="grdnogrn_RowDataBound" Width="96%" OnPageIndexChanging="OnPaging"
                OnRowCommand="grdnogrn_RowCommand" AutoGenerateColumns="False" ShowFooter="true" OnSelectedIndexChanged="grdnogrn_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField>
                        <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                        <ItemTemplate>
                            <asp:LinkButton CommandName="cmdBind" runat="server" Text='<%#Eval("custname")+ " ~ " +  Eval("custcode")%>' ID="custgrp"
                                ToolTip="click view details">LinkButton </asp:LinkButton>
                            <asp:Label ID="custgroup" runat="server" Text='<%#Eval("custname")%>' Visible="false"></asp:Label>
                            <itemstyle horizontalalign="left" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="0-10">
                        <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>
                        <ItemTemplate>
                            <asp:LinkButton CommandName="cmdtot2" runat="server" Text='<%#Eval("0-10")%>' ID="totval1">  </asp:LinkButton>
                            <asp:Label ID="tot1" runat="server" Text='<%#Eval("0-10")%>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="11-20">
                        <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="tot2" runat="server" Text='<%#Eval("11-20")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="21-30">
                        <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>
                        <ItemTemplate>
                            <asp:LinkButton CommandName="cmdtot1" runat="server" Text='<%#Eval("21-30")%>' ID="totval3">LinkButton </asp:LinkButton>
                            <asp:Label ID="tot3" runat="server" Text='<%#Eval("21-30")%>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="31-45">
                        <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="tot4" runat="server" Text='<%#Eval("31-45")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="46-60">
                        <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="tot5" runat="server" Text='<%#Eval("46-60")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="61-90">
                        <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="tot6" runat="server" Text='<%#Eval("61-90")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="91-180">
                        <ItemStyle HorizontalAlign="right" Width="7%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="tot7" runat="server" Text='<%#Eval("91-180")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="181-365">
                        <ItemStyle HorizontalAlign="right" Width="11%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="tot8" runat="server" Text='<%#Eval("181-365")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Above 365 day">
                        <ItemStyle HorizontalAlign="right" Width="11%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="tot9" runat="server" Text='<%#Eval("Above 365 day")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Value">
                        <ItemStyle HorizontalAlign="right" Width="10%"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="totval" runat="server"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotal" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#AED6F1" Font-Bold="True" HorizontalAlign="Right" Font-Names="Arial, Helvetica, sans-serif" Font-Size="Small" ForeColor="black" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="true" />
            </asp:GridView>
        </div>
        <br />
        <table style="width: 100%; height: 24px;">
            <tr>
                <td style="background-color: white; text-align: center; padding-right: 25px;">
                    <asp:Button ID="btnReset" CssClass="button" TabIndex="25" runat="server" Text="Back"
                        ToolTip="Back to The Page" Width="70px" OnClick="btnReset_Click" />
                </td>

            </tr>
        </table>
    </div>

</asp:Content>


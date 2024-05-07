<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmHome.aspx.cs" Inherits="frmHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
	<asp:UpdateProgress ID="upProgFNSearch" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
		<ProgressTemplate>
			<div id="processMessage_UpdatePanel">
				<div id="loadingimg">
					<table style="width: 100%" border="1" class="table-condensed">
						<tr class="text-left">
							<td>
								<img id="Img1" alt="progress" runat="server" src="Images/loaderblueCirDot.gif" />&nbsp;&nbsp;<span>Please Wait....</span>
							</td>
						</tr>
					</table>
				</div>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<Triggers>
		<%--	<asp:AsyncPostBackTrigger  ControlID="ddlplant" />		
			<asp:PostBackTrigger ControlID="ReportViewer1" />
			<asp:AsyncPostBackTrigger ControlID="imgbtnAdvFilter" EventName="Click" />
			<asp:AsyncPostBackTrigger ControlID="ddlCategory" EventName="SelectedIndexChanged" />--%>
		</Triggers>
		<ContentTemplate>
           <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <table id="tbl1" class="table-condensed" style="width: 95%" border="0" runat="server">
                <tr>
                    <td style="text-align: center; padding-left:55px; text-size-adjust:auto">

                        <br />
                        <br />                        
                        <asp:HyperLink ID="HyperLink1" runat="server" Visible="false">Click to Review ToolRoom Details</asp:HyperLink>
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>










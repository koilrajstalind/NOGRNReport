<%@ Page Language="C#" AutoEventWireup="true" CodeFile="errorPage.aspx.cs" Inherits="errorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Iconlogo.jpg" rel="shortcut icon" type="image/x-icon" />
    <meta charset="utf-8" />
    <meta name="viewport" content="user-scalable=no, width=device-width">
    <title><%: Page.Title %> - PIT- Web Page Error!</title>
</head>
<body style="background-color: #EEEEEE; font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif; font-size: .90em;">
    <form id="form1" runat="server">

        <table class="table-condensed">

            <tr>
                <td style="background-color: #C55042; color: #FFFFFF;">
                    <h3>Oops! An error occurred while performing your request.</h3>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server" Text="Sorry for any convenience." /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblGoBack" runat="server" Text="You may want to get back to the previous page and perform other activities." /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblErrorMsg" runat="server" ForeColor="blue" /></td>
            </tr>
            <tr>
                <td style="border-bottom: 2px solid #999999;"></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hlinkPreviousPage" ForeColor="Red" runat="server">Go back</asp:HyperLink>
                    &nbsp;&nbsp; [or] &nbsp;&nbsp;&nbsp;
                                       <asp:HyperLink ID="hlinkHomePage" ForeColor="Red" runat="server" NavigateUrl="~/Default.aspx">Go Home</asp:HyperLink></td>
            </tr>

        </table>
    </form>
</body>
</html>

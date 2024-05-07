using System;

public partial class errorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strPerviousUri = Request["aspxUri"];
        if (!string.IsNullOrEmpty(strPerviousUri))
        {
         //   pnlError.Visible = true;
            lblErrorMsg.Text ="Error Details: " +  Request["aspxError"];
            hlinkPreviousPage.NavigateUrl = strPerviousUri;
        }
    }
}   
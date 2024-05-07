using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Globalization;
using System;
using System.Data.SqlClient;

public partial class frmHome : System.Web.UI.Page
{

    public PIT.PITDATA objData = new PIT.PITDATA();
    BusinessLayer objMaster = new BusinessLayer();
	public string strMessage;
	public string SPName;
	public string strValidation = null;
	
	protected void Page_Load(object sender, EventArgs e)
	{

		CultureInfo ci = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.LCID);
		ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
		ci.DateTimeFormat.DateSeparator = "/";
		System.Threading.Thread.CurrentThread.CurrentCulture = ci;
		if (!Page.IsPostBack)
		{

            //String mn = DateTime.Now.Month.ToString("00");
            //String yy = DateTime.Now.Year.ToString();
            //WebMaskMonth.Value = yy + mn.ToString();
			
		
		}
	}


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Mediclaim
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService()]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Mediclaim : System.Web.Services.WebService
{
    private static string strconnection = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
    //database connection 
    SqlConnection con = new SqlConnection(strconnection);

    public Mediclaim()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod]
    public List<string> GetInsuCode(string prefixText)
    {
        // SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select distinct CMPNY_CODE from MEDICLAIM_INSU_CMPNY where CMPNY_CODE like @namesearch+'%' and status in ('A')";
        cmd.Parameters.AddWithValue("@namesearch", prefixText);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        List<string> ccode = new List<string>();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ccode.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        return ccode;
    }

    [WebMethod]
    public List<string> GetUnionCode(string prefixText)
    {
        // SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select distinct UNION_CODE from OPR_UNION where UNION_CODE like @namesearch+'%' and status in ('A')";
        cmd.Parameters.AddWithValue("@namesearch", prefixText);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        List<string> ucode = new List<string>();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ucode.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        return ucode;
    }

}

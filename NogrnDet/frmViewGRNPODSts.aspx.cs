using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Services;

public partial class _Default : System.Web.UI.Page
{
    public PIT.PITDATA objData = new PIT.PITDATA();
    BusinessLayer objMaster = new BusinessLayer();
    public string sts;
    public string agegrp, custgrp, chkval, grnchk;
    public decimal sumFooterValue = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        grnchk = Session["chk"].ToString();
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(b1);
        if (!Page.IsPostBack)
        {
            chkval = Session["chk"].ToString();
            lbldate.Text = DateTime.Now.AddDays(-1).ToString("dd/MMM/yyyy");
            BindGRNDet();
        }
    }
    private void BindGRNDet()
    {
        try
        {
            DataSet dsName = new DataSet();
            DataTable dt = new DataTable();
            if (chkval.Equals("chk"))
            {
                dsName = objMaster.fnLoadGRN(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty, 0, 0, 0, 0, 0, string.Empty, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Session["nogrnsts1"].ToString(), string.Empty, string.Empty, string.Empty, "GetgrnNoEmptyValDet");
            }
            else if (chkval.Equals("nochk"))
            {
                dsName = objMaster.fnLoadGRN(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, Session["agegrp"].ToString(), 0, 0, 0, 0, 0, string.Empty, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Session["custgrp"].ToString(), string.Empty, string.Empty, "GetgrnCellNoEmptyValDet");
            }
            else if (chkval.Equals("ftrchk"))
            {
                dsName = objMaster.fnLoadGRN(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, Session["agegrp"].ToString(), 0, 0, 0, 0, 0, string.Empty, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "GetgrntotNoEmptyValDet");
            }
            else if (chkval.Equals("ftrtotchk"))
            {
                dsName = objMaster.fnLoadGRN(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty, 0, 0, 0, 0, 0, string.Empty, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "GetgrnNoEmptydetval");
            }
            else
            {

            }
            
            if (dsName.Tables[0].Rows.Count > 0)
            {
                dt = dsName.Tables[0];
                grdnogrn.DataSource = dt;
                grdnogrn.DataBind();

                decimal tot1 = dt.AsEnumerable().Sum(row => row.Field<decimal>("salesval"));
                grdnogrn.FooterRow.Cells[12].Text = "Total";
                grdnogrn.FooterRow.Cells[12].Font.Bold = true;
                grdnogrn.FooterRow.Cells[12].HorizontalAlign = HorizontalAlign.Right;
                grdnogrn.FooterRow.Cells[13].Text = tot1.ToString("N2");

                decimal tot2 = dt.AsEnumerable().Sum(row => row.Field<decimal>("cgstamnt"));
                grdnogrn.FooterRow.Cells[14].Text = tot2.ToString("N2");

                decimal tot3 = dt.AsEnumerable().Sum(row => row.Field<decimal>("sgstamnt"));
                grdnogrn.FooterRow.Cells[15].Text = tot3.ToString("N2");

                decimal tot4 = dt.AsEnumerable().Sum(row => row.Field<decimal>("igstamnt"));
                grdnogrn.FooterRow.Cells[16].Text = tot4.ToString("N2");

                decimal tot5 = dt.AsEnumerable().Sum(row => row.Field<decimal>("drval"));
                grdnogrn.FooterRow.Cells[17].Text = tot5.ToString("N2");

            }
            else
            {
                grdnogrn.DataSource = null;
                grdnogrn.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {

        BindGRNDet();
        grdnogrn.PageIndex = e.NewPageIndex;
        grdnogrn.DataBind();

    }
    protected void b1_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "GRN" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        grdnogrn.GridLines = GridLines.Both;
        grdnogrn.HeaderStyle.Font.Bold = true;
        grdnogrn.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }


    protected void btnReset_Click(object sender, EventArgs e)
    {

        try
        {
            if (grnchk.Equals("chk"))
            {
                Response.Redirect("frmCustDetWthotPOD.aspx");
            }
            else
            {
                Response.Redirect("frmGRNDisplay.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
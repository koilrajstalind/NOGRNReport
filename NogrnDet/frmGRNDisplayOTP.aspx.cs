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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Web;
using System.Security;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

public partial class _Default : System.Web.UI.Page
{
    public PIT.PITDATA objData = new PIT.PITDATA();
    BusinessLayer objMaster = new BusinessLayer();
    public string sts;
    public decimal sumFooterValue = 0;
    public decimal sumFooterValue1 = 0,netval = 0;
    public DataTable dtval = new DataTable();
    public decimal ftrtot1 = 0, ftrtot2 = 0, ftrtot3 = 0, ftrtot4 = 0, ftrtot5 = 0, ftrtot6 = 0, ftrtot7 = 0, ftrtot8 = 0, ftrtot9 = 0;
    public decimal ftrpotot1 = 0, ftrpotot2 = 0, ftrpotot3 = 0, ftrpotot4 = 0, ftrpotot5 = 0, ftrpotot6 = 0, ftrpotot7 = 0, ftrpotot8 = 0, ftrpotot9 = 0;
    EmployeeDataAccess objDataAccess = new EmployeeDataAccess();
    SqlDataReader sqlDRead;
    String lv_otp = "";
    Int32 OTPValue = 0;
    String Mailid = "";
    String Module = "MIS";
    String Reportid = "frmGRNDisplay";
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(b1);

        frmDiv1.Visible = true;
        NOGRNDIV1.Visible = false;
        NOGRN1.Visible = false;
        grdnogrn.Visible = false;
        gridcontainrmiddle1.Visible = true;
        TotalNoGrn1.Visible = false;
      

        if (!Page.IsPostBack)
        {
            // Visible True for Conditional Checking

           

            // Visible True for Conditional Checking

            ScriptManager.GetCurrent(Page).RegisterPostBackControl(b1);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(b2);
            lbldate.Text = DateTime.Now.AddDays(-1).ToString("dd/MMM/yyyy");
            lbldate1.Text = DateTime.Now.AddDays(-1).ToString("dd/MMM/yyyy");
            BindGRNDet();
            BindGRNPODDet();
            netval = sumFooterValue + sumFooterValue1;
            lblnetval.Text = netval.ToString("N2");

           
        }
    }
    protected void BtnOTP_Click(object sender, EventArgs e)
    {
        string strQuery = string.Empty;

        string lv_otp = txtotp.Text.ToString();
        string flag = "0";
        string sql = "";
        SqlDataReader dsOTP = null;
        try
        {
            if (lv_otp.Length > 0)
            {
                int lv1_otp = Convert.ToInt32(lv_otp);

                strQuery = "SELECT * FROM MISOTPMaster WHERE CONVERT(date, GETDATE())= CurrentDate and OTP=" + lv_otp;
                dsOTP = objDataAccess.GetDataReader(strQuery);

                if (dsOTP.Read())
                {
                    flag = "1";
                    frmDiv1.Visible = false;
                    NOGRNDIV1.Visible = true;
                    NOGRN1.Visible = true;
                    grdnogrn.Visible = true;
                    gridcontainrmiddle1.Visible = true;
                    TotalNoGrn1.Visible = true;

                    OTPValue = dsOTP.GetInt32(1);
                    Mailid = dsOTP.GetString(2);
                    dsOTP.Close();

                }
                else
                {
                    txtotp.Focus();
                    txtotp.Text = "";
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox1", "alert('OTP is Not available');", true);
                }

            }
            else
            {
                txtotp.Focus();
                txtotp.Text = "";
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox1", "alert('Please Enter OTP');", true);
            }
          

        }
        catch (Exception ex)
        {
            throw new Exception("Error Messages " + ex.Message);
        }
       


        if (flag.Equals("1"))
        {
            sql = "insert into MISOTPLog(OTP,Mailid,Module,reportid,CurrentDateTime) values (" + OTPValue + ",'" + Mailid + "','" + Module + "','" + Reportid + "','" + DateTime.Now + "')";
            int lg = objDataAccess.ExecuteQuery(sql);

        }

    }
    private void BindGRNDet()
    {
        try
        {
            DataSet dsName = new DataSet();
            dsName = objMaster.fnLoadGRN(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty, 0, 0, 0, 0, 0, string.Empty, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "GetgrnEmptyVal");
            if (dsName.Tables[0].Rows.Count > 0)
            {
                dtval = dsName.Tables[0];

                for (int i = 0; i < dtval.Rows.Count; i++)
                {
                    for (int j = 0; j < dtval.Columns.Count; j++)
                    {
                        if (string.IsNullOrEmpty(dtval.Rows[i][j].ToString()))
                        {
                            // Write your Custom Code
                            dtval.Rows[i][j] = "0";
                        }
                    }
                }
                DataView dv = new DataView();
                dv = dtval.DefaultView;
                dv.Sort = "Totalvalue desc";
                grdnogrn.DataSource = dtval;
                grdnogrn.DataBind();

                grdnogrn.FooterRow.Cells[0].Text = "Total";
                grdnogrn.FooterRow.Cells[0].Font.Bold = true;
                grdnogrn.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                ViewState["dirState"] = dtval;
                grdnogrn.UseAccessibleHeader = true;
                grdnogrn.HeaderRow.TableSection = TableRowSection.TableHeader;

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

    private void BindGRNPODDet()
    {
        try
        {
            DataSet dsName = new DataSet();
            DataTable dt = new DataTable();
            dsName = objMaster.fnLoadGRN(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty, 0, 0, 0, 0, 0, string.Empty, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "GetgrnNoEmptyVal");
            if (dsName.Tables[0].Rows.Count > 0)
            {

                dt = dsName.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            // Write your Custom Code
                            dt.Rows[i][j] = "0";
                        }
                    }
                }
                DataView dv = new DataView();
                dv = dt.DefaultView;
                dv.Sort = "Totalvalue desc";
                grdgrnpodsts.DataSource = dt;
                grdgrnpodsts.DataBind();
                grdgrnpodsts.FooterRow.Cells[0].Text = "Total";
                grdgrnpodsts.FooterRow.Cells[0].Font.Bold = true;
                grdgrnpodsts.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;

            }
            else
            {
                grdgrnpodsts.DataSource = null;
                grdgrnpodsts.DataBind();
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
    protected void grdnogrn_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow grv = grdnogrn.Rows[grdnogrn.SelectedIndex];
    }

    protected void grdnogrn_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnktst = new LinkButton();
            LinkButton tot1 = e.Row.FindControl("totval1") as LinkButton;
            LinkButton tot2 = e.Row.FindControl("totval2") as LinkButton;
            LinkButton tot3 = e.Row.FindControl("totval3") as LinkButton;
            LinkButton tot4 = e.Row.FindControl("totval4") as LinkButton;
            LinkButton tot5 = e.Row.FindControl("totval5") as LinkButton;
            LinkButton tot6 = e.Row.FindControl("totval6") as LinkButton;
            LinkButton tot7 = e.Row.FindControl("totval7") as LinkButton;
            LinkButton tot8 = e.Row.FindControl("totval8") as LinkButton;
            LinkButton tot9 = e.Row.FindControl("totval9") as LinkButton;
            Label lbltotval = e.Row.FindControl("totval") as Label;

            string totval1 = tot1.Text.ToString();
            decimal dt1 = Convert.ToDecimal(totval1) / 100000;
            tot1.Text = dt1.ToString("N2");

            string totval2 = tot2.Text.ToString();
            decimal dt2 = Convert.ToDecimal(totval2) / 100000;
            tot2.Text = dt2.ToString("N2");

            string totval3 = tot3.Text.ToString();
            decimal dt3 = Convert.ToDecimal(totval3) / 100000;
            tot3.Text = dt3.ToString("N2");

            string totval4 = tot4.Text.ToString();
            decimal dt4 = Convert.ToDecimal(totval4) / 100000;
            tot4.Text = dt4.ToString("N2");

            string totval5 = tot5.Text.ToString();
            decimal dt5 = Convert.ToDecimal(totval5) / 100000;
            tot5.Text = dt5.ToString("N2");

            string totval6 = tot6.Text.ToString();
            decimal dt6 = Convert.ToDecimal(totval6) / 100000;
            tot6.Text = dt6.ToString("N2");

            string totval7 = tot7.Text.ToString();
            decimal dt7 = Convert.ToDecimal(totval7) / 100000;
            tot7.Text = dt7.ToString("N2");

            string totval8 = tot8.Text.ToString();
            decimal dt8 = Convert.ToDecimal(totval8) / 100000;
            tot8.Text = dt8.ToString("N2");

            string totval9 = tot9.Text.ToString();
            decimal dt9 = Convert.ToDecimal(totval9) / 100000;
            tot9.Text = dt9.ToString("N2");

            decimal totalvalue = dt1 + dt2 + dt3 + dt4 + dt5 + dt6 + dt7 + dt8 + dt9;

            string fnltotval = lbltotval.Text.ToString();
            decimal fnltot = Convert.ToDecimal(fnltotval) / 100000;
            lbltotval.Text = fnltot.ToString("N2");

            sumFooterValue += totalvalue;
            ftrtot1 += dt1;
            ftrtot2 += dt2;
            ftrtot3 += dt3;
            ftrtot4 += dt4;
            ftrtot5 += dt5;
            ftrtot6 += dt6;
            ftrtot7 += dt7;
            ftrtot8 += dt8;
            ftrtot9 += dt9;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            LinkButton ftrval1 = e.Row.FindControl("ftrtotval1") as LinkButton;
            ftrval1.Text = ftrtot1.ToString("N2");
            LinkButton ftrval2 = e.Row.FindControl("ftrtotval2") as LinkButton;
            ftrval2.Text = ftrtot2.ToString("N2");
            LinkButton ftrval3 = e.Row.FindControl("ftrtotval3") as LinkButton;
            ftrval3.Text = ftrtot3.ToString("N2");
            LinkButton ftrval4 = e.Row.FindControl("ftrtotval4") as LinkButton;
            ftrval4.Text = ftrtot4.ToString("N2");
            LinkButton ftrval5 = e.Row.FindControl("ftrtotval5") as LinkButton;
            ftrval5.Text = ftrtot5.ToString("N2");
            LinkButton ftrval6 = e.Row.FindControl("ftrtotval6") as LinkButton;
            ftrval6.Text = ftrtot6.ToString("N2");
            LinkButton ftrval7 = e.Row.FindControl("ftrtotval7") as LinkButton;
            ftrval7.Text = ftrtot7.ToString("N2");
            LinkButton ftrval8 = e.Row.FindControl("ftrtotval8") as LinkButton;
            ftrval8.Text = ftrtot8.ToString("N2");
            LinkButton ftrval9 = e.Row.FindControl("ftrtotval9") as LinkButton;
            ftrval9.Text = ftrtot9.ToString("N2");
            LinkButton lbl = e.Row.FindControl("lbltotal") as LinkButton; 
            lbl.Text = sumFooterValue.ToString("N2");
            lbltot1.Text = sumFooterValue.ToString("N2");
        }

    }

    private void doRestore(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    protected void grdnogrn_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        if (e.CommandName == "cmdBind")
        {
            LinkButton lb = (LinkButton)e.CommandSource;
            Session["nogrn"] = lb.Text.ToString();
            Session["chk"] = "chk";
            Response.Redirect("frmCustDetWthPOD.aspx");
        }
        else if (e.CommandName == "cmdtot1")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "0-10";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "cmdtot2")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "11-20";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "cmdtot3")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "21-30";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "cmdtot4")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "31-45";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "cmdtot5")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "46-60";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "cmdtot6")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "61-90";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "cmdtot7")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "91-180";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "cmdtot8")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "181-365";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "cmdtot9")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "Above 365 day";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "ftrcmdtot1")
        {
            Session["agegrp"] = "0-10";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "ftrcmdtot2")
        {
            Session["agegrp"] = "11-20";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "ftrcmdtot3")
        {
            Session["agegrp"] = "21-30";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "ftrcmdtot4")
        {
            Session["agegrp"] = "31-45";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "ftrcmdtot5")
        {
            Session["agegrp"] = "46-60";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "ftrcmdtot6")
        {
            Session["agegrp"] = "61-90";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "ftrcmdtot7")
        {
            Session["agegrp"] = "91-180";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "ftrcmdtot8")
        {
            Session["agegrp"] = "181-365";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "ftrcmdtot9")
        {
            Session["agegrp"] = "Above 365 day";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else if (e.CommandName == "ftrcmdtot")
        {
            Session["chk"] = "ftrtotchk";
            Response.Redirect("frmViewGRN.aspx");
        }
        else
        {

        }
    }
    protected void grdgrnpodsts_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnktst = new LinkButton();
            LinkButton tot1 = e.Row.FindControl("totval1") as LinkButton;
            LinkButton tot2 = e.Row.FindControl("totval2") as LinkButton;
            LinkButton tot3 = e.Row.FindControl("totval3") as LinkButton;
            LinkButton tot4 = e.Row.FindControl("totval4") as LinkButton;
            LinkButton tot5 = e.Row.FindControl("totval5") as LinkButton;
            LinkButton tot6 = e.Row.FindControl("totval6") as LinkButton;
            LinkButton tot7 = e.Row.FindControl("totval7") as LinkButton;
            LinkButton tot8 = e.Row.FindControl("totval8") as LinkButton;
            LinkButton tot9 = e.Row.FindControl("totval9") as LinkButton;
            Label lbltotval = e.Row.FindControl("totval") as Label;

            string totval1 = tot1.Text.ToString();
            decimal dt1 = Convert.ToDecimal(totval1) / 100000;
            tot1.Text = dt1.ToString("N2");

            string totval2 = tot2.Text.ToString();
            decimal dt2 = Convert.ToDecimal(totval2) / 100000;
            tot2.Text = dt2.ToString("N2");

            string totval3 = tot3.Text.ToString();
            decimal dt3 = Convert.ToDecimal(totval3) / 100000;
            tot3.Text = dt3.ToString("N2");

            string totval4 = tot4.Text.ToString();
            decimal dt4 = Convert.ToDecimal(totval4) / 100000;
            tot4.Text = dt4.ToString("N2");

            string totval5 = tot5.Text.ToString();
            decimal dt5 = Convert.ToDecimal(totval5) / 100000;
            tot5.Text = dt5.ToString("N2");

            string totval6 = tot6.Text.ToString();
            decimal dt6 = Convert.ToDecimal(totval6) / 100000;
            tot6.Text = dt6.ToString("N2");

            string totval7 = tot7.Text.ToString();
            decimal dt7 = Convert.ToDecimal(totval7) / 100000;
            tot7.Text = dt7.ToString("N2");

            string totval8 = tot8.Text.ToString();
            decimal dt8 = Convert.ToDecimal(totval8) / 100000;
            tot8.Text = dt8.ToString("N2");

            string totval9 = tot9.Text.ToString();
            decimal dt9 = Convert.ToDecimal(totval9) / 100000;
            tot9.Text = dt9.ToString("N2");

            decimal totalvalue = dt1 + dt2 + dt3 + dt4 + dt5 + dt6 + dt7 + dt8 + dt9;

            string fnltotval = lbltotval.Text.ToString();
            decimal fnltot = Convert.ToDecimal(fnltotval) / 100000;
            lbltotval.Text = fnltot.ToString("N2");
            sumFooterValue1 += totalvalue;
            ftrpotot1 += dt1;
            ftrpotot2 += dt2;
            ftrpotot3 += dt3;
            ftrpotot4 += dt4;
            ftrpotot5 += dt5;
            ftrpotot6 += dt6;
            ftrpotot7 += dt7;
            ftrpotot8 += dt8;
            ftrpotot9 += dt9;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            LinkButton ftrval1 = e.Row.FindControl("ftrtotval1") as LinkButton;
            ftrval1.Text = ftrpotot1.ToString("N2");
            LinkButton ftrval2 = e.Row.FindControl("ftrtotval2") as LinkButton;
            ftrval2.Text = ftrpotot2.ToString("N2");
            LinkButton ftrval3 = e.Row.FindControl("ftrtotval3") as LinkButton;
            ftrval3.Text = ftrpotot3.ToString("N2");
            LinkButton ftrval4 = e.Row.FindControl("ftrtotval4") as LinkButton;
            ftrval4.Text = ftrpotot4.ToString("N2");
            LinkButton ftrval5 = e.Row.FindControl("ftrtotval5") as LinkButton;
            ftrval5.Text = ftrpotot5.ToString("N2");
            LinkButton ftrval6 = e.Row.FindControl("ftrtotval6") as LinkButton;
            ftrval6.Text = ftrpotot6.ToString("N2");
            LinkButton ftrval7 = e.Row.FindControl("ftrtotval7") as LinkButton;
            ftrval7.Text = ftrpotot7.ToString("N2");
            LinkButton ftrval8 = e.Row.FindControl("ftrtotval8") as LinkButton;
            ftrval8.Text = ftrpotot8.ToString("N2");
            LinkButton ftrval9 = e.Row.FindControl("ftrtotval9") as LinkButton;
            ftrval9.Text = ftrpotot9.ToString("N2");
            LinkButton lbl = e.Row.FindControl("lbltotal") as LinkButton;
            lbl.Text = sumFooterValue1.ToString("N2");
            lbltot2.Text = sumFooterValue1.ToString("N2");
        }
    }
    protected void grdgrnpodsts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        if (e.CommandName == "cmdpostsBind")
        {
            LinkButton lb = (LinkButton)e.CommandSource;
            Session["nogrnsts"] = lb.Text.ToString();
            Session["chk"] = "chk";
            Response.Redirect("frmCustDetWthotPOD.aspx");
        }
        else if (e.CommandName == "cmdtot1")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "0-10";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "cmdtot2")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "11-20";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "cmdtot3")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "21-30";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "cmdtot4")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "31-45";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "cmdtot5")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "46-60";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "cmdtot6")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "61-90";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "cmdtot7")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "91-180";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "cmdtot8")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "181-365";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "cmdtot9")
        {
            LinkButton lbtot = (LinkButton)e.CommandSource;
            LinkButton lblcustgrp = (LinkButton)gvrow.FindControl("custgrp");
            Session["custgrp"] = lblcustgrp.Text.ToString();
            Session["agegrp"] = "Above 365 day";
            Session["chk"] = "nochk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "ftrcmdtot1")
        {
            Session["agegrp"] = "0-10";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "ftrcmdtot2")
        {
            Session["agegrp"] = "11-20";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "ftrcmdtot3")
        {
            Session["agegrp"] = "21-30";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "ftrcmdtot4")
        {
            Session["agegrp"] = "31-45";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "ftrcmdtot5")
        {
            Session["agegrp"] = "46-60";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "ftrcmdtot6")
        {
            Session["agegrp"] = "61-90";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "ftrcmdtot7")
        {
            Session["agegrp"] = "91-180";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "ftrcmdtot8")
        {
            Session["agegrp"] = "181-365";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "ftrcmdtot9")
        {
            Session["agegrp"] = "Above 365 day";
            Session["chk"] = "ftrchk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
        else if (e.CommandName == "ftrcmdtot")
        {
            Session["chk"] = "ftrtotchk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
    }
    protected void b1_Click(object sender, EventArgs e)
    {
        grdnogrn.ShowHeader = true;
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            grdnogrn.AllowPaging = false;
            this.BindGRNDet();

            foreach (TableCell cell in grdnogrn.HeaderRow.Cells)
            {
                cell.BackColor = grdnogrn.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in grdnogrn.Rows)
            {

                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = grdnogrn.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = grdnogrn.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                    List<Control> controls = new List<Control>();

                    //Add controls to be removed to Generic List
                    foreach (Control control in cell.Controls)
                    {
                        controls.Add(control);
                    }

                    //Loop through the controls to be removed and replace with Literal
                    foreach (Control control in controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "LinkButton":
                                cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                break;
                            case "Label":
                                cell.Controls.Add(new Literal { Text = (control as Label).Text });
                                break;
                        }
                        cell.Controls.Remove(control);
                    }
                }
            }

            grdnogrn.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    protected void b2_Click(object sender, EventArgs e)
    {
        grdgrnpodsts.ShowHeader = true;
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            grdgrnpodsts.AllowPaging = false;
            this.BindGRNPODDet();

            foreach (TableCell cell in grdgrnpodsts.HeaderRow.Cells)
            {
                cell.BackColor = grdgrnpodsts.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in grdgrnpodsts.Rows)
            {

                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = grdgrnpodsts.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = grdgrnpodsts.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                    List<Control> controls = new List<Control>();

                    //Add controls to be removed to Generic List
                    foreach (Control control in cell.Controls)
                    {
                        controls.Add(control);
                    }

                    //Loop through the controls to be removed and replace with Literal
                    foreach (Control control in controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "LinkButton":
                                cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                break;
                            case "Label":
                                cell.Controls.Add(new Literal { Text = (control as Label).Text });
                                break;
                        }
                        cell.Controls.Remove(control);
                    }
                }
            }

            grdgrnpodsts.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void grdgrnpodsts_SelectedIndexChanged(object sender, EventArgs e)
    {

    }    
    protected void grdnogrn_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridViewRow grv = grdnogrn.Rows[grdnogrn.SelectedIndex];
    }

}
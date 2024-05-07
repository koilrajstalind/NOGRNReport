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

public partial class Default2 : System.Web.UI.Page
{
    public PIT.PITDATA objData = new PIT.PITDATA();
    BusinessLayer objMaster = new BusinessLayer();
    public string sts, custname;
    public decimal sumFooterValue = 0;
    public decimal sumFooterValue1 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        custname = Session["nogrnsts"].ToString();
        if (custname.Equals("") || custname.Equals(null) || custname.Equals("null"))
        {
            custname = Session["nogrnsts1"].ToString();
        }
        if (!Page.IsPostBack)
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(b1);
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
            dsName = objMaster.fnLoadGRN(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty, 0, 0, 0, 0, 0, string.Empty, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, custname.ToString(), string.Empty, string.Empty, "GetCustNoEmptyVal");
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
                grdnogrn.DataSource = dt;
                grdnogrn.DataBind();
                decimal tot1 = dt.AsEnumerable().Sum(row => row.Field<decimal>("0-10"));
                tot1 = tot1 / 100000;
                grdnogrn.FooterRow.Cells[0].Text = "Total";
                grdnogrn.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                grdnogrn.FooterRow.Cells[0].Font.Bold = true;
                //grdnogrn.FooterRow.Cells[0].Font.Size = FontUnit.Medium;
                grdnogrn.FooterRow.Cells[1].Text = tot1.ToString("N2");

                decimal tot2 = dt.AsEnumerable().Sum(row => row.Field<decimal>("11-20"));
                tot2 = tot2 / 100000;
                grdnogrn.FooterRow.Cells[2].Text = tot2.ToString("N2");

                decimal tot3 = dt.AsEnumerable().Sum(row => row.Field<decimal>("21-30"));
                tot3 = tot3 / 100000;
                grdnogrn.FooterRow.Cells[3].Text = tot3.ToString("N2");

                decimal tot4 = dt.AsEnumerable().Sum(row => row.Field<decimal>("31-45"));
                tot4 = tot4 / 100000;
                grdnogrn.FooterRow.Cells[4].Text = tot4.ToString("N2");

                decimal tot5 = dt.AsEnumerable().Sum(row => row.Field<decimal>("46-60"));
                tot5 = tot5 / 100000;
                grdnogrn.FooterRow.Cells[5].Text = tot5.ToString("N2");

                decimal tot6 = dt.AsEnumerable().Sum(row => row.Field<decimal>("61-90"));
                tot6 = tot6 / 100000;
                grdnogrn.FooterRow.Cells[6].Text = tot6.ToString("N2");

                decimal tot7 = dt.AsEnumerable().Sum(row => row.Field<decimal>("91-180"));
                tot7 = tot7 / 100000;
                grdnogrn.FooterRow.Cells[7].Text = tot7.ToString("N2");

                decimal tot8 = dt.AsEnumerable().Sum(row => row.Field<decimal>("181-365"));
                tot8 = tot8 / 100000;
                grdnogrn.FooterRow.Cells[8].Text = tot8.ToString("N2");

                decimal tot9 = dt.AsEnumerable().Sum(row => row.Field<decimal>("Above 365 day"));
                tot9 = tot9 / 100000;
                grdnogrn.FooterRow.Cells[9].Text = tot9.ToString("N2");

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
    protected void grdnogrn_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdnogrn_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            LinkButton lbtot3 = e.Row.FindControl("totval3") as LinkButton;
            ScriptManager.GetCurrent(this).RegisterPostBackControl(lbtot3);

            string tot1 = ((Label)e.Row.FindControl("tot1")).Text;
            string tot2 = ((Label)e.Row.FindControl("tot2")).Text;
            string tot3 = ((Label)e.Row.FindControl("tot3")).Text;
            string tot4 = ((Label)e.Row.FindControl("tot4")).Text;
            string tot5 = ((Label)e.Row.FindControl("tot5")).Text;
            string tot6 = ((Label)e.Row.FindControl("tot6")).Text;
            string tot7 = ((Label)e.Row.FindControl("tot7")).Text;
            string tot8 = ((Label)e.Row.FindControl("tot8")).Text;
            string tot9 = ((Label)e.Row.FindControl("tot9")).Text;
            decimal dt1 = Convert.ToDecimal(tot1);
            dt1 = dt1 / 100000;
            decimal dt2 = Convert.ToDecimal(tot2);
            dt2 = dt2 / 100000;
            decimal dt3 = Convert.ToDecimal(tot3);
            dt3 = dt3 / 100000;
            decimal dt4 = Convert.ToDecimal(tot4);
            dt4 = dt4 / 100000;
            decimal dt5 = Convert.ToDecimal(tot5);
            dt5 = dt5 / 100000;
            decimal dt6 = Convert.ToDecimal(tot6);
            dt6 = dt6 / 100000;
            decimal dt7 = Convert.ToDecimal(tot7);
            dt7 = dt7 / 100000;
            decimal dt8 = Convert.ToDecimal(tot8);
            dt8 = dt8 / 100000;
            decimal dt9 = Convert.ToDecimal(tot9);
            dt9 = dt9 / 100000;
            decimal totalvalue = dt1 + dt2 + dt3 + dt4 + dt5 + dt6 + dt7 + dt8 + dt9;
            e.Row.Cells[10].Text = totalvalue.ToString("N2");
            e.Row.Cells[1].Text = dt1.ToString("N2");
            e.Row.Cells[2].Text = dt2.ToString("N2");
            e.Row.Cells[3].Text = dt3.ToString("N2");
            e.Row.Cells[4].Text = dt4.ToString("N2");
            e.Row.Cells[5].Text = dt5.ToString("N2");
            e.Row.Cells[6].Text = dt6.ToString("N2");
            e.Row.Cells[7].Text = dt7.ToString("N2");
            e.Row.Cells[8].Text = dt8.ToString("N2");
            e.Row.Cells[9].Text = dt9.ToString("N2");
            sumFooterValue += totalvalue;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lbltotal");
            lbl.Text = sumFooterValue.ToString("N2");
            lbltot1.Text = sumFooterValue.ToString("N2");
        }
    }
    protected void grdnogrn_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        if (e.CommandName == "cmdBind")
        {
            LinkButton lb = (LinkButton)e.CommandSource;
            string[] separators = { "", "~" };
            string value = lb.Text.ToString();
            string[] words = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Session["nogrnsts1"] = words[0].ToString();
            Session["chk"] = "chk";
            Response.Redirect("frmViewGRNPODSts.aspx");
        }
    }
    protected void b1_Click(object sender, EventArgs e)
    {
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

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void grdgrnpodsts_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("frmGRNDisplay.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
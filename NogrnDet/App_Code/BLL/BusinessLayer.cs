using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BusinessLayer
{
    #region userDefinedVariable

    ArrayList alParams = new ArrayList();
    ArrayList alValues = new ArrayList();
    csdataAccess objDataAccess = new csdataAccess();
    SqlDataReader sqlDRead;
    int intReturnValue;

    #endregion

    public BusinessLayer()
	{
	}
    public ArrayList fnLoginValidate(int intLoginID, string strPassword, int intDeptID, string strIP)
    {
        try
        {
            alParams.Clear();alValues.Clear();
            alParams.Add("@intLoginID");alValues.Add(intLoginID);
            alParams.Add("@vchPassword");alValues.Add(strPassword);
            alParams.Add("@intDeptID");alValues.Add(intDeptID);
            alParams.Add("@vchIP");alValues.Add(strIP);

            sqlDRead = objDataAccess.fnExecuteReaderWithParams("procLoginValidate", alParams, alValues);
            alValues.Clear();
            while (sqlDRead.Read())
            {
                alValues.Add(sqlDRead["vchEmpName"].ToString().Trim());
                alValues.Add(sqlDRead["intTeamID"].ToString().Trim());
                alValues.Add(sqlDRead["intLevelID"].ToString().Trim());
                //alValues.Add(sqlDRead["intDesignationID"].ToString().Trim());
                alValues.Add(sqlDRead["intRoleID"].ToString().Trim());
                alValues.Add(sqlDRead["intDeptFunctionID"].ToString().Trim());
            }
            return alValues;
        }
        catch (Exception ex)
        {
            throw new Exception("fnLoginValidate- " + ex.Message);
            // provide error information for debugging
            /*string template = "Error Validating the user {0}." + " Login ID: {1}. Password: {2}\n" + "Department ID: {3}\n{4}";
            Exception informationException = new Exception(string.Format(template, intLoginID, strPassword, intDeptID, ex.Message));
            throw  informationException;*/
        }
        finally
        {
            if (sqlDRead!=null)
                sqlDRead.Close();
        }
    }
    public int fnLogOFFOrChangePwd(int intLoginID, string strPassword, string strNewPassword, string strOption)
    {
        try
        {
            alParams.Clear();alValues.Clear();
            alParams.Add("@intLoginID");alValues.Add(intLoginID);
            alParams.Add("@vchPassword");alValues.Add(strPassword);
            alParams.Add("@vchNewPassword");alValues.Add(strNewPassword);
            alParams.Add("@vchOption");alValues.Add(strOption);
            
            return objDataAccess.fnExecuteWithParams("procLoginValidate", alParams, alValues);
        }
        catch (Exception ex)
        {
            throw new Exception("fnLogOFFOrChangePwd- " + ex.Message);
        }
    }
	public DataSet fnGetMenu(string intRoleID, string strLevelID, int intEmpCode)
	{
		try
		{
			alParams.Clear(); alValues.Clear();
			alParams.Add("@intRoleID"); alValues.Add(intRoleID);
			alParams.Add("@vchLevelID"); alValues.Add(strLevelID);
			alParams.Add("@intEmpCode"); alValues.Add(intEmpCode);

			return objDataAccess.fnDSWithParams("procGetMenu", alParams, alValues);
		}
		catch (Exception ex)
		{
			throw new Exception("fnGetMenu- " + ex.Message);
		}
	}

    public int fnSaveUpdateGRN(string @plant, string @devision, string @acttype, string @invno, string @grndate, string @gstinvno, int @age, string @agegrp, decimal @salesval, decimal @cgstamnt, decimal @sgstamnt, decimal @igstamnt, decimal @drval, string @matcode, string @custmatcode, string @descptn, decimal @quantity, string @custpono, string @cdate, string @LRNo, string @carrier, string @podsts, string @podblsts, string @custcode, string @custname, string @custgrp, string @created_date, string @updated_date, string @Option)
    {
        try
        {
            alParams.Clear(); alValues.Clear();
            alParams.Add("@plant"); alValues.Add(plant);
            alParams.Add("@devision"); alValues.Add(devision);
            alParams.Add("@acttype"); alValues.Add(acttype);
            alParams.Add("@invno"); alValues.Add(invno);
            alParams.Add("@grndate"); alValues.Add(grndate);
            alParams.Add("@gstinvno"); alValues.Add(gstinvno);
            alParams.Add("@age"); alValues.Add(age);
            alParams.Add("@agegrp"); alValues.Add(agegrp);
            alParams.Add("@salesval"); alValues.Add(salesval);
            alParams.Add("@cgstamnt"); alValues.Add(cgstamnt);
            alParams.Add("@sgstamnt"); alValues.Add(sgstamnt);
            alParams.Add("@igstamnt"); alValues.Add(igstamnt);
            alParams.Add("@drval"); alValues.Add(drval);
            alParams.Add("@matcode"); alValues.Add(matcode);
            alParams.Add("@custmatcode"); alValues.Add(custmatcode);
            alParams.Add("@descptn"); alValues.Add(descptn);
            alParams.Add("@quantity"); alValues.Add(quantity);
            alParams.Add("@custpono"); alValues.Add(custpono);
            alParams.Add("@cdate"); alValues.Add(cdate);
            alParams.Add("@LRNo"); alValues.Add(LRNo);
            alParams.Add("@carrier"); alValues.Add(carrier);
            alParams.Add("@podsts"); alValues.Add(podsts);
            alParams.Add("@podblsts"); alValues.Add(podblsts);
            alParams.Add("@custcode"); alValues.Add(custcode);
            alParams.Add("@custname"); alValues.Add(custname);
            alParams.Add("@custgrp"); alValues.Add(custgrp);
            alParams.Add("@created_date"); alValues.Add(created_date);
            alParams.Add("@updated_date"); alValues.Add(updated_date);
            alParams.Add("@Option"); alValues.Add(Option);
            return objDataAccess.fnExecuteWithParams("proc_GRNDet", alParams, alValues);
        }
        catch (Exception ex)
        {
            throw new Exception("fnInsertUpdate- " + ex.Message);
        }

    }
    public DataSet fnLoadGRN(string @plant, string @devision, string @acttype, string @invno, string @grndate, string @gstinvno, int @age, string @agegrp, decimal @salesval, decimal @cgstamnt, decimal @sgstamnt, decimal @igstamnt, decimal @drval, string @matcode, string @custmatcode, string @descptn, decimal @quantity, string @custpono, string @cdate, string @LRNo, string @carrier, string @podsts, string @podblsts, string @custcode, string @custname, string @custgrp, string @created_date, string @updated_date, string @Option)
    {
        try
        {
            alParams.Clear(); alValues.Clear();
            alParams.Add("@plant"); alValues.Add(plant);
            alParams.Add("@devision"); alValues.Add(devision);
            alParams.Add("@acttype"); alValues.Add(acttype);
            alParams.Add("@invno"); alValues.Add(invno);
            alParams.Add("@grndate"); alValues.Add(grndate);
            alParams.Add("@gstinvno"); alValues.Add(gstinvno);
            alParams.Add("@age"); alValues.Add(age);
            alParams.Add("@agegrp"); alValues.Add(agegrp);
            alParams.Add("@salesval"); alValues.Add(salesval);
            alParams.Add("@cgstamnt"); alValues.Add(cgstamnt);
            alParams.Add("@sgstamnt"); alValues.Add(sgstamnt);
            alParams.Add("@igstamnt"); alValues.Add(igstamnt);
            alParams.Add("@drval"); alValues.Add(drval);
            alParams.Add("@matcode"); alValues.Add(matcode);
            alParams.Add("@custmatcode"); alValues.Add(custmatcode);
            alParams.Add("@descptn"); alValues.Add(descptn);
            alParams.Add("@quantity"); alValues.Add(quantity);
            alParams.Add("@custpono"); alValues.Add(custpono);
            alParams.Add("@cdate"); alValues.Add(cdate);
            alParams.Add("@LRNo"); alValues.Add(LRNo);
            alParams.Add("@carrier"); alValues.Add(carrier);
            alParams.Add("@podsts"); alValues.Add(podsts);
            alParams.Add("@podblsts"); alValues.Add(podblsts);
            alParams.Add("@custcode"); alValues.Add(custcode);
            alParams.Add("@custname"); alValues.Add(custname);
            alParams.Add("@custgrp"); alValues.Add(custgrp);
            alParams.Add("@created_date"); alValues.Add(created_date);
            alParams.Add("@updated_date"); alValues.Add(updated_date);
            alParams.Add("@Option"); alValues.Add(Option);
            return objDataAccess.fnDSWithParams("proc_GRNDet", alParams, alValues);
        }
        catch (Exception ex)
        {
            throw new Exception("fnTRHeader- " + ex.Message);
        }
    }   

}
﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmpBLL
/// </summary>
public class EmpBLL
{
    #region userDefinedVariable

    ArrayList alParams = new ArrayList();
    ArrayList alValues = new ArrayList();
    EmpDalc objDataAccess = new EmpDalc();
    SqlDataReader sqlDRead;
    int intReturnValue;

    #endregion
    public EmpBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public ArrayList fnLoginValidate(int intLoginID, string strPassword, int intDeptID, string strIP)
    {
        try
        {
            alParams.Clear(); alValues.Clear();
            alParams.Add("@intLoginID"); alValues.Add(intLoginID);
            alParams.Add("@vchPassword"); alValues.Add(strPassword);
            alParams.Add("@intDeptID"); alValues.Add(intDeptID);
            alParams.Add("@vchIP"); alValues.Add(strIP);

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
            if (sqlDRead != null)
                sqlDRead.Close();
        }
    }
    //Data exchange Save request and document details
    public int fnEmployeeSave(string vcode, string vname, string vpassword, string email, string vtype, string vRole, string sts, string strOption)
    {
        try
        {

            alParams.Clear(); alValues.Clear();
            alParams.Add("@UserID"); alValues.Add(vcode);
            alParams.Add("@UserName"); alValues.Add(vname);
            alParams.Add("@Password"); alValues.Add(vpassword);
            alParams.Add("@email"); alValues.Add(email);
            alParams.Add("@vtype"); alValues.Add(vtype);
            alParams.Add("@vRole"); alValues.Add(vRole);
            alParams.Add("@sts"); alValues.Add(sts);
            alParams.Add("@Option"); alValues.Add(strOption);
            return objDataAccess.fnExecuteWithParams("procLogin", alParams, alValues);
        }
        catch (Exception ex)
        {
            throw new Exception("Register- " + ex.Message);
        }
    }
    public DataSet fnLoadEmployee(string vcode, string vname, string vpassword, string email, string vtype, string vRole, string sts, string strOption)
    {
        try
        {
            alParams.Clear(); alValues.Clear();
            alParams.Add("@UserID"); alValues.Add(vcode);
            alParams.Add("@UserName"); alValues.Add(vname);
            alParams.Add("@Password"); alValues.Add(vpassword);
            alParams.Add("@email"); alValues.Add(email);
            alParams.Add("@vtype"); alValues.Add(vtype);
            alParams.Add("@vRole"); alValues.Add(vRole);
            alParams.Add("@sts"); alValues.Add(sts);
            alParams.Add("@Option"); alValues.Add(strOption);
            return objDataAccess.fnDSWithParams("procLogin", alParams, alValues);

        }
        catch (Exception ex)
        {
            throw new Exception("Vendor Register - procLogin - " + ex.Message);
        }
    }

    public ArrayList fnLoginUser(string Empcode, string Empname, string password, string Plant, string strOption)
    {
        try
        {
            alParams.Clear(); alValues.Clear();
            alParams.Add("@Empcode"); alValues.Add(Empcode);
            alParams.Add("@Empname"); alValues.Add(Empname);
            alParams.Add("@password"); alValues.Add(password);
            alParams.Add("@Plant"); alValues.Add(Plant);
            alParams.Add("@Option"); alValues.Add(strOption);
            sqlDRead = objDataAccess.fnExecuteReaderWithParams("procLogin", alParams, alValues);
            alValues.Clear();
            while (sqlDRead.Read())
            {
                alValues.Add(sqlDRead["EMP_CODE"].ToString().Trim());
                alValues.Add(sqlDRead["EMP_NAME"].ToString().Trim());
                alValues.Add(sqlDRead["DESIG_CODE"].ToString().Trim());
                alValues.Add(sqlDRead["TEAM_CODE"].ToString().Trim());
                alValues.Add(sqlDRead["PLANT_CODE"].ToString().Trim());
                alValues.Add(sqlDRead["ROLE"].ToString().Trim());
                alValues.Add(sqlDRead["EMAIL"].ToString().Trim());
                alValues.Add(sqlDRead["REPORT_TO"].ToString().Trim());
                alValues.Add(sqlDRead["REV_EMAIL"].ToString().Trim());
                alValues.Add(sqlDRead["APPROVER"].ToString().Trim());
                alValues.Add(sqlDRead["APP_EMAIL"].ToString().Trim());
                alValues.Add(sqlDRead["APPROVER1"].ToString().Trim());
                alValues.Add(sqlDRead["APP1_EMAIL"].ToString().Trim());
                alValues.Add(sqlDRead["DESIGNATION"].ToString().Trim());
                alValues.Add(sqlDRead["TITLE"].ToString().Trim());
                alValues.Add(sqlDRead["MOBILENO"].ToString().Trim());
            }
            return alValues;
        }
        catch (Exception ex)
        {
            throw new Exception("fnLoginValidateCustomer- " + ex.Message);

        }
        finally
        {
            if (sqlDRead != null)
                sqlDRead.Close();
        }
    }
    public ArrayList fnLoginValidateVendor(string strVcode, string strVName, string strPassword, string strEmail, string strRole, string strOption)
    {
        try
        {
            alParams.Clear(); alValues.Clear();
            alParams.Add("@UserID"); alValues.Add(strVcode);
            alParams.Add("@UserName"); alValues.Add(strVName);
            alParams.Add("@Password"); alValues.Add(strPassword);
            alParams.Add("@email"); alValues.Add(strEmail);



            alParams.Add("@Option"); alValues.Add(strOption);
            sqlDRead = objDataAccess.fnExecuteReaderWithParams("procLogin", alParams, alValues);
            alValues.Clear();
            while (sqlDRead.Read())
            {
                alValues.Add(sqlDRead["UserID"].ToString().Trim());
                alValues.Add(sqlDRead["UserName"].ToString().Trim());
                alValues.Add(sqlDRead["email"].ToString().Trim());
                alValues.Add(sqlDRead["vtype"].ToString().Trim());
                alValues.Add(sqlDRead["vrole"].ToString().Trim());
                alValues.Add(sqlDRead["sts"].ToString().Trim());

            }
            return alValues;
        }
        catch (Exception ex)
        {
            throw new Exception("fnLoginValidateVendor- " + ex.Message);

        }
        finally
        {
            if (sqlDRead != null)
                sqlDRead.Close();
        }
    }

    public int fnLogOFFOrChangePwd(int intLoginID, string strPassword, string strNewPassword, string strOption)
    {
        try
        {
            alParams.Clear(); alValues.Clear();
            alParams.Add("@intLoginID"); alValues.Add(intLoginID);
            alParams.Add("@vchPassword"); alValues.Add(strPassword);
            alParams.Add("@vchNewPassword"); alValues.Add(strNewPassword);
            alParams.Add("@vchOption"); alValues.Add(strOption);

            return objDataAccess.fnExecuteWithParams("procLoginValidate", alParams, alValues);
        }
        catch (Exception ex)
        {
            throw new Exception("fnLogOFFOrChangePwd- " + ex.Message);
        }
    }
}
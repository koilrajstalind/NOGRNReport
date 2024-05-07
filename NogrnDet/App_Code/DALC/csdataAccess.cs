using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class csdataAccess
{
    #region userDefinedVariable

    string strConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
    SqlConnection sqlCon;
    SqlCommand sqlCmd;
    SqlDataAdapter sqlDA;
    SqlDataReader sqlDR;
    DataSet ds;
    int intReturnValue;
    string strReturnValue;

    #endregion

    public csdataAccess()
	{
        fnGetSQLConnection();
	}
    private void fnGetSQLConnection()
    {
        sqlCon = null;
        sqlCon = new SqlConnection(strConnectionString);
    }
    private void fnOpenSQLConnection()
    {
        try
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }
        catch (Exception ex)
        { throw new HttpException("fnOpenSQLConnection- " +  ex.Message); }
    }
    private void fnCloseSQLConnection()
    {
        try
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
        catch (Exception ex)
        { throw new HttpException("fnCloseSQLConnection- " +  ex.Message); }
    }
    public int fnExecuteWithParams(string strProcName, ArrayList alParam, ArrayList alValue)
    {
        try
        {
            sqlCmd = new SqlCommand(strProcName, sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = 120;
            for (int i = 0; i < alParam.Count; i++)
            {
               if (alValue[i].ToString().Length == 0)
                  sqlCmd.Parameters.AddWithValue(alParam[i].ToString().Trim(), String.Empty);
                else
                  sqlCmd.Parameters.AddWithValue(alParam[i].ToString().Trim(), alValue[i].ToString());
            }
            fnOpenSQLConnection();
            intReturnValue = sqlCmd.ExecuteNonQuery();
            return intReturnValue;

        }
        catch (Exception ex)
        { throw new HttpException("fnExecuteWithParams- " + ex.Message); }
        finally
        { fnCloseSQLConnection(); }
    }

    public int fnExecuteScalarWithParams(string strProcName, ArrayList alParam, ArrayList alValue)
    {
        try
        {
            sqlCmd = new SqlCommand(strProcName, sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = 120;
            for (int i = 0; i < alParam.Count; i++)
            {
                if (alValue[i].ToString().Trim().Length==0)
                    sqlCmd.Parameters.AddWithValue(alParam[i].ToString().Trim(), String.Empty);
                else
                    sqlCmd.Parameters.AddWithValue(alParam[i].ToString().Trim(), alValue[i].ToString().Trim());
            }
            fnOpenSQLConnection();
            intReturnValue = (int)sqlCmd.ExecuteScalar();
            return intReturnValue;
        }
        catch (Exception ex)
        { throw new HttpException("fnExecuteScalarWithParams- " + ex.Message); }
        finally  { fnCloseSQLConnection(); }
    }
    public DataSet fnDSWithParams(string strProcName, ArrayList alParam, ArrayList alValue)
    {
        try
        {
            sqlDA = new SqlDataAdapter(strProcName, sqlCon);
            sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDA.SelectCommand.CommandTimeout = 120;
            for (int i = 0; i < alParam.Count; i++)
            {
                if (alValue[i].ToString().Trim().Length == 0)
                    sqlDA.SelectCommand.Parameters.AddWithValue(alParam[i].ToString().Trim(), String.Empty);
                else
                    sqlDA.SelectCommand.Parameters.AddWithValue(alParam[i].ToString().Trim(), alValue[i].ToString().Trim());
            }
            ds = new DataSet();
            sqlDA.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        { throw new HttpException("fnDSWithParams- " + ex.Message); }
    }
    public DataSet fnDSWithoutParams(string strProcName)
    {
        try
        {
            sqlDA = new SqlDataAdapter(strProcName, sqlCon);
            sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDA.SelectCommand.CommandTimeout = 120;
            ds = new DataSet();
            sqlDA.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        { throw new HttpException("fnDSWithoutParams- " + ex.Message); }
    }
    public SqlDataReader fnExecuteReaderWithParams(string strProcName, ArrayList alParam, ArrayList alValue)
    {
        try
        {
            sqlCmd = new SqlCommand(strProcName, sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = 120;
            for (int i = 0; i < alParam.Count; i++)
            {
                if (alValue[i].ToString().Trim().Length == 0)
                    sqlCmd.Parameters.AddWithValue(alParam[i].ToString().Trim(), String.Empty);
                else
                    sqlCmd.Parameters.AddWithValue(alParam[i].ToString().Trim(), alValue[i].ToString().Trim());
            }
            fnOpenSQLConnection();
            sqlDR = sqlCmd.ExecuteReader();
            return sqlDR;
        }
        catch (Exception ex)
        {
            throw new Exception ("fnExecuteReaderWithParams- " + ex.Message);
        }
        finally
        {
            fnCloseSQLConnection();
        }
    }
}
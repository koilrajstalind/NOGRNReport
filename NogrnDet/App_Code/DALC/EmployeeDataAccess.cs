using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class EmployeeDataAccess
{
	SqlConnection sqlCon = new SqlConnection();
	public EmployeeDataAccess()
	{
        //
        // TODO: Add constructor logic here
        //

        //sqlCon.ConnectionString = ConfigurationManager.ConnectionStrings["WRS"].ToString();
        // sqlCon.ConnectionString = ConfigurationManager.ConnectionStrings["WRS"].ToString();
        sqlCon.ConnectionString = ConfigurationManager.ConnectionStrings["WRS"].ToString();

    }
	private Boolean OpenConnection()
	{
		try
		{
			if (sqlCon.State == ConnectionState.Closed)
			{
				sqlCon.Open();
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private Boolean CloseConnection()
	{
		try
		{
			sqlCon.Close();
			return true;
		}
		catch
		{
			return false;
		}
	}

	/// <summary>
	/// execute the query
	/// </summary>
	/// <param name="strQuery">query</param>
	/// <returns></returns>
	public int ExecuteQuery(string strQuery)
	{
		try
		{
			SqlCommand sqlCmd = new SqlCommand();
			sqlCmd.CommandText = strQuery;
			sqlCmd.Connection = sqlCon;
			int iAffected = 0;
			if (OpenConnection() == true)
			{
				iAffected = sqlCmd.ExecuteNonQuery();
			}
			CloseConnection();
			return iAffected;
		}
		catch(Exception e)
		{
			return 0;
		}
	}

	/// <summary>
	/// return the dataset
	/// </summary>
	/// <param name="strQuery"></param>
	/// <returns>query</returns>
	public DataSet GetDataset(string strQuery)
	{
		try
		{
			SqlCommand sqlCmd = new SqlCommand();
			sqlCmd.CommandText = strQuery;
			sqlCmd.Connection = sqlCon;
			DataSet ds = new DataSet();
			if (OpenConnection() == true)
			{
				SqlDataAdapter dap = new SqlDataAdapter();
				dap.SelectCommand = sqlCmd;
				dap.Fill(ds);
			}
			CloseConnection();
			return ds;
		}
		catch
		{
			return null;
		}
	}

	/// <summary>
	/// return the datareader
	/// </summary>
	/// <param name="strQuery">query</param>
	/// <returns></returns>
	public SqlDataReader GetDataReader(string strQuery)
	{
		try
		{
			SqlCommand sqlCmd = new SqlCommand();
			sqlCmd.CommandText = strQuery;
			sqlCmd.Connection = sqlCon;
			SqlDataReader dr = null;
			if (OpenConnection() == true)
			{
				dr = sqlCmd.ExecuteReader();
			}
          //  CloseConnection();
            return dr;
           
        }
        catch
		{
			return null;
		}


	}

	/// <summary>
	/// method for add data table to specfic dataset
	/// </summary>
	/// <param name="strQuery">sql query</param>
	/// <param name="dtName">Datatable Name</param>
	/// <param name="ds">Dataset</param>
	/// <returns></returns>
	public DataSet FillDataTable(string strQuery, string dtName, DataSet ds)
	{
		try
		{
			SqlCommand sqlCmd = new SqlCommand();
			sqlCmd.CommandText = strQuery;
			sqlCmd.Connection = sqlCon;
			if (OpenConnection() == true)
			{
				SqlDataAdapter dap = new SqlDataAdapter();
				dap.SelectCommand = sqlCmd;
				DataTable dtNew = new DataTable();
				dtNew.TableName = dtName;
				dap.Fill(dtNew);
				ds.Tables.Add(dtNew);
			}
			CloseConnection();
			return ds;
		}
		catch
		{
			return ds;
		}
	}

	public Boolean ExecuteList(ArrayList arrQueries)
	{
		SqlTransaction sqlTran = null;
		try
		{
			SqlCommand sqlCmd = new SqlCommand();
			sqlCmd.Connection = sqlCon;
			if (OpenConnection() == true)
			{
				sqlTran = sqlCon.BeginTransaction(IsolationLevel.Serializable, "ListExecution");
				sqlCmd.Transaction = sqlTran;
				for (int count = 0; count < arrQueries.Count; count++)
				{
					if (sqlCon.State == ConnectionState.Open)
					{
						sqlCmd.CommandText = arrQueries[count].ToString();
						sqlCmd.ExecuteNonQuery();
					}
				}
				sqlTran.Commit();
			}
			CloseConnection();
			return true;
		}
		catch
		{
			if (sqlTran != null)
			{
				sqlTran.Rollback();
			}
			return false;
		}
	}


	//public DataSet GetDataFromDB(T2TRAQ.DATA.CommonData obj)
	//{
	//    StringBuilder dataSB = GetDynamicQueryString(obj);
	//    return objDalc.GetDataset(dataSB.ToString());
	//}

	// private StringBuilder GetDynamicQueryString(T2TRAQ.DATA.CommonData obj)
	//{
	//    try
	//    {
	//        StringBuilder sbQueryStr = new StringBuilder();
	//        sbQueryStr.Append("select ");

	//        if ((obj.ColumnNames != null) && (obj.ColumnNames != ""))
	//        {
	//            sbQueryStr.Append(obj.ColumnNames);
	//        }
	//        else
	//        {
	//            sbQueryStr.Append(" * ");
	//        }
	//        sbQueryStr.Append(" from ");
	//        sbQueryStr.Append(obj.TableName);

	//        if (obj.SearchCondition != null && obj.SearchCondition != "")
	//        {
	//            sbQueryStr.Append(" where ");
	//            sbQueryStr.Append(obj.SearchCondition);
	//        }

	//        if ((obj.OrderBy != null) && (obj.OrderBy != ""))
	//        {
	//            sbQueryStr.Append(" order by ");
	//            sbQueryStr.Append(obj.OrderBy);
	//            //sbQueryStr.Append("  ");
	//            //sbQueryStr.Append(obj.RecordAscOrDesc);
	//        }

	//        return sbQueryStr;
	//    }
	//    catch (Exception ex)
	//    {
	//        throw ex;
	//    }
	//}

	//public Boolean ExecuteList(ArrayList arrQueries)
	//{
	//    return objDalc.ExecuteList(arrQueries);
	//}

}
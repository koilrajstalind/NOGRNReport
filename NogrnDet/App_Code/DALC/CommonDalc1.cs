using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OracleClient;
using System.Web.UI;


namespace Framework.Common.DataAccess
{
    public class CommonDalc1
    {

        OracleConnection sqlCon = new OracleConnection();
        public CommonDalc1()
        {
            //
            // TODO: Add constructor logic here
            //
            sqlCon.ConnectionString = ConfigurationSettings.AppSettings["WRS"];
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
                OracleCommand sqlCmd = new OracleCommand();
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
            catch
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
                OracleCommand sqlCmd = new OracleCommand();
                sqlCmd.CommandText = strQuery;
                sqlCmd.Connection = sqlCon;
                DataSet ds = new DataSet();
                if (OpenConnection() == true)
                {
                    OracleDataAdapter dap = new OracleDataAdapter();
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
        public OracleDataReader GetDataReader(string strQuery)
        {
            try
            {
                OracleCommand sqlCmd = new OracleCommand();
                sqlCmd.CommandText = strQuery;
                sqlCmd.Connection = sqlCon;
                OracleDataReader dr = null;
                if (OpenConnection() == true)
                {
                    dr = sqlCmd.ExecuteReader();
                }
                CloseConnection();
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
                OracleCommand sqlCmd = new OracleCommand();
                sqlCmd.CommandText = strQuery;
                sqlCmd.Connection = sqlCon;
                if (OpenConnection() == true)
                {
                    
                    OracleDataAdapter dap = new OracleDataAdapter();
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

        /// <summary>
        /// Method for execute the List of queries
        /// </summary>
        /// <param name="arrQueries">Query list</param>
        /// <returns></returns>
        public Boolean ExecuteList(ArrayList arrQueries)
        {
            try
            {
                OracleCommand sqlCmd = new OracleCommand();
                sqlCmd.Connection = sqlCon;
                if (OpenConnection() == true)
                {
                    for (int count = 0; count < arrQueries.Count; count++)
                    {
                        if (sqlCon.State == ConnectionState.Open)
                        {
                            sqlCmd.CommandText = arrQueries[count].ToString();
                            sqlCmd.ExecuteNonQuery();
                        }
                    }
                }
                CloseConnection();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class PITEmployeeLayer
{
    #region userDefinedVariable

    ArrayList alParams = new ArrayList();
    ArrayList alValues = new ArrayList();
	EmployeeDataAccess objDataAccess = new EmployeeDataAccess();
    SqlDataReader sqlDRead;
    int intReturnValue;

    #endregion

    public PITEmployeeLayer()
	{
	}


	public DataSet GetPANInformation(string empCode)
	{
		string strQuery = string.Empty;
		DataSet dsrole = null;
		try
		{
			strQuery = "SELECT emp_name,PAN_NO FROM EmployeeMaster where emp_code='" + empCode.ToString() + "' and status='A'";
			dsrole = objDataAccess.GetDataset(strQuery);
			return dsrole;

		}
		catch (Exception ex)
		{
			throw new Exception("GetPANInformation- " + ex.Message);
		}
	}


}
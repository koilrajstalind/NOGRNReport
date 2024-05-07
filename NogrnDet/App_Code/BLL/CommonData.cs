/*
 * =======================================================================
 * Application              :   PRA.LAB - MATSMS
 * Module                   :   Test
 * Company Name             :   PRICOL
 * Form/Class               :  
 * Version                  :
 * SRS Id                   :   
 * Created By               :  Ramkumar.M
 * Created On               :  27/06/2008
 * Purpose                  :
 * Components/Services Used :   
 * Libraries Used           :
 * Modification History     :
 *
 *  Date               Author              Change  
 *  
 * =======================================================================
 *
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace OperationProfit.DATA
{
    public class CommonData
    {

        #region "Common"

        private DataSet _dsGridValues;

        public DataSet dsGridValues
        {
            get { return _dsGridValues; }
            set { _dsGridValues = value; }
        }
        private string strTableName;
        private string strColumnNames;
        private string strSearchCondition;
        private string strPkey;
        private string strUser;
        private string strOrderBy;
       // private string curntpwd;
        private string nwpwd;
        private string strFlag;
        private string strCurMonthYear;
        private string cfrmpwd;
        private string Employeecode;
        private string strFromDate;
        private string strToDate;

        public string UserName
        {
            get { return strUser; }
            set { strUser = value; }

        }

        public string PriKey
        {
            get { return strPkey; }
            set { strPkey = value; }
        }

        public string EmpCode
        {
            get { return Employeecode; }
            set { Employeecode = value; }
        }


        public string crntpwd
        {
            get { return crntpwd; }
            set { crntpwd = value; }
        }



        public string newpwd
        {
            get { return nwpwd; }
            set { nwpwd = value; }
        }

        public string cnfrmpwd
        {
            get { return cfrmpwd; }
            set { cfrmpwd = value; }
        }




        private string strPrimaryColIndex;
        private string strPrimaryKeyColumns;

        public string TableName
        {
            get { return strTableName; }
            set { strTableName = value; }
        }

        public string ColumnNames
        {
            get { return strColumnNames; }
            set { strColumnNames = value; }
        }
        public string SearchCondition
        {
            get { return strSearchCondition; }
            set { strSearchCondition = value; }
        }

        public string PrimaryColIndex
        {
            get { return strPrimaryColIndex; }
            set { strPrimaryColIndex = value; }
        }
        public string PrimaryKeyColumns
        {
            get { return strPrimaryKeyColumns; }
            set { strPrimaryKeyColumns = value; }
        }

        public string OrderBy
        {
            get { return strOrderBy; }
            set { strOrderBy = value; }
        }

        public string Flag
        {
            get { return strFlag; }
            set { strFlag = value; }
        }

        public string CurrentMonthYear
        {
            get { return strCurMonthYear; }
            set { strCurMonthYear = value; }
        }

        public string FromDate
        {
            get { return strFromDate; }
            set { strFromDate = value; }
        }

        public string ToDate
        {
            get { return strToDate; }
            set { strToDate = value; }
        }
        #endregion

    }
}

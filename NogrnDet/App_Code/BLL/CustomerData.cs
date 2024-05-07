/*
 * =======================================================================
 * Application              :  OperationProfit Creation
 * Module                   :  Hi
 * Company Name             :  PRICOL
 * Form/Class               :  Hi
 * Version                  :  Hi
 * SRS Id                   :  Hi 
 * Created By               :  Dayakar.G
 * Created On               :  05.02.2013
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
using System.Data.SqlClient;

namespace OperationProfit.DATA
{
    public class CustomerData
    {

        private string customercode;
        public string CustomerCode
        {
            get { return customercode; }
            set { customercode = value; }
        }
        
        private string customername;        
        public string CustomerName
        {
            get { return customername; }
            set { customername = value; }
        }

        private string addrs1;
        public string Address1
        {
            get { return addrs1; }
            set { addrs1 =value ;}
        }
        private string addrs2;
        public string Address2
        {
            get { return addrs2; }
            set { addrs2 = value; }
        }

        private string flag;
        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }

    }
}

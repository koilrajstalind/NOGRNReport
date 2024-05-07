using System;
using System.Collections.Generic;
using System.Text;

namespace OperationProfit.DATA
{
    public class General
    {
        public General()
        {
            //Constructor
        }

        private string strUserName;

        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        private string strPassword;

        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }
	
    }
}

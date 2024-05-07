/* =======================================================================
 * Application              :   SAP USER ACCCESS LOG SYSTEM
 * Module                   :   
 * Company Name             :   PRICOL
 * Form/Class               :  
 * Version                  :
 * SRS Id                   :   
 * Created By               :  Dayakar.G
 * Created On               :  18.11.2011
 * Purpose                  :  sap user access log
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
using System.Collections;
using System.Text;
using System.IO;
using System.Data;
namespace PIT
{
    public class PITDATA
	{
        private string strempcode;
        public string empcode
        {
            get { return strempcode; }
            set { strempcode = value; }
        }

        private string strContinerType;
        public string ContinerType
        {
            get { return strContinerType; }
            set { strContinerType = value; }
        }
        //vendor
        private string strvcode;
        public string vcode
        {
            get { return strvcode; }
            set { strvcode = value; }
        }

        private string strIssueDate;
        public string IssueDate
        {
            get { return strIssueDate; }
            set { strIssueDate = value; }
        }

        private string strnoofCopy;
        public string noofCopy
        {
            get { return strnoofCopy; }
            set { strnoofCopy = value; }
        }

        private string strDesc;
        public string Description
        {
            get { return strDesc; }
            set { strDesc = value; }
        }

        private string strvname;
        public string Vendorname
        {
            get { return strvname; }
            set { strvname = value; }
        }
        private string strvcontact;
        public string VendorContact
        {
            get { return strvcontact; }
            set { strvcontact = value; }
        }
        private string strvEmail;
        public string VendorEmail
        {
            get { return strvEmail; }
            set { strvEmail = value; }
        }

        //vendor
        private string strApproverstatus;
        public string Approverstatus
        {
            get { return strApproverstatus; }
            set { strApproverstatus = value; }
        }
        private string strApproverComment;
        public string ApproverComment
        {
            get { return strApproverComment; }
            set { strApproverComment = value; }
        }
        private string strApprover;
        public string Approver
        {
            get { return strApprover; }
            set { strApprover = value; }
        }

        private string strApproverEmail;
        public string ApproverEmail
        {
            get { return strApproverEmail; }
            set { strApproverEmail = value; }
        }

        private string strstatus;
        public string status
        {
            get { return strstatus; }
            set { strstatus = value; }
        }
        private string strContinerID;
        public string ContinerID
        {
            get { return strContinerID; }
            set { strContinerID = value; }
        } 
        private string strContinerDetails;
        public string ContinerDetails
        {
            get { return strContinerDetails; }
            set { strContinerDetails = value; }
        }
        private string strReleaseID;
        public string ReleaseID
        {
            get { return strReleaseID; }
            set { strReleaseID = value; }
        }

      
        private string strDrawingType;
        public string DrawingType
        {
            get { return strDrawingType; }
            set { strDrawingType = value; }
        }
        private string strDrawingsize;
        public string DrawingSize
        {
            get { return strDrawingsize; }
            set { strDrawingsize = value; }
        }   
        private string strReleaseType;
        public string ReleaseType
        {
            get { return strReleaseType; }
            set { strReleaseType = value; }
        }

        //OperationProfit Request
        private string strSNo;
        public string ReqSNo
        {
            get { return strSNo; }
            set { strSNo = value; }
        }


        private string strReqID;
        public string ReqID
        {
            get { return strReqID; }
            set { strReqID = value; }
        }
        private string strIniID;
        public string  INI_ID
        {
            get { return strIniID; }
            set { strIniID = value; }
        }

        private string strIniName;
        public string INI_NAME
        {
            get { return strIniName; }
            set { strIniName = value; }
        }

        private string strIniContactNo;
        public string INI_ContactNo
        {
            get { return strIniContactNo; }
            set { strIniContactNo = value; }
        }

        private string strIniplant;
        public string INI_Plant
        {
            get { return strIniplant; }
            set { strIniplant = value; }
        }
        private string strInidepart;
        public string INI_Department
        {
            get { return strInidepart; }
            set { strInidepart = value; }
        }

        private string strIniemail;
        public string INI_Email
        {
            get { return strIniemail; }
            set { strIniemail = value; }
        }
        private string strreqpurpose;
        public string DrawingReqPurpose
        {
            get { return strreqpurpose; }
            set { strreqpurpose = value; }
        }
        private string strhardCopy;
        public string HardCopy
        {
            get { return strhardCopy; }
            set { strhardCopy = value; }
        }
        //OperationProfit Request
        private string strDraNo;
        public string DraNo
        {
            get { return strDraNo; }
            set { strDraNo = value; }
        }
        private string strOldDraNo;
        public string OldDraNo
        {
            get { return strOldDraNo; }
            set { strOldDraNo = value; }
        }

        //common OperationProfit
        private string strcommDraNo;
        public string CommDraNo
        {
            get { return strcommDraNo; }
            set { strcommDraNo = value; }
        }

        private string strOldcommDraNo;
        public string OldcommDraNo
        {
            get { return strOldcommDraNo; }
            set { strOldcommDraNo = value; }
        }
        
        private string strcommDraDescription;
        public string ComDrawDescription
        {
            get { return strcommDraDescription; }
            set { strcommDraDescription = value; }
        }

        private string strcomDrawRevisionNo;
        public string ComDrawRevisionNo
        {
            get { return strcomDrawRevisionNo; }
            set { strcomDrawRevisionNo = value; }
        }
       
        private string strDocType;
        public string DocType
        {
            get { return strDocType; }
            set { strDocType = value; }
        }
       
        private string stindDrawSno;
        public string IndDrawSno
        {
            get { return stindDrawSno; }
            set { stindDrawSno = value; }
        }
        private string stindDraw;
        public string IndDrawNo
        {
            get { return stindDraw; }
            set { stindDraw = value; }
        }
        private string strRviseOldDrawing;
        public string ReviseOldDrawing
        {
            get { return strRviseOldDrawing; }
            set { strRviseOldDrawing = value; }
        }
        private string strReviseSAPDrawing;
        public string ReviseSAPDrawing
        {
            get { return strReviseSAPDrawing; }
            set { strReviseSAPDrawing = value; }
        }
        private string strReviseDrawingDescription;
        public string ReviseDrawingDescription
        {
            get { return strReviseDrawingDescription; }
            set { strReviseDrawingDescription = value; }
        }
        // End common OperationProfit

        // Ind OperationProfit

        





        private string strIndSapDraNo;
        public string IndSapDrawNo
        {
            get { return strIndSapDraNo; }
            set { strIndSapDraNo = value; }
        }

        private string strIndOldDraNo;
        public string IndOldDraNo
        {
            get { return strIndOldDraNo; }
            set { strIndOldDraNo = value; }
        }
        private string strUploadDrawingNo;
        public string UploadDrawingNo
        {
            get { return strUploadDrawingNo; }
            set { strUploadDrawingNo = value; }
        }
        private string strRefNo;
        public string ReferenceNo
        {
            get { return strRefNo; }
            set { strRefNo = value; }
        }

        private string strRemarks;
        public string Remarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }
        }


        private string strmaterialDesc;
        public string MaterialDesc
        {
            get { return strmaterialDesc; }
            set { strmaterialDesc = value; }
        }
        private string strIssueLocation;
        public string IssueLocation
        {
            get { return strIssueLocation; }
            set { strIssueLocation = value; }
        }
        private string strPrintEnable;
        public string PrintEnable
        {
            get { return strPrintEnable; }
            set { strPrintEnable = value; }
        }
        private string strHardCopyEnable;
        public string HardCopyEnable
        {
            get { return strHardCopyEnable; }
            set { strHardCopyEnable = value; }
        }
        private string strPrintEndDate;
        public string PrintEndDate
        {
            get { return strPrintEndDate; }
            set { strPrintEndDate = value; }
        }
        private string strReleaseDate;
        public string ReleaseDate
        {
            get { return strReleaseDate; }
            set { strReleaseDate = value; }
        }

        private string strTargetDate;
        public string TargetDate
        {
            get { return strTargetDate; }
            set { strTargetDate = value; }
        }

        private string strUplodDrawingFile;
        public string UplodDrawingFile
        {
            get { return strUplodDrawingFile; }
            set { strUplodDrawingFile = value; }
        }
        private string strIndDraDescription;
        public string IndDrawDescription
        {
            get { return strIndDraDescription; }
            set { strIndDraDescription = value; }
        }

        private string strIndSapComDrawingNo;
        public string IndSapComDrawingNo
        {
            get { return strIndSapComDrawingNo; }
            set { strIndSapComDrawingNo = value; }
        }
        private string strIndSapcode;
        public string IndSapcode
        {
            get { return strIndSapcode; }
            set { strIndSapcode = value; }
        }
        private string strsapcode;
        public string sapcode
        {
            get { return strsapcode; }
            set { strsapcode = value; }
        }

        private string strFromEmail;
        public string FromEmail
        {
            get { return strFromEmail; }
            set { strFromEmail = value; }
        }
        private string strFromDate;
        public string FromDate
        {
            get { return strFromDate; }
            set { strFromDate = value; }
        }

        private string strToDate;
        public string ToDate
        {
            get { return strToDate; }
            set { strToDate = value; }
        }


        

        private string strCCEmail;
        public string CCEmail
        {
            get { return strCCEmail; }
            set { strCCEmail = value; }
        }
        private string strToEmail;
        public string ToEmail
        {
            get { return strToEmail; }
            set { strToEmail = value; }
        }

        private string strsapoldcode;
        public string Sapoldcode
        {
            get { return strsapoldcode; }
            set { strsapoldcode = value; }
        }
        private string strRevision;
        public string Revision
        {
            get { return strRevision; }
            set { strRevision = value; }
        }
        private string strReleaseInfo;
        public string ReleaseInfo
        {
            get { return strReleaseInfo; }
            set { strReleaseInfo = value; }
        }
        private string struserid;
        public string Userid
        {
            get { return struserid; }
            set { struserid = value; }
        }
        private string strplant;
        public string Plant
        {
            get { return strplant; }
            set { strplant = value; }
        }
		private string strMonthYear;
		public string MonthYear
		{
			get { return strMonthYear; }
			set { strMonthYear = value; }
		}
		private string strDepartment;
        public string Department
        {
            get { return strDepartment; }
            set { strDepartment = value; }
        }

        private string strIndRevisionNo;
        public string IndRevisionNo
        {
            get { return strIndRevisionNo; }
            set { strIndRevisionNo = value; }
        }
        private string strIndDocType;
        public string IndDocType
        {
            get { return strIndDocType; }
            set { strIndDocType = value; }
        }

        private ArrayList strsapdrawing;
        public ArrayList ArrSAPDrawing
        {
            get { return strsapdrawing; }
            set { strsapdrawing = value; }
        }


        private ArrayList strcomsapdrawing;
        public ArrayList ArrComSAPDrawing
        {
            get { return strcomsapdrawing; }
            set { strcomsapdrawing = value; }
        }
         private ArrayList strcomolddrawing;
         public ArrayList ArrCommOldDrawing
        {
            get { return strcomolddrawing; }
            set { strcomolddrawing = value; }
        }
        
        private ArrayList strolddrawing;
        public ArrayList ArrOldDrawing
        {
            get { return strolddrawing; }
            set { strolddrawing = value; }
        }
        private ArrayList strrev;
        public ArrayList ArrRev
        {
            get { return strrev; }
            set { strrev = value; }
        }
        private ArrayList strDepart;
        public ArrayList ArrDepart
        {
            get { return strDepart; }
            set { strDepart = value; }
        }
        private ArrayList strtype;
        public ArrayList ArrType
        {
            get { return strtype; }
            set { strtype = value; }
        }
        private ArrayList strissuedate;
        public ArrayList ArrIssueDate
        {
            get { return strissuedate; }
            set { strissuedate = value; }
        }
        private ArrayList strDrawType;
        public ArrayList ArrDrawType
        {
            get { return strDrawType; }
            set { strDrawType = value; }
        }  
    }
}

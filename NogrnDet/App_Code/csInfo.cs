using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Ionic.Zip;
using System.Net.Mail;
using System.Collections;

public class csInfo
{
    #region UserDefinedVars
    #endregion

    public csInfo()
	{
		
	}
    public string fnConvertDateToInt(DateTime dtDate)
    {
        string strDate;
        if (dtDate.Month <= 9)
            strDate = dtDate.Year + "0" + dtDate.Month;
        else
            strDate = dtDate.Year.ToString() + dtDate.Month;
        if (dtDate.Day <= 9)
            strDate += "0" + dtDate.Day;
        else
            strDate += dtDate.Day;
        return strDate;
    }
    public string fnGetRandomPassword(int length)
    {
        char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
        string password = string.Empty;
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            int x = random.Next(1, chars.Length);
            //For avoiding Repetation of Characters
            if (!password.Contains(chars.GetValue(x).ToString()))
                password += chars.GetValue(x);
            else
                i--;
        }
        return password;
    }
    public void Export2Excel_ClearControls(Control control)
    {
        for (int i = control.Controls.Count - 1; i >= 0; i--)
        {
            Export2Excel_ClearControls(control.Controls[i]);
        }
        if (!(control is TableCell))
        {
            if (control.GetType().GetProperty("SelectedItem") != null)
            {
                LiteralControl literal = new LiteralControl();
                control.Parent.Controls.Add(literal);
                try
                {
                    literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                }
                catch
                { }
                control.Parent.Controls.Remove(control);
            }
            else if (control.GetType().GetProperty("Text") != null)
            {
                LiteralControl literal = new LiteralControl();
                control.Parent.Controls.Add(literal);
                literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                control.Parent.Controls.Remove(control);
            }
        }
        return;
    }
    //Zip files
    public bool fnZip(string strVDTrackNoPath, string strZipFolderName, string[] strAttachedFiles4Zip)
    {
        try
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFiles(strAttachedFiles4Zip, strZipFolderName);
                zip.Save(strVDTrackNoPath + ".zip");
            }
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
           
        }
    }
    //Upload files in Virtual directory
    public bool fnUploadFilesInVD(string strRequestTrackNo, DirectoryInfo dirInfoCreateDir, FileUpload fupDocs)
    {
        try
        {
            //Customer Directory exists check and create directory
            if (!dirInfoCreateDir.Exists)
                dirInfoCreateDir.Create();          
            fupDocs.SaveAs(dirInfoCreateDir + @"\" + fupDocs.PostedFile.FileName.Trim());
            return true;
        }
        catch (Exception ex)
        {
            return false;
            throw ex;
        }
    }

    public bool sendMail(ArrayList toAddress, ArrayList ccAddress, string fromAddress, string subject, string messageBody)
    {
        try
        {
            MailMessage message = new MailMessage();
            MailAddress fromEmailAddress = new MailAddress(fromAddress.ToString(), "Pricol - ToolRoom Portal");
            //From address will be given as a MailAddress Object
            message.From = fromEmailAddress;

            // To address collection of MailAddress
            if (toAddress != null)
            {
                message.To.Clear();
                for (int i = 0; i < toAddress.Count; i++)
                {
                    message.To.Add((string)toAddress[i]);
                }
            }
            message.Subject = subject;

            // CC and BCC optional
            // MailAddressCollection class is used to send the email to various users
            // You can specify Address as new MailAddress("admin1@yoursite.com")
            if (ccAddress != null)
            {
                message.CC.Clear();
                for (int i = 0; i < ccAddress.Count; i++)
                {
                    message.CC.Add((string)ccAddress[i]);

                }
            }

            //Specify true if it  is html message
            message.IsBodyHtml = true;

            // Message body content
            message.Body = messageBody;

            // Send SMTP mail
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(message);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
            return false;
        }
    }

  



   
   
  
}
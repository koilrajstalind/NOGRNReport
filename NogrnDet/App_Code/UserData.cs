#region Author
/*
 *
 * =======================================================================
 * Application              : PRA LAB - MATSMS
 * Module                   : 
 * Version                  : 
 * SRS Id                   :   
 * Created By               : 
 * Created On               : 
 * Purpose                  : 
 * Components/Services Used : 
 * Libraries Used           :
 * Tables Affected          : 
 * Modification History     :
 *
 *  Date               Author              Change  
 *  
 * =======================================================================
 *
 */
#endregion
using System;
using System.Collections.Generic;
using System.Text;

public class UserData
{
	private string _userID;
	public string UserID
	{
		get { return _userID; }
		set { _userID = value; }
	}


	private string _Email;
	public string Email
	{
		get { return _Email; }
		set { _Email = value; }
	}

	private string _areaCode;
	public string AreaCode
	{
		get { return _areaCode; }
		set { _areaCode = value; }
	}
	private string _activeStatus;
	public string ActiveStatus
	{
		get { return _activeStatus; }
		set { _activeStatus = value; }
	}
	private string _password;
	public string Password
	{
		get { return _password; }
		set { _password = value; }
	}

	private string _approver;
	public string Approver
	{
		get { return _approver; }
		set { _approver = value; }
	}


	private string _appEmail;
	public string AppEmail
	{
		get { return _appEmail; }
		set { _appEmail = value; }
	}
	private string _role;
	public string Role
	{
		get { return _role; }
		set { _role = value; }
	}
	private string _sts;
	public string Status
	{
		get { return _sts; }
		set { _sts = value; }
	}
	private string _vtype;
	public string vtype
	{
		get { return _vtype; }
		set { _vtype = value; }
	}
	private string _userLoginTime;
	public string UserLoginTime
	{
		get { return _userLoginTime; }
		set { _userLoginTime = value; }
	}

	private string _userName;
	public string UserName
	{
		get { return _userName; }
		set { _userName = value; }
	}

	private string _bu;
	public string BU
	{
		get { return _bu; }
		set { _bu = value; }
	}
	private string _plant;
	public string plant
	{
		get { return _plant; }
		set { _plant = value; }
	}

	private string _dept;
	public string dept
	{
		get { return _dept; }
		set { _dept = value; }
	}
}


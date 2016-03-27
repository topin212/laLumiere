/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 03/26/2016
 * Time: 16:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace La_Lumière.Model
{
	/// <summary>
	/// Description of LoginModel.
	/// </summary>
	public class LoginModel
	{
		public string login { get; set; }
		public string password { get; set; }
		
		public bool checkIfGood(){
			//TODO complete logging in to a database as a guest, and checkng for password.
			return true;
		}
		
		public LoginModel()
		{
		}
	}
}

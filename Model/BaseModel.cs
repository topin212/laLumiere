/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 03/29/2016
 * Time: 13:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;

namespace La_Lumière.Model
{
	/// <summary>
	/// Description of BaseModel.
	/// </summary>
	public class BaseModel
	{
		public static string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
		
		public BaseModel()
		{
			
		}
	}
}

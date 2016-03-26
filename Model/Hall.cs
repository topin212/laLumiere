/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 25.03.2016
 * Time: 20:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace La_Lumière.Model
{
	/// <summary>
	/// Description of Hall.
	/// </summary>
	public class Hall
	{
		public string Name { get; set; }
		public Row[] rows { get; set; }
		
		public Row[] getSeats(){
			return rows;
		}
		public Hall()
		{
		 
		}
	}
}

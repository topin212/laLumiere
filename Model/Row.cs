/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 25.03.2016
 * Time: 21:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace La_Lumière.Model
{
	/// <summary>
	/// Description of Row.
	/// </summary>
	public class Row
	{
		public Seat[] seats { get; set; }
		
		public Row()
		{
			
		}
		public Row(Seat[] seats)
		{
			if (seats == null)
				throw new ArgumentNullException("seats");
			this.seats = seats;			
		}
	}
}

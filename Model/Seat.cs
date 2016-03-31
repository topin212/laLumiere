/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 25.03.2016
 * Time: 21:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace La_Lumière.Model
{
	/// <summary>
	/// Description of Seat.
	/// </summary>
	public class Seat
	{
		public Tuple<int,int> location { get; set; }
		public double priceKoeff { get; set; }		
		
		public Seat()
		{
			
		}
		public Seat(Tuple<int, int> location)
		{
			if (location == null)
				throw new ArgumentNullException("location");
			this.location = location;
			this.priceKoeff=1;
		}
		public Seat(Tuple<int, int> location, double price)
		{
			if (location == null)
				throw new ArgumentNullException("location");
			if (price < 0)
				throw new ArgumentOutOfRangeException("price", price, "Value must be greater than " + 0);
			this.location = location;
			this.priceKoeff = price;
			
		}
		
		
	}
}

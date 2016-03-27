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
		public int rowNumber { get; set; }
		public double priceKoeff { get; set; }
		
		int _seatNumber;
		public Tuple<int, int> row2Tuple(){
			return new Tuple<int, int>(rowNumber, seats.Length);
		}
		
		public int seatNumber {
			get { return _seatNumber = seats.Length; }
		}
		public Row()
		{
			
		}
		public Row(Seat[] seats)
		{
			if (seats == null)
				throw new ArgumentNullException("seats");
			this.seats = seats;
			this.priceKoeff=1;
		}
		public Row(Seat[] seats, int priceKoeff)
		{
			if (seats == null)
				throw new ArgumentNullException("seats");
			if (priceKoeff < 0)
				throw new ArgumentOutOfRangeException("priceKoeff", priceKoeff, "Value must be greater than 0");
			this.seats = seats;
			this.priceKoeff = priceKoeff;
			
		}
		public Row(Seat[] seats, int rowNumber, double priceKoeff)
		{
			if (seats == null)
				throw new ArgumentNullException("seats");
			if (rowNumber < 0)
				throw new ArgumentOutOfRangeException("rowNumber", rowNumber, "Value must be greater than 0.");
			if (priceKoeff < 0)
				throw new ArgumentOutOfRangeException("priceKoeff", priceKoeff, "Value must be greater than 0.");
			this.seats = seats;
			this.rowNumber = rowNumber;
			this.priceKoeff = priceKoeff;
			
		}
		public Row(int rowNumber, int seatNumber)
		{
			seats = new Seat[seatNumber];
			this.rowNumber = rowNumber;
			priceKoeff = 1;
			
			for (int i = 0; i < seats.Length; i++) {
				seats[i] = new Seat(new Tuple<int, int>(rowNumber, i+1));
			}
		}
	}
}

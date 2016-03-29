/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 25.03.2016
 * Time: 21:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace La_Lumière.Model
{
	/// <summary>
	/// Description of Row.
	/// </summary>
	public class Row
	{
		public List<Seat> seats { get; set; }
		public int rowNumber { get; set; }
		public double priceKoeff { get; set; }
		
		
		int _seatNumber;
		public Tuple<int, int> row2Tuple(){
			return new Tuple<int, int>(rowNumber, seats.Count);
		}
		
		public int seatNumber {
			get { return _seatNumber = seats.Count; }
		}
		public Row()
		{
			
		}
		public Row(List<Seat> seats)
		{
			if (seats == null)
				throw new ArgumentNullException("seats");
			this.seats = seats;
			this.priceKoeff=1;
		}
		public Row(List<Seat> seats, int priceKoeff)
		{
			if (seats == null)
				throw new ArgumentNullException("seats");
			if (priceKoeff < 0)
				throw new ArgumentOutOfRangeException("priceKoeff", priceKoeff, "Value must be greater than 0");
			this.seats = seats;
			this.priceKoeff = priceKoeff;
			
		}
		public Row(int rowNumber, double priceKoeff, List<Seat> seats)
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
			seats = new List<Seat>();
			this.rowNumber = rowNumber;
			priceKoeff = 1;
			
			for (int i = 0; i < seats.Count; i++) {
				seats.Add(new Seat(new Tuple<int, int>(rowNumber, i+1)));
			}
		}
	}
}

/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 03/31/2016
 * Time: 06:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace La_Lumière.Model
{
	/// <summary>
	/// Description of Film.
	/// </summary>
	public class Film
	{
		public string  name { get; set; }
		public double price { get; set; }
		public string category { get; set; }
		
		public Film(){}
		public Film(string name, double price, string category)
		{
			if (name == null)
				throw new ArgumentNullException("name");
			if (price < 0)
				throw new ArgumentOutOfRangeException("price", price, "Value must be greater than 0.");
			if (category == null)
				throw new ArgumentNullException("category");
			this.name = name;
			this.price = price;
			this.category = category;
		}
	}
}

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
		
		public Row[] getRows(){
			return rows;
		}
		public Hall(){
			Name = "default";
			rows = new []{new Row(new []{new Seat(new Tuple<int, int>(1,1),1)})};
		}
		public Hall(string name, Row[] rows)
		{
			if (name == null)
				throw new ArgumentNullException("name");
			if (rows == null)
				throw new ArgumentNullException("rows");
			this.Name = name;
			this.rows = rows;
			
		}
		public Hall(Tuple<int,int>[] rowsList)
		{
			rows = new Row[rowsList.Length];
			for (int i = 0; i < rows.Length; i++) {
				rows[i] = new Row(rowsList[i].Item1, rowsList[i].Item2);
			}
		}
	}
}

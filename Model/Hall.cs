/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 25.03.2016
 * Time: 20:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace La_Lumière.Model
{
	/// <summary>
	/// Description of Hall.
	/// </summary>
	public class Hall
	{
		public string Name { get; set; }
		public List<Row> rows { get; set; }
		
		public List<Row> getRows(){
			return rows;
		}
		public Hall(){
		}
		public Hall(string name, List<Row> rows)
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
			rows = new List<Row>();
			for (int i = 0; i < rows.Count; i++) {
				rows.Add(new Row(rowsList[i].Item1, rowsList[i].Item2));
			}
		}
	}
}

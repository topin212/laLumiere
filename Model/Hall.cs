/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 25.03.2016
 * Time: 20:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;

namespace La_Lumière.Model
{
	/// <summary>
	/// Description of Hall.
	/// </summary>
	public class Hall : BaseModel
	{
		public string Name { get; set; }
		public List<Row> rows { get; set; }
		
		public List<Row> getRows(){
			return rows;
		}
		
		public Hall(){
			Name = "default";
			rows = new List<Row>();
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

        public static List<Tuple<int,int, int>> getHall(string source)
        {
            var ret = new List<Tuple<int, int, int>>();
            string s = "";
            using (var file = new StreamReader(source))
            {
                while((s = file.ReadLine())!=null){
                    var tempArray = s.Split(' ');
                    ret.Add(new Tuple<int,int, int>(int.Parse(tempArray[0]), int.Parse(tempArray[1]), int.Parse(tempArray[2])));
                    //Console.WriteLine("{0}, {1}", int.Parse(tempArray[0]), int.Parse(tempArray[1]));
                }
            }

            return ret;
        }
        public static List<Hall> getAllHalls(){
        	var ret = new List<Hall>();
        	var listOfRows = new List<Row>();
        	var listOfSeats = new List<Seat>();
        	
        	List<Tuple<string, int, int>> dbDescription = new List<Tuple<string, int, int>>();
        	string CmdString = string.Empty;
        	
        	//so, first thing first I need to get the description of all halls available.
        	//its "select * from hallsDescription"
        	//it will show me the dimensions for each hall
        	//but how do i know how much halls there are?
        	//well, i could create a hall with an e,pty constructor, and then form row[] and seat[] along
        	
        	try {
        		using (SqlConnection con = new SqlConnection(ConString)) {
        			CmdString = "select * from hallsDescription";
        			SqlCommand cmd = new SqlCommand(CmdString, con);
        			con.Open();
        			using (SqlDataReader sqr = cmd.ExecuteReader()){
        				while (sqr.Read()) {
        					dbDescription.Add(new Tuple<string, int, int>(sqr.GetString(0), sqr.GetInt32(1), sqr.GetInt32(2)));
        				}
        			}
        		}
        	} catch (Exception EXC) {
        		Console.WriteLine(EXC.Message);
           	}
        	
        	//so, now i have all the info on the halls in the database. Now I only need to read it.
        	
        	Boolean breakFlag = false;
        	
        	try {
        		using (SqlConnection con = new SqlConnection(ConString)) {
        			CmdString = "select * from hallsview";
        			SqlCommand cmd = new SqlCommand(CmdString, con);
        			con.Open();
        			using (SqlDataReader sqr = cmd.ExecuteReader()){
        				sqr.Read();
        				for (int i = 0; i<dbDescription.Count; i++) {
        					var currentHallDescription = dbDescription[i];
        					//var currentHallDescription = dbDescription.Find(x => x.Item1 == hallName);
							var currentHallName = sqr.GetString(0);
							var currentRowNumber = sqr.GetInt32(1);
        					for (int j = 0; j < currentHallDescription.Item2; j++) {
        						int currentRow = sqr.GetInt32(1);
        					
        						for (int k = 0; !currentHallName.Equals(sqr.GetString(0)) && currentRowNumber != sqr.GetInt32(1); k++) {
        							sqr.Read();
    								listOfSeats.Add(new Seat(new Tuple<int, int>(sqr.GetInt32(1), sqr.GetInt32(2)), sqr.GetInt32(3)));
    								
        						}
        						listOfRows.Add(new Row(listOfSeats));
        						listOfSeats.Clear();
							}
        					ret.Add(new Hall(dbDescription[i].Item1, listOfRows));
        					listOfRows.Clear();
						}
        			}
        		}
        	} catch (Exception EXC) {
        		Console.WriteLine(EXC.Message + "\n during getting halls");
           	}        	
        	
        	
        	foreach (var hall in ret) {
        		Console.WriteLine(hall.Name);
        		Console.WriteLine(hall.rows.Count);
        		foreach (var row in hall.rows) {
        			Console.WriteLine(row.seats.Count);
        		}
        	}
        	return ret;
        }
        public Hall(int id)
        {
        	//string ConString = "Data Source=(local); User Id=sa;Password=zaqwsx;";
        	//string ConString = System.Configuration.ConfigurationSettings.AppSettings.Get("ConString");
        	
		   
		 
        }
        
        public void save(){
        	string CmdString = string.Empty;
			for (int i = 0, rowsCount = rows.Count; i < rowsCount; i++) {
				try {
					using (SqlConnection con = new SqlConnection(ConString)) {
						CmdString = "exec remove hall " + Name;
						SqlCommand cmd = new SqlCommand(CmdString, con);
						con.Open();
						cmd.ExecuteReader();
						CmdString = "exec addRowToHall " + Name + ", " + rows.Count;
						cmd = new SqlCommand(CmdString, con);
						cmd.ExecuteReader();
					}
				} catch (Exception exc) {
					Console.WriteLine(exc.Message);
				}
			}
        }
	}
}

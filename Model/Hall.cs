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
        	
        	//first we need to check how much halls we have.
        	//select count(name) from halls
        	int hallCount = 0;
        	string CmdString = string.Empty;
        	try {
		    	using (SqlConnection con = new SqlConnection(ConString))
			    {
			        CmdString = "use lumiere; SELECT count(name) FROM halls";
			        SqlCommand cmd = new SqlCommand(CmdString, con);
			        
			        con.Open();
			        using(SqlDataReader sqlReader = cmd.ExecuteReader()){
			        	if(sqlReader.Read() && sqlReader.FieldCount==1){
			        		hallCount = sqlReader.GetInt32(0);
			        	}
			        }
			    }
		    } catch (SqlException exc) {
		    	Console.WriteLine(exc.Message);

		    }
        	
        	Console.WriteLine("HallCount = "+ hallCount);
        	
        	for (int i = 0; i < hallCount; i++) {
        		ret.Add(new Hall("Hall", listOfRows));
        	}
        	
        	return ret;
        	//then we need to instantiate them
        	//in order to instantiate a hall I need List<Row> and List<Seat>
        	//Both can be retrieved from the database. 
        	//I stored a method to get the connection string in the base class

        }
        public Hall(int id)
        {
        	//string ConString = "Data Source=(local); User Id=sa;Password=zaqwsx;";
        	//string ConString = System.Configuration.ConfigurationSettings.AppSettings.Get("ConString");
        	
		   
		 
        }
	}
}

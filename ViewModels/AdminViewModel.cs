/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 03/27/2016
 * Time: 20:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using La_Lumière.Util;
using La_Lumière.Model;

namespace La_Lumière.ViewModels
{
	/// <summary>
	/// Description of AdminViewModel.
	/// </summary>
	public class AdminViewModel : BaseViewModel
	{
		HallPreviewDrawer hallDrawer = new HallPreviewDrawer();
		Hall hall = new Hall();
		
		public ObservableCollection<Hall> halls { get; set; }
		
		public ObservableCollection<Row> rows { get; set; }
		
		#region relay commands
		public RelayCommand addRowCommand { get; set; }
		public RelayCommand removeSelectedRowCommand { get; set; }
		
		public RelayCommand addFilmToDB { get; set; }
		#endregion
		
		public AdminViewModel()
		{
			//hall = new Hall(fillDummyData());
			rows = new ObservableCollection<Row>(hall.getRows());
			halls = new ObservableCollection<Hall>(Hall.getAllHalls());
			#region relay commands setup
			addRowCommand = new RelayCommand(addRowToHall);
			removeSelectedRowCommand = new RelayCommand(removeRowFromHall);
			#endregion
		}
		
		void addRowToHall(object seatsInRow){
			Tuple<int,int>[] infoForDrawer = new Tuple<int, int>[rows.Count+1];
			
			try{
				rows.Add(new Row(rows.Count, int.Parse(seatsInRow as string)));
			}catch(FormatException exc){
				Console.WriteLine(exc.Message + "\n during adding a hall in admin View");
			}
			//and here we need to fire an event
			
			for (int i = 0; i < rows.Count; i++) {
				infoForDrawer[i] = rows[i].row2Tuple();
				Console.WriteLine("{0}|{1}", infoForDrawer[i].Item1, infoForDrawer[i].Item2);
			}
			
			hallDrawer.generateHall(infoForDrawer);
		}
		void removeRowFromHall(object rowToRemove){
			rows.Remove(rowToRemove as Row);
		}
		
		Tuple<int,int>[] fillDummyData(){
			Random random = new Random(654645);
			Tuple<int,int>[] dummy = new Tuple<int, int>[6];
			for (int i = 0; i < dummy.Length; i++) {
				dummy[i] = new Tuple<int, int>(i+1,random.Next(3,10));
			}
			return dummy;
		}
	}
}

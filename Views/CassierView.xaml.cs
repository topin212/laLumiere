/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 26.03.2016
 * Time: 19:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using La_Lumière.Util;
using La_Lumière.ViewModels;

namespace La_Lumière.Views
{
	/// <summary>
	/// Interaction logic for CassierView.xaml
	/// </summary>
	public partial class CassierView : Window
	{
		CassierViewModel vm;
		
		public CassierView()
		{
			InitializeComponent();
			vm = DataContext as CassierViewModel;
			if(vm==null) return;
			vm.generateFieldEvent += generateButtons;
		}

        public void generateButtons(object sender, NotificationEventArgs schema){
			for (int i = 0; i < schema.Content.Count; i++) {
				Console.WriteLine("{0}|{1}", schema.Content[i].Item1,schema.Content[i].Item2);
			}
			Console.WriteLine();
			
			
            Button tempButton;
            StackPanel tempRow;
            #region govnokod
            int max = 0;
            for (int i = 0; i < schema.Content.Count; i++)
			{
                max = max<schema.Content[i].Item2?schema.Content[i].Item2:max;
			}
            #endregion

            int margin = 5;
            int defaultSize = 35;

            int maxWidth = margin+(defaultSize + margin)*max;
            int rowWidth;
            
            for (int i = 0; i < schema.Content.Count; i++)
            {
            	rowWidth = margin+(defaultSize + margin)*schema.Content[i].Item2;
            	
            	tempRow = new StackPanel();
            	tempRow.Height = (defaultSize+margin)*1.5;
            	tempRow.Margin = new Thickness(10, 10 + i*50, 10, 10);
            	//tempRow.Background = Brushes.Aqua;
            	tempRow.Orientation = Orientation.Horizontal;
            	tempRow.VerticalAlignment=VerticalAlignment.Top;
            	tempRow.HorizontalAlignment = HorizontalAlignment.Center;
            	
            	Brush rowColor = null;
            	
            	switch (schema.Content[i].Item3) {
        			case 1: rowColor = priceCat1Color.Background;
            			break;
            		case 2: rowColor = priceCat2Color.Background;
            			break;
            		case 3: rowColor = priceCat3Color.Background;
            			break;
            	}
            	
            	
            	for (int j = 0; j < schema.Content[i].Item2; j++) {
					tempButton = new Button();
					tempButton.Height = defaultSize;
					tempButton.Width = defaultSize;
					tempButton.Margin = new Thickness(10);
					tempButton.Content = (j+1).ToString();
					tempButton.Background = rowColor;
					tempButton.Click += buttonPress;
					tempRow.Children.Add(tempButton);
            	}
            	generatedHall.Children.Add(tempRow);
            }
        }

		public void buttonPress(object sender, RoutedEventArgs e){
			(sender as Button).Background = Brushes.LightGray;
			(sender as Button).IsEnabled = false;
		}
		void FillDataGrid()
		{ 
		    string ConString = "Data Source=(local); User Id=sa;Password=zaqwsx;";
		    string CmdString = string.Empty;
		    try {
		    	using (SqlConnection con = new SqlConnection(ConString))
			    {
			        CmdString = "use lumiere; SELECT * FROM halls";
			        SqlCommand cmd = new SqlCommand(CmdString, con);
			        SqlDataAdapter sda = new SqlDataAdapter(cmd);
			        DataTable dt = new DataTable("Employee");
			        sda.Fill(dt);
			        hallGrid.ItemsSource = dt.DefaultView; 
			    }
		    } catch (SqlException exc) {
		    	Console.WriteLine(exc.Message);
		    	
		    }
		}

	}
}
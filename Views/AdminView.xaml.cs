/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 03/27/2016
 * Time: 18:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace La_Lumière.Views
{
	/// <summary>
	/// Interaction logic for AdminView.xaml
	/// </summary>
	public partial class AdminView : Window, IClosable
	{		
		public static string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
		public AdminView()
		{
			InitializeComponent();		
			FillData();
		}

		void FillData()
		{
			#region populationg halls
			string CmdString = "select * from hallCapacityView";
			try {
		    	using (SqlConnection con = new SqlConnection(ConString))
			    {
		    		SqlCommand cmd = new SqlCommand(CmdString, con);
		    		SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
		    		DataTable data = new DataTable();
			        con.Open();
			        dataAdapter.Fill(data);
			        hallViewer.ItemsSource = data.DefaultView;
			    }
		    } catch (SqlException exc) {
		    	Console.WriteLine(exc.Message);}
			#endregion
			#region populating seances
			CmdString = "select * from seances";
			try {
		    	using (SqlConnection con = new SqlConnection(ConString))
			    {
		    		SqlCommand cmd = new SqlCommand(CmdString, con);
		    		SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
		    		DataTable data = new DataTable();
			        con.Open();
			        dataAdapter.Fill(data);
			        seanceViewer.ItemsSource = data.DefaultView;
			    }
		    } catch (SqlException exc) {
		    	Console.WriteLine(exc.Message);}
			#endregion
			#region populating films
			CmdString = "select * from films";
			try {
		    	using (SqlConnection con = new SqlConnection(ConString))
			    {
		    		SqlCommand cmd = new SqlCommand(CmdString, con);
		    		SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
		    		DataTable data = new DataTable();
			        con.Open();
			        dataAdapter.Fill(data);
			        filmViewer.ItemsSource = data.DefaultView;
			    }
		    } catch (SqlException exc) {
		    	Console.WriteLine(exc.Message);}
			#endregion
			#region populating employees
			CmdString = "select * from employees";
			try {
		    	using (SqlConnection con = new SqlConnection(ConString))
			    {
		    		SqlCommand cmd = new SqlCommand(CmdString, con);
		    		SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
		    		DataTable data = new DataTable();
			        con.Open();
			        dataAdapter.Fill(data);
			        employeeViewer.ItemsSource = data.DefaultView;
			    }
		    } catch (SqlException exc) {
		    	Console.WriteLine(exc.Message);}
			#endregion
		}


		#region IClosable implementation

		public void close()
		{
			Close();
		}

		public string login {
			get {
				return "admin";
			}
		}

		#endregion
	}
}
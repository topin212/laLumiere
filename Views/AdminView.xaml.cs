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
		public AdminView()
		{
			InitializeComponent();		
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
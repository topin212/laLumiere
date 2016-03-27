﻿/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 26.03.2016
 * Time: 13:12
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
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window, IClosable
	{
		public LoginWindow()
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
				return loginTextBox.Text;
			}
		}

		#endregion
	}
}
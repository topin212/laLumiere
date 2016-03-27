/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 03/26/2016
 * Time: 13:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
//possibly not needed, but i haven't figured out what to do.
using System.Windows;
using La_Lumière.Model;
using La_Lumière.Util;
using La_Lumière.Views;

namespace La_Lumière.ViewModels
{
	/// <summary>
	/// Description of LoginViewModel.
	/// </summary>
	public class LoginViewModel
	{
		LoginModel loginModel = new LoginModel();
		
		public RelayCommand onLoginCommand { get; set; }
		
		public LoginViewModel()
		{
			onLoginCommand = new RelayCommand(onLogin);
		}
		
		void onLogin(object loginInfo){
			if(loginModel.checkIfGood()){
				var oldWindow = loginInfo as IClosable;
				Window newWindow = new Window();
				switch(oldWindow.login){
					case "admin": newWindow = new AdminView();
						break;
					case "cassier": newWindow = new CassierView();
						break;
					default:
						Console.WriteLine("Unexpected login.");
						break;
				}
				
				
				oldWindow.close();
				newWindow.Show();
			}
		}
	}
}

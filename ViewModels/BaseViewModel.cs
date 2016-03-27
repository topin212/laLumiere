/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 26.03.2016
 * Time: 19:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;

namespace La_Lumière.ViewModels
{
	/// <summary>
	/// Description of BaseViewModel.
	/// </summary>
	public class BaseViewModel : INotifyPropertyChanged
	{
		public BaseViewModel()
		{
		}

		#region INotifyPropertyChanged implementation
	    public event PropertyChangedEventHandler PropertyChanged;
	    protected void OnPropertyChanged(string propertyName)
	    {
	        PropertyChangedEventHandler handler = PropertyChanged;
	        if (handler != null) 
	        	handler(this, new PropertyChangedEventArgs(propertyName));
	    }
	    
		#endregion

	}
}

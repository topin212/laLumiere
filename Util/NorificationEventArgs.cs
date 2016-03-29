/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 03/28/2016
 * Time: 21:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace La_Lumière.Util
{
	/// <summary>
	/// Description of NorificationEventArgs.
	/// </summary>
public class NotificationEventArgs : EventArgs {
		public List<Tuple<int, int, int>> Content { get; protected set; }
		
		public NotificationEventArgs(){}
		public NotificationEventArgs(List<Tuple<int, int, int>> message){
			Content = message;
		}
	}
}

/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 26.03.2016
 * Time: 19:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace La_Lumière.Util
{
	/// <summary>
	/// Description of IClosable.
	/// </summary>
	public interface IClosable
	{
		string login { get; }
		void close();
	}
}

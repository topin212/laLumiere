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
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace La_Lumière.Views
{
	/// <summary>
	/// Interaction logic for CassierView.xaml
	/// </summary>
	public partial class CassierView : Window
	{
		public CassierView()
		{
			InitializeComponent();
            
		}

        public void generateButtons(List<Tuple<int, int>> schema){
            Button tempButton;
            #region govnokod
            int max = 0;
            for (int i = 0; i < schema.Count; i++)
			{
                max = max<schema[i].Item2?schema[i].Item2:max;
			}
            #endregion

            int margin = 10;
            int defaultSize = 40;

            int maxWidth = margin+(defaultSize + margin)*max;

            for (int i = 0; i < schema.Count; i++)
            {
                tempButton = new Button();
                tempButton.Height = defaultSize;
                tempButton.Width = defaultSize;
                tempButton.Margin = new Thickness((maxWidth - )/2)
            }
        }

	}
}
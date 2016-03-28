/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 03/27/2016
 * Time: 19:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace La_Lumière.Util
{
	/// <summary>
	/// Description of HallPreviewDrawer.
	/// </summary>
	public class HallPreviewDrawer
	{
		//basic margin
		int x,y=10,margin=10, defaultSize = 40;
		int imageWidth=600, imageHeight=600;
		
		//TODO accept width and height as parameters
		public Bitmap generateHall(Tuple<int,int>[] hall){
			
			foreach (var element in hall) {
				Console.WriteLine("{0}|{1}", element.Item1, element.Item2);
			}
			
			//rowNumber, seatNumber
			int maximumSeats=0;
			int[] margins = new int[hall.Length];
			
			for (int i = 0; i < hall.Length; i++) {
				if(maximumSeats<hall[i].Item2){
					maximumSeats = hall[i].Item2;
				}
			}
			
			//So, we got the maximum, now we need to form margin array.
			if(maximumSeats %2 == 0){
				for (int i = 0; i < hall.Length; i++) {
					if(hall[i].Item2 % 2 == 0){
						margins[i] = margin + (defaultSize + margin) * ((maximumSeats - hall[i].Item2)/2);
					}else{
						margins[i] = margin + (defaultSize/2 + margin/2) * (maximumSeats - hall[i].Item2);
					}
				}
			}
			else{
				for (int i = 0; i < hall.Length; i++) {
					if(hall[i].Item2 % 2 == 0){
						margins[i] = margin + (defaultSize/2 + margin/2) * (maximumSeats - hall[i].Item2);
					}else{
						margins[i] = margin + (defaultSize + margin) * ((maximumSeats - hall[i].Item2)/2);
					}
				}
			}
			
			imageWidth = margin+((margin+defaultSize)*maximumSeats);
			imageHeight = (margin+defaultSize)*hall.Length;
			Bitmap generated = new Bitmap(imageWidth, imageHeight);
			SolidBrush sb = new SolidBrush(Color.Black);
			Graphics g = Graphics.FromImage(generated);
			
			for (int i = 0; i < hall.Length; i++) {
				x = margins[i];
				for (int j = 0; j < hall[i].Item2; j++) {
					g.FillRectangle(sb, x, (y+margin+defaultSize)*(1+i), defaultSize, defaultSize);
					x+=defaultSize+margin;
				}
			}
			
			generated.Save("kek.bmp");
			return generated;
		}
		
		public HallPreviewDrawer()
		{
		}
	}
}

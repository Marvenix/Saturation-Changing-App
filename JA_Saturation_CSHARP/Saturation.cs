using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA_Saturation_CSHARP
{
	public class Saturation
	{
		
		private object _locker = new object();
		public void saturationCSHARP_map(Bitmap bmp, int widthStart, int widthStop, int height, float valueR, float valueG, float valueB)
		{
			for (int i = widthStart; i < widthStop; i++)
			{
				for (int j = 0; j < height; j++)
				{
					lock (_locker)
                    {
						var pixel = bmp.GetPixel(i, j);
						int A = (int)pixel.A;
						int R = (int)pixel.R;
						int G = (int)pixel.G;
						int B = (int)pixel.B;
						R = Math.Min(255, (int)(R + (R * valueR)));
						G = Math.Min(255, (int)(G + (G * valueG)));
						B = Math.Min(255, (int)(B + (B * valueB)));
						bmp.SetPixel(i, j, Color.FromArgb(A, R, G, B));
					}
				}
			}
			
		}
		
		public void saturationCSHARP_byte(byte[] rgbValues, int widthStart, int widthStop, float valueB, float valueG, float valueR)
        {
			for (int counter = widthStart; counter < widthStop; counter += 3)
            {
				rgbValues[counter] = (byte)Math.Min(255, (int)rgbValues[counter] + (int)(rgbValues[counter] * valueR));
				rgbValues[counter+1] = (byte)Math.Min(255, (int)rgbValues[counter+1] + (int)(rgbValues[counter+1] * valueG));
				rgbValues[counter+2] = (byte)Math.Min(255, (int)rgbValues[counter+2] + (int)(rgbValues[counter+2] * valueB));
			}
		}

		public void saturationCSHARP_byte_png(byte[] rgbValues, int widthStart, int widthStop, float valueB, float valueG, float valueR)
		{
			for (int counter = widthStart; counter < widthStop; counter += 4)
			{
				rgbValues[counter] = (byte)Math.Min(255, (int)rgbValues[counter] + (int)(rgbValues[counter] * valueR));
				rgbValues[counter + 1] = (byte)Math.Min(255, (int)rgbValues[counter + 1] + (int)(rgbValues[counter + 1] * valueG));
				rgbValues[counter + 2] = (byte)Math.Min(255, (int)rgbValues[counter + 2] + (int)(rgbValues[counter + 2] * valueB));
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Week1Day3
{
    class GrayScale
    {
        static void Main(string[] args)
        {
            Bitmap bmap = (Bitmap)Image.FromFile("Pony.bmp");

            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    Color pixel = bmap.GetPixel(i, j);
                    Color newPixel = Color.FromArgb((pixel.R + pixel.B + pixel.G) / 3, (pixel.R + pixel.B + pixel.G) / 3, (pixel.R + pixel.B + pixel.G) / 3);
                    bmap.SetPixel(i, j, newPixel);
 

                }
            }

            bmap.Save("newPony.bmp");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LinearFilter
{
    class LinearFilter
    {
        static void BlurImage(Bitmap bitmap)
        {
            int Rpix = 0;
            int Bpix = 0;
            int Gpix = 0;
            int counter = 0;
            Bitmap container = new Bitmap(bitmap.Width, bitmap.Height);
            
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j);

                    Rpix += pixel.R;
                    Bpix += pixel.B;
                    Gpix += pixel.G;

                    counter ++;
                }
            }
            
            Rpix = Rpix / counter;
            Bpix = Bpix / counter;
            Gpix = Gpix / counter;


            for (int i = 0; i < container.Width; i++)
            {
                for (int j = 0; j < container.Height; j++)
                {
                    container.SetPixel(i, j, Color.FromArgb(Rpix, Bpix, Gpix));
                }
            }


            container.Save("newPoonY.bmp");
        }
        static void Main(string[] args)
        {
            BlurImage((Bitmap)Image.FromFile("Pony.bmp"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace InterpolateImage
{
    class InterpolateImage
    {
         static void ResizeImage(Image image, int width, int height)
        {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destImage = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(destImage);                 
            graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);            
            destImage.Save("BitMapImgNew.bmp");

        }
        static void Main(string[] args)
        {
            ResizeImage(Image.FromFile("BitMapImg.bmp"), 25, 25);
        }
    }
}

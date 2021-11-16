using System;
using System.Drawing;

namespace ImageFilter
{
    class Program
    {
        static void Main()
        {
            Bitmap bitmap = new(Image.FromFile("input.png"));
            Console.WriteLine("read image");
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    bitmap.SetPixel(x, y, ColorSwap(bitmap.GetPixel(x, y)));
                    Console.Write(ColorToString(bitmap.GetPixel(x, y)));
                }
                Console.WriteLine();
            }
            Console.WriteLine("filtered the image");
            bitmap.Save("output.png");
            Console.ReadKey();
        }
        static Color ColorSwap(Color color)
        {
            if (color.A == 0) return color;
            if (Math.Max(color.G, color.B) - color.R > 20) return Color.FromArgb(color.A, color.B, color.G, color.R);
            return Color.FromArgb(color.A, color.B / 3, color.R / 3, color.G / 3);
        }
        static string ColorToString(Color color)
        {
            if (color.A == 0) return " ";
            if (Math.Max(color.G, color.B) - color.R > 20) return "@";
            return "X";
        }
    }
}

using System.Drawing;
using System.IO;

namespace Fractals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Artist artist = new Artist();
            Console.WriteLine("Enter width, height, zoom in 1 string, separated by spaces");
            string input = Console.ReadLine();
            string[] stringValues = input.Split();
            int[] intValues = new int[stringValues.Length];
            for (int i = 0; i < stringValues.Length; i++)
            {
                int value = int.Parse(stringValues[i]);
                intValues[i] = value;
            }
            int width = intValues[0];
            int height = intValues[1];
            int zoom = intValues[2];
            Bitmap bmp = artist.Drawer(width, height, zoom);
            string path = @"D:\Git Projects\Fractals\Images\Fractal.jpg";
            bmp.Save(path);
        }
    }
}

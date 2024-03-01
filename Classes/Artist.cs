using System.ComponentModel;
using System.Drawing;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Xml.Linq;

public class Artist
{
	private int[][] data;
	private const double CReal = -0.71;
	private const double CImaginary = 0.25015;
	public Bitmap Drawer(int width, int height, int zoom)
	{
		int[][] data = new int[width*height][];
		int index = 0;
		for (int y  = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
                data[index] = Point(x, y, width, height, zoom);
                index++;
            }
		}
		Bitmap bitmap = new Bitmap(width, height);
        for (int i = 0; i < data.Length; i++)
		{
            Color color = Colors[data[i][2]];
			bitmap.SetPixel(data[i][0], data[i][1], color);
		}
		return bitmap;
	}

	private int[] Point(int x, int y, int width, int height, int zoom)
	{
        int[] pointParams = new int[3];
        int iteration = 256;
        double zX = 1.5 * (x - width / 2) / (0.5 * zoom * width);
        double zY = 1.0 * (y - height / 2) / (0.5 * zoom * height);
        while (((Math.Pow(zX, 2) + Math.Pow(zY, 2)) < 4) && iteration > 1)
        {
            double temp = Math.Pow(zX, 2) - Math.Pow(zY, 2) + CReal;
            zY = 2.0 * zX * zY + CImaginary;
            zX = temp;
            iteration--;
        }
        pointParams[0] = x;
        pointParams[1] = y;
        pointParams[2] = iteration;
        return pointParams;
    }

    public static Color[] Colors => Enumerable.Range(0, 256)
    .Select(c => Color.FromArgb((c & 3) * 85 % 256, (c >> 7) * 36 % 256, (c >> 3 & 5) * 36 % 256))
    .ToArray();
}

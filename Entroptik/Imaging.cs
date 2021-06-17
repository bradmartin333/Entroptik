using System.Collections.Generic;
using System.Drawing;

namespace Entroptik
{
    public static class Imaging
    {
        public static List<Rectangle> Rectangles = new List<Rectangle>();

        private static Pen Pen = new Pen(Color.HotPink);
        private static Point Guide = new Point(150, 150);

        public static void ShowImage(string filePath)
        {
            Bitmap img = new Bitmap(filePath);
            FileHandler.PictureBox.BackgroundImage = img;
            MakeGrid();
            ShowGrid();
        }

        private static void MakeGrid()
        {
            Bitmap grid = new Bitmap(FileHandler.PictureBox.BackgroundImage.Width, FileHandler.PictureBox.BackgroundImage.Height);
            FileHandler.PictureBox.Image = grid;
            Pen.Width = grid.Width / 250;
            for (int i = 0; i <= FileHandler.FormMain.numX.Value - 1; i++)
            {
                for (int j = 0; j <= FileHandler.FormMain.numY.Value - 1; j++)
                {
                    using (Graphics g = Graphics.FromImage(grid))
                    {
                        Rectangles.Add(new Rectangle((int)(Guide.X + i * FileHandler.FormMain.numXpitch.Value - FileHandler.FormMain.numWid.Value / 2),
                            (int)(Guide.Y + j * FileHandler.FormMain.numYpitch.Value - FileHandler.FormMain.numHgt.Value / 2),
                            (int)FileHandler.FormMain.numWid.Value, (int)FileHandler.FormMain.numHgt.Value));
                    }
                }
            }
        }

        private static void ShowGrid()
        {
            Bitmap grid = new Bitmap(FileHandler.PictureBox.Image.Width, FileHandler.PictureBox.Image.Height);
            foreach (Rectangle rectangle in Rectangles)
            {
                using (Graphics g = Graphics.FromImage(grid))
                {
                    g.DrawRectangle(Pen, rectangle);
                }
            }
            FileHandler.PictureBox.Image = grid;
        }
    }
}

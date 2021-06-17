using System.Collections.Generic;
using System.Drawing;

namespace Entroptik
{
    public static class Imaging
    {
        public static List<Rectangle> Rectangles = new List<Rectangle>();

        private static Pen Pen = new Pen(Color.HotPink);

        public static void ShowImage(string filePath)
        {
            Bitmap img = new Bitmap(filePath);
            FileHandler.PictureBox.BackgroundImage = img;
        }

        public static void MakeGrid()
        {
            Rectangles.Clear();

            Bitmap grid = new Bitmap(FileHandler.PictureBox.BackgroundImage.Width, FileHandler.PictureBox.BackgroundImage.Height);
            FileHandler.PictureBox.Image = grid;
            Pen.Width = grid.Width / 250;

            for (int i = 0; i < FileHandler.FormMain.numX.Value; i++)
            {
                for (int j = 0; j < FileHandler.FormMain.numY.Value; j++)
                {
                    using (Graphics g = Graphics.FromImage(grid))
                    {
                        Rectangles.Add(new Rectangle((int)(FileHandler.Workspace.Guide.X + i * FileHandler.FormMain.numXpitch.Value - FileHandler.FormMain.numWid.Value / 2),
                            (int)(FileHandler.Workspace.Guide.Y + j * FileHandler.FormMain.numYpitch.Value - FileHandler.FormMain.numHgt.Value / 2),
                            (int)FileHandler.FormMain.numWid.Value, (int)FileHandler.FormMain.numHgt.Value));
                    }
                }
            }

            foreach (Rectangle rectangle in Rectangles)
            {
                using (Graphics g = Graphics.FromImage(FileHandler.PictureBox.Image))
                {
                    g.DrawRectangle(Pen, rectangle);
                }
            }
        }
    }
}

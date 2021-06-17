using Accord.Imaging;
using Accord.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Entroptik
{
    public static class Imaging
    {
        public static List<Rectangle> Rectangles = new List<Rectangle>();

        private static double BaseHeight = 550;
        private static Pen Pen = new Pen(Color.HotPink);

        public static void ShowImage(string filePath)
        {
            Bitmap img = new Bitmap(filePath);
            double heightRatio = BaseHeight / img.Height;
            Bitmap resize = new Bitmap((int)(heightRatio * img.Width), (int)BaseHeight);
            using (Graphics g = Graphics.FromImage(resize))
            {
                g.DrawImage(img, 0, 0, resize.Width, resize.Height);
            }
            img.Dispose();

            Bitmap working = resize.Clone(new Rectangle(new Point(0, 0), resize.Size), System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            resize.Dispose();

            if (FileHandler.FormMain.viewFilterToolStripButton.Checked)
                working = HighlightRects(working);

            FileHandler.PictureBox.BackgroundImage = working;
        }
        private static Bitmap HighlightRects(Bitmap img)
        {
            Edges filter = new Edges();
            Bitmap output = img.Clone(System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            foreach (Rectangle rectangle in Rectangles)
            {
                Bitmap feature = new Bitmap(rectangle.Width, rectangle.Height);
                using (Graphics g = Graphics.FromImage(feature))
                {
                    g.DrawImage(img, new Rectangle(0, 0, feature.Width, feature.Height), rectangle, GraphicsUnit.Pixel);
                }
                filter.ApplyInPlace(feature);
                using (Graphics g = Graphics.FromImage(output))
                {
                    g.DrawImage(feature, rectangle);
                }
            }
            return output;
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

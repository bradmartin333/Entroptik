using Accord.Imaging;
using Accord.Imaging.Filters;
using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Entroptik
{
    public static class Imaging
    {
        public static List<Rectangle> Rectangles = new List<Rectangle>();
        public static List<double> Scores = new List<double>();

        private static double BaseHeight = 550;
        private static Pen Pen = new Pen(Color.HotPink);
        private static Pen PassPen = new Pen(Color.LawnGreen);
        private static Pen FailPen = new Pen(Color.Red);

        public static void ShowImage()
        {
            Bitmap img;
            if (FileHandler.Workspace.Images == null)
                img = Properties.Resources._default;
            else
                img = new Bitmap(FileHandler.Workspace.Images[FileHandler.Workspace.ImageIndex]);

            double heightRatio = BaseHeight / img.Height;
            Bitmap resize = new Bitmap((int)(heightRatio * img.Width), (int)BaseHeight);
            using (Graphics g = Graphics.FromImage(resize))
            {
                g.DrawImage(img, 0, 0, resize.Width, resize.Height);
            }
            img.Dispose();

            Bitmap working = resize.Clone(new Rectangle(new Point(0, 0), resize.Size), System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            resize.Dispose();

            Bitmap scanned = ScanImage(working);

            if (FileHandler.FormMain.viewFilterToolStripButton.Checked)
                FileHandler.PictureBox.BackgroundImage = scanned;
            else
                FileHandler.PictureBox.BackgroundImage = working;

            MakeGrid();
            System.Windows.Forms.Application.DoEvents();
        }
        
        private static Bitmap ScanImage(Bitmap img)
        {
            Edges filter = new Edges();

            Scores.Clear();

            Bitmap output = img.Clone(System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            foreach (Rectangle rectangle in Rectangles)
            {
                Bitmap feature = new Bitmap(rectangle.Width, rectangle.Height);
                using (Graphics g = Graphics.FromImage(feature))
                {
                    g.DrawImage(img, new Rectangle(0, 0, feature.Width, feature.Height), rectangle, GraphicsUnit.Pixel);
                }

                filter.ApplyInPlace(feature);

                List<double> pixelVals = new List<double>();
                for (int i = 0; i < feature.Width; i++)
                {
                    for (int j = 0; j < feature.Height; j++)
                    {
                        pixelVals.Add(feature.GetPixel(i, j).ToArgb());
                    }
                }
                Scores.Add(Statistics.Entropy(pixelVals.ToArray()));

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
            Pen.Width = grid.Width / 150;
            PassPen.Width = grid.Width / 150;
            FailPen.Width = grid.Width / 150;

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
                    if (Scores.Count == Rectangles.Count)
                        if (Math.Abs(Scores[Rectangles.IndexOf(rectangle)] - FileHandler.Workspace.Pass.Item1) < FileHandler.Workspace.Pass.Item2)
                            g.DrawRectangle(PassPen, rectangle);
                        else if (Math.Abs(Scores[Rectangles.IndexOf(rectangle)] - FileHandler.Workspace.Fail.Item1) < FileHandler.Workspace.Fail.Item2)
                            g.DrawRectangle(FailPen, rectangle);
                        else
                            g.DrawRectangle(Pen, rectangle);
                    else
                        g.DrawRectangle(Pen, rectangle);
                }
            }
        }
    }
}

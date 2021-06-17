using Accord.Imaging;
using Accord.Imaging.Filters;
using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Entroptik
{
    public class Feature
    {
        public Rectangle Rectangle;
        public double Score;
        public int Row;
        public int Col;
    }

    public static class Imaging
    {
        public static List<Feature> Features = new List<Feature>();

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

            MakeGrid();
            Bitmap scanned = ScanImage(working);

            if (FileHandler.FormMain.viewFilterToolStripButton.Checked)
                FileHandler.PictureBox.BackgroundImage = scanned;
            else
                FileHandler.PictureBox.BackgroundImage = working;

            ShowGrid();
            System.Windows.Forms.Application.DoEvents();
        }
        
        private static Bitmap ScanImage(Bitmap img)
        {
            Edges filter = new Edges();
            Bitmap output = img.Clone(System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            foreach (Feature feature in Features)
            {
                Bitmap bmp = new Bitmap(feature.Rectangle.Width, feature.Rectangle.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), feature.Rectangle, GraphicsUnit.Pixel);
                }

                filter.ApplyInPlace(bmp);

                List<double> pixelVals = new List<double>();
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        pixelVals.Add(bmp.GetPixel(i, j).ToArgb());
                    }
                }
                feature.Score = Statistics.Entropy(pixelVals.ToArray());

                using (Graphics g = Graphics.FromImage(output))
                {
                    g.DrawImage(bmp, feature.Rectangle);
                }
            }
            return output;
        }

        public static void MakeGrid()
        {
            Bitmap grid = new Bitmap(FileHandler.PictureBox.BackgroundImage.Width, FileHandler.PictureBox.BackgroundImage.Height);
            FileHandler.PictureBox.Image = grid;
            Pen.Width = grid.Width / 150;
            PassPen.Width = grid.Width / 150;
            FailPen.Width = grid.Width / 150;

            Features.Clear();
            for (int i = 0; i < FileHandler.FormMain.numX.Value; i++)
            {
                for (int j = 0; j < FileHandler.FormMain.numY.Value; j++)
                {
                    using (Graphics g = Graphics.FromImage(grid))
                    {
                        Feature newFeature = new Feature
                        {
                            Rectangle = new Rectangle((int)(FileHandler.Workspace.Guide.X + i * FileHandler.FormMain.numXpitch.Value - FileHandler.FormMain.numWid.Value / 2),
                                (int)(FileHandler.Workspace.Guide.Y + j * FileHandler.FormMain.numYpitch.Value - FileHandler.FormMain.numHgt.Value / 2),
                                (int)FileHandler.FormMain.numWid.Value, (int)FileHandler.FormMain.numHgt.Value),
                            Row = j,
                            Col = i
                        };
                        Features.Add(newFeature);
                    }
                }
            }
        }

        public static void ShowGrid()
        {
            foreach (Feature feature in Features)
            {
                feature.Rectangle = new Rectangle((int)(FileHandler.Workspace.Guide.X + feature.Row * FileHandler.FormMain.numXpitch.Value - FileHandler.FormMain.numWid.Value / 2),
                        (int)(FileHandler.Workspace.Guide.Y + feature.Col * FileHandler.FormMain.numYpitch.Value - FileHandler.FormMain.numHgt.Value / 2),
                        (int)FileHandler.FormMain.numWid.Value, (int)FileHandler.FormMain.numHgt.Value);
                using (Graphics g = Graphics.FromImage(FileHandler.PictureBox.Image))
                {
                    if (Math.Abs(feature.Score - FileHandler.Workspace.Pass.Item1) < FileHandler.Workspace.Pass.Item2)
                        g.DrawRectangle(PassPen, feature.Rectangle);
                    else if (Math.Abs(feature.Score - FileHandler.Workspace.Fail.Item1) < FileHandler.Workspace.Fail.Item2)
                        g.DrawRectangle(FailPen, feature.Rectangle);
                    else
                        g.DrawRectangle(Pen, feature.Rectangle);
                }
            }
        }
    }
}

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
        public int FileRow;
        public int FileCol;
    }

    public static class Imaging
    {
        public static List<Feature> Features = new List<Feature>();

        private static double BaseHeight = 800;
        private static Pen Pen = new Pen(Color.HotPink);
        private static Pen PassPen = new Pen(Color.LawnGreen);
        private static Pen FailPen = new Pen(Color.Red);

        public static void ShowImage()
        {
            Bitmap img;
            string path = null;
            if (FileHandler.Workspace.Images == null)
                img = Properties.Resources._default;
            else
            {
                path = FileHandler.Workspace.Images[FileHandler.Workspace.ImageIndex];
                img = new Bitmap(path);
            }

            double heightRatio = BaseHeight / img.Height;
            Bitmap resize = new Bitmap((int)(heightRatio * img.Width), (int)BaseHeight);
            using (Graphics g = Graphics.FromImage(resize))
            {
                g.DrawImage(img, 0, 0, resize.Width, resize.Height);
            }
            img.Dispose();

            Bitmap working = resize.Clone(new Rectangle(new Point(0, 0), resize.Size), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            resize.Dispose();

            MakeGrid();
            ScanImage(working);
            FileHandler.PictureBox.BackgroundImage = working;
            FileHandler.FormMain.runToolStripButton.Enabled = true;
            ShowGrid(path);
            System.Windows.Forms.Application.DoEvents();
        }
        
        private static void ScanImage(Bitmap img)
        {
            foreach (Feature feature in Features)
            {
                Bitmap bmp = new Bitmap(feature.Rectangle.Width, feature.Rectangle.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), feature.Rectangle, GraphicsUnit.Pixel);
                }

                List<double> pixelVals = new List<double>();
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        pixelVals.Add(bmp.GetPixel(i, j).ToArgb());
                    }
                }
                feature.Score = Statistics.Entropy(pixelVals.ToArray());

                using (Graphics g = Graphics.FromImage(img))
                {
                    g.DrawImage(bmp, feature.Rectangle);
                }
            }
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

        public static void ShowGrid(string path = null)
        {
            foreach (Feature feature in Features)
            {
                feature.Rectangle = new Rectangle((int)(FileHandler.Workspace.Guide.X + feature.Col * FileHandler.FormMain.numXpitch.Value - FileHandler.FormMain.numWid.Value / 2),
                        (int)(FileHandler.Workspace.Guide.Y + feature.Row * FileHandler.FormMain.numYpitch.Value - FileHandler.FormMain.numHgt.Value / 2),
                        (int)FileHandler.FormMain.numWid.Value, (int)FileHandler.FormMain.numHgt.Value);

                if (path != null)
                {
                    feature.FileRow = Data.GetFileRow(path);
                    feature.FileCol = Data.GetFileCol(path);
                }

                int numX = (int)FileHandler.FormMain.numX.Value;
                int numY = (int)FileHandler.FormMain.numY.Value;

                using (Graphics g = Graphics.FromImage(FileHandler.PictureBox.Image))
                {
                    if (Math.Abs(feature.Score - FileHandler.Workspace.Pass.Item1) < FileHandler.Workspace.Pass.Item2)
                    {
                        g.DrawRectangle(PassPen, feature.Rectangle);
                        Data.DataArray[feature.FileRow * numX + feature.Row, feature.FileCol * numY + feature.Col] = 1;
                    }
                    else if (Math.Abs(feature.Score - FileHandler.Workspace.Fail.Item1) < FileHandler.Workspace.Fail.Item2)
                    {
                        g.DrawRectangle(FailPen, feature.Rectangle);
                        Data.DataArray[feature.FileRow * numX + feature.Row, feature.FileCol * numY + feature.Col] = 0;
                    }
                    else
                    {
                        g.DrawRectangle(Pen, feature.Rectangle);
                        Data.DataArray[feature.FileRow * numX + feature.Row, feature.FileCol * numY + feature.Col] = -1;
                    }
                }
            }
        }
    }
}

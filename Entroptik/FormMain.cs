using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Entroptik
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            FileHandler.FormMain = this;
            FileHandler.PictureBox = pictureBox;
            pictureBox.MouseDown += PictureBox_MouseDown;
            FileHandler.LoadWorkspaceParameters();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            string pathBuffer = OpenDirectory("Select a directory containing target images");
            if (pathBuffer == null)
                return;
            else
                FileHandler.Workspace.DirectoryPath = pathBuffer;

            FileHandler.Workspace.Images = GetImagesFrom(FileHandler.Workspace.DirectoryPath);
            if (!Data.VerifyFiles())
            {
                progressBar.Value = 0;
                MessageBox.Show("Invalid Directory Contents");
                return;
            }

            progressBar.Maximum = FileHandler.Workspace.Images.Length;
            FileHandler.Workspace.ImageIndex = 0;
            Data.ClearArray();
            Imaging.ShowImage();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            string pathBuffer = OpenFile("Open an Entroptik workspace", "Entroptik Workspace(*.ew) | *.ew");
            if (pathBuffer == null)
                return;
            else
                FileHandler.Workspace.FilePath = pathBuffer;
            FileHandler.Loaded = false;
            FileHandler.ReadParametersFromBinaryFile();
            Data.ClearArray();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            string pathBuffer = SaveFile("Save an Entroptik workspace", "Entroptik Workspace(*.ew) | *.ew");
            if (pathBuffer == null)
                return;
            else
                FileHandler.Workspace.FilePath = pathBuffer;
            FileHandler.WriteParametersToBinaryFile();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            string pathBuffer = SaveFile("Save output CSV", "Comma Separated Values(*.csv) | *.csv");
            if (pathBuffer == null)
                return;
            else
                FileHandler.Workspace.OutputPath = pathBuffer;
            File.WriteAllLines(FileHandler.Workspace.OutputPath, Data.ToCsv());
        }

        private void runToolStripButton_Click(object sender, EventArgs e)
        {
            NextImage();
        }

        private void runAllToolStripButton_Click(object sender, EventArgs e)
        {
            if (FileHandler.Workspace.Images != null)
                while (true)
                {
                    if (!NextImage())
                        break;
                }
        }

        private void startOverToolStripButton_Click(object sender, EventArgs e)
        {
            Data.ClearArray();
            progressBar.Value = 0;
            FileHandler.Workspace.ImageIndex = 0;
            Imaging.ShowImage();
        }

        private bool NextImage()
        {
            if (FileHandler.Workspace.Images != null)
            {
                FileHandler.Workspace.ImageIndex++;
                progressBar.PerformStep();
                Imaging.ShowImage();
                if (FileHandler.Workspace.ImageIndex == FileHandler.Workspace.Images.Length - 1)
                {
                    progressBar.Value = 0;
                    runToolStripButton.Enabled = false;
                    return false;
                }
                return true;
            }
            return false;
        }

        private string OpenFile(string title, string filter)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = title;
                openFileDialog.Filter = filter;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    return openFileDialog.FileName;
            }
            return null;
        }

        private string SaveFile(string title, string filter)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = title;
                saveFileDialog.Filter = filter;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    return saveFileDialog.FileName;
            }
            return null;
        }

        private string OpenDirectory(string description)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = description;
                folderBrowserDialog.ShowNewFolderButton = false;
                folderBrowserDialog.SelectedPath = FileHandler.Workspace.DirectoryPath;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    return folderBrowserDialog.SelectedPath;
            }
            return null;
        }

        private static string[] GetImagesFrom(string searchFolder)
        {
            List<string> filesFound = new List<string>();
            SearchOption searchOption = SearchOption.TopDirectoryOnly;
            string[] filters = new string[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, string.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }

        private void numGuideX_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.Loaded)
                return;
            FileHandler.Workspace.Guide = new Point((int)numGuideX.Value, (int)numGuideY.Value);
            Imaging.ShowImage();
        }

        private void numGuideY_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.Loaded)
                return;
            FileHandler.Workspace.Guide = new Point((int)numGuideX.Value, (int)numGuideY.Value);
            Imaging.ShowImage();
        }

        private void numX_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.Loaded)
                return;
            numY.Value = numX.Value;
            FileHandler.Workspace.GridSize = new Point((int)numX.Value, (int)numY.Value);
            Data.ClearArray();
            Imaging.ShowImage();
        }

        private void numY_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.Loaded)
                return;
            numX.Value = numY.Value;
            FileHandler.Workspace.GridSize = new Point((int)numX.Value, (int)numY.Value);
            Data.ClearArray();
            Imaging.ShowImage();
        }

        private void numWid_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.Loaded)
                return;
            FileHandler.Workspace.FeatureSize = new Size((int)numWid.Value, (int)numHgt.Value);
            Imaging.ShowImage();
        }

        private void numHgt_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.Loaded)
                return;
            FileHandler.Workspace.FeatureSize = new Size((int)numWid.Value, (int)numHgt.Value);
            Imaging.ShowImage(); 
        }

        private void numXpitch_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.Loaded)
                return;
            FileHandler.Workspace.Pitch = new Point((int)numXpitch.Value, (int)numYpitch.Value);
            Imaging.ShowImage(); 
        }

        private void numYpitch_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.Loaded)
                return;
            FileHandler.Workspace.Pitch = new Point((int)numXpitch.Value, (int)numYpitch.Value);
            Imaging.ShowImage(); 
        }

        private void numPassScore_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.Loaded)
                return;
            FileHandler.Workspace.Pass = ((double)numPassScore.Value, (double)numPassTol.Value);
            Imaging.ShowImage(); 
        }

        private void numPassTol_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.Loaded)
                return;
            FileHandler.Workspace.Pass = ((double)numPassScore.Value, (double)numPassTol.Value);
            Imaging.ShowImage(); 
        }

        private void numFailScore_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.Loaded)
                return;
            FileHandler.Workspace.Fail = ((double)numFailScore.Value, (double)numFailTol.Value);
            Imaging.ShowImage(); 
        }

        private void numFailTol_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.Loaded)
                return;
            FileHandler.Workspace.Fail = ((double)numFailScore.Value, (double)numFailTol.Value);
            Imaging.ShowImage(); 
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = ZoomMousePos(e.Location);
            foreach (Feature feature in Imaging.Features)
            {
                if (feature.Rectangle.Contains(point))
                    toolStripTextBox.Text = feature.Score.ToString();
            }
        }

        private Point ZoomMousePos(Point click)
        {
            PictureBox pbx = pictureBox;
            float BackgroundImageAspect = pbx.BackgroundImage.Width / (float)pbx.BackgroundImage.Height;
            float controlAspect = pbx.Width / (float)pbx.Height;
            PointF pos = new PointF(click.X, click.Y);
            if (BackgroundImageAspect > controlAspect)
            {
                float ratioWidth = pbx.BackgroundImage.Width / (float)pbx.Width;
                pos.X *= ratioWidth;
                float scale = pbx.Width / (float)pbx.BackgroundImage.Width;
                float displayHeight = scale * pbx.BackgroundImage.Height;
                float diffHeight = pbx.Height - displayHeight;
                diffHeight /= 2;
                pos.Y -= diffHeight;
                pos.Y /= scale;
            }
            else
            {
                float ratioHeight = pbx.BackgroundImage.Height / (float)pbx.Height;
                pos.Y *= ratioHeight;
                float scale = pbx.Height / (float)pbx.BackgroundImage.Height;
                float displayWidth = scale * pbx.BackgroundImage.Width;
                float diffWidth = pbx.Width - displayWidth;
                diffWidth /= 2;
                pos.X -= diffWidth;
                pos.X /= scale;
            }
            return new Point((int)pos.X, (int)pos.Y);
        }
    }
}

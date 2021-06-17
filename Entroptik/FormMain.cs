using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
            pictureBox.MouseUp += PictureBox_MouseUp;
            FileHandler.LoadWorkspaceParameters();
            FileHandler.DefaultsLoaded = true;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            string pathBuffer = OpenDirectory("Select a directory containing target images");
            if (pathBuffer == null)
                return;
            else
                FileHandler.Workspace.DirectoryPath = pathBuffer;
            FileHandler.Workspace.Images = GetImagesFrom(FileHandler.Workspace.DirectoryPath);
            if (FileHandler.Workspace.Images.Length == 0)
            {
                FileHandler.Workspace.Images = null;
                return;
            }
            Imaging.ShowImage(FileHandler.Workspace.Images[0]);
            Imaging.MakeGrid();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            string pathBuffer = OpenFile("Open an Entroptik workspace", "Entroptik Workspace(*.ew) | *.ew");
            if (pathBuffer == null)
                return;
            else
                FileHandler.Workspace.FilePath = pathBuffer;
            FileHandler.ReadParametersFromBinaryFile();
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
            // Write to file
        }

        private void trainToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void runToolStripButton_Click(object sender, EventArgs e)
        {
            NextImage();
        }

        private void runAllToolStripButton_Click(object sender, EventArgs e)
        {
            if (FileHandler.Workspace.Images != null)
            {
                for (int i = FileHandler.Workspace.ImageIndex; i < FileHandler.Workspace.Images.Length - 1; i++)
                {
                    NextImage();
                }
            }
        }

        private void stopToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void startOverToolStripButton_Click(object sender, EventArgs e)
        {
            FileHandler.Workspace.ImageIndex = 0;
            runToolStripButton.Enabled = true;
            NextImage();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Tips>().Any())
                Application.OpenForms.OfType<Tips>().First().BringToFront();
            else
                _ = new Tips();
        }

        private void NextImage()
        {
            if (FileHandler.Workspace.Images != null)
            {
                FileHandler.Workspace.ImageIndex++;
                Imaging.ShowImage(FileHandler.Workspace.Images[FileHandler.Workspace.ImageIndex]);
                if (FileHandler.Workspace.ImageIndex == FileHandler.Workspace.Images.Length - 1)
                    runToolStripButton.Enabled = false;
            }
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

        private void numX_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.DefaultsLoaded)
                return;
            FileHandler.Workspace.GridSize = new Point((int)numX.Value, (int)numY.Value);
            Imaging.MakeGrid();
        }

        private void numY_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.DefaultsLoaded)
                return;
            FileHandler.Workspace.GridSize = new Point((int)numX.Value, (int)numY.Value);
            Imaging.MakeGrid(); 
        }

        private void numWid_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.DefaultsLoaded)
                return;
            FileHandler.Workspace.FeatureSize = new Size((int)numWid.Value, (int)numHgt.Value);
            Imaging.MakeGrid(); 
        }

        private void numHgt_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.DefaultsLoaded)
                return;
            FileHandler.Workspace.FeatureSize = new Size((int)numWid.Value, (int)numHgt.Value);
            Imaging.MakeGrid(); 
        }

        private void numXpitch_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.DefaultsLoaded)
                return;
            FileHandler.Workspace.Pitch = new Point((int)numXpitch.Value, (int)numYpitch.Value);
            Imaging.MakeGrid(); 
        }

        private void numYpitch_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.DefaultsLoaded)
                return;
            FileHandler.Workspace.Pitch = new Point((int)numXpitch.Value, (int)numYpitch.Value);
            Imaging.MakeGrid(); 
        }

        private void numPassScore_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.DefaultsLoaded)
                return;
            FileHandler.Workspace.Pass = ((int)numPassScore.Value, (int)numPassTol.Value);
            Imaging.MakeGrid(); 
        }

        private void numPassTol_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.DefaultsLoaded)
                return;
            FileHandler.Workspace.Pass = ((int)numPassScore.Value, (int)numPassTol.Value);
            Imaging.MakeGrid(); 
        }

        private void numFailScore_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.DefaultsLoaded)
                return;
            FileHandler.Workspace.Fail = ((int)numFailScore.Value, (int)numFailTol.Value);
            Imaging.MakeGrid(); 
        }

        private void numFailTol_ValueChanged(object sender, EventArgs e)
        {
            if (!FileHandler.DefaultsLoaded)
                return;
            FileHandler.Workspace.Fail = ((int)numFailScore.Value, (int)numFailTol.Value);
            Imaging.MakeGrid(); 
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = ZoomMousePos(e.Location);
            foreach (Rectangle rectangle in Imaging.Rectangles)
            {
                if (rectangle.Contains(point))
                    toolStripTextBox.Text = point.ToString();
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!inspectToolStripButton.Checked)
            {
                FileHandler.Workspace.Guide = ZoomMousePos(e.Location);
                Imaging.MakeGrid();
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

        private void inspectToolStripButton_Click(object sender, EventArgs e)
        {
            toolStripTextBox.Visible = inspectToolStripButton.Checked;
        }
    }
}

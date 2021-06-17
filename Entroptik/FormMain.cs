using System;
using System.Collections.Generic;
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
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            string pathBuffer = OpenDirectory("Select a directory containing target images");
            if (pathBuffer == null)
                return;
            else
                FileHandler.Workspace.DirectoryPath = pathBuffer;
            FileHandler.Workspace.Images = GetImagesFrom(FileHandler.Workspace.DirectoryPath);
            Imaging.ShowImage(FileHandler.Workspace.Images[0]);
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

        }

        private void trainToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void inspectToolStripButton_Click(object sender, EventArgs e)
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
    }
}

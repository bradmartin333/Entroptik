using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Entroptik
{
    [Serializable]
    public class Workspace
    {
        public Point Guide = new Point(75, 75);
        public Point GridSize = new Point(5, 5);
        public Size FeatureSize = new Size(50, 50);
        public Point Pitch = new Point(100, 100);
        public (double, double) Pass = (4.0, 2.0);
        public (double, double) Fail = (0.5, 2.0);
        [NonSerialized]
        public string DirectoryPath = @"C:\";
        public string FilePath = null;
        public string OutputPath = null;
        public string[] Images = null;
        public int ImageIndex = 0;
    }

    public static class FileHandler
    {
        public static Workspace Workspace = new Workspace();
        public static FormMain FormMain = null;
        public static PictureBox PictureBox = null;
        public static bool DefaultsLoaded = false;

        public static void LoadWorkspaceParameters()
        {
            FormMain.numX.Value = Workspace.GridSize.X;
            FormMain.numY.Value = Workspace.GridSize.Y;
            FormMain.numWid.Value = Workspace.FeatureSize.Width;
            FormMain.numHgt.Value = Workspace.FeatureSize.Height;
            FormMain.numXpitch.Value = Workspace.Pitch.X;
            FormMain.numYpitch.Value = Workspace.Pitch.Y;
            FormMain.numPassScore.Value = (decimal)Workspace.Pass.Item1;
            FormMain.numPassTol.Value = (decimal)Workspace.Pass.Item2;
            FormMain.numFailScore.Value = (decimal)Workspace.Fail.Item1;
            FormMain.numFailTol.Value = (decimal)Workspace.Fail.Item2;
            Data.ClearArray();
            Imaging.MakeGrid();
            Imaging.ShowImage();
        }

        public static void WriteParametersToBinaryFile()
        {
            using (Stream stream = File.Open(Workspace.FilePath, false ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, Workspace);
            }
        }

        public static void ReadParametersFromBinaryFile()
        {
            using (Stream stream = File.Open(Workspace.FilePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                Workspace = (Workspace)binaryFormatter.Deserialize(stream);
            }
            LoadWorkspaceParameters();
        }
    }
}

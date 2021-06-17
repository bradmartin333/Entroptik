using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Entroptik
{
    [Serializable]
    public class Workspace
    {
        public Point GridSize = new Point(5, 5);
        public Size FeatureSize = new Size(100, 100);
        public Point Pitch = new Point(200, 200);
        public (int, int) Pass = (10, 2);
        public (int, int) Fail = (5, 2);
        [NonSerialized]
        public string DirectoryPath = null;
        public string FilePath = null;
        public string[] Images = null;
        public int ImageIndex = 0;
    }

    public static class FileHandler
    {
        public static Workspace Workspace = new Workspace();
        public static FormMain FormMain = null;
        public static PictureBox PictureBox = null;

        public static void WriteParametersToBinaryFile()
        {
            Workspace.GridSize = new Point((int)FormMain.numX.Value, (int)FormMain.numY.Value);
            Workspace.FeatureSize = new Size((int)FormMain.numWid.Value, (int)FormMain.numHgt.Value);
            Workspace.Pitch = new Point((int)FormMain.numXpitch.Value, (int)FormMain.numYpitch.Value);
            Workspace.Pass = ((int)FormMain.numPassScore.Value, (int)FormMain.numPassTol.Value);
            Workspace.Fail = ((int)FormMain.numFailScore.Value, (int)FormMain.numFailTol.Value);

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
        }
    }
}

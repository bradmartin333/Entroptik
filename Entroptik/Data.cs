using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entroptik
{
    static class Data
    {
        public static DataType Type = DataType.Invalid;
        public enum DataType
        {
            RawIncremental,
            RowCol,
            Invalid
        }

        public static int[,] DataArray = new int[5,5];

        public static void ClearArray()
        {
            int len = 1;
            if (FileHandler.Workspace.Images != null)
                len = (int)Math.Sqrt(FileHandler.Workspace.Images.Length);

            DataArray = new int[(int)(len * (double)FileHandler.FormMain.numX.Value),
                (int)(len * (double)FileHandler.FormMain.numY.Value)];
        }

        public static IEnumerable<string> ToCsv()
        {
            for (int i = 0; i < DataArray.GetLength(0); ++i)
                yield return string.Join(",", Enumerable
                  .Range(0, DataArray.GetLength(1))
                  .Select(j => DataArray[i, j]));
        }

        public static bool VerifyFiles()
        {
            bool isRawIncremental = true;
            bool isRowCol = true;

            if (FileHandler.Workspace.Images.Length == 0)
            {
                Type = DataType.Invalid;
                return false;
            }

            foreach (string file in FileHandler.Workspace.Images)
            {
                if (!file.Contains("raw"))
                    isRawIncremental = false;
                if (!file.Contains("R") || !file.Contains("C"))
                    isRowCol = false;
            }

            if (isRawIncremental)
                Type = DataType.RawIncremental;
            else if (isRowCol)
                Type = DataType.RowCol;
            else
                Type = DataType.Invalid; 

            return true;
        }

        public static int GetFileRow(string path)
        {
            string cleanPath = path.Split('\\').Last().Split('.').First();
            switch (Type)
            {
                case DataType.RawIncremental:
                    int fileNum = int.Parse(cleanPath.Replace("raw", ""));
                    double diff = double.Parse((fileNum / Math.Sqrt(FileHandler.Workspace.Images.Length)).ToString().Split('.').First());
                    return (int)diff;
                case DataType.RowCol:
                    return int.Parse(cleanPath.Split('C').First().Replace("R", "").Replace("_","")) - 1;
            }
            return 0;
        }

        public static int GetFileCol(string path)
        {
            string cleanPath = path.Split('\\').Last().Split('.').First();
            switch (Type)
            {
                case DataType.RawIncremental:
                    int fileNum = int.Parse(cleanPath.Replace("raw", ""));
                    double diff = double.Parse((fileNum / Math.Sqrt(FileHandler.Workspace.Images.Length)).ToString().Split('.').First());
                    double col = (fileNum / Math.Sqrt(FileHandler.Workspace.Images.Length) - diff) *
                        Math.Sqrt(FileHandler.Workspace.Images.Length);
                    return (int)col;
                case DataType.RowCol:
                    return int.Parse(cleanPath.Split('C').Last()) - 1;
            }
            return 0;
        }
    }
}

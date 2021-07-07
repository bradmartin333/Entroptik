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

        public static int[,] DataArray = new int[5, 5];
        public static int[,] OriginalDataMap = new int[1, 1];
        public static int[,] DataMap = new int[1, 1];

        public static void ClearArray()
        {
            int len = 1;
            if (FileHandler.Workspace.Images != null)
                len = (int)Math.Sqrt(FileHandler.Workspace.Images.Length);

            DataArray = new int[(int)(len * (double)FileHandler.FormMain.numX.Value),
                (int)(len * (double)FileHandler.FormMain.numY.Value)];

            DataMap = new int[len, len];

            int idx = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    DataMap[i, j] = idx;
                    idx++;
                }
            }

            OriginalDataMap = (int[,])DataMap.Clone();

            _ = new MapFlip();
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

        public static int[] GetFileRowCol(string path)
        {
            string cleanPath = path.Split('\\').Last().Split('.').First();
            switch (Type)
            {
                case DataType.RawIncremental:
                    int fileNum = int.Parse(cleanPath.Replace("raw", ""));
                    for (int i = 0; i < OriginalDataMap.GetLength(0); i++)
                    {
                        for (int j = 0; j < OriginalDataMap.GetLength(1); j++)
                        {
                            if (OriginalDataMap[i, j] == fileNum)
                            {
                                return new int[] { i, j };
                            }
                        }
                    }
                    return new int[] { 0, 0 };
                case DataType.RowCol:
                    return new int[] { int.Parse(cleanPath.Split('C').First().Replace("R", "").Replace("_", "")) - 1, 
                        int.Parse(cleanPath.Split('C').Last()) - 1 };
            }
            return new int[] { 0, 0 };
        }
    }
}

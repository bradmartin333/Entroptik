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
    }
}

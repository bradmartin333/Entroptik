using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entroptik
{
    class Data
    {
        public DataType Type = DataType.Standard;
        public enum DataType
        {
            Standard,
            RawIncremental,
            RowCol
        }

        public Data()
        {
            bool isRawIncremental = true;
            bool isRowCol = true;

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
                Type = DataType.Standard;

        }
    }
}

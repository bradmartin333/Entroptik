using System;
using System.Drawing;
using System.Windows.Forms;
using static Entroptik.Data;

namespace Entroptik
{
    public partial class MapFlip : Form
    {
        Panel[] _Panels = new Panel[4];
        Color[] _PnlColors = new Color[4];
        Color[] _PnlColorsInit = new Color[4];

        public MapFlip(bool show = false)
        {
            InitializeComponent();
            _Panels = new Panel[] { pnlOutA, pnlOutB, pnlOutC, pnlOutD };
            getPanelColors(init: true);

            foreach (int modification in FileHandler.Workspace.DataOrientation)
            {
                switch (modification)
                {
                    case 0:
                        HorizFlip(true, show);
                        break;
                    case 1:
                        VertFlip(true, show);
                        break;
                    case 2:
                        Rotate(true, show);
                        break;
                }
            }

            if (show) Show();
        }

        private void HorizFlip(bool load = false, bool show = false)
        {
            UpdateColors(new int[] { 1, 0, 3, 2 });
            if (show) return;
            int[,] DataMapClone = (int[,])DataMap.Clone();
            for (int i = 0; i < DataMap.GetLength(0); i++)
            {
                for (int j = 0; j < DataMap.GetLength(1); j++)
                {
                    DataMap[i, DataMap.GetLength(1) - j - 1] = DataMapClone[i, j];
                }
            }
            if (load) return;
            FileHandler.Workspace.DataOrientation.Add(0);
        }

        private void VertFlip(bool load = false, bool show = false)
        {
            UpdateColors(new int[] { 2, 3, 0, 1 });
            if (show) return;
            int[,] DataMapClone = (int[,])DataMap.Clone();
            for (int i = 0; i < DataMap.GetLength(0); i++)
            {
                for (int j = 0; j < DataMap.GetLength(1); j++)
                {
                    DataMap[DataMap.GetLength(0) - i - 1, j] = DataMapClone[i, j];
                }
            }
            if (load) return;
            FileHandler.Workspace.DataOrientation.Add(1);
        }

        private void Rotate(bool load = false, bool show = false)
        {
            UpdateColors(new int[] { 1, 3, 0, 2 });
            if (show) return;
            int[,] DataMapClone = (int[,])DataMap.Clone();
            for (int i = 0; i < DataMap.GetLength(0); i++)
            {
                for (int j = 0; j < DataMap.GetLength(1); j++)
                {
                    DataMap[i, j] = DataMapClone[j, DataMap.GetLength(0) - i - 1];
                }
            }
            if (load) return;
            FileHandler.Workspace.DataOrientation.Add(2);
        }

        private void UpdateColors(int[] vals)
        {
            getPanelColors();
            _Panels[0].BackColor = _PnlColors[vals[0]];
            _Panels[1].BackColor = _PnlColors[vals[1]];
            _Panels[2].BackColor = _PnlColors[vals[2]];
            _Panels[3].BackColor = _PnlColors[vals[3]];
        }

        private void btnClick(object sender, EventArgs e)
        {
            BackColor = Color.Firebrick;
            Refresh();

            Button button = (Button)sender;
            try
            {
                switch (button.Tag)
                {
                    case "0":
                        HorizFlip();
                        break;
                    case "1":
                        VertFlip();
                        break;
                    case "2":
                        Rotate();
                        break;
                }
            }
            catch (Exception) { }

            BackColor = Color.Silver;
        }

        private void getPanelColors(bool init = false)
        {
            for(int i = 0; i < 4; i++)
            {
                if (init)
                {
                    _PnlColorsInit[i] = _Panels[i].BackColor;
                }
                else
                {
                    _PnlColors[i] = _Panels[i].BackColor;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _Panels.Length; i++)
            {
                _Panels[i].BackColor = _PnlColorsInit[i];
            }

            DataMap = OriginalDataMap;
            FileHandler.Workspace.DataOrientation.Clear();
        }
    }
}

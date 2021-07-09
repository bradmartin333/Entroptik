using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Entroptik
{
    public partial class Plotter : Form
    {
        public Plotter(string path)
        {
            InitializeComponent();

            Text = path.Split('\\').Last();

            string[] rawData = File.ReadAllLines(path);
            int cols = rawData[0].Replace(",", "").Length;
            int rows = rawData.Length;

            PlotModel plotModel = new PlotModel();
            ScatterSeries[] scatterSeries = new ScatterSeries[] {
                new ScatterSeries()
                {
                    MarkerFill = OxyColors.Pink
                },
                new ScatterSeries()
                {
                    MarkerFill = OxyColors.Red
                },
                new ScatterSeries()
                {
                    MarkerFill = OxyColors.Green
                }
            };
            foreach (ScatterSeries series in scatterSeries)
            {
                plotModel.Series.Add(series);
            }

            for (int j = 0; j < rows; j++)
            {
                string[] data = rawData[j].Split(',');
                for (int i = 0; i < cols; i++)
                {
                    int value = int.Parse(data[i]);
                    ScatterPoint scatterPoint = new ScatterPoint(i, j);
                    scatterSeries[value + 1].Points.Add(scatterPoint);
                }
            }

            LinearAxis YAxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                StartPosition = 1,
                EndPosition = 0,
            };

            plotModel.Axes.Add(YAxis);
            plotView.Model = plotModel;

            Show();
        }
    }
}

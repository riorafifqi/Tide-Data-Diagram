using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TideDiagramApp
{
    public partial class Form1 : Form
    {
        TideData tideData;
        public Form1()
        {
            InitializeComponent();
            tideData = new TideData();
            tideData.Request();
            
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var objChart = chart.ChartAreas[0];

            // TimeDate
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            objChart.AxisX.Minimum = tideData.response.meta.start.ToOADate();
            objChart.AxisX.Maximum = tideData.response.meta.end.ToOADate();

            // Tide
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = -2;
            objChart.AxisY.Maximum = 2;

            //Clear
            chart.Series.Clear();

            Series newSeries = new Series("Tide");
            newSeries.ChartType = SeriesChartType.Line;
            newSeries.BorderWidth = 2;
            newSeries.Color = Color.DarkBlue;
            newSeries.XValueType = ChartValueType.DateTime;
            chart.Series.Add(newSeries);

            for (int i = 0; i < tideData.response.data.Count; i++)
            {
                chart.Series[0].Points.AddXY(tideData.response.data[i].time, tideData.response.data[i].height);
                Refresh();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

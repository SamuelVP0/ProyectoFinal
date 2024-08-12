using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Prueba1
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private Random random;
        private int timeElapsed;

        public Form1()
        {
            InitializeComponent();
            InitializeChart();
            InitializeTimer();
            random = new Random();
        }

        private void InitializeChart()
        {
            chartECG.Series.Clear();
            chartECG.ChartAreas.Clear();
            chartECG.ChartAreas.Add(new ChartArea("MainArea"));
            Series series = new Series("ECG Data")
            {
                ChartType = SeriesChartType.Line,
                Color = System.Drawing.Color.Red,
                BorderWidth = 2
            };
            chartECG.Series.Add(series);
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 100; // Update every 100 ms
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            double yValue = 100 * Math.Sin(timeElapsed / 10.0) + random.Next(-10, 10);
            chartECG.Series[0].Points.AddY(yValue);

            if (chartECG.Series[0].Points.Count > 100) // Keep last 100 points
            {
                chartECG.Series[0].Points.RemoveAt(0);
            }

            chartECG.Invalidate();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
                btnStartStop.Text = "Start";
            }
            else
            {
                timer.Start();
                btnStartStop.Text = "Stop";
            }
        }
    }
}

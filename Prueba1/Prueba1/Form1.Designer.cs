namespace Prueba1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.chartECG = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnStartStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartECG)).BeginInit();
            this.SuspendLayout();
            // 
            // chartECG
            // 
            this.chartECG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartECG.Location = new System.Drawing.Point(12, 12);
            this.chartECG.Name = "chartECG";
            this.chartECG.Size = new System.Drawing.Size(760, 400);
            this.chartECG.TabIndex = 0;
            this.chartECG.Text = "chart1";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 418);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.chartECG);
            this.Name = "Form1";
            this.Text = "ECG Simulation";
            ((System.ComponentModel.ISupportInitialize)(this.chartECG)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataVisualization.Charting.Chart chartECG;
        private System.Windows.Forms.Button btnStartStop;
    }
}

using System;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
namespace SpeedForm
{
    public partial class Form1 : Form
    {
        static System.Windows.Forms.Timer Timer1 = new System.Windows.Forms.Timer();
        Label speedLabel;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer1.Interval = 100;
            Timer1.Tick += new EventHandler(Timer1_Tick);
            Timer1.Enabled = true;

            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            this.Size = new Size(500, 300);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(1480, 0);
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            speedLabel = new Label();
            Color myColor = Color.FromArgb(255, Color.Red);
            speedLabel.Text = "10";
            speedLabel.Size = new Size(500, 300);
            speedLabel.Location = new Point(10, 25);
            speedLabel.Font = new Font("Calibri", 50);
            speedLabel.ForeColor = myColor;
            this.Controls.Add(speedLabel);
        }
        private void Timer1_Tick(object Sender, EventArgs e)
        {
            Tuple<float, float, float> position1 = Memory.getPos();
            float X1 = position1.Item1;
            float Y1 = position1.Item2;
            float Z1 = position1.Item3;

            Thread.Sleep(100);

            Tuple<float, float, float> position2 = Memory.getPos();
            float X2 = position2.Item1;
            float Y2 = position2.Item2;
            float Z2 = position2.Item3;
            speedLabel.Text = $"{(int)(10 * Math.Sqrt(Math.Pow((double)(X2 - X1), 2) + Math.Pow((double)(Y2 - Y1), 2) + Math.Pow((double)(Z2 - Z1), 2)))} MPH";
        }
    }
}

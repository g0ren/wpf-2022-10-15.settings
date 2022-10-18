using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace _10._15._4_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool datetime = false;
        private string[] ru = new string[] 
            {"Öâåò ôîðìû", "Íàñòðîéêè", "Öâåò", "ßçûê" };

        private string[] en = new string[]
            {"Form color", "Settings", "Color", "Language"};

        private void Form1_Load(object sender, EventArgs e)
        {
            textToolStripMenuItem.Text = DateTime.Now.ToString("dddd");
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd'-'MM'-'yyyy");
            colorPanel.Visible = false;
            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += new EventHandler(Timer_tick);
            timer.Start();
        }

        private void Timer_tick(object sender, EventArgs e)
        {
            if (datetime)
            {
                toolStripStatusLabel1.Text = DateTime.Now.ToString("hh':'mm");
                datetime = false;
            }
            else
            {
                toolStripStatusLabel1.Text = DateTime.Now.ToString("dd'-'MM'-'yyyy");
                datetime = true;
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void öâåòToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            colorPanel.Visible = !colorPanel.Visible;
        }

        private void ðóññêèéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");

            System.ComponentModel.ComponentResourceManager resources = 
                new System.ComponentModel.ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");
            foreach(Control c in this.Controls)
            {
                resources.ApplyResources(c, c.Name);
            }
            label2.Text = ru[0];
            öâåòToolStripMenuItem.Text = ru[1];
            öâåòToolStripMenuItem1.Text = ru[2];
            ÿçûêToolStripMenuItem.Text = ru[3];
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");
            foreach (Control c in this.Controls)
            {
                resources.ApplyResources(c, c.Name);
            }
            label2.Text = en[0];
            öâåòToolStripMenuItem.Text = en[1];
            öâåòToolStripMenuItem1.Text = en[2];
            ÿçûêToolStripMenuItem.Text = en[3];
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
    }
}
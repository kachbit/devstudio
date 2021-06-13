using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Installer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Panel pnlTop = new Panel() { Height = 4, Dock = DockStyle.Top, BackColor = Color.Black };
            this.Controls.Add(pnlTop);

            Panel pnlRight = new Panel() { Width = 4, Dock = DockStyle.Right, BackColor = Color.Black };
            this.Controls.Add(pnlRight);

            Panel pnlBottom = new Panel() { Height = 4, Dock = DockStyle.Bottom, BackColor = Color.Black };
            this.Controls.Add(pnlBottom);

            Panel pnlLeft = new Panel() { Width = 4, Dock = DockStyle.Left, BackColor = Color.Black };
            this.Controls.Add(pnlLeft);
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();



        private void Form2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Console.WriteLine("works");
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://devstudioapp.github.io/devstudio/");
        }
    }
}

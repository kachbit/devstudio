using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            treeView1.ExpandAll();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Console.WriteLine(e.Node.Name);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuickOps
{
    public partial class QuickOpsForm : Form
    {
        public Stream texts;

        public QuickOpsForm()
        {
            Monitor monitor = new Monitor();
            monitor.OutputChanged += new EventHandler(Output_Changed);
            monitor.StartPrintDateTime();
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Output_Changed(object sender, EventArgs e)
        {
            textBox1.Text = Monitor.output.ToString();
        }
    }
}

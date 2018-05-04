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
        public QuickOpsForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            FormClosing += QuickOpsForm_FormClosing;
            InitializeComponent();
        }

        private void QuickOpsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void WriteToForm(string s)
        {
            textBox1.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void QuickOpsForm_Load(object sender, EventArgs e)
        {

        }
    }
}

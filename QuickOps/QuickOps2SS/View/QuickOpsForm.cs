using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using QuickOps2SS.Model;
using QuickOps2SS.Controller;

namespace QuickOps2SS.View
{
    public partial class QuickOpsForm : Form
    {
        SSController controller;

        public QuickOpsForm()
        {
            controller = new SSController();
            FormClosing += QuickOpsForm_FormClosing;
            InitializeComponent();
            controller.statistics.StatusChanged += Statistics_StatusChanged;
        }

        private void Statistics_StatusChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = controller.statistics.StatusCount.ToString();
        }

        private void QuickOpsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Visible = false;
            e.Cancel = true;
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

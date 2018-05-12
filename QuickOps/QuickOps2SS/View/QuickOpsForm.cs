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
        HttpStatistics statistics;
        DataTable statisticsTable;

        public QuickOpsForm()
        {
            controller = new SSController();
            statistics = controller.statistics;
            FormClosing += QuickOpsForm_FormClosing;
            InitializeComponent();
            controller.statistics.StatusChanged += Statistics_StatusChanged;
            InitTable();
        }

        private void InitTable()
        {
            statisticsTable = new DataTable();
            statisticsTable.Columns.Add(new DataColumn("Name", typeof(String)));
            statisticsTable.Columns.Add(new DataColumn("Code", typeof(String)));
            foreach(var s in statistics.Statuses)
            {
                statisticsTable.Rows.Add(s.Url, Convert.ToInt32(s.StatusCode));
            }
            listView1.Columns.Add("Name", 300, HorizontalAlignment.Left);
            listView1.Columns.Add("Code", 200, HorizontalAlignment.Left);
        }

        private void Statistics_StatusChanged(object sender, EventArgs e)
        {
            //richTextBox1.Text = statistics.StatusCount.ToString();
            var row = statistics.Statuses[statistics.Statuses.Count - 1];
            statisticsTable.Rows.Add(row.Url.ToString(), row.StatusCode);
            listView1.BeginUpdate();
            ListViewItem lt = new ListViewItem();
            lt.Text = row.Url.ToString();
            listView1.Items.Add(lt);
            listView1.EndUpdate();
        }

        private void QuickOpsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Visible = false;
            e.Cancel = true;
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

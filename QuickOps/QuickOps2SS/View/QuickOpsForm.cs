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
using Newtonsoft.Json;

namespace QuickOps2SS.View
{
    public partial class QuickOpsForm : Form
    {
        public Router router;
        SSController controller;
        HttpStatistics statistics;
        private delegate void UpdateViewFromListCallback(List<HttpStatistics.SingleHttpStatus> singles);

        public QuickOpsForm()
        {
            controller = new SSController();
            router = controller.router;
            statistics = controller.statistics;
            FormClosing += QuickOpsForm_FormClosing;
            InitializeComponent();
            statistics.StatusChanged += Statistics_StatusChanged;
            dataGridView1.DataSource = statistics.Statuses;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                router.Urls.Add(dataGridView1[0, e.RowIndex].ToString());
            }
        }

        private void UpdateViewFromList(List<HttpStatistics.SingleHttpStatus> singles)
        {
            if (dataGridView1.InvokeRequired)
            {
                UpdateViewFromListCallback setListCallback = new UpdateViewFromListCallback(UpdateViewFromList);
                Invoke(setListCallback, new object[] { singles});
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = singles;
            }
        }

        private void Statistics_StatusChanged(object sender, EventArgs e)
        {
            UpdateViewFromList(statistics.Statuses);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

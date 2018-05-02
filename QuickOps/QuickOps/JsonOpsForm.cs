using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace QuickOps
{
    public partial class JsonOpsForm : Form
    {
        NumbersAndLetters aa;

        public JsonOpsForm()
        {
            InitializeComponent();
            aa = new NumbersAndLetters();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aa.ll.Add(DateTime.Now.Second);
            string strJson = JsonConvert.SerializeObject(aa);
            jsonresult.Text = strJson;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            aa.ss.Add(DateTime.Now.ToString());
            string strJson = JsonConvert.SerializeObject(aa);
            jsonresult.Text = strJson;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class NumbersAndLetters
    {
        public List<int> ll { get; set; }
        public List<string> ss { get; set; }

        public NumbersAndLetters()
        {
            ll = new List<int>();
            ss = new List<string>();
        }
    }
}

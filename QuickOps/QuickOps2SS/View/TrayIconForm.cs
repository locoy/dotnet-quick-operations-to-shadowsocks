using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickOps2SS.View
{
    public partial class TrayIconForm : Form
    {
        public TrayIconForm()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void TrayIconForm_Load(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}

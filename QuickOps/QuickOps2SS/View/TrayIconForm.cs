using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickOps2SS.Controller;

namespace QuickOps2SS.View
{
    public partial class TrayIconForm : Form
    {
        QuickOpsForm quickOpsForm;

        public TrayIconForm()
        {
            quickOpsForm = new QuickOpsForm();
            quickOpsForm.ClientSize = new System.Drawing.Size(800, 450);
            quickOpsForm.Location = new System.Drawing.Point(494, 494);
            quickOpsForm.Name = "quickOpsForm";
            quickOpsForm.Text = "QuickOpsForm";
            quickOpsForm.Visible = false;
            quickOpsForm.Load += new System.EventHandler(this.QuickOpsForm_Load);
            InitializeComponent();
            notifyIcon1.MouseClick += new MouseEventHandler(ShowOrHideQuickOpsForm);
            notifyIcon1.ContextMenu = new ContextMenu(
                new MenuItem[] 
                {
                    new MenuItem("Exit", Exit),
                    new MenuItem("RunAutoConfig", RunAutoConfig)
                });
        }

        private void RunAutoConfig(object sender, EventArgs e)
        {

        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void TrayIconForm_Load(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void QuickOpsForm_Load(object sender, EventArgs e)
        {

        }

        private void ShowOrHideQuickOpsForm(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                quickOpsForm.Visible = !quickOpsForm.Visible;
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            quickOpsForm.Dispose();
            Application.Exit();
        }
    }
}

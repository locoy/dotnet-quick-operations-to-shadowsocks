using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using QuickOps2SS.Controller;
using QuickOps2SS.Properties;
using QuickOps2SS.View;

namespace QuickOps2SS.View
{
    class MenuViewController
    {
        private SSController controller;
        private HttpMonitor monitor;

        private NotifyIcon notifyIcon;
        //private Bitmap iconmap;
        //private Icon icon;
        private ContextMenu contextMenu;

        private MenuItem exitItem;
        private MenuItem runAutoRouteItem;

        private QuickOpsForm quickOpsForm;

        public MenuViewController(SSController controller)
        {
            this.controller = controller;
            this.monitor = controller.monitor;
            quickOpsForm = new QuickOpsForm(controller);
            quickOpsForm.Name = "QuickOpsForm";
            quickOpsForm.Text = "Quick Ops Form";
            quickOpsForm.Visible = false;
            exitItem = new MenuItem("Exit", Exit);
            runAutoRouteItem = new MenuItem("Run AutoRoute", RunAutoConfig);
            contextMenu = new ContextMenu(new MenuItem[] { runAutoRouteItem, exitItem });
            notifyIcon = new NotifyIcon
            {
                Visible = true,
                Icon = Resources.plane,
                ContextMenu = contextMenu
            };
            notifyIcon.MouseClick += new MouseEventHandler(ShowOrHideQuickOpsForm);
        }

        private void RunAutoConfig(object sender, EventArgs e)
        {

        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void QuickOpsForm_Load(object sender, EventArgs e)
        {

        }

        private void ShowOrHideQuickOpsForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (quickOpsForm.Visible)
                {
                    quickOpsForm.Visible = false;
                    monitor?.Dispose();
                }
                else
                {
                    quickOpsForm.Visible = true;
                    monitor = new HttpMonitor();
                }
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            quickOpsForm.Dispose();
            Application.Exit();
        }
    }
}

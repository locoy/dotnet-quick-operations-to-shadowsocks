using QuickOps.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickOps
{
    class TrayIcon : ApplicationContext
    {
        private NotifyIcon trayIcon;
        //private ClipboardCleaner MyClipboardCleaner = new ClipboardCleaner();
        private QuickOpsForm quickOpsForm;
        private Monitor monitor;
        private Thread writeThread;

        public TrayIcon()
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                //Icon = Resources.AppTrayIcon,
                Icon = Resources.Plane,
                ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Exit", Exit) }),
                Visible = true,
                Text = "Click to show quick ops form."
            };
            quickOpsForm = new QuickOpsForm();
            monitor = new Monitor();
            monitor.CaptureHttp();
            quickOpsForm.Visible = false;
            trayIcon.MouseClick += new MouseEventHandler(ShowQuickOpsForm);
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;
            Application.Exit();
        }

        void ShowQuickOpsForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (quickOpsForm.Visible == false)
                {
                    quickOpsForm.Visible = true;
                }
                else
                {
                    quickOpsForm.Visible = false;
                }
            }
        }

        //when the form is visible, stick it in the front and refresh data every 2 seconds;
    }
}

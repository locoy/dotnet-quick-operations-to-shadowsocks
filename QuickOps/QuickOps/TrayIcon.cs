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
        private QuickOpsForm quickOpsForm;
        private Monitor monitor;
        //private Thread writeThread;

        public TrayIcon()
        {
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.Plane,
                ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Exit", Exit) }),
                Visible = true,
                Text = "Click to show quick ops form."
            };
            quickOpsForm = new QuickOpsForm
            {
                Visible = false,
                TopMost = true
            };
            monitor = new Monitor();
            monitor.OutputChanged += new EventHandler(WriteLogToForm);
            trayIcon.MouseClick += new MouseEventHandler(ShowQuickOpsForm);
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;
            //Application.Exit();
            Application.ExitThread();
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

        void WriteLogToForm(object sender, EventArgs e)
        {
            quickOpsForm.WriteToForm(monitor.Output.ToString());
        }

        //when the form is visible, stick it in the front and refresh data every 2 seconds;
    }
}

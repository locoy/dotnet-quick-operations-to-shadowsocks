using QuickOps.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickOps
{
    class TrayIcon : ApplicationContext
    {
        private NotifyIcon trayIcon;
        //private ClipboardCleaner MyClipboardCleaner = new ClipboardCleaner();

        public TrayIcon()
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                //Icon = Resources.AppTrayIcon,
                Icon = Resources.Plane,
                ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Exit", Exit) }),
                Visible = true,
                Text = "Click to show configure page."
            };
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;
            Application.Exit();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using QuickOps2SS.Controller;
using QuickOps2SS.View;

namespace QuickOps2SS.View
{
    class MenuViewController
    {
        private ShadowsocksController controller;

        private NotifyIcon notifyIcon;
        private Bitmap iconmap;
        private Icon icon;
        private ContextMenu contextMenu;

        private MenuItem exitItem;
        private MenuItem runAutoRouteItem;

        private QuickOpsForm quickOpsForm;

        public MenuViewController(ShadowsocksController shadowsocksController)
        {
            this.controller = shadowsocksController;
        }
    }
}

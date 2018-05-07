﻿using QuickOps2SS.Properties;
using System;
using System.Windows.Forms;

namespace QuickOps2SS.View
{
    partial class TrayIconForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public QuickOpsForm quickOpsForm;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            quickOpsForm = new QuickOpsForm();
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Icon = Resources.plane;
            this.notifyIcon1.ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Exit", Exit) });
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notifyIcon1.MouseClick += new MouseEventHandler(this.ShowOrHideQuickOpsForm);
            // 
            // TrayIconForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "TrayIconForm";
            this.Text = "TrayIconForm";
            this.Load += new System.EventHandler(this.TrayIconForm_Load);
            this.ResumeLayout(false);

        }

        private void ShowOrHideQuickOpsForm(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
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

        private void Exit(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}
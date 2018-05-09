using QuickOps2SS.Properties;
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
        public 

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
            this.quickOpsForm = new QuickOps2SS.View.QuickOpsForm();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = global::QuickOps2SS.Properties.Resources.plane;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            //this.notifyIcon1.ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Exit", Exit)});
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowOrHideQuickOpsForm);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // quickOpsForm
            // 
            this.quickOpsForm.ClientSize = new System.Drawing.Size(800, 450);
            this.quickOpsForm.Location = new System.Drawing.Point(494, 494);
            this.quickOpsForm.Name = "quickOpsForm";
            this.quickOpsForm.Text = "QuickOpsForm";
            this.quickOpsForm.Visible = false;
            this.quickOpsForm.Load += new System.EventHandler(this.QuickOpsForm_Load);
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
namespace QuickOps
{
    partial class JsonOpsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.jsonresult = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 95);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add numbers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(463, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 95);
            this.button2.TabIndex = 1;
            this.button2.Text = "Add letters";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // jsonresult
            // 
            this.jsonresult.Location = new System.Drawing.Point(168, 180);
            this.jsonresult.Name = "jsonresult";
            this.jsonresult.Size = new System.Drawing.Size(456, 229);
            this.jsonresult.TabIndex = 2;
            this.jsonresult.Text = "";
            this.jsonresult.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // JsonOpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.jsonresult);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "JsonOpsForm";
            this.Text = "JsonOpsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox jsonresult;
    }
}
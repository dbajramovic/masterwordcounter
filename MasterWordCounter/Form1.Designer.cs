namespace MasterWordCounter
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.importTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTextsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tESTINSERTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertVerbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importTextToolStripMenuItem,
            this.viewTextsToolStripMenuItem,
            this.tESTINSERTToolStripMenuItem,
            this.insertVerbToolStripMenuItem,
            this.dashboardToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(447, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // importTextToolStripMenuItem
            // 
            this.importTextToolStripMenuItem.Name = "importTextToolStripMenuItem";
            this.importTextToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.importTextToolStripMenuItem.Text = "Import Text...";
            this.importTextToolStripMenuItem.Click += new System.EventHandler(this.importTextToolStripMenuItem_Click);
            // 
            // viewTextsToolStripMenuItem
            // 
            this.viewTextsToolStripMenuItem.Name = "viewTextsToolStripMenuItem";
            this.viewTextsToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.viewTextsToolStripMenuItem.Text = "View Texts";
            this.viewTextsToolStripMenuItem.Click += new System.EventHandler(this.viewTextsToolStripMenuItem_Click);
            // 
            // tESTINSERTToolStripMenuItem
            // 
            this.tESTINSERTToolStripMenuItem.Name = "tESTINSERTToolStripMenuItem";
            this.tESTINSERTToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.tESTINSERTToolStripMenuItem.Text = "Insert Noun";
            this.tESTINSERTToolStripMenuItem.Click += new System.EventHandler(this.tESTINSERTToolStripMenuItem_Click);
            // 
            // insertVerbToolStripMenuItem
            // 
            this.insertVerbToolStripMenuItem.Name = "insertVerbToolStripMenuItem";
            this.insertVerbToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.insertVerbToolStripMenuItem.Text = "Insert Verb";
            this.insertVerbToolStripMenuItem.Click += new System.EventHandler(this.insertVerbToolStripMenuItem_Click);
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 261);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem importTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTextsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tESTINSERTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertVerbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
    }
}


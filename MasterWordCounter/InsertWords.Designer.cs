namespace MasterWordCounter
{
    partial class InsertWords
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
            this.label1 = new System.Windows.Forms.Label();
            this.t_word = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.c_root = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ch_regular = new System.Windows.Forms.CheckBox();
            this.ch_root = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.l_InList = new System.Windows.Forms.Label();
            this.l_words = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Word:";
            // 
            // t_word
            // 
            this.t_word.Location = new System.Drawing.Point(55, 10);
            this.t_word.Name = "t_word";
            this.t_word.Size = new System.Drawing.Size(217, 20);
            this.t_word.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type:";
            // 
            // c_type
            // 
            this.c_type.FormattingEnabled = true;
            this.c_type.Location = new System.Drawing.Point(55, 38);
            this.c_type.Name = "c_type";
            this.c_type.Size = new System.Drawing.Size(217, 21);
            this.c_type.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Root:";
            // 
            // c_root
            // 
            this.c_root.FormattingEnabled = true;
            this.c_root.Location = new System.Drawing.Point(55, 68);
            this.c_root.Name = "c_root";
            this.c_root.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.c_root.Size = new System.Drawing.Size(217, 21);
            this.c_root.TabIndex = 5;
            this.c_root.SelectedIndexChanged += new System.EventHandler(this.c_root_SelectedIndexChanged);
            this.c_root.TextUpdate += new System.EventHandler(this.c_root_TextUpdate);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ch_regular
            // 
            this.ch_regular.AutoSize = true;
            this.ch_regular.Location = new System.Drawing.Point(55, 99);
            this.ch_regular.Name = "ch_regular";
            this.ch_regular.Size = new System.Drawing.Size(63, 17);
            this.ch_regular.TabIndex = 7;
            this.ch_regular.Text = "Regular";
            this.ch_regular.UseVisualStyleBackColor = true;
            // 
            // ch_root
            // 
            this.ch_root.AutoSize = true;
            this.ch_root.Location = new System.Drawing.Point(125, 99);
            this.ch_root.Name = "ch_root";
            this.ch_root.Size = new System.Drawing.Size(66, 17);
            this.ch_root.TabIndex = 8;
            this.ch_root.Text = "Is Root?";
            this.ch_root.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Words:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(431, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "In List:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(295, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Last Word:";
            // 
            // l_InList
            // 
            this.l_InList.AutoSize = true;
            this.l_InList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_InList.Location = new System.Drawing.Point(506, 13);
            this.l_InList.Name = "l_InList";
            this.l_InList.Size = new System.Drawing.Size(45, 13);
            this.l_InList.TabIndex = 12;
            this.l_InList.Text = "No/No";
            // 
            // l_words
            // 
            this.l_words.AutoSize = true;
            this.l_words.Location = new System.Drawing.Point(342, 13);
            this.l_words.Name = "l_words";
            this.l_words.Size = new System.Drawing.Size(35, 13);
            this.l_words.TabIndex = 13;
            this.l_words.Text = "label7";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(278, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Next";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(359, 95);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Refresh List";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // InsertWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 128);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.l_words);
            this.Controls.Add(this.l_InList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ch_root);
            this.Controls.Add(this.ch_regular);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.c_root);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.c_type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t_word);
            this.Controls.Add(this.label1);
            this.Name = "InsertWords";
            this.Text = "Insert Words";
            this.Load += new System.EventHandler(this.InsertWords_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_word;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox c_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox c_root;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ch_regular;
        private System.Windows.Forms.CheckBox ch_root;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label l_InList;
        private System.Windows.Forms.Label l_words;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
namespace Bonbon
{
    partial class BonbonOptions
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
            this.cb_RunOnStartup = new System.Windows.Forms.CheckBox();
            this.b_ok = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.clb_monitors = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b_BonbonGithub = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_RunOnStartup
            // 
            this.cb_RunOnStartup.AutoSize = true;
            this.cb_RunOnStartup.Location = new System.Drawing.Point(12, 160);
            this.cb_RunOnStartup.Name = "cb_RunOnStartup";
            this.cb_RunOnStartup.Size = new System.Drawing.Size(96, 17);
            this.cb_RunOnStartup.TabIndex = 0;
            this.cb_RunOnStartup.Text = "Run on startup";
            this.cb_RunOnStartup.UseVisualStyleBackColor = true;
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(143, 300);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 1;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(62, 300);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 2;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // clb_monitors
            // 
            this.clb_monitors.FormattingEnabled = true;
            this.clb_monitors.Location = new System.Drawing.Point(11, 200);
            this.clb_monitors.Name = "clb_monitors";
            this.clb_monitors.Size = new System.Drawing.Size(206, 94);
            this.clb_monitors.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Monitors (check to disable)";
            // 
            // b_BonbonGithub
            // 
            this.b_BonbonGithub.Location = new System.Drawing.Point(11, 106);
            this.b_BonbonGithub.Name = "b_BonbonGithub";
            this.b_BonbonGithub.Size = new System.Drawing.Size(206, 23);
            this.b_BonbonGithub.TabIndex = 5;
            this.b_BonbonGithub.Text = "Visit the Bonbon Github";
            this.b_BonbonGithub.UseVisualStyleBackColor = true;
            this.b_BonbonGithub.Click += new System.EventHandler(this.b_BonbonGithub_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(36, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 46);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft MHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 23);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(111, 36);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bonbon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "v0.01 - by Vinh Nguyen";
            // 
            // BonbonOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 333);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.b_BonbonGithub);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clb_monitors);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_ok);
            this.Controls.Add(this.cb_RunOnStartup);
            this.MaximizeBox = false;
            this.Name = "BonbonOptions";
            this.Text = "Bonbon - Options";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_RunOnStartup;
        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.CheckedListBox clb_monitors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_BonbonGithub;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
namespace LogMyTime
{
    partial class Warn
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
            this.lblGoHome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGoHome
            // 
            this.lblGoHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGoHome.Font = new System.Drawing.Font("Calibri", 124F, System.Drawing.FontStyle.Bold);
            this.lblGoHome.ForeColor = System.Drawing.Color.White;
            this.lblGoHome.Location = new System.Drawing.Point(0, 0);
            this.lblGoHome.Name = "lblGoHome";
            this.lblGoHome.Size = new System.Drawing.Size(284, 261);
            this.lblGoHome.TabIndex = 0;
            this.lblGoHome.Text = "Go Home";
            this.lblGoHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGoHome.Click += new System.EventHandler(this.lblGoHome_Click);
            // 
            // Warn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblGoHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Warn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warn";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Warn_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGoHome;
    }
}
namespace LogMyTime
{
    partial class ConfigurationView
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
            this.ckStartup = new System.Windows.Forms.CheckBox();
            this.ckWarn = new System.Windows.Forms.CheckBox();
            this.ckSubtract = new System.Windows.Forms.CheckBox();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.rbBothPeriods = new System.Windows.Forms.RadioButton();
            this.rbWorkedHours = new System.Windows.Forms.RadioButton();
            this.dtWarn = new System.Windows.Forms.DateTimePicker();
            this.dtSubtract = new System.Windows.Forms.DateTimePicker();
            this.dtCondition = new System.Windows.Forms.DateTimePicker();
            this.lblWorkload = new System.Windows.Forms.Label();
            this.dtWorkload = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtTolerance = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // ckStartup
            // 
            this.ckStartup.AutoSize = true;
            this.ckStartup.Location = new System.Drawing.Point(18, 37);
            this.ckStartup.Name = "ckStartup";
            this.ckStartup.Size = new System.Drawing.Size(154, 21);
            this.ckStartup.TabIndex = 0;
            this.ckStartup.Text = "Start up with Windows";
            this.ckStartup.UseVisualStyleBackColor = true;
            // 
            // ckWarn
            // 
            this.ckWarn.AutoSize = true;
            this.ckWarn.Location = new System.Drawing.Point(18, 189);
            this.ckWarn.Name = "ckWarn";
            this.ckWarn.Size = new System.Drawing.Size(247, 21);
            this.ckWarn.TabIndex = 1;
            this.ckWarn.Text = "Warn when total worked time achieves";
            this.ckWarn.UseVisualStyleBackColor = true;
            // 
            // ckSubtract
            // 
            this.ckSubtract.AutoSize = true;
            this.ckSubtract.Location = new System.Drawing.Point(19, 65);
            this.ckSubtract.Name = "ckSubtract";
            this.ckSubtract.Size = new System.Drawing.Size(75, 21);
            this.ckSubtract.TabIndex = 2;
            this.ckSubtract.Text = "Subtract";
            this.ckSubtract.UseVisualStyleBackColor = true;
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Location = new System.Drawing.Point(54, 95);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(95, 21);
            this.rbDaily.TabIndex = 5;
            this.rbDaily.TabStop = true;
            this.rbDaily.Text = "for each day";
            this.rbDaily.UseVisualStyleBackColor = true;
            // 
            // rbBothPeriods
            // 
            this.rbBothPeriods.AutoSize = true;
            this.rbBothPeriods.Location = new System.Drawing.Point(54, 122);
            this.rbBothPeriods.Name = "rbBothPeriods";
            this.rbBothPeriods.Size = new System.Drawing.Size(266, 21);
            this.rbBothPeriods.TabIndex = 6;
            this.rbBothPeriods.TabStop = true;
            this.rbBothPeriods.Text = "for each day I work morning and afternoon";
            this.rbBothPeriods.UseVisualStyleBackColor = true;
            // 
            // rbWorkedHours
            // 
            this.rbWorkedHours.AutoSize = true;
            this.rbWorkedHours.Location = new System.Drawing.Point(54, 149);
            this.rbWorkedHours.Name = "rbWorkedHours";
            this.rbWorkedHours.Size = new System.Drawing.Size(195, 21);
            this.rbWorkedHours.TabIndex = 7;
            this.rbWorkedHours.TabStop = true;
            this.rbWorkedHours.Text = "for each day I work more than";
            this.rbWorkedHours.UseVisualStyleBackColor = true;
            // 
            // dtWarn
            // 
            this.dtWarn.CustomFormat = "HH:mm";
            this.dtWarn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtWarn.Location = new System.Drawing.Point(271, 187);
            this.dtWarn.Name = "dtWarn";
            this.dtWarn.ShowUpDown = true;
            this.dtWarn.Size = new System.Drawing.Size(86, 24);
            this.dtWarn.TabIndex = 10;
            this.dtWarn.Value = new System.DateTime(2016, 5, 5, 0, 0, 0, 0);
            // 
            // dtSubtract
            // 
            this.dtSubtract.CustomFormat = "HH:mm";
            this.dtSubtract.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSubtract.Location = new System.Drawing.Point(100, 63);
            this.dtSubtract.Name = "dtSubtract";
            this.dtSubtract.ShowUpDown = true;
            this.dtSubtract.Size = new System.Drawing.Size(88, 24);
            this.dtSubtract.TabIndex = 11;
            this.dtSubtract.Value = new System.DateTime(2016, 5, 5, 0, 0, 0, 0);
            // 
            // dtCondition
            // 
            this.dtCondition.CustomFormat = "HH:mm";
            this.dtCondition.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCondition.Location = new System.Drawing.Point(255, 148);
            this.dtCondition.Name = "dtCondition";
            this.dtCondition.ShowUpDown = true;
            this.dtCondition.Size = new System.Drawing.Size(86, 24);
            this.dtCondition.TabIndex = 12;
            this.dtCondition.Value = new System.DateTime(2016, 5, 5, 0, 0, 0, 0);
            // 
            // lblWorkload
            // 
            this.lblWorkload.AutoSize = true;
            this.lblWorkload.Location = new System.Drawing.Point(19, 13);
            this.lblWorkload.Name = "lblWorkload";
            this.lblWorkload.Size = new System.Drawing.Size(121, 17);
            this.lblWorkload.TabIndex = 13;
            this.lblWorkload.Text = "My daily workload is";
            // 
            // dtWorkload
            // 
            this.dtWorkload.CustomFormat = "HH:mm";
            this.dtWorkload.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtWorkload.Location = new System.Drawing.Point(146, 11);
            this.dtWorkload.Name = "dtWorkload";
            this.dtWorkload.ShowUpDown = true;
            this.dtWorkload.Size = new System.Drawing.Size(88, 24);
            this.dtWorkload.TabIndex = 14;
            this.dtWorkload.Value = new System.DateTime(2016, 5, 5, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "with tolerance of ";
            // 
            // dtTolerance
            // 
            this.dtTolerance.CustomFormat = "HH:mm";
            this.dtTolerance.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTolerance.Location = new System.Drawing.Point(349, 11);
            this.dtTolerance.Name = "dtTolerance";
            this.dtTolerance.ShowUpDown = true;
            this.dtTolerance.Size = new System.Drawing.Size(88, 24);
            this.dtTolerance.TabIndex = 16;
            this.dtTolerance.Value = new System.DateTime(2016, 5, 5, 0, 0, 0, 0);
            // 
            // ConfigurationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 222);
            this.Controls.Add(this.dtTolerance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtWorkload);
            this.Controls.Add(this.lblWorkload);
            this.Controls.Add(this.dtCondition);
            this.Controls.Add(this.dtSubtract);
            this.Controls.Add(this.dtWarn);
            this.Controls.Add(this.rbWorkedHours);
            this.Controls.Add(this.rbBothPeriods);
            this.Controls.Add(this.rbDaily);
            this.Controls.Add(this.ckSubtract);
            this.Controls.Add(this.ckWarn);
            this.Controls.Add(this.ckStartup);
            this.Font = new System.Drawing.Font("Calibri", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configuration_FormClosing);
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckStartup;
        private System.Windows.Forms.CheckBox ckWarn;
        private System.Windows.Forms.CheckBox ckSubtract;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbBothPeriods;
        private System.Windows.Forms.RadioButton rbWorkedHours;
        private System.Windows.Forms.DateTimePicker dtWarn;
        private System.Windows.Forms.DateTimePicker dtSubtract;
        private System.Windows.Forms.DateTimePicker dtCondition;
        private System.Windows.Forms.Label lblWorkload;
        private System.Windows.Forms.DateTimePicker dtWorkload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtTolerance;
    }
}
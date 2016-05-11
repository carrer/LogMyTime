using System;

namespace LogMyTime
{
    partial class DateInput
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

        public void setTime(DayInfo d, int f)
        {
            edit = d;
            field = f;
            if (f == 0)
                dtInput.Value = (DateTime)edit.getFirstActivity();
            else
                dtInput.Value = (DateTime)edit.getLastActivity();
        }

        public void callBack()
        {
            if (field == 0)
                edit.setFirstActivity(dtInput.Value.ToString("HH:mm:ss"));
            else
                edit.setLastActivity(dtInput.Value.ToString("HH:mm:ss"));

            ((frmMain)_parent).callbackSetTime(edit);
            Close();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtInput = new System.Windows.Forms.DateTimePicker();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtInput
            // 
            this.dtInput.CustomFormat = "HH:mm:ss";
            this.dtInput.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInput.Location = new System.Drawing.Point(12, 12);
            this.dtInput.Name = "dtInput";
            this.dtInput.ShowUpDown = true;
            this.dtInput.Size = new System.Drawing.Size(77, 23);
            this.dtInput.TabIndex = 0;
            this.dtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtInput_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(95, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // DateInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 47);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dtInput);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DateInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modify entry";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtInput;
        private System.Windows.Forms.Button btnOk;
    }
}
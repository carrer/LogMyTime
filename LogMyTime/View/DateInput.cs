using LogMyTime.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogMyTime
{
    public partial class DateInputView : Form
    {
        public DateInputPresenter Presenter { get; set; }

        public DateInputView(Form p)
        {
            InitializeComponent();
        }

        public DateTime DateField
        {
            set
            {
                dtInput.Value = value;
            }
            get
            {
                return dtInput.Value;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Presenter.OK();
        }

        private void dtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.Focus();
                btnOk_Click(sender, e);
            }
        }
    }
}

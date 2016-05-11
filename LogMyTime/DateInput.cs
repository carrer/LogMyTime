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
    public partial class DateInput : Form
    {
        private Form _parent;
        private DayInfo edit;
        private int field;

        public DateInput(Form p)
        {
            InitializeComponent();
            _parent = p;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            callBack();
        }

        private void dtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk_Click(sender, e);
        }
    }
}

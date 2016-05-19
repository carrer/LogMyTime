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
    public partial class Warn : Form
    {
        public Warn()
        {
            InitializeComponent();
        }

        private void lblGoHome_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Warn_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }
    }
}

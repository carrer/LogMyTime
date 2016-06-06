using LogMyTime.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogMyTime.View
{
    public partial class CommentView : Form
    {
        public CommentPresenter Presenter { get; set; }

        public CommentView()
        {
            InitializeComponent();
        }

        public string Comment
        {
            get
            {
                return txtComment.Text;
            }
            set
            {
                txtComment.Text = value;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Presenter.OK();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Presenter.Clear();
        }

        private void txtComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.Focus();
                btnOk_Click(sender, e);
            }
        }
    }
}

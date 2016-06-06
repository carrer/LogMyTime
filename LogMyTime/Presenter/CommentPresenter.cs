using LogMyTime.Model;
using LogMyTime.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogMyTime.Presenter
{
    public class CommentPresenter
    {
        private CommentModel model;
        private CommentView view;

        public CommentPresenter(CommentModel model, CommentView view)
        {
            this.model = model;
            this.view = view;
            view.Presenter = this;
            view.Comment = model.Comment;
        }

        public void OK()
        {
            if (!model.Comment.Equals(view.Comment))
            {
                model.Comment = view.Comment;
                model.HasChanged = true;
            }
            else
                model.HasChanged = false;

            view.Close();
        }

        public void Clear()
        {
            if (model.Comment.Length > 0)
            {
                model.Comment = "";
                model.HasChanged = true;
            }
            else
                model.HasChanged = false;

            view.Close();
        }

    }
}

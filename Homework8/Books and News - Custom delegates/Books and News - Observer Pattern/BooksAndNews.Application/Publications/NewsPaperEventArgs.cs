using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.BooksAndNews.Application.Publications
{
    internal class NewsPaperEventArgs : EventArgs
    {
        private readonly Newspaper newsPaper;
        public NewsPaperEventArgs(Newspaper newspaper)
        {
            this.newsPaper = newspaper;
        }

        public Newspaper Newspaper => newsPaper;
    }
}

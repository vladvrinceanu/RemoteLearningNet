using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.BooksAndNews.Application.Publications
{
    internal class NewspaperEventArgs : EventArgs
    {
        private readonly Newspaper newsPaper;
        public NewspaperEventArgs(Newspaper newspaper)
        {
            this.newsPaper = newspaper;
        }

        public Newspaper Newspaper => newsPaper;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.BooksAndNews.Application.Publications
{
    public class NewspaperEventArgs : EventArgs
    {
        public Newspaper Newspaper;
        public NewspaperEventArgs(Newspaper newspaper)
        {
            this.Newspaper = newspaper;
        }
    }
}

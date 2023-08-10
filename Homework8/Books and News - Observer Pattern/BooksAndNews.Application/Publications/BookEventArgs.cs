using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.BooksAndNews.Application.Publications
{
    internal class BookEventArgs : EventArgs
    {
        private readonly Book book;

        public BookEventArgs(Book book)
        {
            this.book = book;
        }
        public Book Book => book;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.BooksAndNews.Application.Publications
{
    public class BookEventArgs : EventArgs
    {
        public Book Book;

        public BookEventArgs(Book book)
        {
            this.Book = book;
        }
    }
}

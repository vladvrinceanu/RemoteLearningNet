using iQuest.BooksAndNews.Application.DataAccess;
using iQuest.BooksAndNews.Application.Publications;
using System;
using System.Collections.Generic;

namespace iQuest.BooksAndNews.Application.Publishers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is the class that will publish books and newspapers.
    /// It must offer a mechanism through which different other classes can subscribe ether
    /// to books or to newspaper.
    /// When a book or newspaper is published, the PrintingOffice must notify all the corresponding
    /// subscribers.
    /// </summary>
  
    public class PrintingOffice
    {
        public delegate void BookEventHandler(Book book);
        public delegate void NewspaperEventHandler(Newspaper newspaper);

        public event BookEventHandler BookPublished;
        public event NewspaperEventHandler NewspaperPublished;

        private readonly IBookRepository bookRepository;
        private readonly INewspaperRepository newspaperRepository;
        private readonly ILog log;

        public PrintingOffice(IBookRepository bookRepository, INewspaperRepository newspaperRepository, ILog log)
        {
            this.bookRepository = bookRepository;
            this.newspaperRepository = newspaperRepository;
            this.log = log;
        }
        public void SubsribeToBooks(BookEventHandler handler)
        {
            BookPublished += handler;
        }
        public void UnsubscribeFromBooks(BookEventHandler handler)
        {
            BookPublished -= handler;
        }
        public void SubsribeToNewspapers(NewspaperEventHandler handler)
        {
            NewspaperPublished += handler;
        }
        public void UnsubscribeFromNewspapers(NewspaperEventHandler handler)
        {
            NewspaperPublished -= handler;
        }
        public void PrintRandom(int bookCount, int newspaperCount)
        {
            for (int i = 0; i < bookCount; i++)
            {
                var book = bookRepository.GetRandom();
                log.WriteInfo($"Publishing book: {book.Title}");
                OnBookPublished(book);
            }
            for (int i = 0; i < newspaperCount; i++)
            {
                var newspaper = newspaperRepository.GetRandom();
                log.WriteInfo($"Publishing newspaper: {newspaper.Title}");
                OnPrintedNews(newspaper);
            }
        }
        protected virtual void OnBookPublished(Book book)
        {
            BookPublished?.Invoke(book);
        }
        protected virtual void OnPrintedNews(Newspaper newspaper)
        {
            NewspaperPublished?.Invoke(newspaper);
        }
    }
}
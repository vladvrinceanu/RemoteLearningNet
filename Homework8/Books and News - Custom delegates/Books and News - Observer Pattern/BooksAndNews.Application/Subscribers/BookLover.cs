using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Publishers;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever a book
    /// is printed.
    ///
    /// Subscribe to the printing office and log each book that was printed.
    /// </summary>
    public class BookLover
    {
        private readonly string name;
        private readonly PrintingOffice printingOffice;
        private readonly ILog log;
        public BookLover(string name, PrintingOffice printingOffice, ILog log)
        {
            this.name = name;
            this.printingOffice = printingOffice;
            this.log = log;

            printingOffice.BookPublished += OnBookPublished;
        }

        private void OnBookPublished(Book book)
        {
            log.WriteInfo($"{name} received notification: Book {book.Title}");
        }
    }
}

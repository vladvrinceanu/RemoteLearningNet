using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Publishers;
using System;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever news
    /// are printed.
    ///
    /// Subscribe to the printing office and log each news that was printed.
    /// </summary>
    public class NewsHunter
    {
            private readonly string name;
            private readonly PrintingOffice printingOffice;
            private readonly ILog log;
            public NewsHunter(string name, PrintingOffice printingOffice, ILog log)
            {
                this.name = name;
                this.printingOffice = printingOffice;
                this.log = log;

                printingOffice.NewspaperPublished += OnPrintedNews;
            }

            private void OnPrintedNews(Newspaper newspaper)
            {
                log.WriteInfo($"{name} received printed news: {newspaper.Title}");
            }
    }
}
using System;
using szamonkeres;

namespace szamonkeres
{
    internal class Create
    {
        LibraryResults libraryResults = new LibraryResults();

        public LibraryResults CreateBook(string title, string author, int year, int price)
        {
            try
            {
                using (var context = new librarydbContext())
                {
                    var book = new Books
                    {
                        Title = title,
                        Author = author,
                        Year = year,
                        Price = price
                    };

                    context.Books.Add(book);
                    context.SaveChanges();

                    libraryResults.Message = "Sikeres könyv felvétel";
                    libraryResults.Result = book;

                    return libraryResults;
                }
            }
            catch (Exception ex)
            {
                libraryResults.Message = ex.Message;
                libraryResults.Result = null;

                return libraryResults;
            }
        }
    }
}
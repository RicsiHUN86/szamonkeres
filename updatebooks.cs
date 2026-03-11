using System.Linq;

namespace szamonkeres
{
    internal class Update
    {
        LibraryResults libraryResults = new LibraryResults();

        public LibraryResults UpdateBook(int id, string title, string author, int year, int price)
        {
            using (var context = new librarydbContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Id == id);

                if (book == null)
                {
                    libraryResults.Message = "Nincs ilyen könyv";
                    return libraryResults;
                }

                book.Title = title;
                book.Author = author;
                book.Year = year;
                book.Price = price;

                context.SaveChanges();

                libraryResults.Message = "Sikeres módosítás";
                libraryResults.Result = book;

                return libraryResults;
            }
        }
    }
}
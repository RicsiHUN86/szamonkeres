using System.Linq;

namespace szamonkeres
{
    internal class Delete
    {
        LibraryResults libraryResults = new LibraryResults();

        public LibraryResults DeleteBook(int id)
        {
            using (var context = new librarydbContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Id == id);

                if (book == null)
                {
                    libraryResults.Message = "Nincs ilyen könyv";
                    return libraryResults;
                }

                context.Books.Remove(book);
                context.SaveChanges();

                libraryResults.Message = "Sikeres törlés";
                return libraryResults;
            }
        }

    }
}

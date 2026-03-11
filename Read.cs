using System.Collections.Generic;
using System.Linq;
using szamonkeres;

namespace szamonkeres
{
    internal class Read
    {
        public List<Books> GetBooks()
        {
            using (var context = new librarydbContext())
            {
                return context.Books.ToList();
            }
        }
    }
}
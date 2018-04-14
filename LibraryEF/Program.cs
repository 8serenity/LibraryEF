using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEF
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Reader> readers = new List<Reader>
            {
                new Reader() {Name = "First Reader", IsDebtor=false },
                new Reader() {Name = "Second Reader", IsDebtor=false },
                new Reader() {Name = "Third Reader", IsDebtor=true },
                new Reader() {Name = "Fourth Reader", IsDebtor=false },
                new Reader() {Name = "Fifth Reader", IsDebtor=true }
            };



            List<Book> booksFirstEdition = new List<Book>
            {
                new Book(){ Name = "Atlas Shrugged", Genre="Novel", },
                new Book(){ Name = "Death Note Black Edition", Genre="Mistery" },
                new Book(){ Name = "Les Misérables", Genre="Historical Novel" }
            };


            List<Book> booksSecondEdition = new List<Book>
            {
                new Book(){ Name = "Norwegian Wood", Genre="Novel" },
                new Book(){ Name = "The Art of War", Genre="Treatise" },
                new Book(){ Name = "The Black Swan: The Impact of the Highly Improbable", Genre="Non-fiction" }
            };

            List<Book> booksThirdEdition = new List<Book>
            {
                new Book(){ Name = "The Lion, the Witch and the Wardrobe", Genre="Novel" },
                new Book(){ Name = "The Da Vinci Code", Genre="Mistery" },
                new Book(){ Name = "Birdsong", Genre="General & Literary Fiction" }
            };


            List<Writer> writers = new List<Writer>
            {
                 new Writer(){ Name = "First Author", Surname="First surname", Books=booksFirstEdition },
                 new Writer(){ Name = "Second Author", Surname="Second surname", Books=booksSecondEdition.Union(booksFirstEdition).ToList() },
                 new Writer(){ Name = "Third Author", Surname="Third surname", Books=booksThirdEdition.Union(booksSecondEdition).ToList().Union(booksFirstEdition).ToList() },
            };



            using (var db = new LibraryContext())
            {
                //db.Readers.AddRange(readers);
                //db.Books.AddRange(booksThirdEdition.Union(booksSecondEdition).ToList().Union(booksFirstEdition).ToList());
                //db.Writers.AddRange(writers);
                //var books = db.Books.Where(x => x.Id == 1 || x.Id == 4 || x.Id == 6 || x.Id == 8 || x.Id == 9).Select(x => x);
                //int i = 1;
                //foreach (var book in books)
                //{
                //    book.ReaderId = i++;
                //}

                //First task
                var debtors = db.Readers.Where(x => x.IsDebtor == true).Select(x => x);
                foreach (var debtor in debtors)
                {
                    Console.WriteLine(debtor.Name);
                }

                //Second task
                var authorsOfThirdBook = from writer
                                         in db.Writers
                                         where writer.Books.Any(c => c.Id == 3)
                                         select writer;
                foreach (var writer in authorsOfThirdBook)
                {
                    Console.WriteLine(writer.Name);
                }

                //Выведите список книг, которые доступны в данный момент.

                var availableBooks = db.Books.Where(x => x.ReaderId == null).Select(x => x);
                foreach (var book in availableBooks)
                {
                    Console.WriteLine(book.Name);
                }
                //Вывести список книг, которые на руках у пользователя №2.
                var booksOfSecondReader = db.Books.Where(x => x.ReaderId == 2).Select(x => x);
                foreach (var book in booksOfSecondReader)
                {
                    Console.WriteLine(book.Name);
                }

                // Обнулите задолженности всех должников
                var debtorsToChange = db.Readers.Where(x => x.IsDebtor == true).Select(x => x);
                foreach(var debtor in debtorsToChange)
                {
                    debtor.IsDebtor = false;
                }

                db.SaveChanges();
            }
            Console.Read();
        }
    }
}

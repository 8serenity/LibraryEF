using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEF
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base()
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Reader> Readers { get; set; }
    }
}

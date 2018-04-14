using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEF
{
    public class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public Writer()
        {
            Books = new HashSet<Book>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEF
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDebtor { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}

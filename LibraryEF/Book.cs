using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEF
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        [ForeignKey("Reader")]
        public int? ReaderId { get; set; }
        public Reader Reader { get; set; }
        public virtual ICollection<Writer> Writers { get; set; }
        public Book()
        {
            Writers = new HashSet<Writer>();
        }
    }
}

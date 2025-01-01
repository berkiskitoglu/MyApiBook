using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.EntityLayer.Concrete
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }     
        public List<Book> Books { get; set; }
        public List<Article> Articles { get; set; }
        public List<Quotation> Quotations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.EntityLayer.Concrete
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal OrginalPrice { get; set; }
        public decimal? CurrentPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }  
        public Category Category { get; set; }
        public int AuthorID { get; set; } 
        public Author Author { get; set; }
       
        
       
    }
}

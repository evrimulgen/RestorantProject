using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public int LetterMenuId { get; set; }
        [NotMapped]
        public string LetterMenuName { get; set; }
        public virtual LetterMenu LetterMenu { get; set; }
        public Category()
        { 

        }

    }
}

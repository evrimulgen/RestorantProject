using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class LetterMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categorys { get; set; }
        public LetterMenu()
        {
            
        }
    }
}

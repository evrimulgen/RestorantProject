using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Table
    {
        [Key] 
        public int Number { get; set; }
        public string State { get; set; }
        public List<Waiter> Waiter { get; set; }
        public List<CloseTable> Closes { get; set; }
        public Table()
        {
            Closes = new List<CloseTable>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Order
    {
        [Key] 
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public List<ItemOrder> Items { get; set; }
        public long CloseTableCloseNumber { get; set; }
        public virtual CloseTable CloseTable { get; set; }
    }
}

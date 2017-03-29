using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class CloseTable
    {
        [Key]
        public long CloseNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Order> Orders { get; set; }
        public int TableNumber { get; set; }
        public virtual Table Table { get; set; }

    }
}

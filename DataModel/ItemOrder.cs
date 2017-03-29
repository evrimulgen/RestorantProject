using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ItemOrder
    {
        public int Id { get; set; }
        public Product Prduct { get; set; }
        public int Count { get; set; }
        public int OrderNumber { get; set; }
        public virtual Order Order { get; set; }

    }
}

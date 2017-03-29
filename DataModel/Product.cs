using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategorityId { get; set; }
        public virtual Category Categority { get; set; }
        //public ProductState State { get; set; }
        // [NotMapped]
        //public DateTime SendDate { get; set; }

        public Product()
        {
        }
    }
    //public enum ProductState
    //{
    //    Dispatched,
    //    Soon,
    //    Committed
    //}
}

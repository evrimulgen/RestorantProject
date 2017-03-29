using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext()
            : base("ShDbContext")
        { 
            
        }
        public virtual DbSet<LetterMenu> LetterMenu { get; set; } 
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Waiter> Waiters { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<CloseTable> CloseTable { get; set; } 
    }
}

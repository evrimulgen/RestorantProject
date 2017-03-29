using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public class MocContext : DbContext
    {
        public MocContext()
            : base("ShDbContext")
        { 
            
        }
        public virtual DbSet<Product> Products { get; set; }
    }
}

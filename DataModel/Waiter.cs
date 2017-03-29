using Nancy.Authentication.Forms;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Waiter : IUserIdentity
    {
        [Key] 
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Table> Tablets { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}

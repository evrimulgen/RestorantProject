using DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMarket.Models.ViewModels
{
    public class ViewCategoritys
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public int LetterMenuId { get; set; }

    }
}
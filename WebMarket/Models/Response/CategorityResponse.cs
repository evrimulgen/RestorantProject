using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel;
using WebMarket.Models.ViewModels;
namespace WebMarket.Models.Response
{
    public class CategorityResponse : Response
    {
        public ViewCategoritys Categority { get; set; }
    }
}
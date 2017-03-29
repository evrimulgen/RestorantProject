using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel;
using WebMarket.Models.ViewModels;
namespace WebMarket.Models.Response
{
    public class GetCategorityResponse : Response
    {
        public List<ViewCategoritys> Categoritys { get; set; }
    }
}
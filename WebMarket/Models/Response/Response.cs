using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMarket.Models.Response
{
    public class Response
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Response()
        {
            Code = 0;
        }
    }
}
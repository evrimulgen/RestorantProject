using DataModel;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMarket.Models
{
    public class DatabaseUser : IUserMapper
    {
        public IRepository repostiry { get; set; }
        public DatabaseUser(IRepository repo)
        {
            repostiry = repo;
        }
        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            var w = repostiry.GetUser(identifier);
            if (w == null)
                return null;

            return new Waiter
            {
                UserName = w.UserName,
                Claims = new[]
                {
                    "NewUser",
                    "CanComment"
                }
            };
        }
    }
}
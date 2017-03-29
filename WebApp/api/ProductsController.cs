using DataModel;
using Microsoft.AspNet.SignalR;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApp.Hub;


namespace WebApp.api
{
    public class ProductsController : ApiController
    {
        private IProductRepository _repository;
        private IHubContext _hub;
        public ProductsController()
        {
            _hub = GlobalHost.ConnectionManager.GetHubContext<BugHub>();
        }
        public ProductsController(IProductRepository repository)
        {
            _hub = GlobalHost.ConnectionManager.GetHubContext<BugHub>();
            _repository = repository;
        }
        public IEnumerable<Product> Get()
        {
            var res = _repository.GetProducts();
            return res;
        }
        [Route("api/Products/insert")]
        public bool Insert([FromBody] Product product)
        {
            var bug = _repository.AddProduct(product);
            
            //_hub.Clients.All.moved(bug);
            return true;
        }
        [Route("api/Bugs/working")]
        public Product MoveToWorking([FromBody] int id)
        {
            var bug = _repository.GetProducts().First(b => b.Id == id);
            
            _hub.Clients.All.moved(bug);
            return bug;
        }
        [Route("api/Bugs/done")]
        public Product MoveToDone([FromBody] int id)
        {
            var bug = _repository.GetProducts().First(b => b.Id == id);
           
            _hub.Clients.All.moved(bug);
            return bug;
        }
    }
}
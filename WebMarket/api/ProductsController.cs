using AutoMapper;
using DataModel;
using Microsoft.AspNet.SignalR;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebMarket.Hub;
using WebMarket.Models.Response;
using WebMarket.Models.ViewModels;


namespace WebMarket.api
{
    public class ProductsController : ApiController
    {
        private IRepository _repository;
        private IHubContext _hub;
        public ProductsController()
        {
            _hub = GlobalHost.ConnectionManager.GetHubContext<OrderHub>();
        }
        public ProductsController(IRepository repository)
        {
            _hub = GlobalHost.ConnectionManager.GetHubContext<OrderHub>();
            _repository = repository;
        }
        public IEnumerable<Product> Get()
        {
            var res = _repository.GetProducts();
            return res;
        }
        [Route("api/Products/insert")]
        public Response Insert([FromBody] Product product)
        {
            Response response = new Response();
            try
            {
                var bug = _repository.AddProduct(product);
                response.Code = bug;
                //_hub.Clients.All.moved(bug);
            }
            catch (Exception ex)
            {
                response.Code = 1;
                response.Message = ex.Message;
            }
            return response;

        }
        [Route("api/Products/update")]
        public Response UpdateProduct([FromBody]Product product)
        {
            Response response = new Response();
            try
            {
                int i = _repository.UpdateProduct(product);
                response.Code = i;
            }
            catch (Exception ex)
            {
                response.Code = 1;
                response.Message = ex.Message;
            }

            return response;
        }
        [Route("api/Products/loadProduct")]
        public ProductResponse LoadProduct([FromBody]Category cat)
        {
            ProductResponse response = new ProductResponse();
            try
            {
                var list = _repository.GetProducts(cat);
                if (list != null)
                {
                    Mapper.CreateMap<Product, ViewProducts>();
                    var res = Mapper.Map<List<Product>, List<ViewProducts>>(list.ToList());
                    Mapper.AssertConfigurationIsValid();
                    response.Products = res;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Code = 1;
                response.Message = ex.Message;
            }

            return response;
        }
        [Route("api/Products/GetProduct")]
        public ViewProducts GetProduct(string name, int cat)
        {
            ViewProducts response = new ViewProducts();
            try
            {
                var list = _repository.GetProduct(name, cat);
                if (list != null)
                {
                    Mapper.CreateMap<Product, ViewProducts>();
                    response = Mapper.Map<Product, ViewProducts>(list);

                }
            }
            catch (Exception ex)
            {
                response = null;
            }

            return response;
        }

        [Route("api/Products/send")]
        public Response Send([FromBody] Order order)
        {
            Response response = new Response();
            try
            {
                if (order != null && order.Items != null && order.Items.Count > 0)
                {
                    order.Date = DateTime.Now;
                    //_repository.AddOrder(order);
                    _hub.Clients.All.moved(order);
                }
                else {
                    response.Code = 1;
                    response.Message = "Sin productos para enviar.";
                }
            }
            catch (Exception)
            {
                response.Code = 1;
                response.Message = "No se pudo procesar su solicitud";
            }
            //_hub.Clients.All.moved(bug);
            return response;
        }
        [Route("api/Products/GetLetters")]
        public List<LetterMenu> GetLetters()
        {
            try
            {
                return _repository.GetLettersMenu(); 
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [Route("api/Products/GetTables")]
        public Waiter GetTables(string id)
        {
            return _repository.GetUser(id);
        }
    }
}
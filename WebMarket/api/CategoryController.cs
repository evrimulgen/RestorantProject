using AutoMapper;
using DataModel;
using Microsoft.AspNet.SignalR;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebMarket.Hub;
using WebMarket.Models.Request;
using WebMarket.Models.Response;
using WebMarket.Models.ViewModels;


namespace WebMarket.api
{
    public class CategoryController : ApiController
    {
        private IRepository _repository;
        private IHubContext _hub;
        public CategoryController()
        {
            _hub = GlobalHost.ConnectionManager.GetHubContext<OrderHub>();
        }
        public CategoryController(IRepository repository)
        {
            _hub = GlobalHost.ConnectionManager.GetHubContext<OrderHub>();
            _repository = repository;
        }

        [Route("api/Category/createCategory")]
        public Response CreateCategory([FromBody]Category cat)
        {
            Response response = new Response();
            try
            {
                int l = cat.LetterMenu.Id;
                cat.LetterMenu = null;
              int i = _repository.AddCategority(cat,l);
              response.Code = i;
            }
            catch (Exception ex)
            {
                response.Code = 1;
                response.Message = ex.Message;
            }

            return response;
        }
        [Route("api/Category/updateCategory")]
        public Response UpdateCategory([FromBody]Category cat)
        {
            Response response = new Response();
            try
            {
                int i = _repository.UpdateCategority(cat);
                response.Code = i;
            }
            catch (Exception ex)
            {
                response.Code = 1;
                response.Message = ex.Message;
            }

            return response;
        }
        [Route("api/Category/loadCategory")]
        public GetCategorityResponse LoadCategory([FromBody]LetterMenu menu)
        {
            GetCategorityResponse response = new GetCategorityResponse();
            try
            {
                var list = _repository.GetCategorys(menu.Id);
                string c = list[0].Name;
                if (list != null)
                {
                    Mapper.CreateMap<Category, ViewCategoritys>();
                    var res = Mapper.Map<List<Category>, List<ViewCategoritys>>(list);
                    Mapper.AssertConfigurationIsValid();
                    response.Categoritys = res;
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
        [Route("api/Category/GetCategory")]
        public GetCategorityResponse GetCategory()
        {
            GetCategorityResponse response = new GetCategorityResponse();
            try
            {
                var list = _repository.GetCategorys();
                if (list != null)
                {
                    Mapper.CreateMap<Category, ViewCategoritys>();
                    var res = Mapper.Map<List<Category>, List<ViewCategoritys>>(list);
                    Mapper.AssertConfigurationIsValid();
                    response.Categoritys = res;
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
        [Route("api/Category/GetCategory")]
        public CategorityResponse GetCategory(string Name, int Let)
        {
            CategorityResponse response = new CategorityResponse();
            try
            {
                var cat = _repository.GetCategory(Let, Name);
                if (cat != null)
                {
                    Mapper.CreateMap<Category, ViewCategoritys>();
                    var res = Mapper.Map<Category, ViewCategoritys>(cat);
                    response.Categority = res;
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
        [Route("api/Letter/deleteCategority")]
        public Response DeleteCategority([FromBody]Category cat)
        {
            Response response = new Response();
            try
            {
                int i = _repository.RemoveCategority(cat);
                response.Code = i;
            }
            catch (Exception ex)
            {
                response.Code = 1;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
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
    public class LetterController : ApiController
    {
        private IRepository _repository;
        private IHubContext _hub;
        public LetterController()
        {
            _hub = GlobalHost.ConnectionManager.GetHubContext<OrderHub>();
        }
        public LetterController(IRepository repository)
        {
            _hub = GlobalHost.ConnectionManager.GetHubContext<OrderHub>();
            _repository = repository;
        }

        [Route("api/Letter/createLetter")]
        public Response CreateLetter([FromBody]LetterMenu cat)
        {
            Response response = new Response();
            try
            {
              int i = _repository.AddLetterMenu(cat);
              response.Code = i;
            }
            catch (Exception ex)
            {
                response.Code = 1;
                response.Message = ex.Message;
            }

            return response;
        }
        [Route("api/Letter/deleteLetter")]
        public Response DeleteLetter([FromBody]LetterMenu cat)
        {
            Response response = new Response();
            try
            {
                int i = _repository.RemoveLetter(cat);
                response.Code = i;
            }
            catch (Exception ex)
            {
                response.Code = 1;
                response.Message = ex.Message;
            }

            return response;
        }
        [Route("api/Letter/loadLetter")]
        public GetLetterResponse LoadLetter()
        {
            GetLetterResponse response = new GetLetterResponse();
            try
            {
                var list = _repository.GetLettersMenu();
                if (list != null)
                {
                    response.Letters = list;
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
        [Route("api/Letter/GetLetter")]
        public LetterMenu GetLetter(string Let)
        {
            LetterMenu response = new LetterMenu();
            try
            {
                var cat = _repository.GetLetterMenu(Let);
                if (cat != null)
                {
                    response = cat;
                }

            }
            catch (Exception ex)
            {

            }

            return response;
        }
       
    }
}
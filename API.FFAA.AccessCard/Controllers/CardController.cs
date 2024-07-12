using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FFAA.AccessCard.BO;
using FFAA.AccessCard.Entity;

namespace API.FFAA.AccessCard.Controllers
{
    public class CardController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetInfo(string username)
        {
            CardInfoEntity cardInfo = CardManager.GetInfo(username);

            if (cardInfo == null)
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

            return Request.CreateResponse(HttpStatusCode.OK, cardInfo);
        }
    }
}

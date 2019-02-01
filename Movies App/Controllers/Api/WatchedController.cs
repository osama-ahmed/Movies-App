using Microsoft.AspNet.Identity;
using Movie_App.Models;
using Movies_App.Dto;
using System;
using System.Web.Http;

namespace Movies_App.Controllers.Api
{
    public class WatchedController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Watched(ToWatchListDto dto)
        {
            var userID = User.Identity.GetUserId();
            

            DB db = new DB();
            db.watched(Convert.ToInt32(dto.movieId), userID);

            return Ok();
        }
    }
}

using Microsoft.AspNet.Identity;
using Movie_App.Models;
using Movies_App.Dto;
using Movies_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Movies_App.Controllers.Api
{
    public class ToWatchController : ApiController
    {
        [HttpPost]
        public IHttpActionResult ToWatch(ToWatchListDto dto)
        {
            var userID = User.Identity.GetUserId();
            var toWatchList = new ToWatchList
            {
                userId = userID,
                movieId = Convert.ToInt32(dto.movieId)
            };

            DB db = new DB();
            db.towatch(toWatchList);
            
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Movie> getAll()
        {
            return (Movie.getMovies().ToList());
        }
    }
}
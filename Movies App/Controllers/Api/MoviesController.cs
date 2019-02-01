
using Management_System.Models;
using System.Linq;
using System.Web.Http;

namespace Movies_App.Controllers.Api
{
    public class MoviesController : ApiController
    {
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var movies = Movie.getMovies().AsQueryable();
            Movie movie = movies.FirstOrDefault(m => m.id == id);

            if (movie.deleted)
                return NotFound();

            Movie.deleteMovie(movie);

            return Ok();
        }
    }
}
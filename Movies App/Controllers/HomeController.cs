using Movie_App.Models;
using Movies_App.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Movies_App.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index(int page=1)
        {
            var movies = Movie.getMovies()
                .Where(m => m.deleted != true);

            var pageMovies = movies
                //.Where(m => m.img!="")  //select only movies that have images
                .OrderBy(m => m.year)
                .Reverse()
                .Skip( (page-1)*16 )
                .Take(16)
                .ToList();

            var viewModel = new MovieViewModel
            {
                movies = pageMovies,
                action="Index",
                totalCount=movies.Count()

            };

            /*var towatch = new ToWatchList
            {
                userId = User.Identity.GetUserId(),
                movieId = 60
            };
            DB db = new DB();
            db.towatch(towatch);*/

            return View("Index", viewModel);
        }

    }
}

using Microsoft.AspNet.Identity;
using Movie_App.Models;
using Movies_App.Models;
using Movies_App.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Movies_App.Controllers
{
    [Authorize]
	public class MoviesController : Controller
	{
		[Authorize]
		public ActionResult Create()
		{
			var viewModel = new MovieFormViewModel
			{
				types = MovieType.getTypes(),
				languages=MovieLanguage.getLanguages(),
				Watched = MovieWatched.getWatched()
			};

			return View(viewModel);
		}

		[Authorize]
		[HttpPost]
		public ActionResult Create(Movie movie)
		{
			/*if(!ModelState.IsValid)
			{
				return View();
			}*/

			var userId = User.Identity.GetUserId();
			movie.userId = userId;

			Movie.addMovie(movie);

			return RedirectToAction("Index", "Home");
		}

		[Authorize]
		public ActionResult Edit(int id)
		{
			IQueryable<Movie> movies = Movie.getMovies().AsQueryable();
			Movie movie = movies.FirstOrDefault(m => m.id == id);

			var viewModel = new MovieFormViewModel
			{
				movie=movie,
				types = MovieType.getTypes(),
				languages = MovieLanguage.getLanguages(),
				Watched=MovieWatched.getWatched()
			};

			return View("Create", viewModel);
		}

		[Authorize]
		[HttpPost]
		public ActionResult Edit(Movie movie)
		{
			/*if(!ModelState.IsValid)
			{
				return View();
			}*/

			Movie.updateMovie(movie);

			return RedirectToAction("Index","Home");
		}

		public ActionResult Details(int id)
		{
			var movies=Movie.getMovies().AsQueryable();
			Movie movie=movies.FirstOrDefault(m => m.id==id);

			return View(movie);
		}

		public ActionResult Search(string searchTerm)
		{
			var movies = Movie.getMovies();
			movies = movies
				.Where(m => m.name.ToLower().Contains(searchTerm.ToLower()) ||
					m.year.ToString() == searchTerm)
				.Where(m => m.deleted!=true)
				.OrderBy(m => m.year)
				.Reverse()
				.ToList();

			var viewModel = new MovieViewModel
			{
				movies = movies,
				searchTerm = searchTerm,
				action="Search"
			};

			return View("Index", viewModel);
		}

		public ActionResult Import()
		{
			MyExcel.DB_PATH = @"D:\output\My projects\ASP.NET\Management System v2\Movies App\Movies App\App_Data\movies.xlsx";
			MyExcel.InitializeExcel();
			List<Movie> excelMovies = MyExcel.ReadMyExcel().ToList();

			foreach (var movie in excelMovies)
			{
				Movie.addMovie(movie);
			}

			MyExcel.CloseExcel();

			return View(excelMovies);
		}

		public ActionResult Export()
		{
			MyExcel.DB_PATH = @"D:\output\My projects\ASP.NET\Management System v2\Movies App\Movies App\App_Data\movies_export.xlsx";
			MyExcel.InitializeExcel();
			var movies = Movie.getMovies().ToList();

			foreach(var movie in movies)
			{
				MyExcel.WriteToExcel(movie);
			}

			MyExcel.CloseExcel();

			return View();
		}

		public ActionResult MoviesReport()
		{
			var movies = Movie.getMovies();
			movies = movies
				.Where(m => m.deleted != true)
				.OrderBy(m => m.year)
				.Reverse()
				.ToList();

			var viewModel = new MovieViewModel
			{
				movies = movies,
				action="MoviesReport"
			};

			return View(viewModel);
		}

		public ActionResult ToWatch()
		{
			var toWatchMovies = Movie.getToWatch().ToList();
			var movies = Movie.getMovies().ToList();
			List<Movie> result = new List<Movie>();

			foreach(var movie in movies)
			{
				foreach(var toWatchMovie in toWatchMovies)
				{
					if (movie.id == toWatchMovie.movieId)
						result.Add(movie);
				}
			}

			var viewModel = new MovieViewModel
			{
				movies = result
				.OrderBy(m => m.year)
				.Reverse(),
				action="ToWatch"
			};

			return View("Index", viewModel);
		}

		public ActionResult Watched()
		{
			var movies = Movie.getMovies()
				.Where(m => m.watched==true)
				.OrderBy(m => m.year)
				.Reverse()
				.ToList();

			var viewModel = new MovieViewModel
			{
				movies = movies,
				action="Watched"
			};

			return View("Index", viewModel);
		}
	}
}
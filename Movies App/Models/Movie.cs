using Movies_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_App.Models
{
    public class Movie
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public int? year { get; set; }

        public string type { get; set; }

        public bool watched { get; set; }

        public string img { get; set; }

        public string language { get; set; }

        public bool deleted { get; set; }

        public string userId { get; set; }

        public static DB db;

        public Movie()
        {
            db = new DB();
        }

        public static List<Movie> getMovies()
        {
            List<Movie> movies = new List<Movie>();
            db = new DB();

            movies=db.getAll();

            return movies;
        }

        public static int addMovie(Movie m)
        {
            int success = db.add(m);
            return success;
        }

        public static int updateMovie(Movie m)
        {
            int success = db.update(m);
            return success;
        }

        public static int deleteMovie(Movie m)
        {
            int success = db.delete(m);
            return success;
        }

        public static List<ToWatchList> getToWatch()
        {
            return db.getToWatch();
        }
    }
}

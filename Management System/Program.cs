using Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            
           // List<Movie> movies=Movie.getMovies();

            /*foreach(Movie movie in movies)
            {
                Console.WriteLine("Movie Name: {0}, Year: {1}",movie.name, movie.year);
            }*/

            /*Movie m = new Movie();
            m.name = "ahmed";
            m.year = 2000;
            m.type = "series";
            Movie.addMovie(m);*/

            /*movies[0].name = "aref";
            Movie.updateMovie(movies[0]);*/

            //Movie.deleteMovie( movies.Single(m => m.id==9 ) );
        }
    }
}

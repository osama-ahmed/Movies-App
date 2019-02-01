using Movie_App.Models;
using Movies_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies_App.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie movie { get; set; }
        public List<MovieType> types { get; set; }
        public List<MovieLanguage> languages { get; set; }

        public List<MovieWatched> Watched { get; set;}
    }
}
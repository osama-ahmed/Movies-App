using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies_App.Models
{
    public class MovieWatched
    {
        public string name { get; set; }
        public bool value { get; set; }

        public static List<MovieWatched> getWatched()
        {
            List<MovieWatched> Watched = new List<MovieWatched>();

            Watched.Add(new MovieWatched { name = "Yes", value=true });
            Watched.Add(new MovieWatched { name = "No", value = false });

            return Watched;
        }
    }
}
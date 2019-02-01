using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies_App.Models
{
    public class MovieType
    {
        public string name { get; set; }

        public static List<MovieType> getTypes()
        {
            List<MovieType> types = new List<MovieType>();

            types.Add(new MovieType { name = "Movie" });
            types.Add(new MovieType { name = "Series" });

            return types;
        }
    }
}
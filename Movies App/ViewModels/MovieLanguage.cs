using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies_App.Models
{
    public class MovieLanguage
    {
        public string name { get; set; }

        public static List<MovieLanguage> getLanguages()
        {
            List<MovieLanguage> languages = new List<MovieLanguage>();

            languages.Add(new MovieLanguage { name = "English" });
            languages.Add(new MovieLanguage { name = "Arabic" });

            return languages;
        }
    }
}
using Movie_App.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movies_App.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<Movie> movies { get; set; }

        [Required(ErrorMessage = "No data entered")]
        public string searchTerm { get; set; }

        public string action { get; set; }

        public int totalCount { get; set; }
    }
}
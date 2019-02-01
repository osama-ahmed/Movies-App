using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies_App.Models
{
    public class ToWatchList
    {
        public string userId { get; set; }

        public int movieId { get; set; }
    }
}
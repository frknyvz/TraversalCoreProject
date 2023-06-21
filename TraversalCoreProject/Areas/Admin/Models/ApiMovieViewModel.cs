using System;

namespace TraversalCoreProject.Areas.Admin.Models
{
    public class ApiMovieViewModel
    {
        public int rank { get; set; }
        public string title { get; set; }
        public string rating { get; set; }
        public int year { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string trailer { get; set; }
    }
}

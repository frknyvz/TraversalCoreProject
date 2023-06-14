using System;

namespace TraversalCoreProject.Areas.Admin.Models
{
    public class AnnouncementListViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}

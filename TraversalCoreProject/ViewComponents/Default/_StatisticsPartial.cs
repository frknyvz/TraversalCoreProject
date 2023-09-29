using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _StatisticsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.v1 = c.Destinations.Count();
            ViewBag.v2 = c.Guides.Count();
            ViewBag.v3 = "285";
            ViewBag.v4 = c.Reservations.Where(x => x.Status == "Onaylandı").Count();
            return View();
        }
    }
}

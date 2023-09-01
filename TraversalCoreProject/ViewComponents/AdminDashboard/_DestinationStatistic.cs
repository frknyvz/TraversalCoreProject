using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.ViewComponents.AdminDashboard
{
    public class _DestinationStatistic : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly Context _context;

        public _DestinationStatistic(IDestinationService destinationService, Context context)
        {
            _destinationService = destinationService;
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetList();
            ViewBag.totalPrice = _context.Destinations.Sum(x => x.Price);
            return View(values);
        }
    }
}

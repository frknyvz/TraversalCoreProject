using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.AdminDashboard
{
    public class _DestinationTable : ViewComponent
    {
        private readonly IReservationService _reservationService;

        public _DestinationTable(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _reservationService.GetListReservationWithUserDestination(id);
            return View(values);
        }
    }
}

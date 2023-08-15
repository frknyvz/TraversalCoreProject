using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProject.ViewComponents.MemberDashboard
{
    public class _MemberStatistic : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());

        Context c = new Context();

        public _MemberStatistic(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.routeCount = c.Destinations.Count();
            ViewBag.guideCount = c.Guides.Count();
            ViewBag.visitorCount = c.Testimonials.Count();
        
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            var valuesActiveList = reservationManager.GetListWithReservationByAccepted(values.Id);
            ViewBag.activeRes = valuesActiveList.Count();

            var valuesOldList = reservationManager.GetListWithReservationByPrevious(values.Id);
            ViewBag.oldRes = valuesOldList.Count();

            var valuesWaitingList = reservationManager.GetListWithReservationByWaitApproval(values.Id);
            ViewBag.waitingRes = valuesWaitingList.Count();

            ViewBag.userImage = values.ImageUrl;
            ViewBag.failedCount = values.AccessFailedCount;
            return View();
        }
    }
}

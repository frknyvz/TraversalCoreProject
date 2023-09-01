using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TraversalCoreProject.ViewComponents.AdminDashboard
{
    public class _Cards2Statistics : ViewComponent
    {
        private readonly Context _context;

        public _Cards2Statistics(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                bool acikMi = command.Connection.State == System.Data.ConnectionState.Open;
                if (!acikMi) command.Connection.Open();
                try
                {
                    command.CommandText = "SELECT sum(Price) FROM Destinations AS dest JOIN Reservations AS res ON dest.DestinationID = res.DestinationID WHERE res.Status = 'Onaylandı'";
                    var topKazanc = (double)command.ExecuteScalar();
                    ViewBag.v3 = topKazanc;
                    ViewBag.v1 = _context.Guides.Count();
                    ViewBag.v2 = _context.Comments.Count();
                    return View();
                }
                finally
                {
                    if (!acikMi) command.Connection.Close();
                }
            }
        }
    }
}

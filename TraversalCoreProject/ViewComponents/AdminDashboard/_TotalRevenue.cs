using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TraversalCoreProject.ViewComponents.AdminDashboard
{
    public class _TotalRevenue : ViewComponent
    {
        private readonly Context _context;

        public _TotalRevenue(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                bool acikMi = command.Connection.State == System.Data.ConnectionState.Open;
                if(!acikMi) command.Connection.Open();
                try
                {
                    command.CommandText = "SELECT sum(Price) FROM Destinations AS dest JOIN Reservations AS res ON dest.DestinationID = res.DestinationID WHERE res.Status = 'Onaylandı'";
                    var topKazanc = (double)command.ExecuteScalar();
                    ViewBag.v1 = topKazanc;
                    return View();
                }
                finally
                {
                    if(!acikMi) command.Connection.Close();
                }           

            }
        }
    }
}

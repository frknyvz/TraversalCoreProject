using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;

        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateDestinationCommand command)
        {
            _context.Destinations.Add(new EntityLayer.Concrete.Destination
            {
                City= command.City,
                DayNight = command.DayNight,
                Price= command.Price,
                Capacity= command.Capacity,
                Status= true
            });
            _context.SaveChanges();
        }
    }
}

using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using PresentationLayer.CQRS.Commands.DestinationCommands;

namespace PresentationLayer.CQRS.Handlers.DestinationHandlers
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
            _context.Destinations.Add(new Destination
            {
                City = command.City,
                DayNight = command.City,
                Price = command.Price,
                Capacity = command.Capacity,
                Status = command.Status
            });
            _context.SaveChanges();
        }
    }
}

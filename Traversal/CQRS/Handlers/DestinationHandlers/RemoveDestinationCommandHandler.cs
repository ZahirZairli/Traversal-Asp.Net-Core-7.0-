using DataAccessLayer.Concrete;
using PresentationLayer.CQRS.Commands.DestinationCommands;

namespace PresentationLayer.CQRS.Handlers.DestinationHandlers
{
    public class RemoveDestinationCommandHandler
    {
        private readonly Context _context;

        public RemoveDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(RemoveDestinationCommand command)
        {
            var value = _context.Destinations.Find(command.DestinationId);
            _context.Destinations.Remove(value);
            _context.SaveChanges();
        }
    }
}

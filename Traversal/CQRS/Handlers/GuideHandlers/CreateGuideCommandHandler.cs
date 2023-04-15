using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using PresentationLayer.CQRS.Commands.GuideCommands;

namespace PresentationLayer.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                FullName = request.FullName,
                Description = request.Description
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

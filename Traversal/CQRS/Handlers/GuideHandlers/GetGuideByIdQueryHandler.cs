using DataAccessLayer.Concrete;
using MediatR;
using PresentationLayer.CQRS.Queries.GuideQueries;
using PresentationLayer.CQRS.Results.GuideResults;

namespace PresentationLayer.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIdQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIdQueryResult
            {
                GuideId = value.GuideId,
                FullName = value.FullName,
                Description = value.Description
            };
        }
    }
}

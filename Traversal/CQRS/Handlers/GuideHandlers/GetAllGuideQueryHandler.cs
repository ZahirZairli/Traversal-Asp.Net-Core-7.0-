using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.CQRS.Queries.GuideQueries;
using PresentationLayer.CQRS.Results.GuideResults;

namespace PresentationLayer.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandler:IRequestHandler<GetAllGuideQuery,List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                GuideId = x.GuideId,
                FullName = x.FullName,
                Image = x.Image,
                Description = x.Description
            }).AsNoTracking().ToListAsync();
        }
    }
}

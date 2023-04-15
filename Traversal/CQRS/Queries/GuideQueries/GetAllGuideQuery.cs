using MediatR;
using PresentationLayer.CQRS.Results.GuideResults;

namespace PresentationLayer.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {
    }
}

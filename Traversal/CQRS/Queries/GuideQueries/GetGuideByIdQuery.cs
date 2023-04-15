using MediatR;
using PresentationLayer.CQRS.Results.GuideResults;

namespace PresentationLayer.CQRS.Queries.GuideQueries
{
    public class GetGuideByIdQuery: IRequest<GetGuideByIdQueryResult>
    {
        public GetGuideByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}

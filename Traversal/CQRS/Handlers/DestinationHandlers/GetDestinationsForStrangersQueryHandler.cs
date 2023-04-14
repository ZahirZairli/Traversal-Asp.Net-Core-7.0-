using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.CQRS.Queries.DestinationQueries;
using PresentationLayer.CQRS.Results.DestinationResults;

namespace PresentationLayer.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationsForStrangersQueryHandler
    {
        private readonly Context _context;

        public GetDestinationsForStrangersQueryHandler(Context context)
        {
            _context = context;
        }
        //GetDestinationsForStrangersQuery query
        public List<GetDestinationsForStrangersQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetDestinationsForStrangersQueryResult
            {
                DestinationId = x.DestinationId,
                Capacity = x.Capacity,
                City = x.City,
                DayNight = x.DayNight,
                Price = x.Price
            }).AsNoTracking().ToList();
            return values;
            //AsNotTracking nedir: EntityFrameWorkde entitylerde deyisikliklerin olub olmadiqi her zaman yoxlanilir,buna
            //gorede bezen suret zeiflemesi ola biler.
            //AsNoTrackingde biz listeleme metodumuzda entitlerde deyisiklikler olmayacaqindan izlenmesini dayandiririq
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _destinationDal;
        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }
        public void TAdd(Destination t)
        {
            _destinationDal.Insert(t);
        }

        public void TDelete(Destination t)
        {
            _destinationDal.Delete(t);
        }

        public Destination TGetById(int id)
        {
            return _destinationDal.GetById(id);
        }

        public Destination TGetByIdWithGuide(int id)
        {
            return _destinationDal.GetByIdWithGuide(id);
        }

        public List<Destination> TGetList()
        {
            return _destinationDal.GetListAll();
        }

        public List<Destination> TGetListFilter(Expression<Func<Destination, bool>> filter)
        {
            return _destinationDal.ListCondition(filter);
        }

        public void TUpdate(Destination t)
        {
            _destinationDal.Update(t);
        }
    }
}

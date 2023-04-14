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
    public class ReservatioManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservatioManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public List<Reservation> TGetReservationsByUserActive(int id)
        {
            return _reservationDal.GetReservationsByUserActive(id);
        }

        public List<Reservation> TGetReservationsByUserApproval(int id)
        {
           return _reservationDal.GetReservationsByUserApproval(id);
        }

        public List<Reservation> TGetReservationsByUserPassive(int id)
        {
            return _reservationDal.GetReservationsByUserPassive(id);
        }

        public void TAdd(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public Reservation TGetById(int id)
        {
            return _reservationDal.GetById(id);
        }

        public List<Reservation> TGetList()
        {
            return _reservationDal.GetListAll();
        }

        public List<Reservation> TGetListFilter(Expression<Func<Reservation, bool>> filter)
        {
            return _reservationDal.ListCondition(filter);
        }
        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> GetReservationsByUserActive(int id);
        List<Reservation> GetReservationsByUserPassive(int id);
        List<Reservation> GetReservationsByUserApproval(int id);
    }
}

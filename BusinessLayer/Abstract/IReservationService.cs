using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        List<Reservation> TGetReservationsByUserActive(int id);
        List<Reservation> TGetReservationsByUserApproval(int id);
        List<Reservation> TGetReservationsByUserPassive(int id);
    }
}

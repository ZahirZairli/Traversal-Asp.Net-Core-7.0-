using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetReservationsByUserActive(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x=>x.Destination).Where(x=> x.AppUserId == id && x.Status == "Rezervasiya təsdiqləndi").OrderByDescending(x=>x.ReservationId).ToList();
            }
        }

        public List<Reservation> GetReservationsByUserApproval(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.AppUserId == id && x.Status == "Rezervasiya təsdiq gözləyir").OrderByDescending(x => x.ReservationId).ToList();
            }
        }

        public List<Reservation> GetReservationsByUserPassive(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.AppUserId == id && x.Status == "Rezervasiya bitdi").OrderByDescending(x => x.ReservationId).ToList();
            }
        }
    }
}

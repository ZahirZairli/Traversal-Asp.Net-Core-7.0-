using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public string Description { get; set; } = "Traversal detail";
        public double Price { get; set; }
        public string Image { get; set; } = "user.png";
        public string CoverImage { get; set; } = "user.png";
        public string Details1 { get; set; } = "Traversal detail";
        public string Details2 { get; set; } = "Traversal detail";
        public string Image2 { get; set; } = "user.png";
        public DateTime Date { get; set; } = DateTime.Now;
        public int Capacity { get; set; }
        public bool Status { get; set; } = true;
        public int GuideId { get; set; }
        public Guide Guide{ get; set; }
        public List<Comment> Comments { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}

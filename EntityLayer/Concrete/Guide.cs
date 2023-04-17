using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Guide
    {
        [Key]
        public int GuideId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } = "user.png";
        public string TwitterUrl { get; set; } = "user.png";
        public string InstagramUrl { get; set; } = "user.png";
        public bool Status { get; set; } = true;
        public List<Destination> Destinations;
    }
}

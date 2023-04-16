using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content{ get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser{ get; set; }


    }
}

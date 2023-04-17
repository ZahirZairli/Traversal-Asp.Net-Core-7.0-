using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContactUs
    {
        [Key]
        public int ContactUsId{ get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime MessageDate { get; set; } = DateTime.Now;
    }
}

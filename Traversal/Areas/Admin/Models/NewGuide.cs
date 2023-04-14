using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Areas.Admin.Models
{
    public class NewGuide
    {
        [Required(ErrorMessage ="Zəhmət olmasa bu hissəni doldurun")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa bu hissəni doldurun")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa bu hissəni doldurun")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa bu hissəni doldurun")]
        public string TwitterUrl { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa bu hissəni doldurun")]
        public string InstagramUrl { get; set; }
    }
}

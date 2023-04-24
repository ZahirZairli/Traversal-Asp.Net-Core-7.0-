using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Zəhmət olmasa bu hissənidoldurun!")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Zəhmət olmasa bu hissənidoldurun!")]
        [Compare("ConfirmPassword",ErrorMessage ="Şifrələr eyni deyil")]
        public string ConfirmPassword { get; set; }
        public string userId { get; set; }
        public string token { get; set; }
    }
}

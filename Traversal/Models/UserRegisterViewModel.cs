
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage="Zəhmət olmasa adınızı daxil edin")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa soy adınızı daxil edin")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa istifadəçi adınızı daxil edin")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa emailinizi daxil edin")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa telefon nömrənizi daxil edin")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa şifrənizi daxil edin")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Şifrələr eyni deyil")]
        public string ConfirmPassword { get; set; }
    }
}

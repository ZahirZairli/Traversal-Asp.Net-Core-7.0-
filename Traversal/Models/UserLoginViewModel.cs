
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Zəhmət olmasa istifadəçi adınızı daxil edin")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa şifrənizi daxil edin")]
        public string UserPassword { get; set; }
    }
}

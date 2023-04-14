using Microsoft.AspNetCore.Identity;

namespace PresentationLayer.Models
{
	public class CustomIdentityValidator : IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Şifrə minimum {length} sayda simvoldan ibarət olmalıdır"
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Şifrədə ən azı 1 simvol olmaldır"
			};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = "Şifrədə ən az 1 böyük hərf olmalıdır"
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = "Şifrədə ən az 1 kiçik hərf olmalıdır",
			};
		}
		public override IdentityError DuplicateUserName(string userName)
		{
			return new IdentityError()
			{
				Code = "DuplicateUserName",
				Description = $"Daxil etdiyiniz istifadəçi adı({userName}) sistemdə mövcuddur.Zəhmət olmasa fərqli bir istifadəçi adı daxil edin."
			};
		}
		public override IdentityError InvalidEmail(string? email)
		{
			return new IdentityError()
			{
				Code = "InvalidEmail",
				Description = $"Daxil etdiyiniz istifadəçi maili({email}) keçərsizdir.Zəhmət olmasa fərqli bir mail daxil edin."
			};
		}
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresDigit",
				Description = "Şifrədə ən az 1 rəqəm olmalıdır"
			};
		}
	}
}

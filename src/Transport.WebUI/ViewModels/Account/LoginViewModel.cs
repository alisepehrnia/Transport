using System.ComponentModel.DataAnnotations;

namespace Trasnsport.WebUI.ViewModels.Account
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "ایمیل را وارد کنید")]
		[Display(Name = "ایمیل")]
		[EmailAddress(ErrorMessage = "ایمیل را به درستی وارد کنید")]
		public string Email { get; set; }

		[Required(ErrorMessage = "رمز عبور را وارد کنید")]
		[DataType(DataType.Password)]
		[Display(Name = "رمز عبور")]
		public string Password { get; set; }

		[Display(Name = "من را به خاطر بسپار")]
		public bool RememberMe { get; set; }
	}
}

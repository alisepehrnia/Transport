using System.ComponentModel.DataAnnotations;

namespace Trasnsport.WebUI.ViewModels.Account
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "نام‌کاربری را پر کنید")]
		[Display(Name = "نام‌کاربری")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "رمز عبور را پر کنید")]
		[DataType(DataType.Password)]
		[Display(Name = "رمز عبور")]
		public string Password { get; set; }

		[Display(Name = "من را به خاطر بسپار")]
		public bool RememberMe { get; set; }
	}
}

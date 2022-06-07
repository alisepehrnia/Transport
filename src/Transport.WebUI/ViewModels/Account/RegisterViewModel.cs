using System.ComponentModel.DataAnnotations;

namespace Trasnsport.WebUI.ViewModels.Account
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "ایمیل را وارد کنید")]
		[EmailAddress]
		[Display(Name = "ایمیل")]
		public string Email { get; set; }

		[Required(ErrorMessage = "رمز عبور را وارد کنید")]
		[StringLength(100, ErrorMessage = "{0} باید حداقل {2} حرف داشته باشد", MinimumLength = 8)]
		[DataType(DataType.Password,ErrorMessage = "خطا در رمز عبور")]
		[Display(Name = "رمز عبور")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "تاییدیه رمز عبور")]
		[Compare(nameof(Password), ErrorMessage = "رمز عبور و تاییدیه آن با هم همخوانی ندارد.")]
		public string ConfirmPassword { get; set; }
	}
}

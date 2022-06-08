using System.ComponentModel.DataAnnotations;

namespace Trasnsport.WebUI.ViewModels.Account
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "نام‌کاربری را پر کنید")]
		[Display(Name = "نام‌کاربری")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "رمز عبور را پر کنید")]
		[StringLength(100, ErrorMessage = "{0} باید حداقل {2} حرف داشته باشد", MinimumLength = 8)]
		[DataType(DataType.Password, ErrorMessage = "خطا در رمز عبور")]
		[Display(Name = "رمز عبور")]
		public string Password { get; set; }

		[Required(ErrorMessage = "تاییدیه رمز عبور را پر کنید")]
		[DataType(DataType.Password)]
		[Display(Name = "تاییدیه رمز عبور")]
		[Compare(nameof(Password), ErrorMessage = "رمز عبور و تاییدیه آن با هم همخوانی ندارد.")]
		public string ConfirmPassword { get; set; }
	}
}

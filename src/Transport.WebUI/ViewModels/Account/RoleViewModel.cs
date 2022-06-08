using System.ComponentModel.DataAnnotations;

namespace Trasnsport.WebUI.ViewModels.Account
{
	public class RoleViewModel
{
		public string Id { get; set; }

		[Required(ErrorMessage = "نقش را پر کنید")]
		[Display(Name = "نقش")]
		public string Name { get; set; }

		[Required(ErrorMessage = "سطح را پر کنید")]
		[Display(Name = "سطح")]
		public int Level { get; set; }
	}
}
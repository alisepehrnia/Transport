using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Trasnsport.WebUI.Startup))]
namespace Trasnsport.WebUI
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}

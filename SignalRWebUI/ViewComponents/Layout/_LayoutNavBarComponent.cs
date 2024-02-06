using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.Layout
{
	public class _LayoutNavBarComponent :ViewComponent
	{

		public IViewComponentResult Invoke()
		{
				return View();
		}
	}
}

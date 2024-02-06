using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.Layout
{
	public class _LayoutSideBarComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

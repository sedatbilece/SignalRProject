using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.Layout
{
    public class _LayoutHeaderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

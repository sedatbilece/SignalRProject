using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult BookTable()
        {
            return View();
        }
    }
}

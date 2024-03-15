using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using QRCoder;
using System.Drawing.Imaging;
using System.Drawing;

namespace SignalRWebUI.Controllers
{
	public class QrCodeController : Controller
	{


		[HttpGet]
		public IActionResult Index()
		{

			return View();
		}


		[HttpPost]
		public IActionResult Index(string value)
		{


			using (MemoryStream memoryStream = new MemoryStream())
			{
				QRCodeGenerator createQRCode = new QRCodeGenerator();
				QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
				using (Bitmap image = squareCode.GetGraphic(10))
				{
					image.Save(memoryStream, ImageFormat.Png);
					ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
				}
			}
			return View();
		}
	}
}

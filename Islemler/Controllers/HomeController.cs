using Islemler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Islemler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Islemler()
        {
            OprtYukle();

            return View();
        }

        private void OprtYukle()
        {
            List<string> o = new List<string>();
            o.Add("+");
            o.Add("-");
            o.Add("x");
            o.Add("÷");

            SelectList sl = new SelectList(o, "+");

            ViewBag.operatorListesi = sl;
        }

        [HttpGet]
        public IActionResult IslemlerGET(double txtSayi1, string oprt, double txtSayi2)
        {
            double sonuc = 0;

            switch (oprt)
            {
                case "+":
                    sonuc = txtSayi1+txtSayi2;
                    break;
                case "-":
                    sonuc = txtSayi1 - txtSayi2;
                    break;
                case "x":
                    sonuc = txtSayi1 * txtSayi2;
                    break;
                case "÷":
                    sonuc = txtSayi1 / txtSayi2;
                    break;
                default:
                    break;
            }

            ViewBag.Sonuc = sonuc;
            OprtYukle();

            return View("Islemler");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

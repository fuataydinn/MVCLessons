using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCIntro.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCIntro.Controllers
{
    //MVC (Model View Controller) 
    //MVC bir design pattern 
    //Model => Arayuze gönderilen data,nesne
    //View => HTML,CSS, JS (Frontend) 
    //Controller => Backend kodlama yapılan yer 
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
        
        public IActionResult ShowDate()
        {
            //Model => data
            //Response'ta dondurdugumuz veya Request'te karsıladıgımız verilere Model diyebiliriz.
            var now = DateTime.Now;

            //MVC'nin adında her ne kadar sabit V(View) olsa da
            //her Request'in karsılıgı View olmak zorunda degil

            //Controller'da yer alan Content metodu ile yalnızca basit string tipte bir veriyi Response edebilirim.
            return Content(now.ToString()); 
        }
        //Action
        public IActionResult AnaSayfa()
        {
            return View("Views/Home/Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

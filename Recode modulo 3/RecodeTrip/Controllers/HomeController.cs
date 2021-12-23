using Microsoft.AspNetCore.Mvc;

namespace RecodeTrip.Models{
    public class HomeController: Controller{
        
         public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }
    }
}
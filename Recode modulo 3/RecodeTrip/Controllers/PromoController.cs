using Microsoft.AspNetCore.Mvc;

namespace RecodeTrip.Models{
    public class PromoController: Controller{
        
         public IActionResult Index()
        {
            return View();
        }

    }
}
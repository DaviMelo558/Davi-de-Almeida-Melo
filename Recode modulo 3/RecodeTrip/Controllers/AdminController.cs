using Microsoft.AspNetCore.Mvc;

namespace RecodeTrip.Controllers
{
    public class AdminController:Controller
    {
         public IActionResult Index()
        {
            return View();
        }
    }
}
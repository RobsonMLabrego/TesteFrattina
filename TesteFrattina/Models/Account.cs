using Microsoft.AspNetCore.Mvc;

namespace TesteFrattina.Models
{
    public class Account : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

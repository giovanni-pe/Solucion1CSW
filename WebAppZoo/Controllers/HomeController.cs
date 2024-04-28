using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppZoo.Services;
using WebAppZoo.Models;
namespace WebAppZoo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiService _apisevice;

        public HomeController(ApiService apisevice)
        {
           _apisevice= apisevice;
        }

        public async Task<IActionResult> Index()
        {
            List<Animal> Animals = await _apisevice.All();
            return View(Animals);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

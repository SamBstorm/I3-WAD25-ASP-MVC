using Demo_ASP_MVC_01.Models.Demo;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP_MVC_01.Controllers
{
    public class DemoController : Controller
    {
        [ViewData]
        public string[] Demos { get { return _demos; } }

        private readonly string[] _demos = [
            "Demo01",
            "Demo02",
            "SuccessLogin",
            "FailedLogin"
            ];
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Demo01()
        {
            ViewBag.Subtitle = "Utilisation du ViewBag";
            return View();
        }
        public IActionResult Demo02(int nbCol = 8, int nbRow = 8)
        {
            Demo02ViewModel model = new Demo02ViewModel() { 
                Title = "Démonstration avec un modèle de vue",
                PictureURL = @"https://cdn.pixabay.com/photo/2018/08/18/13/26/interface-3614766_1280.png",
                UserOptions = ["Option 1", "Option 2", "Option 3"],
                NbCol = nbCol,
                NbRow = nbRow
            };
            return View(model);
        }

        public IActionResult SuccessLogin()
        {
            TempData["message"] = "Connection réussie!";
            TempData["notificationType"] = "success";
            return RedirectToAction("Index");
        }
        public IActionResult FailedLogin()
        {
            TempData["message"] = "Connection échouée...";
            TempData["notificationType"] = "failed";
            return RedirectToAction("Index");
        }
    }
}

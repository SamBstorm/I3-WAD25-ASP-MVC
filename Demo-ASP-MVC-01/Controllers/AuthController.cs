using Demo_ASP_MVC_01.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP_MVC_01.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        //public IActionResult Login(IFormCollection form)      // IFormCollection => Récupération d'un formulaire adaptatif, mais l'ensemble des données sont au format StringValues
        //public IActionResult Login(string mail, string pwd)   // paramètres spécifiques => Récupération des champs d'un formulaire en effectuant la conversion des données (attention au typage et aux attributs name des inputs)
        public IActionResult Login(LoginForm form)
        {
            return View();
        }
    }
}

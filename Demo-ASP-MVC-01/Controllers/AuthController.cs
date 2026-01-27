using Demo_ASP_MVC_01.Handlers;
using Demo_ASP_MVC_01.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new InvalidOperationException("Le model state n'est pas valide.");
                }
                //Intérroger la DB

                TempData["message"] = "Connexion réussie";
                TempData["alert-type"] = "alert-success";
                return RedirectToAction("Login");
            }
            catch (InvalidOperationException ex)
            {
                TempData["message"] = "Connexion échouée";
                TempData["alert-type"] = "alert-warning";
                return View();
            }
        }
    }
}

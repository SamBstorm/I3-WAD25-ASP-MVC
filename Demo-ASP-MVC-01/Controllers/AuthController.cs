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
                if (string.IsNullOrWhiteSpace(form.Mail)) ModelState.AddModelError(nameof(form.Mail), "Votre Email ne peut être null, vide ou composé d'espace blanc.");
                if (!Regex.IsMatch(form.Mail, "^[a-zA-Z0-9\\-\\.=+*$]+@[a-zA-Z0-9\\-\\.=+*$]+$")) ModelState.AddModelError(nameof(form.Mail), "Votre Email ne n'est pas au bon format.");
                if (form.Pwd.Length < 8 || form.Pwd.Length > 64) ModelState.AddModelError(nameof(form.Pwd), "Le mot de passe doit être compris entre 8 à 64 caractères.");
                //if (!Regex.IsMatch(form.Pwd, "[a-z]")) ModelState.AddModelError(nameof(form.Pwd), "Le mot de passe doit avoir au minimum un caractère minuscule.");
                //if (!Regex.IsMatch(form.Pwd, "[A-Z]")) ModelState.AddModelError(nameof(form.Pwd), "Le mot de passe doit avoir au minimum un caractère majuscule.");
                //if (!Regex.IsMatch(form.Pwd, "[0-9]")) ModelState.AddModelError(nameof(form.Pwd), "Le mot de passe doit avoir au minimum un caractère numérique.");
                //if (!Regex.IsMatch(form.Pwd, @"[\-=\.@\\/$#]")) ModelState.AddModelError(nameof(form.Pwd), "Le mot de passe doit avoir au minimum un caractère de type symbole.");
                ModelState.ContainsLowerCharacterValidator(nameof(form.Pwd), form.Pwd);
                ModelState.ContainsUpperCharacterValidator(nameof(form.Pwd), form.Pwd);
                ModelState.ContainsNumberValidator(nameof(form.Pwd), form.Pwd);
                ModelState.ContainsSymbolCharacterValidator(nameof(form.Pwd), form.Pwd);
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

using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP_MVC_01.Controllers
{
    public class BlogController : Controller
    {
        public string Index(string article)
        {
            return $"Choix de l'article : {article}";
        }
    }
}

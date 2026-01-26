using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP_MVC_01.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
            _logger.Log(LogLevel.Information, "Inticiation du BlogController");
        }

        public string Index(string article)
        {
            _logger.Log(LogLevel.Warning, "Exécution de l'action Index");
            _logger.Log(LogLevel.Error, article);
            return $"Choix de l'article : {article}";
        }
    }
}

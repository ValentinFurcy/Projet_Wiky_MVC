using Entities;
using IRepositories;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository;
using System.Diagnostics;

namespace Projet_Wiky_MVC.Controllers
{
    public class HomeController : Controller
    {
        IArticleRepository articleRepository;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , IArticleRepository IArticleRepository)
        {
            _logger = logger;
            articleRepository = IArticleRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await articleRepository.GetArticleByDateDesc());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

}

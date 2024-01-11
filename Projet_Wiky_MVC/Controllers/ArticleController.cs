using Entities;
using IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Projet_Wiky_MVC.Controllers
{
    public class ArticleController : Controller
    {
        IArticleRepository articleRepository;

        public ArticleController(IArticleRepository IArticleRepository)
        {
            articleRepository = IArticleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await articleRepository.GetAllArticles());
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            article = await articleRepository.CreateArticle(article);

            return RedirectToAction("DetailArticle", new { Id = article.Id});
        }

        [HttpGet]
        public async Task<IActionResult> DetailArticle(int id)
        {
            return View(await articleRepository.GetArticleById(id));
        }

        [HttpGet]
        public async Task<IActionResult>UpdateArticle(int id) 
        {
            return View(await articleRepository.GetArticleById(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateArticle(Article article)
        {
            article = await articleRepository.UpdateArticle(article);

            return RedirectToAction("DetailArticle", new { Id = article.Id });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await articleRepository.DeleteArticle(id);
            TempData["Message"] = "L'article à bien été supprimé";
            return RedirectToAction("Index");
        }
        
    }
}

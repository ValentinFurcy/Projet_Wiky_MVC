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
        public async Task<ActionResult> CheckUniqueTheme(string theme)
        {
            bool res = await articleRepository.IsUnique(theme);
            return Json(!res);
        }
        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            if (!ModelState.IsValid || await articleRepository.IsUnique(article.Theme))
            {            
                return View(article);
            }
            else
            {
                article = await articleRepository.CreateArticle(article);

                return RedirectToAction("DetailArticle", new { Id = article.Id });
            }           
        }

        [HttpGet]
        public async Task<IActionResult> DetailArticle(int id)
        {
            var article = await articleRepository.GetArticleById(id);
            return View(article);
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
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SearchByTheme()
        {         
            return View("SearchArticle");
        }

        [HttpPost]
        public async Task<IActionResult> SearchByTheme(string theme)
        {
            var article = await articleRepository.SearchByTheme(theme);

            return PartialView("_detailArticle", article);
        }

    }
}

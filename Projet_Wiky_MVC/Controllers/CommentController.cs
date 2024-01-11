using Entities;
using IRepositories;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository;

namespace Projet_Wiky_MVC.Controllers
{
    public class CommentController : Controller
    {
        ICommentRepository commentRepository;

        public CommentController(ICommentRepository ICommentRepository)
        {
            commentRepository = ICommentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateComment(int articleId)
        {
            ViewData["articleId"] = articleId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            comment = await commentRepository.CreateComment(comment);
            return RedirectToAction("DetailArticle", "Article", new { Id = comment.ArticleID });         
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComment(int id , int idArticle)
        {
            //int id = comment.Id;
            await commentRepository.DeleteComment(id);
            TempData["Message"] = "Le commentaire à bien été supprimé";
            return RedirectToAction("DetailArticle", "Article", new { Id = idArticle });
            //return RedirectToAction("Index");
        }        
    }
}

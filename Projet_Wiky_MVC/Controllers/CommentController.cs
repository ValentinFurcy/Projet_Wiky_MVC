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
        [HttpPost]
        public async Task<IActionResult> CreateCommentAjax(Comment comment)
        {
            comment = await commentRepository.CreateComment(comment);
            var commentToList = await commentRepository.GetByIdArticleAsync(comment.ArticleID);
            return PartialView("_comment", commentToList);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComment(int id , int idArticle)
        {
            await commentRepository.DeleteComment(id);
            var commentToList = await commentRepository.GetByIdArticleAsync(idArticle);

            TempData["Message"] = "Le commentaire à bien été supprimé";

            return RedirectToAction("DetailArticle", "Article", new { Id = idArticle });
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCommentAjax(int id, int idArticle)
        {
            await commentRepository.DeleteComment(id);
            var commentToList = await commentRepository.GetByIdArticleAsync(idArticle);

            //TempData["Message"] = "Le commentaire à bien été supprimé";

            return PartialView("_comment", commentToList);

        }
    }
}

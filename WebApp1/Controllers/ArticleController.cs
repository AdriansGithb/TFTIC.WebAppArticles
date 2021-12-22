using ArticleDAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;
using WebApp1.Tools;

namespace WebApp1.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _service;
        private readonly ICategorieRepository _catService;

        public ArticleController(IArticleRepository service, ICategorieRepository catService)
        {
            _service = service;
            _catService = catService;
        }
        // GET: ArticleController
        public ActionResult Index()
        {
            List<ArticleModel> articles = _service.GetAll().Select(a => a.toWeb()).ToList();
            foreach(ArticleModel a in articles)
            {
                a.LibCategorie = _catService.GetById(a.IdCategorie).Libelle;
            }
            return View(articles);
        }
        [HttpGet]
        // GET: ArticleController/Details/5
        public ActionResult Details(int id)
        {
            ArticleModel article = _service.GetById(id).toWeb();
            article.LibCategorie = _catService.GetById(article.IdCategorie).Libelle;
            return View(article);
        }
        [HttpGet]
        // GET: ArticleController/Create
        public ActionResult Create()
        {
            ArticleFormModel newArticleForm = new ArticleFormModel();
            newArticleForm.CategorieList = _catService.GetAll().Select(c => c.toWeb());
            return View(newArticleForm);
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleFormModel newArticle)
        {
            try
            {
                if (!ModelState.IsValid) return View(newArticle);
                _service.Create(newArticle.toDal());
                return RedirectToAction("Index");
            }
            catch
            {
                return View(newArticle);
            }
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(int id)
        {
            ArticleFormModel newArticleForm = _service.GetById(id).toWebForm();
            newArticleForm.CategorieList = _catService.GetAll().Select(c => c.toWeb());
            return View(newArticleForm);
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleFormModel modifArticle)
        {
            _service.Update(modifArticle.toDal());
                return RedirectToAction("Index");

        }

        public ActionResult GetArticlesByCategorie(int catId)
        {
            List<ArticleModel> articles = _service.GetAllByCategorieId(catId).Select(a => a.toWeb()).ToList();
            foreach (ArticleModel a in articles)
            {
                a.LibCategorie = _catService.GetById(a.IdCategorie).Libelle;
            }
            return View("Index", articles);
        }

        // POST: ArticleController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using ArticleDAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ICategorieRepository _service;

        public CategorieController(ICategorieRepository service)
        {
            _service = service;
        }

        // GET: CategorieController
        public ActionResult Index()
        {
            return View(_service.GetAll().Select(c=>c.toWeb()).ToList().OrderBy(x=>x.IdCategorie));
        }

        // GET: CategorieController/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.GetById(id).toWeb());
        }

        // GET: CategorieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategorieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategorieModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool res = _service.Create(model.toDal());
                    if(res)
                        return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_service.GetById(id).toWeb());
        }

        // POST: CategorieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategorieModel editedCat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool res = _service.Update(editedCat.toDal());
                    if (res)
                        return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

using AulaRelacionamento.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaRelacionamento.Controllers
{
    public class FilmesController : Controller
    {
        private readonly Contexto db;
        public FilmesController(Contexto contexto)
        {
            db = contexto;
        }
       
        public ActionResult Index()
        {
            return View(db.FILMES.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Create(Filme dados)
        {
            db.FILMES.Add(dados);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

       
        public ActionResult Edit(int id)
        {
            return View(db.FILMES.Find(id));
        }

       
        [HttpPost]
        public ActionResult Edit(int id, Filme dados)
        {
            db.FILMES.Update(dados);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

       
        public ActionResult Delete(int id)
        {
            db.FILMES.Remove(db.FILMES.Find(id));
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}

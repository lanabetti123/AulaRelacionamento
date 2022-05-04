using AulaRelacionamento.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaRelacionamento.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Contexto db;
        public UsuariosController(Contexto contexto)
        {
            db = contexto;
        }

        public ActionResult Index()
        {
            return View(db.USUARIOS.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario dados)
        {
            db.USUARIOS.Add(dados);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Edit(int id)
        {
            return View(db.USUARIOS.Find(id));
        }


        [HttpPost]
        public ActionResult Edit(int id, Usuario dados)
        {
            db.USUARIOS.Update(dados);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id)
        {
            db.USUARIOS.Remove(db.USUARIOS.Find(id));
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}

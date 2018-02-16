using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autores.Data.Repository;
using Autores.Data.Interface;
using Autores.Domain.Entities;

namespace Autores1.Controllers
{
    public class AutoresController : Controller
    {
        private readonly IAutorRepositorio _AutorRepositorio;


        public AutoresController(IAutorRepositorio AutorRepositorio)
        {
            _AutorRepositorio = AutorRepositorio;

        }


        public ActionResult Cadastrar()
        {



            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Autor autor)
        {

            if (ModelState.IsValid)
            {
                _AutorRepositorio.Add(autor);


                return RedirectToAction("Listar");
            }



            return View(autor);
        }
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Editar(int id, Autor autor)
        {


            _AutorRepositorio.FindByid(id);


            return View(autor);

        }



        public ActionResult Editar(Autor autor)
        {

            if (ModelState.IsValid)
            {

                _AutorRepositorio.Update(autor);


                return RedirectToAction("Listar");


            }


            return View(autor);
        }

        [HttpGet]
        public ActionResult Listar()
        {


            var produto = _AutorRepositorio.GetAll();


            return View(produto);
        }



        [HttpPost]
        public ActionResult Excluir(int id)
        {

            var produto = _AutorRepositorio.FindByid(id);

            _AutorRepositorio.Remove(produto);


            TempData["msg"] = "Produto removido";

            return RedirectToAction("Listar");



        }
    }
}
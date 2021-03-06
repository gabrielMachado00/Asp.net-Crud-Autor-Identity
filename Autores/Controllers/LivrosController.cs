﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autores.Data.Repository;
using Autores.Data.Interface;
using Autores.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace Autores.Controllers { 

    public class LivrosController : Controller
    {
        // GET: Livros
        private readonly ILivroRepositorio _LivroRepositorio;

        public LivrosController(ILivroRepositorio LivroRepositorio)
        {
            _LivroRepositorio = LivroRepositorio;

        }


        public ActionResult Cadastrar()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Livro livro)
        {

            string Id = User.Identity.GetUserId();

            livro = new Livro(livro.IdLivro,livro.Id=Id,livro.Titulo,livro.Genero,livro.Quantidade);


            if (ModelState.IsValid)
            {
                _LivroRepositorio.Add(livro);


                return RedirectToAction("Listar");
            }



            return View(livro);
        }
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Editar(int id, Livro livro)
        {


            _LivroRepositorio.FindByid(id);


            return View(livro);

        }



        public ActionResult Editar(Livro livro)
        {

            if (ModelState.IsValid)
            {

                _LivroRepositorio.Update(livro);


                return RedirectToAction("Listar");


            }


            return View(livro);
        }

        [HttpGet]
        public ActionResult Listar()
        {


            var produto = _LivroRepositorio.GetAll();


            return View(produto);
        }



        [HttpGet]

        public ActionResult ListaAutoresLivro()
        {


            var livro = _LivroRepositorio.LivrosPorAutor();


            return View(livro);
        }


        [HttpGet]

        public ActionResult ListaTotal() {

            var livro = _LivroRepositorio.TotalCadastro();

            return View(livro);
        }






        [HttpPost]
        public ActionResult Excluir(int id)
        {

            var produto = _LivroRepositorio.FindByid(id);

            _LivroRepositorio.Remove(produto);


            TempData["msg"] = "Produto removido";

            return RedirectToAction("Listar");



        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmed(int id)
        {

            var autor = _LivroRepositorio.FindByid(id);

            _LivroRepositorio.Remove(autor);


            return RedirectToAction("Listar");
        }



    }
}
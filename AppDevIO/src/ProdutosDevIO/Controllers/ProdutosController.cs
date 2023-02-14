﻿using DevIO.Business.Core.Notificacoes;
using DevIO.Business.Models.Produtos;
using DevIO.Business.Models.Produtos.Services;
using DevIO.Infra.Data.Repository;
using ProdutosDevIO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProdutosDevIO.Controllers
{
    public class ProdutosController : Controller
    {
            private readonly IProdutoRepository _produtoRepository;
            private readonly IProdutoService _produtoService;

            public ProdutosController()
            {
            _produtoRepository = new ProdutoRepository();
            _produtoService = new ProdutoService(_produtoRepository,new Notificador());
            }

            [Route("lista-de-produtos")]
            [HttpGet]
            public async Task<ActionResult> Index()
            {
                return View(await _produtoRepository.ObterTodos());
            }

            [Route("dados-do-produto/{id:guid}")]
            [HttpGet]
            public async Task<ActionResult> Details(Guid id)
            {
                var produtoViewModel = await ObterProduto(id);

                if (produtoViewModel == null)
                {
                    return HttpNotFound();
                }

                return View(produtoViewModel);
            }

            [Route("novo-produto")]
            [HttpGet]
            public ActionResult Create()
            {
                return View();
            }

            [Route("novo-produto")]
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create(ProdutoViewModel produtoViewModel)
            {
                if (ModelState.IsValid)
                {

                    return RedirectToAction("Index");
                }

                return View(produtoViewModel);
            }

            [Route("editar-produto/{id:guid}")]
            [HttpGet]
            public async Task<ActionResult> Edit(Guid id)
            {
                var produtoViewModel = await ObterProduto(id);

                if (produtoViewModel == null)
                {
                    return HttpNotFound();
                }

                return View(produtoViewModel);
            }

            [Route("editar-produto/{id:guid}")]
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit(ProdutoViewModel produtoViewModel)
            {
                if (ModelState.IsValid)
                {

                    return RedirectToAction("Index");
                }

                return View(produtoViewModel);
            }


            [Route("excluir-produto/{id:guid}")]
            [HttpGet]
            public async Task<ActionResult> Delete(Guid id)
            {
                var produtoViewModel = await ObterProduto(id);

                if (produtoViewModel == null)
                {
                    return HttpNotFound();
                }

                return View(produtoViewModel);
            }

            [Route("excluir-produto/{id:guid}")]
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> DeleteConfirmed(Guid id)
            {
                var produtoViewModel = await ObterProduto(id);

                if (produtoViewModel == null)
                {
                    return HttpNotFound();
                }


                return RedirectToAction("Index");
            }

            private async Task<ProdutoViewModel> ObterProduto(Guid id)
            {
                return new ProdutoViewModel();
            }

            protected override void Dispose(bool disposing)
            {
                
            }
        }
    }
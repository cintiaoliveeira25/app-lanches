using App_Lanches.Models;
using App_Lanches.Repositories.Interface;
using App_Lanches.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace App_Lanches.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICategoryRepository _categoryRepository;

        public LancheController(ILancheRepository lancheRepository, ICategoryRepository categoryRepository)
        {
            // acesso as instancias do repositorio
            _lancheRepository = lancheRepository;
            _categoryRepository = categoryRepository;
        }

        // retornar lanche por categoria
        public IActionResult List(string categoria)
        {
            // string _categoria = categoria;
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
                categoria = "Todos os lanches";
            }
            else
            {
                /* if (string.Equals("Normal", _categoria, StringComparison.OrdinalIgnoreCase))
                   {
                       lanches = _lancheRepository.Lanches.Where(p => 
                           p.Categorias.CategoriaNome.Equals("Normal")).OrderBy(p => p.Nome);
                   }    
                   else
                   {
                       lanches = _lancheRepository.Lanches.Where(p => 
                           p.Categorias.CategoriaNome.Equals("Natural")).OrderBy(p => p.Nome);
                   }

                   categoriaAtual = _categoria; */

                lanches = _lancheRepository.Lanches
                    .Where(p => p.Categorias.CategoriaNome.Equals(categoria))
                    .OrderBy(p => p.Nome);

                    categoriaAtual = categoria;
            }

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lancheListViewModel);
        }

        public ViewResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(d => d.LancheId == lancheId);
            if (lanche == null)
            {
                return View("./Views/Error/Error.cshtml");
            }
            return View(lanche);
        }
        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Lanche> lanches;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
            }
            else
            {
                lanches = _lancheRepository.Lanches.Where(p => p.Nome.ToLower().Contains(_searchString.ToLower()));
            }

            return View("./Views/Lanche/List.cshtml", new LancheListViewModel { Lanches = lanches, CategoriaAtual = "Todos os lanches" });
        }
    }
}

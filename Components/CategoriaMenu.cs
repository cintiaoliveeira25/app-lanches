using App_Lanches.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App_Lanches.Components
{
    // a classe CategoriaMenu herda de ViewComponent
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        // essa ViewComponent vai retornar as categorias que estão cadastradas 
        public CategoriaMenu(ICategoryRepository categoryRepository)
        // injeção de dependencia do repositorio no construtor CategoriaMenu
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            // a variavel obtem as categorias contidas no repositório
            var categorias = _categoryRepository.Categorias.OrderBy(c => c.CategoriaNome);

            return View(categorias);
            // retorna as categorias obtidas, ordenadas pelo nome
        }
    }
}

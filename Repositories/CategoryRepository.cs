using App_Lanches.Context;
using App_Lanches.Models;
using App_Lanches.Repositories.Interface;
using System.Collections.Generic;

namespace App_Lanches.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;

    }
}

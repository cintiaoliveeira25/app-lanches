using App_Lanches.Models;
using System.Collections.Generic;


namespace App_Lanches.Repositories.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Categoria> Categorias { get; } // somente exibir as categorias (get)
    }
}

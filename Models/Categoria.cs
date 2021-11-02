﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App_Lanches.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [StringLength(100)]
        public string CategoriaNome { get; set; }
        [StringLength(200)]
        public string Descricao { get; set; }
        public List<Lanche> Lanches { get; set; } // relacionamento entre a categoria e o lanche
    }
}

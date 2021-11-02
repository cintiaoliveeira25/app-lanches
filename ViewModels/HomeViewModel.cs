using App_Lanches.Models;
using System.Collections.Generic;

namespace App_Lanches.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}


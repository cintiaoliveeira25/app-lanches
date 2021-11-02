using Microsoft.AspNetCore.Mvc;
using App_Lanches.Repositories.Interface;
using App_Lanches.ViewModels;


namespace App_Lanches.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        public HomeController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            };

            return View(homeViewModel);
        }
        public ViewResult AccessDenied()
        {
            return View();
        }
    }
}
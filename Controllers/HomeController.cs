using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            // Creates an instance of the HomeViewModel to acquire the IEnumerable PiesOfTheWeek method available in the IPieRepository
            var homeViewModel = new HomeViewModel
            {
                PiesOfTheWeek = _pieRepository.PiesOfTheWeek
            };

            // Returns the ViewModel with the IEnumerable PiesOfTheWeek
            return View(homeViewModel);
        }
    }
}
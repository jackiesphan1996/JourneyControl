using JourneyControl.Logic.Services.SupplyChain.Interface;
using JourneyControl.Logic.Services.TripPlanning.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JourneyControl.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILocationService _locationService;
        private readonly IBasketMovementService _basketMovementService;

        public HomeController(ILogger<HomeController> logger, IBasketMovementService basketMovementService, ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
            _basketMovementService = basketMovementService;
        }

        public IActionResult Index()
        {
            var locations = _locationService.GetAllLocationsBySP();

            return View(locations);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return null;
        }
    }
}

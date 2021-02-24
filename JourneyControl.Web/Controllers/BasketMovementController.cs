using JourneyControl.Logic.Services.SupplyChain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JourneyControl.Web.Controllers
{
    [Authorize]
    public class BasketMovementController : Controller
    {
        private readonly IBasketMovementService _basketMovementService;

        public BasketMovementController(IBasketMovementService basketMovementService)
        {
            _basketMovementService = basketMovementService;
        }

        public IActionResult Index()
        {
            var allBasketMovements = _basketMovementService.GetAllBasketMovements();

            return View(allBasketMovements);
        }
    }
}

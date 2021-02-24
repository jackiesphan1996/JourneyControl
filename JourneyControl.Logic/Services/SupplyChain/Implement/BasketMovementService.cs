using JourneyControl.Infrastructure.Persistence.Contexts;
using JourneyControl.Infrastructure.Persistence.Entities.SupplyChain;
using JourneyControl.Logic.Services.SupplyChain.Interface;
using System.Collections.Generic;
using System.Linq;

namespace JourneyControl.Logic.Services.SupplyChain.Implement
{
    public class BasketMovementService : IBasketMovementService
    {
        private readonly SupplyChainDbContext _supplyChainDbContext;

        public BasketMovementService(SupplyChainDbContext supplyChainDbContext)
        {
            _supplyChainDbContext = supplyChainDbContext;
        }

        public List<BasketMovement> GetAllBasketMovements()
        {
            return _supplyChainDbContext.BasketMovements.ToList();
        }

    }
}

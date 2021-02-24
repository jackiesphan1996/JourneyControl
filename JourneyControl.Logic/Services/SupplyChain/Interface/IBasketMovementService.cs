using System.Collections.Generic;
using JourneyControl.Infrastructure.Persistence.Entities.SupplyChain;

namespace JourneyControl.Logic.Services.SupplyChain.Interface
{
    public interface IBasketMovementService
    {
        List<BasketMovement> GetAllBasketMovements();
    }
}

using JourneyControl.Logic.Services.SupplyChain.Implement;
using JourneyControl.Logic.Services.SupplyChain.Interface;
using JourneyControl.Logic.Services.TripPlanning.Implement;
using JourneyControl.Logic.Services.TripPlanning.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace JourneyControl.Logic
{
    public static class ServiceExtensions
    {
        public static void AddLogicLayer(this IServiceCollection services)
        {
            services.AddTransient<IBasketMovementService, BasketMovementService>();
            services.AddTransient<ILocationService, LocationService>();
        }
    }
}

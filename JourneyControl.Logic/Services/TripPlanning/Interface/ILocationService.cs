using JourneyControl.Infrastructure.Persistence.Entities.TripPlanning;
using System.Collections.Generic;

namespace JourneyControl.Logic.Services.TripPlanning.Interface
{
    public interface ILocationService
    {
        List<Location> GetAllLocations();
        List<Location> GetAllLocationsBySP();
    }
}

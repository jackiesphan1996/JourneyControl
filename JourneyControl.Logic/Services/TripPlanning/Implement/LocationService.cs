using Dapper;
using JourneyControl.Infrastructure.Persistence.Contexts;
using JourneyControl.Infrastructure.Persistence.Entities;
using JourneyControl.Logic.Services.TripPlanning.Interface;
using System.Collections.Generic;
using System.Linq;
using JourneyControl.Infrastructure.Persistence.Entities.TripPlanning;

namespace JourneyControl.Logic.Services.TripPlanning.Implement
{
    public class LocationService : ILocationService
    {
        private readonly TripPlanningDbContext _tripPlanningDbContext;

        public LocationService(TripPlanningDbContext tripPlanningDbContext)
        {
            _tripPlanningDbContext = tripPlanningDbContext;
        }

        public List<Location> GetAllLocations()
        {
            return _tripPlanningDbContext.Locations.ToList();
        }

        public List<Location> GetAllLocationsBySP()
        {
            return _tripPlanningDbContext.Connection.Query<Location>("exec STGetAllLocation").ToList();
        }
    }
}


using System.Collections.Generic;
using TravelRoute.Entities;

namespace TravelRoute.Repository.Interfaces
{
    public interface IRouteRepository
    {
        List<Route> ListRoutes();
        void SetRoute(Route route);
    }
}

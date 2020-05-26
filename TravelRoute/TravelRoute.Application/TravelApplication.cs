using System;
using TravelRoute.Application.Interfaces;
using TravelRoute.Entities;
using TravelRoute.Repository.Interfaces;

namespace TravelRoute.Application
{
    public class TravelApplication : ITravelApplication
    {
        private IRouteRepository _routeRepository;

        public TravelApplication(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public PossibleRoute GetBestRoute(string route)
        {
            var routes = _routeRepository.ListRoutes();

            var travel = new Travel(routes);

            travel.GetBestRoute(route.Split('-')[0], route.Split('-')[1]);

            return travel.BestRoute;
        }

        public void SetRoute(Route route)
        {

            if (!route.IsValid())
                throw new Exception("Rota inválida!");

            _routeRepository.SetRoute(route);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace TravelRoute.Entities
{
    public class Travel
    {
        public Travel(List<Route> routes)
        {
            Routes = routes;
            PossibleRoutes = new List<PossibleRoute>();
        }

        public List<Route> Routes { get; set; }

        public List<PossibleRoute> PossibleRoutes { get; set; }

        public PossibleRoute BestRoute { get; set; }

        public void GetBestRoute(string source, string target)
        {

            var possibleRoute = new PossibleRoute
            {
                CurrentTarget = target,
                Source = source
            };

            GetPossibleRoutes(ref possibleRoute, source, target);

            BestRoute = PossibleRoutes.FirstOrDefault(x => x.Value == PossibleRoutes.Select(route => route.Value).Min());
        }

        public void GetPossibleRoutes(ref PossibleRoute possibleRoute, string source, string target)
        {
            var currentTarget = possibleRoute.CurrentTarget;
            var routes = Routes.Where(x => x.Target == currentTarget).ToList();

            string routeSuffix = null;
            decimal value = 0;

            if (routes.Any())
            {
                routeSuffix = possibleRoute.Route;
                value = possibleRoute.Value;
            }
            else
            {
                possibleRoute.Route = null;
                possibleRoute.Value = 0;
            }
            possibleRoute.Source = source;

            foreach (var route in routes)
            {
                possibleRoute.Route = $"{route.Source}-{possibleRoute.Route ?? routeSuffix}";
                possibleRoute.Value = route.Value + (possibleRoute.Value == 0 ? value : possibleRoute.Value);

                if (route.Target == currentTarget && route.Source == source)
                {
                    possibleRoute.Route = $"{possibleRoute.Route}{target}";

                    PossibleRoutes.Add(possibleRoute);
                    possibleRoute = new PossibleRoute();

                }
                else
                {
                    possibleRoute.CurrentTarget = route.Source;
                    GetPossibleRoutes(ref possibleRoute, source, target);
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TravelRoute.Entities;
using TravelRoute.Repository.Interfaces;

namespace TravelRoute.Repository
{
    public class RouteRepository : IRouteRepository
    {
        private static List<Route> routes;

        public RouteRepository()
        {
            OpenFile();
        }

        public List<Route> ListRoutes()
        {
            return routes;
        }

        public void SetRoute(Route route)
        {
            routes.Add(route);
            string[] lines = routes.Select(r => $"{r.Source},{r.Target},{r.Value}").ToArray();
            System.IO.File.WriteAllLines(Directory.GetCurrentDirectory() + @"\Resources\input-file.txt", lines);

        }

        private void OpenFile()
        {
            routes = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\Resources\input-file.txt")
                    .Select(a => a.Split(','))
                    .Select(r => new Route()
                    {
                        Source = r[0],
                        Target = r[1],
                        Value = Convert.ToDecimal(r[2])
                    })
                    .ToList();
        }
    }
}



using Microsoft.Extensions.DependencyInjection;
using System;
using TravelRoute.Application;
using TravelRoute.Application.Interfaces;
using TravelRoute.Repository;
using TravelRoute.Repository.Interfaces;

namespace TravelRoute.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection();
            collection.AddTransient<ITravelApplication, TravelApplication>();
            collection.AddTransient<IRouteRepository, RouteRepository>();
            var serviceProvider = collection.BuildServiceProvider();
            var service = serviceProvider.GetService<ITravelApplication>();

            ExecuteTravelRoute(service);

            serviceProvider.Dispose();
        }

        private static void ExecuteTravelRoute(ITravelApplication service)
        {
            Console.Write("Please enter the route: ");

            var route = Console.ReadLine();

            var bestRoute = service.GetBestRoute(route);

            if (bestRoute == null)
                Console.WriteLine($"Route not found!");
            else
                Console.WriteLine($"best route: {bestRoute.Route} > ${bestRoute.Value} \r\n");

            Console.ReadKey();

            ExecuteTravelRoute(service);
        }
    }
}

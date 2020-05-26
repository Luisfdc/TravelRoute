using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TravelRoute.Entities;

namespace TravelRouteTest
{
    public class TravelTest
    {
        private List<Route> _routes;

        [SetUp]
        public void Setup()
        {
            _routes = new List<Route>
            {
                new Route{Source= "GRU", Target = "BRC", Value = 10},
                new Route{Source= "BRC", Target = "SCL", Value = 5},
                new Route{Source= "GRU", Target = "CDG", Value = 75},
                new Route{Source= "GRU", Target = "SCL", Value = 20},
                new Route{Source= "GRU", Target = "ORL", Value = 56},
                new Route{Source= "ORL", Target = "CDG", Value = 5},
                new Route{Source= "SCL", Target = "ORL", Value = 20}
            };

            /*
             GRU,BRC,10
            BRC,SCL,5
            GRU,CDG,75
            GRU,SCL,20
            GRU,ORL,56
            ORL,CDG,5
            SCL,ORL,20 

             GRU,CDG = 75
             GRU,ORL,CDG = 56 + 5 = 61
             GRU,SCL,ORL,CDG = 20 + 20 + 5 = 45
             GRU,BRC,SCL,ORL,CDG = 10 + 5 + 20 + 5 = 40

             */
        }

        [Test]
        public void Test_route_GRU_to_CDG()
        {
            var travel = new Travel(_routes);
            travel.GetBestRoute("GRU", "CDG");

            var result = travel.PossibleRoutes.Any(x => x.Route == "GRU-CDG") &&
                travel.PossibleRoutes.Any(x => x.Route == "GRU-ORL-CDG") &&
                travel.PossibleRoutes.Any(x => x.Route == "GRU-SCL-ORL-CDG") &&
                travel.PossibleRoutes.Any(x => x.Route == "GRU-BRC-SCL-ORL-CDG");

            Assert.IsTrue(result);
        }


        [Test]
        public void Test_route_GRU_to_ORL()
        {
            var travel = new Travel(_routes);

            travel.GetBestRoute("GRU", "ORL");

            var result = travel.PossibleRoutes.Any(x => x.Route == "GRU-ORL") &&
                travel.PossibleRoutes.Any(x => x.Route == "GRU-SCL-ORL") &&
                travel.PossibleRoutes.Any(x => x.Route == "GRU-BRC-SCL-ORL");

            Assert.IsTrue(result);
        }

        [Test]
        public void Test_value_best_route_40()
        {
            var travel = new Travel(_routes);
            travel.GetBestRoute("GRU", "CDG");

            Assert.IsTrue(travel.BestRoute.Value == 40M);
        }

    }
}
using NUnit.Framework;
using TravelRoute.Repository;
using TravelRoute.Repository.Interfaces;

namespace TravelRoute.RepositoryTest
{
    public class RouteRepositoryTest
    {
        IRouteRepository _routeRepository;
        [SetUp]
        public void Setup()
        {
            _routeRepository = new RouteRepository();
        }

        [Test]
        public void ListRoutesTest()
        {
            var routes=_routeRepository.ListRoutes();

            Assert.IsNotNull(routes);
        }
    }
}
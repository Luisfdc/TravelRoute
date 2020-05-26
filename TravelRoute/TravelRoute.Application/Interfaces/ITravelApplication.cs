using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRoute.Entities;

namespace TravelRoute.Application.Interfaces
{
    public interface ITravelApplication
    {
        void SetRoute(Route route);
        PossibleRoute GetBestRoute(string route);

    }
}

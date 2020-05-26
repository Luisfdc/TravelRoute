using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelRoute.Entities
{
    public class PossibleRoute
    {
        public PossibleRoute()
        {
        }

        public string Source { get; set; }
        public string CurrentTarget { get; set; }
        public string Route { get; set; }
        public decimal Value { get; set; }

    }
}

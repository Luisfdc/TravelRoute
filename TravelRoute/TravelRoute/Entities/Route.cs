using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRoute.Entities
{
    public class Route
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public decimal Value { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(this.Source) &&
                !string.IsNullOrWhiteSpace(this.Target) &&
                 this.Value > 0;
        }
    }
}

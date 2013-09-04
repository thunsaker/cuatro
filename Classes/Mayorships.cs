using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuatro.Common
{
    /// <summary>
    /// Foursquare Mayorships
    /// </summary>
    [Serializable]
    public class Mayorships
    {
        /// <summary>
        /// List of Current Mayorship Venues
        /// </summary>
        public List<Venue> CurrentMayorships { get; set; }
    }
}

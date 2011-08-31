using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace common
{
    public class Location
    {
        /// <summary>
        /// Screet Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Cross Streets
        /// </summary>
        public string CrossStreet { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State/Province
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Postal Code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Latitude Coordinate
        /// </summary>
        public long Latitude { get; set; }

        /// <summary>
        /// Longitude Coordinate
        /// </summary>
        public long Longitude { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Cuatro.Common {
    [Serializable]
    public class Location : Base {
        public int LocationId { get; set; }

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
        /// cc
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Latitude Coordinate
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude Coordinate
        /// </summary>
        public double Longitude { get; set; }

        internal static Location Parse(string p) {
            JObject rawLocationInfo = JObject.Parse(p);

            Location tempLocation = new Location();
            tempLocation.Address = rawLocationInfo["address"] != null ? rawLocationInfo["address"].ToString().Replace("\"", "") : "";
            tempLocation.CrossStreet = rawLocationInfo["crossStreet"] != null ? rawLocationInfo["crossStreet"].ToString().Replace("\"", "") : "";
            tempLocation.City = rawLocationInfo["city"] != null ? rawLocationInfo["city"].ToString().Replace("\"", "") : "";
            tempLocation.State = rawLocationInfo["state"] != null ? rawLocationInfo["state"].ToString().Replace("\"", "") : "";
            tempLocation.PostalCode = rawLocationInfo["postalCode"] != null ? rawLocationInfo["postalCode"].ToString().Replace("\"", "") : "";
            tempLocation.Country = rawLocationInfo["country"] != null ? rawLocationInfo["country"].ToString().Replace("\"", "") : "";
            tempLocation.Latitude = rawLocationInfo["lat"] != null ? double.Parse(rawLocationInfo["lat"].ToString().Replace("\"", "")) : 0;
            tempLocation.Longitude = rawLocationInfo["lng"] != null ? double.Parse(rawLocationInfo["lng"].ToString().Replace("\"", "")) : 0;
            return tempLocation;
        }
    }

    public class LocationCoords {
        /// <summary>
        /// Latitude Coordinate
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude Coordinate
        /// </summary>
        public double Longitude { get; set; }
    }
}
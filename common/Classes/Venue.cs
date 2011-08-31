using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace common
{
    /// <summary>
    /// Foursquare Venue
    /// </summary>
    public class Venue
    {
        /// <summary>
        /// Foursquare Venue Id
        /// </summary>
        public string VenueId { get; set; }

        /// <summary>
        /// Venue Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Venue Item Id
        /// </summary>
        // TODO: Verify what this is
        public string ItemId { get; set; }

        /// <summary>
        /// Venue Contact Information
        /// </summary>
        public Contact ContactInfo { get; set; }

        /// <summary>
        /// Venue Location
        /// </summary>
        public Location LocationInfo { get; set; }

        /// <summary>
        /// List of Venue Categories
        /// </summary>
        public List<VenueCategory> Categories { get; set; }

        /// <summary>
        /// Is this a verified Venue?
        /// </summary>
        public bool Verified { get; set; }

        /// <summary>
        /// Venue Statistics
        /// </summary>
        public VenueStatistics Statistics { get; set; }
    }

    /// <summary>
    /// Foursquare Venue Category
    /// </summary>
    public class VenueCategory
    {
        /// <summary>
        /// Foursquare Venue Category Id
        /// </summary>
        public string FoursquareVenueCategoryId { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Category Plural Name
        /// </summary>
        public string PluralName { get; set; }

        /// <summary>
        /// Icon Uri
        /// </summary>
        public Uri IconUri { get; set; }

        /// <summary>
        /// List of Parent Categories
        /// </summary>
        public List<String> ParentCategories { get; set; }

        /// <summary>
        /// Primary category for given venue?
        /// </summary>
        public bool PrimaryCategory { get; set; }
    }

    /// <summary>
    /// Basic Venue Stats
    /// </summary>
    public class VenueStatistics
    {
        /// <summary>
        /// Total Checkins Count
        /// </summary>
        public int CheckinsCount { get; set; }

        /// <summary>
        /// Total Users Checked In
        /// </summary>
        public int UsersCount { get; set; }

        /// <summary>
        /// Tipa Count
        /// </summary>
        public int TipCount { get; set; }
    }
}

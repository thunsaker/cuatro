using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Cuatro.Common
{
    /// <summary>
    /// Foursquare Venue
    /// </summary>
    [Serializable]
    public class Venue : Base
    {
        /// <summary>
        /// Venue Id
        /// </summary>
        public string VenueId { get; set; }

        /// <summary>
        /// Foursquare Venue Id
        /// </summary>
        public string FoursquareVenueId { get; set; }

        /// <summary>
        /// Venue Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Not sure what this does...
        /// </summary>
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
        /// Web Address
        /// </summary>
        public string VenueUri { get; set; }

        /// <summary>
        /// Venue Statistics
        /// </summary>
        public VenueStatistics Statistics { get; set; }

        internal static Venue Parse(string p)
        {
            JObject rawVenueText = JObject.Parse(p);

            Venue tempVenue = new Venue();
            tempVenue.VenueId = rawVenueText["id"] != null ? rawVenueText["id"].ToString().Replace("\"", "") : "";
            tempVenue.Name = rawVenueText["name"] != null ? rawVenueText["name"].ToString().Replace("\"", "") : "";
            tempVenue.ContactInfo = rawVenueText["contact"] != null ? Contact.Parse(rawVenueText["contact"].ToString()) : null;
            tempVenue.LocationInfo = rawVenueText["location"] != null ? Location.Parse(rawVenueText["location"].ToString()) : null;
            JArray categories = (JArray)rawVenueText["categories"];
            if (categories.Count > 0)
            {
                tempVenue.Categories = new List<VenueCategory>();
                foreach (var vc in categories)
                {
                    tempVenue.Categories.Add(VenueCategory.Parse(vc.ToString()));
                }
            }
            else
                tempVenue.Categories = null;
            tempVenue.Verified = rawVenueText["verified"] != null ? bool.Parse(rawVenueText["verified"].ToString()) : true;
            tempVenue.Statistics = rawVenueText["stats"] != null ? VenueStatistics.Parse(rawVenueText["stats"].ToString()) : null;
            tempVenue.VenueUri = rawVenueText["url"] != null ? rawVenueText["url"].ToString().Replace("\"", "") : "";
            return tempVenue;
        }

    }

    /// <summary>
    /// Foursquare Venue Category
    /// </summary>
    [Serializable]
    public class VenueCategory : Base
    {
        public int VenueCategoryId { get; set; }

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

        /// <summary>
        /// Parse JSON String into a VenueCategory object
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal static VenueCategory Parse(string p)
        {
            JObject rawCategoryText = JObject.Parse(p);

            VenueCategory tempCategory = new VenueCategory();
            VenueCategory vc = new VenueCategory();
            vc.FoursquareVenueCategoryId = rawCategoryText["id"].ToString().Replace("\"", "");
            vc.Name = rawCategoryText["name"] != null ? rawCategoryText["name"].ToString().Replace("\"", "") : "";
            vc.PluralName = rawCategoryText["pluralName"] != null ? rawCategoryText["pluralName"].ToString().Replace("\"", "") : "";
            vc.IconUri = rawCategoryText["icon"] != null ? new Uri(rawCategoryText["icon"].ToString().Replace("\"", "")) : null;
            if (rawCategoryText["parents"] != null)
            {
                vc.ParentCategories = new List<string>();
                foreach (var pc in (JArray)rawCategoryText["parents"])
                {
                    vc.ParentCategories.Add(pc.ToString().Replace("\"", ""));
                }
            }
            vc.PrimaryCategory = rawCategoryText["primary"] != null ? bool.Parse(rawCategoryText["primary"].ToString().Replace("\"", "")) : false;

            return tempCategory;
        }
    }

    /// <summary>
    /// Basic Venue Stats
    /// </summary>
    [Serializable]
    public class VenueStatistics : Base
    {
        public int VenueStatisticsId { get; set; }

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

        /// <summary>
        /// Parse JSON string into a Venue Statistics object
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal static VenueStatistics Parse(string p)
        {
            JObject rawVenueStats = JObject.Parse(p);

            VenueStatistics tempStats = new VenueStatistics();
            tempStats.CheckinsCount = rawVenueStats["checkinsCount"] != null ? int.Parse(rawVenueStats["checkinsCount"].ToString().Replace("\"", "")) : 0;
            tempStats.UsersCount = rawVenueStats["usersCount"] != null ? int.Parse(rawVenueStats["usersCount"].ToString().Replace("\"", "")) : 0;
            tempStats.TipCount = rawVenueStats["tipCount"] != null ? int.Parse(rawVenueStats["tipCount"].ToString().Replace("\"", "")) : 0;
            return tempStats;
        }
    }
}

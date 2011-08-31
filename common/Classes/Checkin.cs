using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace common
{
    /// <summary>
    /// Foursquare Checkin
    /// </summary>
    public class Checkin
    {
        /// <summary>
        /// Foursquare Checkin Id
        /// </summary>
        public string CheckinId { get; set; }

        /// <summary>
        /// Checkin Creation Time/Date
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Checkin Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Private Checkin?
        /// </summary>
        public bool Private { get; set; }

        /// <summary>
        /// Shout Message (if any)
        /// </summary>
        public string Shout { get; set; }

        /// <summary>
        /// Checkin TimeZone
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Checkin Venue
        /// </summary>
        public Venue CheckinVenue { get; set; }

        /// <summary>
        /// List of Photos Attached to Checkin
        /// </summary>
        public CheckinPhotos Photos { get; set; }

        /// <summary>
        /// List of Comments Attached to Checkin
        /// </summary>
        public CheckinComments Comments { get; set; }

        /// <summary>
        /// Checkin Source (Service Name, Uri)
        /// </summary>
        public CheckinSource Source { get; set; }
    }

    /// <summary>
    /// What service was used to checkin?
    /// </summary>
    public struct CheckinSource
    {
        public string Name { get; set; }
        public Uri SourceUri { get; set; }
    }

    /// <summary>
    /// Photos Attached
    /// </summary>
    public struct CheckinPhotos
    {
        public int Count { get; set; }
        public List<Photo> Photos { get; set; }
    }

    /// <summary>
    /// Comments Added
    /// </summary>
    public struct CheckinComments
    {
        public int Count { get; set; }
        public List<String> Comments { get; set; }
    }
}

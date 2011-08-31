using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace common
{
    public class FoursquareUser
    {
        /// <summary>
        /// Foursquare User Id
        /// </summary>
        public int FoursquareUserId { get; set; }

        /// <summary>
        /// User First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User Profile Photo Uri
        /// </summary>
        public Uri PhotoUri { get; set; }

        /// <summary>
        /// User Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// User Home City
        /// </summary>
        public string HomeCity { get; set; }

        /// <summary>
        /// Relationship to Requesting User (self/friend/etc)
        /// </summary>
        public string Relationship { get; set; }
    }

    /// <summary>
    /// Foursquare User
    /// </summary>
    public class FoursquareUserExtended : FoursquareUser
    {
        /// <summary>
        /// User Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Pings Enabled?
        /// </summary>
        public string Pings { get; set; }

        /// <summary>
        /// User Contact Info
        /// </summary>
        public UserContact Contact { get; set; }

        /// <summary>
        /// Total User Badge Count
        /// </summary>
        public int BadgeCount { get; set; }

        /// <summary>
        /// Total User Checkin Count
        /// </summary>
        public int CheckinCount { get; set; }

        /// <summary>
        /// Total Friend Count
        /// </summary>
        public int FriendCount { get; set; }

        /// <summary>
        /// Following Count
        /// </summary>
        public int FollowingCount { get; set; }

        /// <summary>
        /// Pending Friend Request Count
        /// </summary>
        public int RequestCount { get; set; }

        /// <summary>
        /// Total Tip Count
        /// </summary>
        public int TipsCount { get; set; }

        /// <summary>
        /// Total Todo Count
        /// </summary>
        public int TodosCount { get; set; }

        /// <summary>
        /// Recent Scores Count
        /// </summary>
        public int ScoresRecentCount { get; set; }

        /// <summary>
        /// Maximum Score Count
        /// </summary>
        public int ScoresMaxCount { get; set; }

        /// <summary>
        /// Total Checkins Count
        /// TODO: Find out more about this one
        /// </summary>
        public int ScoresCheckinsCount { get; set; }
    }

    /// <summary>
    /// A Friend is a basic FoursquareUser
    /// </summary>
    public class Friend : FoursquareUser { }
}

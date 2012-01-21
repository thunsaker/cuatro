using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Cuatro.Common
{
    [Serializable]
    public class FoursquareUser : Base
    {
        /// <summary>
        /// Foursquare User Id
        /// </summary>
        public int FoursquareUserId { get; set; }

        /// <summary>
        /// Foursquare User Id (Id assigned to each foursquare user)
        /// </summary>
        public int FoursquareId { get; set; }

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
        public string PhotoUri { get; set; }

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

        /// <summary>
        /// Foursquare Oauth Access Token
        /// </summary>
        public string AccessToken { get; set; }

        internal static FoursquareUser Parse(string p)
        {
            JObject u = JObject.Parse(p);
            return new FoursquareUser()
            {
                FoursquareUserId = u["id"] != null ? int.Parse(u["id"].ToString().Replace("\"", "")) : 0,
                FirstName = u["firstName"] != null ? u["firstName"].ToString().Replace("\"", "") : "",
                LastName = u["lastName"] != null ? u["lastName"].ToString().Replace("\"", "") : "",
                PhotoUri = u["photo"] != null ? u["photo"].ToString().Replace("\"", "") : "",
                Gender = u["gender"] != null ? u["gender"].ToString().Replace("\"", "") : "",
                HomeCity = u["homeCity"] != null ? u["homeCity"].ToString().Replace("\"", "") : "",
                Relationship = u["relationship"] != null ? u["relationship"].ToString().Replace("\"", "") : ""
            };
        }
    }

    /// <summary>
    /// Foursquare User
    /// </summary>
    [Serializable]
    public class FoursquareUserExtended : FoursquareUser
    {
        public int FoursquareUserExtendedId { get; set; }

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
    }

    /// <summary>
    /// User Scores
    /// </summary>
    [Serializable]
    public class FoursquareUserScores : Base
    {
        public int FoursquareUserScoresId { get; set; }

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

        internal static FoursquareUserScores Parse(string p)
        {
            JObject s = JObject.Parse(p);

            return new FoursquareUserScores()
            {
                ScoresRecentCount = s["recent"] != null ? int.Parse(s["recent"].ToString().Replace("\"", "")) : 0,
                ScoresMaxCount = s["max"] != null ? int.Parse(s["max"].ToString().Replace("\"", "")) : 0,
                ScoresCheckinsCount = s["checkinsCount"] != null ? int.Parse(s["checkinsCount"].ToString().Replace("\"", "")) : 0
            };
        }
    }

    /// <summary>
    /// A Friend is a basic FoursquareUser
    /// </summary>
    [Serializable]
    public class Friend : FoursquareUser {
        public int FriendId { get; set; }
    }
}

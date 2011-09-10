using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuatro.Common
{
    public class EndpointHelper
    {
        public static string BaseApiUrl = "https://api.foursquare.com/v2/";

        public static Uri BuildApiUrl(Endpoint Endpoint, string AccessToken, int FoursquareUserId)
        {
            return new Uri(String.Format("https://api.foursquare.com/v2/users/self/badges?oauth_token={0}&v=20110831", AccessToken));
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static long ToUnixTime(DateTime standardTime)
        {
            return (standardTime.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
    }

    public enum Endpoint
    {
        Users,
        Venues,
        Checkins,
        Tips,
        Updates,
        Photos,
        Settings,
        Specials
    }
}

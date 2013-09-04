using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuatro.Common;
using Newtonsoft.Json.Linq;

namespace Cuatro.Common.Endpoints {
    public class Venues : IEndpoint {

        #region Variables

        public string AccessToken;
        public FoursquareUser User;

        #endregion

        public Venues(FoursquareUser User, string AccessToken) {
            SetupEndpoint(User, AccessToken, null);
        }

        #region General

        public List<Venue> SearchVenues(string Query, LocationCoords GPSLocation, string Near) {
            try {
                List<Venue> results = new List<Venue>();

                StringBuilder searchParams = new StringBuilder();
                if (!String.IsNullOrEmpty(Query)) {
                    searchParams.Append(String.Format("query={0}", Query));
                }

                if(!String.IsNullOrEmpty(Near)) {
                    searchParams.Append(String.Format("near={0}", Near));
                } else {
                    searchParams.Append(String.Format("ll={0},{1}", GPSLocation.Latitude, GPSLocation.Longitude));
                }
               
                // Get Venues based on location or proximity
                String foursquareVenuesSearchUri = String.Format("https://api.foursquare.com/v2/venues/search?oauth_token={0}{1}{2}", 
                    AccessToken,
                    EndpointHelper.GetVerifiedDateParamForApi(),
                    searchParams.Length > 0 ? String.Format("&{0}", searchParams.ToString()) : "");
                var responseVenueSearch = WebRequestHelper.WebRequest(WebRequestHelper.Method.GET, foursquareVenuesSearchUri.ToString(), string.Empty);
                var jsonVenueSearchResults = JObject.Parse(responseVenueSearch);
                var responseCode = int.Parse(jsonVenueSearchResults["meta"]["code"].ToString());
                if(responseCode == 200) {
                    foreach (var vn in jsonVenueSearchResults["response"]["venues"])
                    {
                        results.Add(Venue.Parse(vn.ToString()));
                    }

                    if(results != null && results.Count > 0)
                        return results;
                }

                return null;

            } catch (Exception ex) {
                string err = ex.Message;
                return null;
            }
        }

        //public Venue GetVenue(string venueId) {

        //}

        #endregion

        #region IEndpoint Members

        /// <summary>
        /// Setup endpoint for use with API calls
        /// </summary>
        /// <param name="CurrentUser"></param>
        /// <param name="CurrentAccessToken"></param>
        /// <param name="extras"></param>
        public void SetupEndpoint(FoursquareUser CurrentUser, string CurrentAccessToken, object extras) {
            AccessToken = CurrentAccessToken;
            User = CurrentUser;
        }
        #endregion
    }
}
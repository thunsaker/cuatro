using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Cuatro.Common.Endpoints {
    public class Users : IEndpoint {
        #region Variables

        public string AccessToken;
        public FoursquareUser User;

        #endregion

        public Users(FoursquareUser User, string AccessToken) {
            SetupEndpoint(User, AccessToken, null);
        }

        #region General

        /// <summary>
        /// Returns the user's leaderboard.
        /// API Uri: https://api.foursquare.com/v2/users/leaderboard
        /// Documentation: https://developer.foursquare.com/docs/users/leaderboard.html
        /// </summary>
        /// <returns></returns>
        public Leaderboard GetLeaderboard() {
            try {
                List<LeaderboardItem> leaderboardList = new List<LeaderboardItem>();

                // Get the leaderboard
                String foursquareLeaderboardUri = String.Format("https://api.foursquare.com/v2/users/leaderboard?oauth_token={0}{1}",
                    AccessToken,
                    EndpointHelper.GetVerifiedDateParamForApi());
                var responseLeaderboard = WebRequestHelper.WebRequest(WebRequestHelper.Method.GET, foursquareLeaderboardUri.ToString(), string.Empty);
                var jsonLeaderboard = JObject.Parse(responseLeaderboard);

                if (int.Parse(jsonLeaderboard["meta"]["code"].ToString()) == 200) {
                    JArray userList = (JArray)jsonLeaderboard["response"]["leaderboard"]["items"];
                    if (userList.Count > 0) {
                        foreach (var u in userList) {
                            LeaderboardItem li = new LeaderboardItem();
                            li.User = FoursquareUser.Parse(u["user"].ToString());
                            li.Scores = FoursquareUserScores.Parse(u["scores"].ToString());
                            li.Rank = u["rank"] != null ? int.Parse(u["rank"].ToString().Replace("\"", "")) : 0;
                            leaderboardList.Add(li);
                        }
                    }

                    if (leaderboardList != null && leaderboardList.Count > 0)
                        return new Leaderboard() {
                            UsersList = leaderboardList
                        };
                }
                return null;
            } catch (Exception ex) {
                string error = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Helps a user locate friends.
        /// API Uri: https://api.foursquare.com/v2/users/search
        /// Documentation: https://developer.foursquare.com/docs/users/search.html
        /// </summary>
        /// <returns></returns>
        public List<FoursquareUser> SearchUser(UserSearchType type, string Query) {
            try {
                List<FoursquareUser> results = new List<FoursquareUser>();

                // Get Friend Requests
                String foursquareUserSearchUri = String.Format("https://api.foursquare.com/v2/users/search?oauth_token={0}{1}&{2}={3}",
                    AccessToken,
                    EndpointHelper.GetVerifiedDateParamForApi(),
                    type.ToString("F"), 
                    Query);
                var responseUserSearch = WebRequestHelper.WebRequest(WebRequestHelper.Method.GET, foursquareUserSearchUri.ToString(), string.Empty);
                var jsonUserSearchResults = JObject.Parse(responseUserSearch);

                if (int.Parse(jsonUserSearchResults["meta"]["code"].ToString()) == 200) {
                    foreach (var fr in jsonUserSearchResults["response"]["results"]) {
                        results.Add(FoursquareUser.Parse(fr.ToString()));
                    }

                    if (results != null && results.Count > 0)
                        return results;
                }

                return null;
            } catch (Exception ex) {
                string err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Pending Friend Requests
        /// API Uri: https://api.foursquare.com/v2/users/requests
        /// Documentation: https://developer.foursquare.com/docs/users/requests.html
        /// </summary>
        /// <returns></returns>
        public List<FriendRequest> GetFriendRequests() {
            try {
                List<FriendRequest> requests = new List<FriendRequest>();

                // Get Friend Requests
                String foursquareFriendRequestsUri = String.Format("https://api.foursquare.com/v2/users/requests?oauth_token={0}{1}", 
                    AccessToken,
                    EndpointHelper.GetVerifiedDateParamForApi());
                var responseFriendRequests = WebRequestHelper.WebRequest(WebRequestHelper.Method.GET, foursquareFriendRequestsUri.ToString(), string.Empty);
                var jsonFriendRequests = JObject.Parse(responseFriendRequests);

                if (int.Parse(jsonFriendRequests["meta"]["code"].ToString()) == 200) {
                    foreach (var fr in jsonFriendRequests["response"]["requests"]) {
                        requests.Add(new FriendRequest() {
                            UserRequesting = FoursquareUser.Parse(fr.ToString())
                        });
                    }

                    if (requests != null && requests.Count > 0)
                        return requests;
                }

                return null;
            } catch (Exception ex) {
                string err = ex.Message;
                return null;
            }
        }

        #endregion

        #region Aspects

        /// <summary>
        /// Returns badges for a given user.
        /// API Uri: https://api.foursquare.com/v2/users/USER_ID/badges
        /// Documentation: https://developer.foursquare.com/docs/users/badges.html
        /// </summary>
        /// <returns></returns>
        public List<UnlockedBadge> GetBadges() {
            try {
                List<UnlockedBadge> UnlockedBadges = new List<UnlockedBadge>();
                // Get the badges
                String foursquareBadgeUri = String.Format("https://api.foursquare.com/v2/users/self/badges?oauth_token={0}{1}",
                    AccessToken, 
                    EndpointHelper.GetVerifiedDateParamForApi());
                var responseBadges = WebRequestHelper.WebRequest(WebRequestHelper.Method.GET, foursquareBadgeUri.ToString(), string.Empty);
                var jsonBadges = JObject.Parse(responseBadges);

                if (int.Parse(jsonBadges["meta"]["code"].ToString()) == 200) {
                    List<UserBadgeCategory> UnlockedBadgeIds = new List<UserBadgeCategory>();
                    JArray badgeList = (JArray)jsonBadges["response"]["sets"]["groups"];
                    foreach (var fbi in badgeList) {
                        if (fbi["type"].ToString().Replace("\"", "").ToLower() != "all") {
                            foreach (var fbid in fbi["items"]) {
                                UserBadgeCategory tempBadgeCategory = new UserBadgeCategory();
                                switch (fbi["type"].ToString().Replace("\"", "").ToLower()) {
                                    case "foursquare":
                                        tempBadgeCategory.UserBadgeId = fbid.ToString().Replace("\"", "");
                                        tempBadgeCategory.Type = BadgeType.foursquare;
                                        UnlockedBadgeIds.Add(tempBadgeCategory);
                                        break;
                                    case "expertise":
                                        tempBadgeCategory.UserBadgeId = fbid.ToString().Replace("\"", "");
                                        tempBadgeCategory.Type = BadgeType.expertise;
                                        UnlockedBadgeIds.Add(tempBadgeCategory);
                                        break;
                                    case "partner":
                                        tempBadgeCategory.UserBadgeId = fbid.ToString().Replace("\"", "");
                                        tempBadgeCategory.Type = BadgeType.partner;
                                        UnlockedBadgeIds.Add(tempBadgeCategory);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }

                    if (UnlockedBadgeIds.Count > 0) {
                        foreach (UserBadgeCategory ubc in UnlockedBadgeIds) {
                            JObject b = JObject.Parse(jsonBadges["response"]["badges"][ubc.UserBadgeId].ToString());
                            UnlockedBadge ub = new UnlockedBadge();
                            if (b["id"] != null && (b["id"].ToString().Replace("\"", "") != b["badgeId"].ToString().Replace("\"", ""))) {
                                ub.BadgeId = b["id"].ToString().Replace("\"", "");

                                Badge badge = new Badge();
                                badge.Name = b["name"] != null ? b["name"].ToString().Replace("\"", "") : "";
                                badge.Description = b["description"] != null
                                    ? b["description"].ToString().Replace("\"", "")
                                    : b["hint"].ToString() != "" ? String.Format("Hint: {0}", b["hint"].ToString().Replace("\"", ""))
                                    : "No hint";
                                badge.FoursquareBadgeId = b["badgeId"] != null ? b["badgeId"].ToString().Replace("\"", "") : "";
                                if (b["image"]["prefix"] != null && b["image"]["name"] != null) {
                                    badge.ImageUri = b["image"]["prefix"].ToString().Replace("\"", "") + "{0}" + b["image"]["name"].ToString().Replace("\"", "");
                                } else
                                    badge.ImageUri = "";
                                badge.Type = ubc.Type;

                                // Create Checkins
                                if (b["unlocks"] != null) {
                                    foreach (var u in b["unlocks"]) {
                                        if (u["checkins"] != null) {
                                            foreach (var c in u["checkins"]) {
                                                Checkin checkin = new Checkin();
                                                checkin.CheckinId = c["id"] != null ? c["id"].ToString().Replace("\"", "") : "";
                                                checkin.CreatedAt = EndpointHelper.FromUnixTime(long.Parse(c["createdAt"].ToString().Replace("\"", "")));
                                                checkin.IsMayor = c["isMayor"] != null ? bool.Parse(c["isMayor"].ToString().Replace("\"", "")) : false;
                                                String checkinType = c["type"] != null ? c["type"].ToString().Replace("\"", "") : "";
                                                checkin.Type = checkinType;

                                                if (checkinType != "venueless") {
                                                    Venue v = new Venue();
                                                    v.VenueId = c["venue"]["id"] != null ? c["venue"]["id"].ToString().Replace("\"", "") : "";
                                                    v.Name = c["venue"]["name"] != null ? c["venue"]["name"].ToString().Replace("\"", "") : "";
                                                    v.ItemId = c["venue"]["itemId"] != null ? c["venue"]["itemId"].ToString().Replace("\"", "") : "";
                                                    v.ContactInfo = c["venue"]["contact"] != null ? Contact.Parse(c["venue"]["contact"].ToString()) : null;
                                                    v.LocationInfo = c["venue"]["location"] != null ? Location.Parse(c["venue"]["location"].ToString()) : null;
                                                    if (c["venue"]["categories"] != null && c["venue"]["categories"].ToString().Replace("\"", "") != "") {
                                                        JArray categories = (JArray)c["venue"]["categories"];
                                                        if (categories.Count > 0) {
                                                            v.Categories = new List<VenueCategory>();
                                                            foreach (var vc in categories) {
                                                                v.Categories.Add(VenueCategory.Parse(vc.ToString()));
                                                            }
                                                        } else
                                                            v.Categories = null;
                                                    } else
                                                        v.Categories = null;
                                                    v.Statistics = c["venue"]["stats"] != null ? VenueStatistics.Parse(c["venue"]["stats"].ToString()) : null;
                                                    v.Verified = c["venue"]["verified"] != null ? bool.Parse(c["venue"]["verified"].ToString().Replace("\"", "")) : true;
                                                    v.VenueUri = c["venue"]["url"] != null ? c["venue"]["url"].ToString().Replace("\"", "") : "";

                                                    checkin.CheckinVenue = v;
                                                }

                                                ub.Checkin = checkin;
                                            }
                                        }
                                    }
                                }

                                ub.Badge = badge;
                                ub.Level = b["level"] != null ? int.Parse(b["level"].ToString()) : 0;
                                UnlockedBadges.Add(ub);
                            }
                            //else
                            //{
                            //    var errorId = b["badgeId"];
                            //    return null;
                            //}
                        }
                    }
                }

                if (UnlockedBadges != null && UnlockedBadges.Count > 0)
                    return UnlockedBadges;
                return null;
            } catch (Exception ex) {
                string error = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Returns a history of checkins for the authenticated user.
        /// API Uri: https://api.foursquare.com/v2/users/USER_ID/checkins
        /// Documentation: https://developer.foursquare.com/docs/users/checkins.html
        /// </summary>
        /// <returns></returns>
        public List<Checkin> GetCheckins(TimeSpan DateRange, int Offset) {
            try {
                List<Checkin> userCheckins = new List<Checkin>();
                // Get the checkins
                DateTime startTime = DateTime.Now;
                DateTime endTime = DateTime.Now.AddDays(-DateRange.Days);

                String foursquareCheckinUri = String.Format("https://api.foursquare.com/v2/users/self/checkins?oauth_token={0}{1}&afterTimestamp={2}&beforeTimestamp{3}&offset={4}",
                    AccessToken, 
                    EndpointHelper.GetVerifiedDateParamForApi(),
                    EndpointHelper.ToUnixTime(endTime), 
                    EndpointHelper.ToUnixTime(startTime), 
                    Offset);
                var responseCheckins = WebRequestHelper.WebRequest(WebRequestHelper.Method.GET, foursquareCheckinUri.ToString(), string.Empty);
                var jsonCheckins = JObject.Parse(responseCheckins);

                if (int.Parse(jsonCheckins["meta"]["code"].ToString()) == 200) {
                    JArray checkinList = (JArray)jsonCheckins["response"]["checkins"]["items"];
                    foreach (var item in checkinList) {
                        Checkin myCheckin = new Checkin() {
                            CheckinId = item["id"] != null ? item["id"].ToString().Replace("\"", "") : "",
                            CreatedAt = item["createdAt"] != null ? EndpointHelper.FromUnixTime(long.Parse(item["createdAt"].ToString())) : DateTime.MinValue,
                            Type = item["type"] != null ? item["type"].ToString().Replace("\"", "") : "",
                            Shout = item["shout"] != null ? item["shout"].ToString().Replace("\"", "") : "",
                            TimeZone = item["timeZone"] != null ? item["timeZone"].ToString().Replace("\"", "") : "",
                            CheckinVenue = item["venue"] != null ? Venue.Parse(item["venue"].ToString()) : new Venue(),
                            Photos = item["photos"] != null ? CheckinPhotos.Parse(item["photos"].ToString()) : new CheckinPhotos(),
                            Comments = item["comments"] != null ? CheckinComments.Parse(item["comments"].ToString()) : new CheckinComments(),
                            CheckinSource = item["source"] != null ? Source.Parse(item["source"].ToString()) : new Source()
                        };

                        userCheckins.Add(myCheckin);
                    }

                    if (userCheckins != null && userCheckins.Count > 0)
                        return userCheckins;
                }

                return null;
            } catch (Exception ex) {
                string error = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Returns an array of a user's friends.
        /// API Uri: https://api.foursquare.com/v2/users/USER_ID/friends
        /// Documentation: https://developer.foursquare.com/docs/users/friends.html
        /// </summary>
        /// <returns></returns>
        public List<Friend> GetFriendsList() {
            return null;
        }

        /// <summary>
        /// Returns a user's mayorships.
        /// API Uri: https://api.foursquare.com/v2/users/USER_ID/mayorships
        /// Documentation: https://developer.foursquare.com/docs/users/mayorships.html
        /// </summary>
        /// <returns></returns>
        public List<Mayorships> GetMayorships() {
            return null;
        }

        /// <summary>
        /// Returns tips from a user.
        /// API Uri: https://api.foursquare.com/v2/users/USER_ID/tips
        /// Documentation: https://developer.foursquare.com/docs/users/tips.html
        /// </summary>
        /// <returns></returns>
        public List<Tips> GetTips() {
            return null;
        }

        /// <summary>
        /// Returns todos from a user.
        /// API Uri: https://api.foursquare.com/v2/users/USER_ID/todos
        /// Documentation: https://developer.foursquare.com/docs/users/todos.html
        /// </summary>
        /// <returns></returns>
        public List<Todos> GetTodos() {
            return null;
        }

        /// <summary>
        /// Returns a list of all venues visited by the specified user, along with how many visits and when they were last there.
        /// Note: This is an experimental API. See documentation link below for more information
        /// API Uri: https://api.foursquare.com/v2/users/USER_ID/venuehistory
        /// Documentation: https://developer.foursquare.com/docs/users/venuehistory.html
        /// </summary>
        /// <returns></returns>
        public List<Venue> GetVenueHistory() {
            return null;
        }

        #endregion

        #region Actions



        #endregion

        #region IEndpoint Members

        /// <summary>
        /// Setup the endpoint for use with API calls
        /// </summary>
        /// <param name="CurrentAccessToken"></param>
        /// <param name="CurrentUser"></param>
        /// <param name="Extras"></param>
        public void SetupEndpoint(FoursquareUser CurrentUser, string CurrentAccessToken, object extras) {
            AccessToken = CurrentAccessToken;
            User = CurrentUser;
        }

        #endregion

        #region Helper Classes

        public struct UserBadgeCategory {
            public BadgeType Type { get; set; }
            public string UserBadgeId { get; set; }
        }

        #endregion
    }
}
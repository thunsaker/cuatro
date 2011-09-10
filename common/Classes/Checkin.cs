using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Cuatro.Common
{
    /// <summary>
    /// Foursquare Checkin
    /// </summary>
    [Serializable]
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
        /// Is mayor of this venue tied to this checkin
        /// </summary>
        public bool IsMayor { get; set; }

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
        public Source CheckinSource { get; set; }
    }

    /// <summary>
    /// Photos Attached
    /// </summary>
    [Serializable]
    public struct CheckinPhotos
    {
        public List<Photo> Photos { get; set; }

        internal static CheckinPhotos Parse(string p)
        {
            JObject rawPhotoText = JObject.Parse(p);
            if (int.Parse(rawPhotoText["count"].ToString()) > 0)
            {
                List<Photo> photosList = new List<Photo>();

                JArray photos = (JArray)rawPhotoText["items"];
                foreach (var item in photos)
                {
                    Photo tempPhoto = new Photo();
                    tempPhoto.FoursquarePhotoId = rawPhotoText["id"] != null ? rawPhotoText["id"].ToString().Replace("\"", "") : "";
                    tempPhoto.CreatedAt = rawPhotoText["createdAt"] != null ? EndpointHelper.FromUnixTime(long.Parse(rawPhotoText["createdAt"].ToString().Replace("\"", ""))) : DateTime.MinValue;
                    

                    JArray photoSizes = (JArray)item["sizes"]["items"];
                    bool original = false;
                    foreach (var ps in photoSizes)
	                {
                        if (original)
                        {
                            tempPhoto.OriginalPhotoInfo = PhotoInfo.Parse(ps.ToString());
                            original = true;
                        }
                        else
                            tempPhoto.OriginalPhotoInfo = PhotoInfo.Parse(ps.ToString());
                    }

                    photosList.Add(tempPhoto);
                }

                return new CheckinPhotos()
                {
                    Photos = photosList
                };
            }

            return new CheckinPhotos();
        }
    }

    /// <summary>
    /// Comments Added
    /// </summary>
    [Serializable]
    public struct CheckinComments
    {
        public List<String> Comments { get; set; }

        internal static CheckinComments Parse(string p)
        {
            JObject rawcommentText = JObject.Parse(p);
            if (int.Parse(rawcommentText["count"].ToString()) > 0)
            {
                List<String> commentsList = new List<String>();

                JArray comments = (JArray)rawcommentText["items"];
                foreach (var item in comments)
                {
                    String tempcomment = string.Empty;
                    tempcomment = rawcommentText["comment"] != null ? rawcommentText["comment"].ToString().Replace("\"", "") : "";
                }

                return new CheckinComments()
                {
                    Comments = commentsList
                };
            }

            return new CheckinComments();
        }
    }
}

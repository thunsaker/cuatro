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
    public class Checkin : Base
    {
        /// <summary>
        /// Foursquare Checkin Id
        /// </summary>
        public string CheckinId { get; set; }

        /// <summary>
        /// Foursquare Checkin Id
        /// </summary>
        public string FoursquareCheckinId { get; set; }

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
                    
                    // TODO: Switch to height/width
                    tempPhoto.OriginalPhotoInfo = new PhotoInfo();
                    int height = rawPhotoText["height"] != null ? int.Parse(rawPhotoText["height"].ToString().Replace("\"", "")) : 100;
                    int width = rawPhotoText["width"] != null ? int.Parse(rawPhotoText["width"].ToString().Replace("\"", "")) : 100;
                    var prefix = rawPhotoText["prefix"] != null ? rawPhotoText["prefix"].ToString().Replace("\"", "") : "";
                    var suffix = rawPhotoText["suffix"] != null ? rawPhotoText["suffix"].ToString().Replace("\"", "") : "";
                    if (prefix != "" && suffix != "") {
                        tempPhoto.OriginalPhotoInfo.Height = height;
                        tempPhoto.OriginalPhotoInfo.Width = width;
                        tempPhoto.OriginalPhotoInfo.PhotoUri = String.Format("{1}{2}x{3}{4}", prefix, height, width, suffix);
                    }

                    //JArray photoSizes = (JArray)item["sizes"]["items"];
                    //bool original = false;
                    //foreach (var ps in photoSizes)
                    //{
                    //    if (original)
                    //    {
                    //        tempPhoto.OriginalPhotoInfo = PhotoInfo.Parse(ps.ToString());
                    //        original = true;
                    //    }
                    //    else
                    //        tempPhoto.OriginalPhotoInfo = PhotoInfo.Parse(ps.ToString());
                    //}

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
        public List<Comment> Comments { get; set; }

        internal static CheckinComments Parse(string p)
        {
            JObject rawcommentText = JObject.Parse(p);
            if (int.Parse(rawcommentText["count"].ToString()) > 0)
            {
                List<Comment> commentsList = new List<Comment>();

                JArray comments = (JArray)rawcommentText["items"];
                foreach (var item in comments)
                {
                    Comment tempComment = new Comment()
                    {
                        Text = rawcommentText["comment"] != null ? rawcommentText["comment"].ToString().Replace("\"", "") : "",
                        Active = true,
                        DateCreated = DateTime.Now
                    };
                    commentsList.Add(tempComment);
                }

                return new CheckinComments()
                {
                    Comments = commentsList,
                };
            }

            return new CheckinComments();
        }
    }

    public class Comment : Base
    {
        /// <summary>
        /// Comment Identifier
        /// </summary>
        public int CommentId { get; set; }

        /// <summary>
        /// Comment Text
        /// </summary>
        public String Text { get; set; }
    }
}



    //"photos": {
    //  "count": 2,
    //  "items": [
    //    {
    //      "id": "52228a9a11d2fdf81db5487e",
    //      "createdAt": 1377995418,
    //      "source": {
    //        "name": "foursquare for Android",
    //        "url": "https://foursquare.com/download/#/android"
    //      },
    //      "prefix": "https://irs1.4sqi.net/img/general/",
    //      "suffix": "/25584_lmKsHXuMXxroKxshqPrRgIU3h9GFaIDpxMsI9EYjifM.jpg",
    //      "width": 720,
    //      "height": 960,
    //      "user": {
    //        "id": "25584",
    //        "firstName": "Tommy",
    //        "lastName": "Hunsaker",
    //        "gender": "male",
    //        "relationship": "self",
    //        "photo": {
    //          "prefix": "https://irs2.4sqi.net/img/user/",
    //          "suffix": "/YBVI4YQSM52CC02T.jpg"
    //        }
    //      },
    //      "visibility": "public"
    //    },
    //    {
    //      "id": "52228afd11d2212f367d7822",
    //      "createdAt": 1377995517,
    //      "source": {
    //        "name": "foursquare for Android",
    //        "url": "https://foursquare.com/download/#/android"
    //      },
    //      "prefix": "https://irs1.4sqi.net/img/general/",
    //      "suffix": "/25584_Y917YBoEi4IAvsN7RUv1k34KTuJkxhIuHua3gUdYQLI.jpg",
    //      "width": 960,
    //      "height": 720,
    //      "user": {
    //        "id": "25584",
    //        "firstName": "Tommy",
    //        "lastName": "Hunsaker",
    //        "gender": "male",
    //        "relationship": "self",
    //        "photo": {
    //          "prefix": "https://irs2.4sqi.net/img/user/",
    //          "suffix": "/YBVI4YQSM52CC02T.jpg"
    //        }
    //      },
    //      "visibility": "public"
    //    }
    //  ]
    //}
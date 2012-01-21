using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Cuatro.Common
{
    /// <summary>
    /// Foursquare Photo
    /// </summary>
    [Serializable]
    public class Photo : Base
    {
        public int PhotoId { get; set; }

        /// <summary>
        /// Foursquare Photo Id
        /// </summary>
        public string FoursquarePhotoId { get; set; }

        /// <summary>
        /// Date/Time Posted
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Original Photo Uri
        /// </summary>
        public PhotoInfo OriginalPhotoInfo { get; set; }

        /// <summary>
        /// Alternate Photo Sizes
        /// </summary>
        public List<PhotoInfo> AlternatePhotoInfo { get; set; }

        /// <summary>
        /// Photo Source
        /// </summary>
        public Source PhotoSource { get; set; }
    }

    /// <summary>
    /// Photo Info (uri, size)
    /// </summary>
    [Serializable]
    public class PhotoInfo : Base
    {
        public int PhotoInfoId { get; set; }

        /// <summary>
        /// Photo Uri
        /// </summary>
        public String PhotoUri { get; set; }

        /// <summary>
        /// Photo Width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Photo Height
        /// </summary>
        public int Height { get; set; }

        internal static PhotoInfo Parse(string p)
        {
            JObject rawPhotoInfoText = JObject.Parse(p);

            return new PhotoInfo()
            {
                PhotoUri = rawPhotoInfoText["url"] != null ? rawPhotoInfoText["url"].ToString() : "",
                Width = rawPhotoInfoText["width"] != null ? int.Parse(rawPhotoInfoText["width"].ToString()) : 0,
                Height = rawPhotoInfoText["height"] != null ? int.Parse(rawPhotoInfoText["height"].ToString()) : 0
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace common
{
    /// <summary>
    /// Foursquare Photo
    /// </summary>
    public class Photo
    {
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
    }

    /// <summary>
    /// Photo Info (uri, size)
    /// </summary>
    public class PhotoInfo
    {
        /// <summary>
        /// Photo Uri
        /// </summary>
        public Uri PhotoUri { get; set; }

        /// <summary>
        /// Photo Width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Photo Height
        /// </summary>
        public int Height { get; set; }
    }
}

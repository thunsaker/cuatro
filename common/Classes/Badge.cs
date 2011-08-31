﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// https://apigee.com/console/apigee-console-snapshots-1312174800000_724b196f-080f-4496-82bb-8402d0e397e3/rendersnapshotview

namespace common
{
    /// <summary>
    /// Foursquare Badges
    /// </summary>
    public class Badge
    {
        /// <summary>
        /// Foursquare Badge Id
        /// </summary>
        public string FoursquareBadgeId { get; set; }

        /// <summary>
        /// Badge Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Badge description.
        /// When a badge has not been unlocked description is not available, as a result it will read "Hint: The Badge hint".
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Image Url (ex. https://foursquare.com/com/img/badge/{0}/allbadges.png)
        /// </summary>
        public string ImageUri { get; set; }

        /// <summary>
        /// Badge type
        /// </summary>
        public BadgeType Type { get; set; }
    }

    /// <summary>
    /// Foursquare Partner Badges
    /// </summary>
    public class PartnerBadge : Badge
    {
        public string Subtype { get; set; }
    }

    /// <summary>
    /// General Badge Types
    /// </summary>
    public enum BadgeType
    {
        all,
        foursquare,
        partner
    }

    /// <summary>
    /// Badge Type Image Sizes
    /// </summary>
    public enum TypeImageSize
    {
        Small = 24,
        Medium = 32,
        Large = 48,
        XLarge = 64
    }

    /// <summary>
    /// Badge Image Sizes
    /// </summary>
    public enum BadgeImageSize
    {
        Small = 57,
        Medium = 114,
        Large = 200,
        XLarge = 300,
        XXLarge = 400
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuatro.Common
{
    /// <summary>
    /// Unlocked Badges
    /// </summary>
    [Serializable]
    public class UnlockedBadge : Base
    {
        public int UnlockedBadgeId { get; set; }

        /// <summary>
        /// Unique user badge id
        /// </summary>
        public string BadgeId { get; set; }

        /// <summary>
        /// Badge info that was unlocked
        /// </summary>
        public Badge Badge { get; set; }

        /// <summary>
        /// Checkin information for the badge
        /// </summary>
        public Checkin Checkin { get; set; }

        /// <summary>
        /// Expertise Level
        /// </summary>
        public int Level { get; set; }
    }
}

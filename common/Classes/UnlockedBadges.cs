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
    public class UnlockedBadge
    {
        /// <summary>
        /// Unique user badge id
        /// </summary>
        public string BadgeId { get; set; }

        /// <summary>
        /// Badge into that was unlocked
        /// </summary>
        public Badge Badge { get; set; }

        /// <summary>
        /// Checkin information for the badge
        /// </summary>
        public Checkin Checkin { get; set; }
    }
}

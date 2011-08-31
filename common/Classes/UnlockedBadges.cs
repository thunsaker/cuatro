using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace common
{
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

        public Checkin Checkin { get; set; }
    }
}

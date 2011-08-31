using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace common
{
    /// <summary>
    /// Foursquare Notifications
    /// </summary>
    public class Notifications
    {
        /// <summary>
        /// Type of Notifications
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Total Number of Unread Messages
        /// </summary>
        public int UnreadCount { get; set; }
    }
}

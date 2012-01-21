using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuatro.Common
{
    /// <summary>
    /// Foursquare Notifications
    /// </summary>
    [Serializable]
    public class Notification : Base
    {
        public int NotificationId { get; set; }

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

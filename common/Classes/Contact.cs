using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace common
{
    /// <summary>
    /// Base Contact Information
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Phone Number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Twitter Handle
        /// </summary>
        public string Twitter { get; set; }

        /// <summary>
        /// Facebook User Id
        /// </summary>
        public string Facebook { get; set; }
    }

    /// <summary>
    /// Venue Contact Information
    /// </summary>
    public class VenueContact : Contact
    {
        /// <summary>
        /// Location Info
        /// </summary>
        public Location LocationInformation { get; set; }
    }

    /// <summary>
    /// User Contact
    /// </summary>
    public class UserContact : Contact
    {
        /// <summary>
        /// User Email Address
        /// </summary>
        public string EmailAddress { get; set; }
    }
}

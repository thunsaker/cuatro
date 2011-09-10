using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Cuatro.Common
{
    /// <summary>
    /// Base Contact Information
    /// </summary>
    [Serializable]
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

        internal static Contact Parse(string p)
        {
            int blah = 0;
            try
            {
                blah = 34;
                JObject rawContactInfo = JObject.Parse(p);
                blah = 36;
                Contact parsedContact = new Contact();
                parsedContact.Phone = rawContactInfo["phone"] != null ? rawContactInfo["phone"].ToString().Replace("\"", "") : "";
                blah = 39;
                parsedContact.Twitter = rawContactInfo["twitter"] != null ? rawContactInfo["twitter"].ToString().Replace("\"", "") : "";
                blah = 41;
                parsedContact.Facebook = rawContactInfo["facebook"] != null ? rawContactInfo["twitter"].ToString().Replace("\"", "") : "";
                blah = 43;
                return parsedContact;
            }
            catch (Exception ex)
            {
                string error = String.Format("Error:{0} Line: {1}", ex.Message, blah);
                return null;
            }
        }
    }

    /// <summary>
    /// Venue Contact Information
    /// </summary>
    [Serializable]
    public class VenueContact : Contact
    {
        /// <summary>
        /// Location Info
        /// </summary>
        public Location LocationInformation { get; set; }

        internal static VenueContact Parse(string p)
        {
            JObject rawContactInfo = JObject.Parse(p);

            VenueContact parsedContact = new VenueContact();
            parsedContact.Phone = rawContactInfo["phone"].ToString().Replace("\"", "");
            parsedContact.Twitter = rawContactInfo["twitter"] != null ? rawContactInfo["twitter"].ToString().Replace("\"", "") : "";
            parsedContact.Facebook = rawContactInfo["facebook"] != null ? rawContactInfo["twitter"].ToString().Replace("\"", "") : "";
            parsedContact.LocationInformation = rawContactInfo["location"] != null ? Location.Parse(rawContactInfo["location"].ToString().Replace("\"", "")) : null;
            return parsedContact;
        }
    }

    /// <summary>
    /// User Contact
    /// </summary>
    [Serializable]
    public class UserContact : Contact
    {
        /// <summary>
        /// User Email Address
        /// </summary>
        public string EmailAddress { get; set; }

        internal static UserContact Parse(string p)
        {
            JObject rawContactInfo = JObject.Parse(p);

            UserContact parsedContact = new UserContact();
            parsedContact.Phone = rawContactInfo["phone"] != null ? rawContactInfo["phone"].ToString().Replace("\"", "") : "";
            parsedContact.Twitter = rawContactInfo["twitter"] != null ? rawContactInfo["twitter"].ToString().Replace("\"", "") : "";
            parsedContact.Facebook = rawContactInfo["facebook"] != null ? rawContactInfo["twitter"].ToString().Replace("\"", "") : "";
            parsedContact.EmailAddress = rawContactInfo["email"] != null ? rawContactInfo["email"].ToString().Replace("\"", "") : "";
            return parsedContact;
        }
    }
}

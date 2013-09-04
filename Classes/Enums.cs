using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuatro.Common
{
    public enum UserSearchType
    {
        phone = 1,
        email = 2,
        fbid = 3,
        twitter = 4
        //twitterSource
    }

    public enum VenueSearchType {
        venueName = 1,
        proximity = 2
    }

    public enum PhotoType {
        profile,
        venue,
        other
    }
}
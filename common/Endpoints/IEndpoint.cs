using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuatro.Common.Endpoints
{
    interface IEndpoint
    {
        void SetupEndpoint(FoursquareUser CurrentUser, string CurrentAccessToken, object extras);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Cuatro.Common
{
    /// <summary>
    /// What service was used to checkin?
    /// </summary>
    [Serializable]
    public struct Source
    {
        public string Name { get; set; }
        public string SourceUri { get; set; }

        internal static Source Parse(string p)
        {
            JObject rawSource = JObject.Parse(p);

            return new Source()
            {
                Name = rawSource["name"] != null ? rawSource["name"].ToString().Replace("\"", "") : "",
                SourceUri = rawSource["url"] != null ? rawSource["url"].ToString().Replace("\"", "") : "",
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace kyrsovaya
{
    class Artist
    {
        [JsonProperty("id")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("mbid")]
        public string Mbid { get; set; }

        [JsonProperty("options")]
        public Options Options { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("thumb_url")]
        public Uri ThumbUrl { get; set; }

        [JsonProperty("facebook_page_url")]
        public Uri FacebookPageUrl { get; set; }

        [JsonProperty("tracker_count")]
        public long TrackerCount { get; set; }

        [JsonProperty("upcoming_event_count")]
        public long UpcomingEventCount { get; set; }

        [JsonProperty("support_url")]
        public string SupportUrl { get; set; }
    }
}

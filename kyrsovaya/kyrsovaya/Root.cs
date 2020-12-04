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
    class Root
    {
        [JsonProperty("id")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string Id { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("artist")]
        public Artist Artist { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }

        [JsonProperty("lineup")]
        public string[] Lineup { get; set; }

        [JsonProperty("offers")]
        public Offer[] Offers { get; set; }

        [JsonProperty("artist_id")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string ArtistId { get; set; }

        [JsonProperty("on_sale_datetime")]
        public string OnSaleDatetime { get; set; }
    }
}

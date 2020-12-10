using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace kyrsovaya
{
    public partial class Root
    {
        [JsonProperty("id")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string Id { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset datetime { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("artist", NullValueHandling = NullValueHandling.Ignore)]
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

    public partial class Artist
    {
        [JsonProperty("id")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string Id { get; set; }

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

    public partial class Options
    {
        [JsonProperty("display_listen_unit")]
        public bool DisplayListenUnit { get; set; }
    }

    public partial class Offer
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Venue
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("latitude", NullValueHandling = NullValueHandling.Ignore)]
        public string Latitude { get; set; }

        [JsonProperty("longitude", NullValueHandling = NullValueHandling.Ignore)]
        public string Longitude { get; set; }
    }
}


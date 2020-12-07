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
    public partial class Offer
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
